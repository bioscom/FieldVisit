using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Menu
/// </summary>
public class Menu
{
    public Menu()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void getChartMenu(XmlDataSource XmlDS)
    {
        try
        {
            DataSet ds = GenericDataAccess.ExecuteSelectCommand(PDR.StoredProcedure.getChartMenu());

            DataTable dtMenu = new DataTable("MenuTable");
            dtMenu.Columns.Add(new DataColumn("MENUID", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("TITLE", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("PARENTID", typeof(System.String)));

            DataSet dsMenu = new DataSet();
            dsMenu.Tables.Add(dtMenu);

            string sNewHeader = "";
            string LastMenuId = "";
            int iUniqueId = 2;
            int iUniqueIdHolder = 1;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (LastMenuId != dr["MENUID"].ToString())
                {
                    sNewHeader = dr["MENUID"].ToString();

                    DataRow anyRow = dsMenu.Tables["MenuTable"].NewRow();

                    DataRow[] oRow = null;
                    oRow = ds.Tables[0].Select("MENUID=" + sNewHeader);
                    if (oRow != null)
                    {
                        anyRow[0] = iUniqueIdHolder;
                        anyRow[1] = oRow[0]["ASSETS"].ToString();
                        anyRow[2] = DBNull.Value;
                        dsMenu.Tables["MenuTable"].Rows.Add(anyRow);

                        foreach (DataRow dr2 in oRow)
                        {
                            anyRow = dsMenu.Tables["MenuTable"].NewRow();
                            anyRow[0] = iUniqueId++;
                            anyRow[1] = dr2["TITLE"].ToString();
                            anyRow[2] = iUniqueIdHolder;
                            dsMenu.Tables["MenuTable"].Rows.Add(anyRow);
                        }
                        iUniqueIdHolder = iUniqueId;
                        iUniqueId++;
                    }

                }
                LastMenuId = sNewHeader;
            }

            dsMenu.DataSetName = "Menus";
            dsMenu.Tables["MenuTable"].TableName = "Menu";

            DataRelation relation = new DataRelation("ParentChild", dsMenu.Tables["Menu"].Columns["MENUID"], dsMenu.Tables["Menu"].Columns["PARENTID"], true);
            relation.Nested = true;
            dsMenu.Relations.Add(relation);

            XmlDS.Data = dsMenu.GetXml(); //Returns the XML representation of the data stored in the System.Data.DataSet

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public static void getChartMenuVerificationHeatMap(XmlDataSource XmlDS)
    {
        try
        {
            DataSet ds = GenericDataAccess.ExecuteSelectCommand(PDR.StoredProcedure.getChartMenu());

            DataTable dtMenu = new DataTable("MenuTable");
            dtMenu.Columns.Add(new DataColumn("MENUID", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("TITLE", typeof(System.String)));
            dtMenu.Columns.Add(new DataColumn("PARENTID", typeof(System.String)));

            DataSet dsMenu = new DataSet();
            dsMenu.Tables.Add(dtMenu);

            string sNewHeader = "";
            string LastMenuId = "";
            int iUniqueId = 2;
            int iUniqueIdHolder = 1;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (LastMenuId != dr["MENUID"].ToString())
                {
                    sNewHeader = dr["MENUID"].ToString();

                    DataRow anyRow = dsMenu.Tables["MenuTable"].NewRow();

                    DataRow[] oRow = null;
                    oRow = ds.Tables[0].Select("MENUID=" + sNewHeader);
                    if (oRow != null)
                    {
                        anyRow[0] = iUniqueIdHolder;
                        anyRow[1] = oRow[0]["ASSETS"].ToString();
                        anyRow[2] = DBNull.Value;
                        dsMenu.Tables["MenuTable"].Rows.Add(anyRow);

                        foreach (DataRow dr2 in oRow)
                        {
                            anyRow = dsMenu.Tables["MenuTable"].NewRow();
                            anyRow[0] = iUniqueId++;
                            anyRow[1] = dr2["TITLE"].ToString();
                            anyRow[2] = iUniqueIdHolder;
                            dsMenu.Tables["MenuTable"].Rows.Add(anyRow);
                        }
                        iUniqueIdHolder = iUniqueId;
                        iUniqueId++;
                    }

                }
                LastMenuId = sNewHeader;
            }

            dsMenu.DataSetName = "Menus";
            dsMenu.Tables["MenuTable"].TableName = "Menu";

            DataRelation relation = new DataRelation("ParentChild", dsMenu.Tables["Menu"].Columns["MENUID"], dsMenu.Tables["Menu"].Columns["PARENTID"], true);
            relation.Nested = true;
            dsMenu.Relations.Add(relation);

            XmlDS.Data = dsMenu.GetXml(); //Returns the XML representation of the data stored in the System.Data.DataSet

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

}