using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;

public partial class UserControl_MyInitiatives : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control()
    {
        int i = 0;
        //Load Pending Initiatives
        MyPendingInitiativeListBox.Items.Clear();
        Initiative oInitiative = new Initiative();
        List<Initiative> initiatives = oInitiative.LstGetPendingInitiativesByUserId(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())), (int)Approval.apprStatusRpt.Approved);
        foreach (Initiative initiative in initiatives)
        {
            i++;
            MyPendingInitiativeListBox.Items.Add(new ListItem(i + ". " + initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
        }

        //Load Approved Initiatives
        MyApprovedInitiativeListBox.Items.Clear();
        List<Initiative> approvedInitiatives = oInitiative.LstGetApprovedNotApprovedInitiativesByUserId(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())), (int)Approval.apprStatusRpt.Approved);
        foreach (Initiative approvedInitiative in approvedInitiatives)
        {
            MyApprovedInitiativeListBox.Items.Add(new ListItem(approvedInitiative.m_sTitle, approvedInitiative.m_lInitiativeId.ToString()));
        }

        //Load Initiatives Not Approved
        //TODO: get the method to load Initiatives not approved
        NotApprovedInitiativeListBox.Items.Clear();
        List<Initiative> notApprovedInitiatives = oInitiative.LstGetApprovedNotApprovedInitiativesByUserId(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())), (int)Approval.apprStatusRpt.NotApproved);
        foreach (Initiative notApprovedinitiative in notApprovedInitiatives)
        {
            NotApprovedInitiativeListBox.Items.Add(new ListItem(notApprovedinitiative.m_sTitle, notApprovedinitiative.m_lInitiativeId.ToString()));
        }
    }

    public void Init_Control_Admin()
    {
        int i = 0;
        //Load Pending Initiatives
        MyPendingInitiativeListBox.Items.Clear();
        Initiative oInitiative = new Initiative();
        List<Initiative> Initiatives = oInitiative.lstGetAllPendingInitiatives();
        foreach (Initiative initiative in Initiatives)
        {
            i++;
            MyPendingInitiativeListBox.Items.Add(new ListItem(i + ". " + initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
        }

        //Load Approved Initiatives
        i = 0;
        MyApprovedInitiativeListBox.Items.Clear();
        List<Initiative> approvedInitiatives = oInitiative.lstGetAllApprovedInitiatives();
        foreach (Initiative approvedInitiative in approvedInitiatives)
        {
            i++;
            MyApprovedInitiativeListBox.Items.Add(new ListItem(i + ". " + approvedInitiative.m_sTitle, approvedInitiative.m_lInitiativeId.ToString()));
        }

        //Load Initiatives Not Approved
        //TODO: get the method to load Initiatives not approved
        NotApprovedInitiativeListBox.Items.Clear();
        i = 0;
        List<Initiative> notApprovedInitiatives = oInitiative.lstGetAllNotApprovedInitiatives();   // lstGetApprovedInitiativesByUserId(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())), (int)Approval.apprStatusRpt.Approved);
        foreach (Initiative notApprovedinitiative in notApprovedInitiatives)
        {
            i++;
            NotApprovedInitiativeListBox.Items.Add(new ListItem(i + ". " + notApprovedinitiative.m_sTitle, notApprovedinitiative.m_lInitiativeId.ToString()));
        }
    }

    public void Init_Control_Approvers()
    {
        //Load Pending Business Initiatives for my approval
        MyPendingInitiativeListBox.Items.Clear();
        Initiative oInitiative = new Initiative();

        int iStatus = -1;
        if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.sponsor)
            iStatus = (int)Approval.apprStatusRpt.Sponsor;
        else if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.FunctionalLead)
            iStatus = (int)Approval.apprStatusRpt.FunctionalLead;
        else if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.AssetOperationsManager)
            iStatus = (int)Approval.apprStatusRpt.AssetOperationsManager;

        List<Initiative> Initiatives = oInitiative.lstGetInitiativesPendingMyApproval(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())), iStatus);
        foreach (Initiative initiative in Initiatives)
        {
            MyPendingInitiativeListBox.Items.Add(new ListItem(initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
        }

        //Load Business Initiatives I have Approved
        MyApprovedInitiativeListBox.Items.Clear();
        List<Initiative> approvedInitiatives = new List<Initiative>();  // oInitiative.lstGetInitiativesIApproved(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())));
        if (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.FunctionalLead)
        {
            approvedInitiatives = oInitiative.lstGetInitiativesApprovedInMyFunction(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())));
        }
        else
        {
            approvedInitiatives = oInitiative.lstGetInitiativesIApproved(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())));
        }

        foreach (Initiative approvedInitiative in approvedInitiatives)
        {
            MyApprovedInitiativeListBox.Items.Add(new ListItem(approvedInitiative.m_sTitle, approvedInitiative.m_lInitiativeId.ToString()));
        }

        //Load Initiatives Not Approved
        //TODO: get the method to load Initiatives not approved
        NotApprovedInitiativeListBox.Items.Clear();
        List<Initiative> notApprovedInitiatives = oInitiative.lstGetInitiativesIApproved(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())));
        foreach (Initiative notApprovedinitiative in notApprovedInitiatives)
        {
            NotApprovedInitiativeListBox.Items.Add(new ListItem(notApprovedinitiative.m_sTitle, notApprovedinitiative.m_lInitiativeId.ToString()));
        }

        ////Load Business Initiatives I have Rejected
        //MyApprovedInitiativeListBox.Items.Clear();
        //List<Initiative> rejectedInitiatives = oInitiative.lstGetInitiativesIApproved(int.Parse(Encoder.HtmlEncode(oSessnx.getOnlineUser.m_iUserId.ToString())));
        //foreach (Initiative approvedInitiative in approvedInitiatives)
        //{
        //    MyApprovedInitiativeListBox.Items.Add(new ListItem(approvedInitiative.m_sTitle, approvedInitiative.m_lInitiativeId.ToString()));
        //}
    }

    protected void newInitBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Nor");
    }

    protected void newImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Nor");
    }

    protected void MyInitiativeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.admin) || (oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0))
        {
            Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Edt&IntiativeId=" + MyPendingInitiativeListBox.SelectedValue);
        }
        else
        {
            Response.Redirect("~/App/ManHour/Forms/DefaultApproval.aspx?xMod=Viw&IntiativeId=" + MyPendingInitiativeListBox.SelectedValue);
        }
    }
    protected void MyApprovedInitiativeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.admin) || (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0))
        {
            Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Edt&IntiativeId=" + MyApprovedInitiativeListBox.SelectedValue);
        }
        else
        {
            Response.Redirect("~/App/ManHour/Forms/DefaultApproval.aspx?xMod=Viw&IntiativeId=" + MyApprovedInitiativeListBox.SelectedValue);
        }
    }
    protected void NotApprovedInitiativeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.admin) || (oSessnx.getOnlineUser.m_iRoleIdManHr == (int)appUsersRoles.userRole.initiator) || (oSessnx.getOnlineUser.m_iRoleIdManHr == null) || (oSessnx.getOnlineUser.m_iRoleIdManHr == 0))
        {
            Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Edt&IntiativeId=" + NotApprovedInitiativeListBox.SelectedValue);
        }
        else
        {
            Response.Redirect("~/App/ManHour/Forms/DefaultApproval.aspx?xMod=Viw&IntiativeId=" + NotApprovedInitiativeListBox.SelectedValue);
        }
    }

    //[WebMethodAttribute(), ScriptMethodAttribute()]
    //public string[] GetCompletionList(string prefixText, int count, string contextKey)
    //{
    //    List<string> MyItems = new List<string>();

    //    Initiative oInitiative = new Initiative();
    //    List<Initiative> Initiatives = oInitiative.lstGetBusinessInitiativeByPrefixText(contextKey);
    //    foreach (Initiative initiative in Initiatives)
    //    {
    //        MyItems.Add(initiative.m_sTitle);
    //        //MyItems.Add(new ListItem(initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
    //    }

    //    //List<accountToCharge> accounts = accountToCharge.lstGetAccountsToChargeByPrefixText(prefixText);
    //    //foreach (accountToCharge account in accounts)
    //    //{
    //    //    MyItems.Add(account.m_sAccount);
    //    //    //MyItems.Items.Add(new ListItem(account.m_sAccount, account.m_sAccountDescription));
    //    //}

    //    return MyItems.ToArray();
    //}

    protected void btnNewInitiative_Click(object sender, EventArgs e)
    {
        //btnNewInitiative_Click
        Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Nor");
    }
}