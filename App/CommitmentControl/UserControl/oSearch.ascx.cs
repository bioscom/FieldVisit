using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_CommitmentControl_UserControl_oSearch : System.Web.UI.UserControl
{
    CommitmentsMgt oMgt = new CommitmentsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        RadSearch.DataSource = GetResults();
    }

    public List<string> GetResults()
    {
        List<string> result = new List<string>();

        foreach (Commitments o in oMgt.lstCommitments())
        {
            result.Add(o.COMITMNTNO + ", " + o.TITLE);
        }

        return result;
    }

    protected void RadSearch_Search(object sender, SearchBoxEventArgs e)
    {
        //RadSearchBox searchBox = (RadSearchBox)sender;
        //string CommitmentId = string.Empty;
        //string likeCondition;

        if (e.DataItem != null)
        {
            //    //CommitmentId = ((Dictionary<string, object>)e.DataItem)["COMMITMENTID"].ToString();
            //    //if (!string.IsNullOrEmpty(CommitmentId))
            //    //{
            //    //    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["COMMITMENTID"].ToString());

            //    //    gridDataSource.SelectCommand = "SELECT TOP 10 [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice]" + "FROM[Products] WHERE [" + searchBox.DataValueField + "] LIKE " + likeCondition;
            //    //    RadGrid1.DataBind();

            //    //}
        }
    }
}