using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserControl_approverSignoff : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void initPage()
    {
        addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Approved);
        addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.NotApproved);
        addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Callme);
        addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt.Reschedule);
    }

    private void addRoleToDropDown(siteVisitApprovalStatus.apprStatusRpt eStatus)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = siteVisitApprovalStatus.StatusRptDesc(eStatus);
            oItem.Value = ((int)eStatus).ToString();
            drpStand.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        //1. retrieve the field visit item from the activity_approval table and determine what role is to be played

        //bool success = siteVisitApproval.actionFieldVisitRequest(0, CommentTextBox.Text, int.Parse(drpStand.SelectedValue));
        //if (success == true)
        //{
        //    //Send mail to the 
        //}
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
}
