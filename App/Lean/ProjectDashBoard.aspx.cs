using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_ProjectDashBoard : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    appUsersHelper oAppUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<int> iYears = oMainProjectHelper.lstYears();
            foreach (int iYear in iYears)
            {
                ddlYear.Items.Add(iYear.ToString());
            }
            //ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
            }

            LoadProjects();
        }
    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        LoadByCriteria();
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        DataSorter sortMe = new DataSorter();

        try
        {
            if ((ButtonClicked == "Sort") || (ButtonClicked == "Page"))
            {
                //CurrentSortExpression = sortMe.MySortExpression(e);

                //int result;
                //if (Int32.TryParse(e.CommandArgument.ToString(), out result) == false)
                //{
                //    Session["SortExpression"] = e.CommandArgument.ToString();
                //}
                //CurrentSortExpression = Session["SortExpression"].ToString();
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

                if (ButtonClicked == "Project")
                {
                    LinkButton lbProjectLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ProjectLinkButton");
                    long ProjectId = long.Parse(lbProjectLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/IESView.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "ViewProject")
                {
                    LinkButton lbProjectLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("ViewLinkButton");
                    long ProjectId = long.Parse(lbProjectLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/Report/MainReport.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "EditProject")
                {
                    LinkButton lbEditLinkButton = (LinkButton)grdGridView.Rows[index].FindControl("EditLinkButton");
                    long ProjectId = long.Parse(lbEditLinkButton.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/EditLeanProject.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "IES")
                {
                    LinkButton lbIES = (LinkButton)grdGridView.Rows[index].FindControl("IESLinkButton");
                    long ProjectId = long.Parse(lbIES.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/IES.aspx" + "?ProjectId=" + ProjectId, false);
                }

                if (ButtonClicked == "VSM")
                {
                    LinkButton lbVSM = (LinkButton)grdGridView.Rows[index].FindControl("VsmLinkButton");
                    long ProjectId = long.Parse(lbVSM.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/AsIsVsm.aspx" + "?ProjectId=" + ProjectId + "&VIW=V", false);
                }

                if (ButtonClicked == "Benefit")
                {
                    LinkButton lbBenefit = (LinkButton)grdGridView.Rows[index].FindControl("BenefitLinkButton");
                    long ProjectId = long.Parse(lbBenefit.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/Benefit.aspx" + "?ProjectId=" + ProjectId + "&VIW=V", false);
                }
                if (ButtonClicked == "Recommendations")
                {
                    LinkButton lbRecommendations = (LinkButton)grdGridView.Rows[index].FindControl("RecommendationsLinkButton");
                    long ProjectId = long.Parse(lbRecommendations.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/ProjectRecommendation.aspx" + "?ProjectId=" + ProjectId + "&VIW=V", false);
                }

                if (ButtonClicked == "LoadDocs")
                {
                    LinkButton lbLoadDocs = (LinkButton)grdGridView.Rows[index].FindControl("DocsLinkButton");
                    long ProjectId = long.Parse(lbLoadDocs.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/LoadDocs.aspx" + "?ProjectId=" + ProjectId + "&VIW=V", false);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void LoadProjects()
    {
        MainProjectHelper oMainProjectHelper = new MainProjectHelper();

        grdGridView.DataSource = oMainProjectHelper.dtGetAllLeanProjectDashBoard();
        grdGridView.DataBind();
        getProjectCoach();
        //ManageTraffic();
    }
    private void getProjectCoach()
    {
        foreach (GridViewRow grdRow in grdGridView.Rows)
        {
            Label labelCoach = (Label)grdRow.FindControl("labelCoach");
            LinkButton lnkView = (LinkButton)grdRow.FindControl("ViewLinkButton");
            long ProjectId = long.Parse(lnkView.Attributes["IDPROJECT"].ToString());
            List<ProjectCoaches> lstProjectCoached = oMainProjectHelper.lstProjectCoaches(ProjectId);
            foreach (ProjectCoaches oProjectCoach in lstProjectCoached)
            {
                labelCoach.Text += oAppUsersHelper.objGetUserByUserID(oProjectCoach.iUserId).m_sFullName + "; ";
            }
        }
    }
    private void LoadProjectsByYear()
    {
        grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectDashBoardByYear(int.Parse(ddlYear.SelectedValue));
        grdGridView.DataBind();
        getProjectCoach();

        //ManageTraffic();
    }
    private void LoadProjectsByFunctionYear()
    {
        grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectDashBoardByYearFunction(int.Parse(ddlYear.SelectedValue), int.Parse(ddlFunction.SelectedValue));
        grdGridView.DataBind();
        getProjectCoach();

        //ManageTraffic();
    }
    private void LoadProjectsByFunction()
    {
        grdGridView.DataSource = oMainProjectHelper.dtGetLeanProjectDashBoardByFunction(int.Parse(ddlFunction.SelectedValue));
        grdGridView.DataBind();
        getProjectCoach();

        //ManageTraffic();
    }
    //private void ManageTraffic()
    //{
    //    try
    //    {
    //        foreach (GridViewRow grdRow in grdGridView.Rows)
    //        {
    //            //LinkButton status = (LinkButton)grdRow.FindControl("statusLinkButton");
    //            //long iActivityId = long.Parse(status.Attributes["ID_ACTIVITYINFO"].ToString());

    //            TextBox txtHandover = (TextBox)grdRow.FindControl("txtHandover");
    //            TextBox txtVisMeasures = (TextBox)grdRow.FindControl("txtVisMeasures");
    //            TextBox txtSOPs = (TextBox)grdRow.FindControl("txtSOPs");

    //            TextBox txtPilot = (TextBox)grdRow.FindControl("txtPilot");
    //            TextBox txtDRB = (TextBox)grdRow.FindControl("txtDRB");
    //            TextBox txtKaizen = (TextBox)grdRow.FindControl("txtKaizen");
    //            TextBox txtVSMValid = (TextBox)grdRow.FindControl("txtVSMValid");
    //            TextBox txtProcessWalk = (TextBox)grdRow.FindControl("txtProcessWalk");
    //            TextBox txtSIPOC = (TextBox)grdRow.FindControl("txtSIPOC");
    //            TextBox txtSignOff = (TextBox)grdRow.FindControl("txtSignOff");


    //            if (txtHandover.Text == "100") txtHandover.BackColor = System.Drawing.Color.Green;
    //            else if (txtHandover.Text == "50") txtHandover.BackColor = System.Drawing.Color.Orange;
    //            else txtHandover.BackColor = System.Drawing.Color.Red;

    //            if (txtVisMeasures.Text == "100") txtVisMeasures.BackColor = System.Drawing.Color.Green;
    //            else if (txtVisMeasures.Text == "50") txtVisMeasures.BackColor = System.Drawing.Color.Orange;
    //            else txtVisMeasures.BackColor = System.Drawing.Color.Red;

    //            if (txtSOPs.Text == "100") txtSOPs.BackColor = System.Drawing.Color.Green;
    //            else if (txtSOPs.Text == "50") txtSOPs.BackColor = System.Drawing.Color.Orange;
    //            else txtSOPs.BackColor = System.Drawing.Color.Red;

    //            if (txtPilot.Text == "100") txtPilot.BackColor = System.Drawing.Color.Green;
    //            else if (txtPilot.Text == "50") txtPilot.BackColor = System.Drawing.Color.Orange;
    //            else txtPilot.BackColor = System.Drawing.Color.Red;

    //            if (txtDRB.Text == "100") txtDRB.BackColor = System.Drawing.Color.Green;
    //            else if (txtDRB.Text == "50") txtDRB.BackColor = System.Drawing.Color.Orange;
    //            else txtDRB.BackColor = System.Drawing.Color.Red;

    //            if (txtKaizen.Text == "100") txtKaizen.BackColor = System.Drawing.Color.Green;
    //            else if (txtKaizen.Text == "50") txtKaizen.BackColor = System.Drawing.Color.Orange;
    //            else txtKaizen.BackColor = System.Drawing.Color.Red;

    //            if (txtVSMValid.Text == "100") txtVSMValid.BackColor = System.Drawing.Color.Green;
    //            else if (txtVSMValid.Text == "50") txtVSMValid.BackColor = System.Drawing.Color.Orange;
    //            else txtVSMValid.BackColor = System.Drawing.Color.Red;

    //            if (txtProcessWalk.Text == "100") txtProcessWalk.BackColor = System.Drawing.Color.Green;
    //            else if (txtProcessWalk.Text == "50") txtProcessWalk.BackColor = System.Drawing.Color.Orange;
    //            else txtProcessWalk.BackColor = System.Drawing.Color.Red;

    //            if (txtSIPOC.Text == "100") txtSIPOC.BackColor = System.Drawing.Color.Green;
    //            else if (txtSIPOC.Text == "50") txtSIPOC.BackColor = System.Drawing.Color.Orange;
    //            else txtSIPOC.BackColor = System.Drawing.Color.Red;

    //            if (txtSignOff.Text == "100") txtSignOff.BackColor = System.Drawing.Color.Green;
    //            else if (txtSignOff.Text == "50") txtSignOff.BackColor = System.Drawing.Color.Orange;
    //            else txtSignOff.BackColor = System.Drawing.Color.Red;

    //            //statusReporter.reportPECStatus(status, iActivityId, txtStatusVST, txtStatusST, txtStatusMT);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //    }


    //    //                   
    //}
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadByCriteria();
    }
    protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadByCriteria();
    }
    private void LoadByCriteria()
    {
        if ((ddlYear.SelectedValue == "-1") && (ddlFunction.SelectedValue == "-1"))
        {
            LoadProjects();
        }
        else if ((ddlYear.SelectedValue != "-1") && (ddlFunction.SelectedValue == "-1"))
        {
            LoadProjectsByYear();
        }
        else if ((ddlYear.SelectedValue == "-1") && (ddlFunction.SelectedValue != "-1"))
        {
            LoadProjectsByFunction();
        }
        else if ((ddlYear.SelectedValue != "-1") && (ddlFunction.SelectedValue != "-1"))
        {
            LoadProjectsByFunctionYear();
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/Default.aspx");
    }
}