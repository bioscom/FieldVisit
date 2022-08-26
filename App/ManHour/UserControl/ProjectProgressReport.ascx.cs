using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_ManHour_UserControl_ProjectProgressReport : System.Web.UI.UserControl
{
    ProjectCurrentStatusHelper oProjectCurrentStatusHelper = new ProjectCurrentStatusHelper();
    ProjectMilestoneHelper oProjectMilestoneHelper = new ProjectMilestoneHelper();
    ProjectMilestone oProjectMilestone = new ProjectMilestone();

    public void Page_Init()
    {

    }

    public void InitPage(long lInitiativeId)
    {
        InitiativeIDHF.Value = lInitiativeId.ToString();

        getProjectCurrentStatus();
        getMileStones(lInitiativeId);
    }

    private void getMileStones(long lInitiativeId)
    {
        grdView.DataSource = oProjectMilestoneHelper.dtGetProjectMilestoneByInitiativeId(lInitiativeId);
        grdView.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Submit the values for Project Status
        bool bRet = false;
        ProjectCurrentStatus oProjectCurrentStatus = new ProjectCurrentStatus();
        ProjectCurrentStatus xProjectCurrentStatus = oProjectCurrentStatusHelper.objGetProjectCurrentStatusByInitiativeId(long.Parse(InitiativeIDHF.Value));

        oProjectCurrentStatus.lStatusId = xProjectCurrentStatus.lStatusId;
        oProjectCurrentStatus.lInitiativeId = long.Parse(InitiativeIDHF.Value);
        oProjectCurrentStatus.sChallenges = txtChallenges.Text;
        oProjectCurrentStatus.sComments = txtComments.Text;
        oProjectCurrentStatus.sLEC = txtLEC.Text;
        oProjectCurrentStatus.sStatus = txtCurrentStatus.Text;

        if (xProjectCurrentStatus.lInitiativeId != 0)
            bRet = oProjectCurrentStatusHelper.UpdateProjectCurrentStatus(oProjectCurrentStatus);
        else
            bRet = oProjectCurrentStatusHelper.InsertProjectCurrentStatus(oProjectCurrentStatus);

        if (bRet)
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Project Status successfully updated.");
        else
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Update not successfully, try again later.");

        getProjectCurrentStatus();
    }

    private void getProjectCurrentStatus()
    {
        ProjectCurrentStatus oProjectCurrentStatus = oProjectCurrentStatusHelper.objGetProjectCurrentStatusByInitiativeId(long.Parse(InitiativeIDHF.Value));

        txtChallenges.Text = oProjectCurrentStatus.sChallenges;
        txtComments.Text = oProjectCurrentStatus.sComments;
        txtLEC.Text = oProjectCurrentStatus.sLEC;
        txtCurrentStatus.Text = oProjectCurrentStatus.sStatus;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Retrieve_Data(long lInitiativeId)
    {
        
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            long lInitiativeId = long.Parse(InitiativeIDHF.Value);
            if (e.CommandName.Equals("Insert"))
            {
                oProjectMilestone.lInitiativeId = lInitiativeId;
                oProjectMilestone.sMilestones = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtMileStone")).Text);
                oProjectMilestone.sRemarks = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtRemarks")).Text);
                oProjectMilestone.sStatus = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtStatus")).Text);
                oProjectMilestone.sTargetDate = Convert.ToString(((TextBox)grdView.FooterRow.FindControl("txtTargetDate")).Text);

                oProjectMilestoneHelper.InsertProjectMilestone(oProjectMilestone);

                getMileStones(lInitiativeId);
                //InitPage(lInitiativeId);
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

                oProjectMilestone.lInitiativeId = lInitiativeId;
                oProjectMilestone.sMilestones = Convert.ToString(((TextBox)emptyRow.FindControl("txtMileStone")).Text);
                oProjectMilestone.sRemarks = Convert.ToString(((TextBox)emptyRow.FindControl("txtRemarks")).Text);
                oProjectMilestone.sStatus = Convert.ToString(((TextBox)emptyRow.FindControl("txtStatus")).Text);
                oProjectMilestone.sTargetDate = Convert.ToString(((TextBox)emptyRow.FindControl("txtTargetDate")).Text);

                oProjectMilestoneHelper.InsertProjectMilestone(oProjectMilestone);

                getMileStones(lInitiativeId);
                //InitPage(lInitiativeId);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lInitiativeId = long.Parse(InitiativeIDHF.Value);
        grdView.EditIndex = -1;
        getMileStones(lInitiativeId);
        //InitPage(lInitiativeId);
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            long lInitiativeId = long.Parse(InitiativeIDHF.Value);
            grdView.EditIndex = e.NewEditIndex;
            getMileStones(lInitiativeId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            long lInitiativeId = long.Parse(InitiativeIDHF.Value);
            long lMilestoneId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());

            oProjectMilestone.lMilestoneId = lMilestoneId;
            oProjectMilestone.sMilestones = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMileStone")).Text);
            oProjectMilestone.sRemarks = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtRemarks")).Text);
            oProjectMilestone.sStatus = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtStatus")).Text);
            oProjectMilestone.sTargetDate = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtTargetDate")).Text);

            oProjectMilestoneHelper.UpdateProjectMilestone(oProjectMilestone);
            grdView.EditIndex = -1;

            getMileStones(lInitiativeId);
            //InitPage(lInitiativeId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lInitiativeId = long.Parse(InitiativeIDHF.Value);

        long lMilestoneId = long.Parse(grdView.DataKeys[e.RowIndex].Values[0].ToString());

        oProjectMilestone.lMilestoneId = lMilestoneId;

        oProjectMilestoneHelper.DeleteProjectMilestone(oProjectMilestone);
        ajaxWebExtension.showJscriptAlertCx(Page, this, "Milestone successfully deleted.");
        getMileStones(lInitiativeId);
        //InitPage(lInitiativeId);
    }
   
}