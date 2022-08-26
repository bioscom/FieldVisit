using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using Microsoft.Security.Application;

public partial class MasterPages_MasterPagePDR : aspnetMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dateLabel.Text = dateRoutine.dateLong(DateTime.Now.Date);
        lblWebSiteTitle.Text = AppConfiguration.siteNameProductionDailyReport;

        //lblInfo.Text = AppConfiguration.LeanFooterInfo;
        //lblCopyRight.Text = AppConfiguration.LeanCopyRight;

        //hpkLogout.Attributes.Add("onclick", "return clientMsgboxOnBlurEffect('Are You Sure You Want to Logout?')");
        loggedinUserLabel.Text = ((string.IsNullOrEmpty(oSessnx.getOnlineUser.m_sFullName))) ? HttpContext.Current.User.Identity.Name : this.oSessnx.getOnlineUser.m_sFullName;

        UserRoleLabel.Text = appUsersRoles.userRoleDesc((appUsersRoles.userRole)oSessnx.getOnlineUser.m_iRoleIdFieldVisit);
    }
    //private void UserMenu(XmlDataSource xmlDataSource)
    //{
    //    DataSet ds = new DataSet();
    //    //TODO: get the datasource for the menu
    //    int currentYear = DateTime.Now.Year;

    //    ds = okpiAccess.dtGetMenuForChart(currentYear.ToString());
    //    ds.DataSetName = "Menus";
    //    ds.Tables[0].TableName = "Menu";

    //    DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MENUID"], ds.Tables["Menu"].Columns["PARENTID"], true);
    //    relation.Nested = true;
    //    ds.Relations.Add(relation);

    //    try
    //    {
    //        //xmlDataSource.CacheDuration = 0;
    //        xmlDataSource.Data = ds.GetXml(); //Returns the XML representation of the data stored in the System.Data.DataSet
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }
    //}

}
