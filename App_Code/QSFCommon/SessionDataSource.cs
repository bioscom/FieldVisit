using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;

namespace Telerik.Web.SessionDS
{
    /// <summary>
    /// SessionDataSource is designed to be primarily used by the Telerik QSF examples.
    /// It acts as a wrapper around SqlDataSource that does not allow changes to be persisted
    /// to the underlying database, but instead stores them in the session state.
    /// This way every visitor of our site can study the controls, but any changes to the
    /// sample data will only be persisted for the duration of the session.
    /// It is not a general purpose solution and there are some limitations you need to know
    /// about if you are willing to use it in your custom scenario:
    /// 
    ///     1.  It is assumed that the tables in the underlying data source use 32-bit positive
    ///         integers for their primary keys. If they use other types or compound primary
    ///         keys consisting of other types, then you will not be able to insert rows.
    /// 
    ///     2.  Internally SessionDataSource assigns negative integers (from Int32.MinValue upwards)
    ///         for the newly added rows to avoid collisions with rows that have not been loaded yet.
    ///         Again, as with the first limitation, if you use negative integers for your primary
    ///         keys the behavior is unpredictable.
    /// 
    ///     3.	No constraints defined in the underlying data source are enforced. You are on your own.
    /// 
    /// Please note that the AutoIncrementFields from the previous versions has been renamed to PrimaryKeyFields.
    /// </summary>
    public class SessionDataSource : SqlDataSource
    {
        public SessionDataSource()
        {

        }

		public void ClearSessionData()
		{
			this.Context.Session[DataSourceSessionKey] = null;
		}

        protected override SqlDataSourceView CreateDataSourceView(string viewName)
        {
            if (base.DesignMode)
            {
                return base.CreateDataSourceView(viewName);
            }

            return new SessionDataSourceView(this, viewName, this.Context, base.CreateDataSourceView(viewName), this.Context.Session);
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			// Reset cached data when page loads the first time.
			if (!base.DesignMode && !this.Page.IsPostBack && ClearSessionOnInitialLoad)
			{
				this.Context.Session[DataSourceSessionKey] = null;
			}
		}

        public string DataSourceSessionKey
        {
            get
            {
                return SessionKey;
            }
        }

        /// <summary>
        /// Comma delimited list of primary key fields (32-bit integers only).
        /// </summary>
        [Description("Comma delimited list of primary key fields (32-bit integers only).")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        public string PrimaryKeyFields
        {
            get
            {
                object res = this.ViewState["pkFields"];
                if (res == null)
                {
                    res = string.Empty;
                }

                return (string) res;
            }
            set
            {
                this.ViewState["pkFields"] = value;
            }
        }

        /// <summary>
        /// Displays a warning that that the modifications will not be persisted.
        /// </summary>
        [Description("Displays a warning that that the modifications will not be persisted.")]
        [DefaultValue(true)]
        public bool DisplayWarning
        {
            get
            {
                object warn = this.ViewState["displayWarning"];
                if (warn == null)
                {
                    warn = true;
                }

                return (bool) warn;
            }
            set
            {
                this.ViewState["displayWarning"] = value;
            }
        }

        /// <summary>
        /// Propagate changes to the original access data file.
        /// </summary>
        [DefaultValue(false)]
        public bool RevertToOriginalDataSource
        {
            get
            {
                return this.ViewState["_rtods"] != null ? (bool) this.ViewState["_rtods"] : false;
            }
            set
            {
                this.ViewState["_rtods"] = value;
            }
        }

		/// <summary>
		/// Reset the session field on initial load
		/// </summary>
		[Description("Reset the session field on initial load.")]
		[NotifyParentProperty(true)]
		[DefaultValue("")]
		public bool ClearSessionOnInitialLoad
		{
			get
			{
				return (bool) (ViewState["ClearSessionOnInitialLoad"] ?? true);
			}
			
			set
			{ 
				this.ViewState["ClearSessionOnInitialLoad"] = value;
			}
		}

        [DefaultValue(true)]
        public override bool Visible
        {
            get
            {
                return true;
            }
            set
            {
                base.Visible = value;
            }
        }

		public string SessionKey
		{
			get
			{
				return (string) ViewState["SessionKey"] ?? Page.ToString() + "_" + ID;
			}
			set
			{
				ViewState["SessionKey"] = value;
			}
		}

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (!this.RevertToOriginalDataSource && DisplayWarning)
            {
                writer.AddAttribute("style", "color:maroon;");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write("Note: The changes in the data will be persisted per Session only. The data will be reset next time you visit the page.");
                writer.RenderEndTag();
            }
        }
    }

    public class SessionDataSourceView : SqlDataSourceView
    {
        private DataSourceView originalView;
        private HttpSessionState session;
        private HttpContext context;
        private SessionDataSource owner;
        private DbCommand selectCommand;
        private Exception selectException;
        private DbParameterCollection currentSelectParameters;


        private string[] PrimaryKeyFields
        {
            get
            {
                if (owner.PrimaryKeyFields + "" != "")
                {
                    return owner.PrimaryKeyFields.Split(',');
                }

                return new string[0];
            }
        }


        public SessionDataSourceView(SqlDataSource owner, string name, HttpContext context, DataSourceView originalView, HttpSessionState session)
            : base(owner, name, context)
        {
            this.owner = owner as SessionDataSource;
            this.originalView = originalView;
            this.session = session;
            this.context = context;
        }

        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            DataTable queryTable = ((DataView) base.ExecuteSelect(arguments)).Table;
            DataTable sessionTable = (DataTable) session[owner.DataSourceSessionKey];

            InitPrimaryKey(queryTable);

            if (owner.RevertToOriginalDataSource)
            {
                RaiseOnSelected(queryTable.DefaultView.Count);
                return queryTable.DefaultView;
            }

            DataTable result;
            if (sessionTable == null)
            {
                sessionTable = queryTable.Copy();
                InitPrimaryKey(sessionTable);
                session[owner.DataSourceSessionKey] = sessionTable;
                result = sessionTable;
            }
            else
            {
                result = SmartMerge(sessionTable, queryTable);
            }

            DataView view = result.DefaultView;
			if (!string.IsNullOrEmpty(arguments.SortExpression))
			{
				view.Sort = arguments.SortExpression;
			}
            RaiseOnSelected(view.Count);
            return view;
        }

        private void RaiseOnSelected(int rowCount)
        {
            SqlDataSourceStatusEventArgs newArgs = new SqlDataSourceStatusEventArgs(selectCommand, rowCount, selectException);
            base.OnSelected(newArgs);
        }

        protected override void OnSelected(SqlDataSourceStatusEventArgs e)
        {
            selectCommand = e.Command;
            selectException = e.Exception;
        }

        protected override void OnSelecting(SqlDataSourceSelectingEventArgs e)
        {
            currentSelectParameters = e.Command.Parameters;
            base.OnSelecting(e);
        }

        protected override int ExecuteDelete(IDictionary keys, IDictionary oldValues)
        {
            if (owner.RevertToOriginalDataSource)
            {
                return base.ExecuteDelete(keys, oldValues);
            }

            DataTable sessionTable = (DataTable) session[owner.DataSourceSessionKey];
            if (sessionTable != null)
            {
                string select = this.SelectRecordString(keys);

                DataRow[] res = sessionTable.Select(select);
                if (res.Length != 1)
                {
                    throw new InvalidOperationException("Unable to locate record to delete. Please asure you have selected the DataKeyNames propery.");
                }

                res[0].Delete();

				OnDeleted(new SqlDataSourceStatusEventArgs(null, 1, null));
				OnDataSourceViewChanged(EventArgs.Empty);
				
                return 1;
            }

            return 0;
        }

        protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
        {
            if (this.owner.RevertToOriginalDataSource)
            {
                return base.ExecuteUpdate(keys, values, oldValues);
            }

            DataTable sessionTable = (DataTable) this.session[this.owner.DataSourceSessionKey];
            if (sessionTable != null)
            {
                string select = this.SelectRecordString(keys);

                DataRow[] res = sessionTable.Select(select);
                if (res.Length != 1)
                {
                    throw new InvalidOperationException("Unable to locate record to update.");
                }

				DataRow rowToUpdate = res[0];

				try
				{
					foreach (DictionaryEntry entry in values)
					{
						rowToUpdate[(string)entry.Key] = entry.Value != null ? entry.Value : DBNull.Value;
					}
				}
				catch (ArgumentException)
				{
					rowToUpdate.RejectChanges();
					throw;
				}

				ExtractCommandParametersToDataRow(UpdateParameters, rowToUpdate);
				
				OnUpdated(new SqlDataSourceStatusEventArgs(null,1,null));
				OnDataSourceViewChanged(EventArgs.Empty);

                return 1;
            }

            return 0;
        }

        protected override int ExecuteInsert(IDictionary values)
        {
            if (this.owner.RevertToOriginalDataSource)
            {
                return base.ExecuteInsert(values);
            }

            DataTable sessionTable = (DataTable) session[owner.DataSourceSessionKey];
            if (sessionTable != null)
            {
                DataRow newRow = sessionTable.NewRow();
                foreach (DictionaryEntry newValue in values)
                {
                    newRow[(string) newValue.Key] = newValue.Value != null ? newValue.Value : DBNull.Value;
                }

                foreach (KeyValuePair<string,int> entry in GetNextPrimaryKey())
                {
                    newRow[entry.Key] = entry.Value;
                }

				ExtractCommandParametersToDataRow(InsertParameters, newRow);

                sessionTable.Rows.Add(newRow);

            	OnInserted(new SqlDataSourceStatusEventArgs(null, 1, null));
				OnDataSourceViewChanged(EventArgs.Empty);

                return 1;
            }

            return 0;
        }

		private void ExtractCommandParametersToDataRow(ParameterCollection parameters, DataRow row)
		{
			IOrderedDictionary paramsValues = parameters.GetValues(context, owner);
			for (int i = 0; i < parameters.Count; i++)
			{
				if (paramsValues[i] != null)
				{
					row[parameters[i].Name] = paramsValues[i];
				}
			}
		}

        private string FormatValue(object value)
        {
            if (value is string)
            {
                string str = (string) value;
                return ("'" + str.Replace("'", "''") + "'");
            }

            if (value is DateTime)
            {
                DateTime date = (DateTime) value;
                return ("'" + date.ToString(System.Globalization.CultureInfo.InvariantCulture) + "'");
            }

            return value.ToString();
        }

        private string SelectRecordString(IDictionary keys)
        {
            string select = string.Empty;
            foreach (DictionaryEntry entry in keys)
            {
                if (select != string.Empty)
                {
                    select += " AND ";
                }

                if (entry.Value != null)
                {
                    select += entry.Key + " = " + FormatValue(entry.Value);
                }
                else
                {
                    select += entry.Key + " Is Null";
                }
            }

            return select;
        }

        private DataTable SmartMerge(DataTable sessionTable, DataTable queryTable)
        {
			AddNewRows(sessionTable, queryTable);

            DataTable mergeResult = queryTable.Copy();
			mergeResult.Locale = System.Globalization.CultureInfo.InvariantCulture;
            mergeResult.BeginLoadData();

            DataTable added = sessionTable.GetChanges(DataRowState.Added);
            if (added != null)
            {
                foreach (DataRow row in added.Rows)
                {
                    mergeResult.Rows.Add(row.ItemArray);
                }
            }

            DataTable deleted = sessionTable.GetChanges(DataRowState.Deleted);
            if (deleted != null)
            {
                foreach (DataRow row in deleted.Rows)
                {
                    DataRow rowToDelete = mergeResult.Rows.Find(GetPrimaryKeyValues(row, DataRowVersion.Original));
                    if (rowToDelete != null)
                    {
                        rowToDelete.Delete();
                    }
                }
            }

            DataTable modified = sessionTable.GetChanges(DataRowState.Modified);
            if (modified != null)
            {
                foreach (DataRow row in modified.Rows)
                {
					mergeResult.LoadDataRow(row.ItemArray, true); 
                }
            }

            mergeResult.EndLoadData();
            mergeResult.AcceptChanges();
			string orderBy = GetCurrentOrderBy();
        	if (owner.SelectCommand.Contains("WHERE"))
        	{
        		DataTable result = mergeResult.Copy();
        		result.Rows.Clear();
        		result.BeginLoadData();
        		foreach (DataRow row in mergeResult.Select(GetCurrentSelectFilterExpression()))
        		{
        			result.Rows.Add(row.ItemArray);
        		}
        		result.EndLoadData();
        		result.AcceptChanges();
				if (!string.IsNullOrEmpty(orderBy))
				{
					result.DefaultView.Sort = orderBy;
				}
        		return result;
        	}
			
			if (!string.IsNullOrEmpty(orderBy))
			{
				mergeResult.DefaultView.Sort = orderBy;
			}
       		return mergeResult;
        }

		private static void AddNewRows(DataTable targetTable, DataTable newTable)
		{
			if (targetTable.PrimaryKey.Length == 0 || newTable.PrimaryKey.Length == 0)
			{
				return;
			}

			foreach (DataRow row in newTable.Rows)
			{
				object[] rowKey = GetPrimaryKeyValues(row, DataRowVersion.Original);
				DataRow existingRow = targetTable.Rows.Find(rowKey);
				if (existingRow == null)
				{
					DataRow deletedRow = FindDeletedRow(targetTable, rowKey);
					if (deletedRow == null)
					{
						targetTable.Rows.Add(row.ItemArray).AcceptChanges();
					}
				}
			}
		}
		
		private string GetCurrentOrderBy()
		{
			int indexOfOrderBy = owner.SelectCommand.IndexOf("ORDER BY");
			if (indexOfOrderBy < 0)
				return string.Empty;
			return owner.SelectCommand.Substring(indexOfOrderBy + "ORDER BY".Length).Replace("[","").Replace("]","") + " ASC";
		}

        private string GetCurrentSelectFilterExpression()
        {
			const string whereStr = "WHERE";
            int ixWhere = owner.SelectCommand.IndexOf(whereStr, StringComparison.InvariantCultureIgnoreCase);
            if (ixWhere == -1)
            {
                return string.Empty;
            }

			string selectCriteria = owner.SelectCommand.Substring(ixWhere + whereStr.Length);

            foreach (OracleParameter param in currentSelectParameters)
            {
                selectCriteria = selectCriteria.Replace(param.ParameterName, FormatValue(param.Value));
            }

            return selectCriteria;
        }

        private void InitPrimaryKey(DataTable table)
        {
            DataColumn[] pk = new DataColumn[PrimaryKeyFields.Length];
            for (int i = 0; i < PrimaryKeyFields.Length; i++)
            {
                DataColumn column = table.Columns[PrimaryKeyFields[i]];
                column.ReadOnly = true;
                pk[i] = column;
            }

            table.PrimaryKey = pk;
        }

        private static object[] GetPrimaryKeyValues(DataRow row, DataRowVersion version)
        {
            object[] pk = new object[row.Table.PrimaryKey.Length];

            for (int i = 0; i < pk.Length; i++)
            {
                pk[i] = row[row.Table.PrimaryKey[i], version];
            }

            return pk;
        }

		private static bool CompareRowKeys(object[] rowKey, object[] candidateKey)
		{
			bool candidateMatches = true;
			for (int i = 0; i < candidateKey.Length; i++)
			{
				if (!rowKey[i].Equals(candidateKey[i]))
				{
					candidateMatches = false;
					break;
				}
			}
			return candidateMatches;
		}

		private static DataRow FindDeletedRow(DataTable table, object[] rowKey)
		{
			DataTable deletedRecords = table.GetChanges(DataRowState.Deleted);
			DataRow deletedRow = null;
			if (deletedRecords != null)
			{
				foreach (DataRow candidateRow in deletedRecords.Rows)
				{
					object[] candidateKey = GetPrimaryKeyValues(candidateRow, DataRowVersion.Original);
					bool candidateMatches = CompareRowKeys(rowKey, candidateKey);

					if (candidateMatches)
					{
						deletedRow = candidateRow;
					}
				}
			}
			return deletedRow;
		}

        private Dictionary<string,int> GetNextPrimaryKey()
        {
            string pkSeedsSessionKey = owner.DataSourceSessionKey + "_pkSeeds";
            Dictionary<string, int> pkSeeds = (Dictionary<string, int>) session[pkSeedsSessionKey];

            if (pkSeeds == null)
            {
                pkSeeds = new Dictionary<string, int>();
                foreach (string pkField in PrimaryKeyFields)
                {
                    pkSeeds[pkField] = int.MinValue;
                }
                session[pkSeedsSessionKey] = pkSeeds;
            }
             
            Dictionary<string,int> newKeys = new Dictionary<string,int>();
            foreach (string pkField in PrimaryKeyFields)
            {
                newKeys[pkField] = pkSeeds[pkField];
                pkSeeds[pkField] = pkSeeds[pkField] + 1;
            }

            return newKeys;
        }
    }
}