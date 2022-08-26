using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contract_Setup_Activity : aspnetPage
{
    PriorityHelper oCorporatePriorityAccess = new PriorityHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess,(appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdContract);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");


        if (!Page.IsPostBack)
        {
            List<Priority> priorities = oCorporatePriorityAccess.lstGetPriority();
            foreach (Priority priority in priorities)
            {
                drpPriority.Items.Add(new ListItem(priority.sPriority, priority.iPriorityId.ToString()));
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //long lKpiHeaderId = 0;
        //string sPerformanceIndex = ""; string sUnit = "";
        //Nullable<Single> sBPTargetOsw; Nullable<Single> sBPTargetDw;

        //lKpiHeaderId = int.Parse(drpHeader.SelectedValue);
        //sPerformanceIndex = txtKPI.Text;
        //sUnit = txtUnit.Text;
        //sBPTargetOsw = dataManager.modifyXlsNumber(txtOSW.Text);
        //sBPTargetDw = dataManager.modifyXlsNumber(txtDW.Text);

        //if (okpiAccess.insertKpiTargets(lKpiHeaderId, sPerformanceIndex, sUnit, sBPTargetOsw, sBPTargetDw, int.Parse(drpLevel.SelectedValue)))
        //{
        //    ajaxWebExtension.showJscriptAlert(Page, this, "Key Performance Index " + sPerformanceIndex + "  successfully added.");
        //    Clear();
        //}
        //else
        //{
        //    ajaxWebExtension.showJscriptAlert(Page, this, "Key Performance Index " + sPerformanceIndex + "  was not submitted, please try again later.");
        //}
    }

    private void Clear()
    {
        txtKPI.Text = "";
        txtUnit.Text = "";
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/AdminInterface/updateKpiTargets.aspx");
    }
}