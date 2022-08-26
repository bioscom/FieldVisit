using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_Setup_KPIReporting : aspnetPage
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    PriorityHelper oPriorityHelper = new PriorityHelper();
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersRoles.userRole.admin.ToString() };
            appUsersRoles oAccess = new appUsersRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdContract);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!Page.IsPostBack)
        {
            List<Priority> priorities = oPriorityHelper.lstGetPriority();//.lstGetCorporatePriority();
            foreach (Priority priority in priorities)
            {
                ddlPriority.Items.Add(new ListItem(priority.sPriority, priority.iPriorityId.ToString()));
            }

            iPanel.Visible = false;
            iPanel2.Visible = false;
        }
    }

    protected void ddlCorpPriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        iPanel.Visible = true;
        iPanel2.Visible = true;
        KPICkb.Items.Clear();
        
        List<ContractActivities> oContractActivities = oContractActivitiesHelper.lstActivitiesByPriority(int.Parse(ddlPriority.SelectedValue));
        foreach (ContractActivities oContractActivity in oContractActivities)
        {
            KPICkb.Items.Add(new ListItem(oContractActivity.sActivity, oContractActivity.iActivitiesId.ToString()));
        }

        loadActivitiesItems(oContractActivities);

        grdView.DataSource = oContractActivitiesHelper.dtGetActivitiesByPriority(int.Parse(ddlPriority.SelectedValue));
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            RadioButtonList RdBList = (RadioButtonList)grdRow.FindControl("RdBList");
            RdBList.Items.Add(new ListItem("Average", "1"));
            RdBList.Items.Add(new ListItem("Sum", "2"));
        }

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            RadioButtonList RdBList = (RadioButtonList)grdRow.FindControl("RdBList");
            int iCalc = int.Parse(RdBList.Attributes["oVAL"].ToString());
            foreach (ListItem li in RdBList.Items)
            {
                if (iCalc == 1)
                {
                    if (li.Value == "1") li.Selected = true;
                }
                else if (iCalc == 2)
                {
                    if (li.Value == "2") li.Selected = true;
                }
            }
        }       
    }

    private void loadActivitiesItems(List<ContractActivities> oContractActivities)
    {
        foreach (ContractActivities oContractActivity in oContractActivities)
        {
            foreach (ListItem li in KPICkb.Items)
            {
                if ((oContractActivity.iBit == 1) && (oContractActivity.iActivitiesId == int.Parse(li.Value)))
                {
                    li.Selected = true;
                    break;
                }
            }
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        //1. Set all the values to 0        
        foreach (ListItem li in KPICkb.Items)
        {
            bRet = oContractActivitiesHelper.updateActivityBit(0, int.Parse(li.Value));
        }

        //2. Then update selected checkboxes to 1
        foreach (ListItem li in KPICkb.Items)
        {
            if (li.Selected == true)
            {
                bRet = oContractActivitiesHelper.updateActivityBit(1, int.Parse(li.Value));
            }
        }

        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Update successful.");
        else ajaxWebExtension.showJscriptAlert(Page, this, "Update not successful!!!");
    }

    protected void closeBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Contract/Default.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool bRet = false;

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbActivity = (Label)grdRow.FindControl("lbActivity");
            int iActivityId = int.Parse(lbActivity.Attributes["IDACTIVITIES"].ToString());
            RadioButtonList RdBList = (RadioButtonList)grdRow.FindControl("RdBList");
            foreach (ListItem li in RdBList.Items)
            {
                if (li.Selected == true)
                {
                    bRet = oContractActivitiesHelper.updateActivityBitCalc(int.Parse(li.Value), iActivityId);
                }
            }
        }

        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Update successful.");
        else ajaxWebExtension.showJscriptAlert(Page, this, "Update not successful!!!");
    }
}