using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_EditLeanProject : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    MainProjects oMainProjects = new MainProjects();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    Department xDepartment = new Department();
    LkUpProjectType xLkUpProjectType = new LkUpProjectType();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProjectId"] != null)
            {
                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                sponsor.editMode();
                manager.editMode();
                //coach.editMode();
                champion.editMode();

                IdentifyStartDate.ErrorMssg("Identify Start Date is required.");
                IdentifyEndDate.ErrorMssg("Identify End Date is required.");

                EliminateStartDate.ErrorMssg("Eliminate Start Date is required.");
                EliminateEndDate.ErrorMssg("Eliminate End Date is required.");

                SustainStartDate.ErrorMssg("Sustain Start Date is required.");
                SustainEndDate.ErrorMssg("Sustain End Date is required.");

                oLeanProjectDetails1.Init_Control(oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId));


                List<int> iYears = oMainProjectHelper.lstYearsExt();
                foreach (int iYear in iYears)
                {
                    ddlYear.Items.Add(iYear.ToString());
                }

                List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
                foreach (Functions oFunction in oFunctions)
                {
                    ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                }

                List<Department> oDepartments = xDepartment.lstGetDeparments();
                foreach (Department oDepartment in oDepartments)
                {
                    ddlDept.Items.Add(new ListItem(oDepartment.m_sDepartment, oDepartment.m_iDepartmentId.ToString()));
                }

                List<LkUpProjectType> oLkUpProjectTypes = xLkUpProjectType.lstGetProjectTypes();
                foreach (LkUpProjectType oLkUpProjectType in oLkUpProjectTypes)
                {
                    ddlProjType.Items.Add(new ListItem(oLkUpProjectType.m_sProjectType, oLkUpProjectType.m_iProjectType.ToString()));
                }

                //Get all users
                //sponsor.thisDropDownList.Items.Clear(); sponsor.thisDropDownList.Items.Add(new ListItem("Please Select...", "-1"));
                //manager.thisDropDownList.Items.Clear(); manager.thisDropDownList.Items.Add(new ListItem("Please Select...", "-1"));
                //coach.thisDropDownList.Items.Clear(); coach.thisDropDownList.Items.Add(new ListItem("Please Select...", "-1"));
                //champion.thisDropDownList.Items.Clear(); champion.thisDropDownList.Items.Add(new ListItem("Please Select...", "-1"));

                LoadProject(lProjectId);
            }
        }
    }

    private void LoadProject(long lProjectId)
    {
        try
        {
            oMainProjects = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);

            appUsers oChampion = appUsersHelper.objGetUserByUserId(oMainProjects.iChampion);
            //appUsers oCoach = appUsersHelper.objGetUserByUserId(oMainProjects.iCoach);

            appUsers oManager = appUsersHelper.objGetUserByUserId(oMainProjects.iManager);
            appUsers oSponsor = appUsersHelper.objGetUserByUserId(oMainProjects.iSponsor);

            ////Load All Project Coach
            //List<appUsers> lstLeanCoach = appUsersHelper.lstGetLeanUsersByRole((int)appUsersLeanRoles.userRole.LeanCoach);
            //foreach (appUsers oLeanCoach in lstLeanCoach)
            //{
            //    coach.thisDropDownList.Items.Add(new ListItem(oLeanCoach.m_sFullName, oLeanCoach.m_iUserId.ToString()));
            //}

            sponsor.thisDropDownList.Items.Add(new ListItem(oSponsor.m_sFullName, oSponsor.m_iUserId.ToString()));
            //coach.thisDropDownList.Items.Add(new ListItem(oCoach.m_sFullName, oCoach.m_iUserId.ToString()));
            manager.thisDropDownList.Items.Add(new ListItem(oManager.m_sFullName, oManager.m_iUserId.ToString()));
            champion.thisDropDownList.Items.Add(new ListItem(oChampion.m_sFullName, oChampion.m_iUserId.ToString()));

            champion.thisDropDownList.SelectedValue = oMainProjects.iChampion.ToString();
            //coach.thisDropDownList.SelectedValue = oMainProjects.iCoach.ToString();
            manager.thisDropDownList.SelectedValue = oMainProjects.iManager.ToString();
            sponsor.thisDropDownList.SelectedValue = oMainProjects.iSponsor.ToString();

            ddlDept.SelectedValue = oMainProjects.iDept.ToString();
            ddlFunction.SelectedValue = oMainProjects.iFunction.ToString();
            ddlProjType.SelectedValue = oMainProjects.iType.ToString();
            ddlYear.SelectedValue = oMainProjects.iYear.ToString();
            txtBuzCase.Text = oMainProjects.sBusinessCase;
            txtComments.Text = oMainProjects.sComments;
            txtGoals.Text = oMainProjects.sGoals;
            txtInScope.Text = oMainProjects.sInScope;
            txtOpportunity.Text = oMainProjects.sOpportunity;
            txtOutScope.Text = oMainProjects.sOutScope;
            txtPotential.Text = oMainProjects.sPotentialBlokers;
            txtTitle.Text = oMainProjects.sTitle;

            //Potential Benefits
            txtCostReduction.Text = oMainProjects.sCostReduction;
            txtCTR.Text = oMainProjects.sCTReduction;
            txtProdEnhancmt.Text = oMainProjects.sProductionBarrel;
            txtNumber.Text = oMainProjects.sNumber;
            txtBenefit.Text = oMainProjects.sBenefits;
            txtPotentialBenftComments.Text = oMainProjects.sPotentialBenftComments;

            lblIdentifyPerc.Text = oIdentifyHelper.IdentifyWorkDoneByProject(oMainProjects.lProjectId).ToString();
            lblEliminatePerc.Text = oEliminateHelper.EliminateWorkDoneByProject(oMainProjects.lProjectId).ToString();
            lblSustainPerc.Text = oSustainHelper.SustainWorkDoneByProject(oMainProjects.lProjectId).ToString();

            IdentifyStartDate.setDate(oMainProjects.dtIdentifySD.ToString("dd/MM/yyyy"));
            IdentifyEndDate.setDate(oMainProjects.dtIdentifyED.ToString("dd/MM/yyyy"));
            EliminateStartDate.setDate(oMainProjects.dtEliminateSD.ToString("dd/MM/yyyy"));
            EliminateEndDate.setDate(oMainProjects.dtEliminateED.ToString("dd/MM/yyyy"));
            SustainStartDate.setDate(oMainProjects.dtSustainSD.ToString("dd/MM/yyyy"));
            SustainEndDate.setDate(oMainProjects.dtSustainED.ToString("dd/MM/yyyy"));

            getTeamMembers(lProjectId);
            getDRBMembers(lProjectId);
            getProjectLeanCoaches(lProjectId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Project Governor
            oMainProjects.iChampion = int.Parse(champion.thisDropDownList.SelectedValue);
            //oMainProjects.iCoach = int.Parse(coach.thisDropDownList.SelectedValue);
            oMainProjects.iManager = int.Parse(manager.thisDropDownList.SelectedValue);
            oMainProjects.iSponsor = int.Parse(sponsor.thisDropDownList.SelectedValue);

            //Project Charter Header
            oMainProjects.sTitle = txtTitle.Text;
            oMainProjects.iDept = int.Parse(ddlDept.SelectedValue);
            oMainProjects.iFunction = int.Parse(ddlFunction.SelectedValue);
            oMainProjects.iType = int.Parse(ddlProjType.SelectedValue);
            oMainProjects.iYear = int.Parse(ddlYear.SelectedValue);

            oMainProjects.sBusinessCase = txtBuzCase.Text;
            oMainProjects.sComments = txtComments.Text;
            oMainProjects.sGoals = txtGoals.Text;
            oMainProjects.sInScope = txtInScope.Text;
            oMainProjects.sOpportunity = txtOpportunity.Text;
            oMainProjects.sOutScope = txtOutScope.Text;
            oMainProjects.sPotentialBlokers = txtPotential.Text;

            //Potential Benefit Fields
            oMainProjects.sCostReduction = txtCostReduction.Text;
            oMainProjects.sCTReduction = txtCTR.Text;
            oMainProjects.sNumber = txtNumber.Text;
            oMainProjects.sProductionBarrel = txtProdEnhancmt.Text;
            oMainProjects.sBenefits = txtBenefit.Text;
            oMainProjects.sPotentialBenftComments = txtPotentialBenftComments.Text;

            //Project Status
            oMainProjects.dtIdentifySD = IdentifyStartDate.dtSelectedDate;
            oMainProjects.dtIdentifyED = IdentifyEndDate.dtSelectedDate;
            oMainProjects.dtEliminateSD = EliminateStartDate.dtSelectedDate;
            oMainProjects.dtEliminateED = EliminateEndDate.dtSelectedDate;
            oMainProjects.dtSustainSD = SustainStartDate.dtSelectedDate;
            oMainProjects.dtSustainED = SustainEndDate.dtSelectedDate;

            //oMainProjects.iFocalPointId = oSessnx.getOnlineUser.m_iUserId; Not needed here. Only required while submitting the project, can be changed when handing over to another person
            long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
            oMainProjects.lProjectId = lProjectId;

            oLeanProjectDetails1.Init_Control(oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId));

            bool bRet = oMainProjectHelper.UpdateLeanProject(oMainProjects);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Project Successfully updated!!!");
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Project not updated!!!");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }


    private void getTeamMembers(long lProjectId)
    {
        grdView.DataSource = oMainProjectHelper.dtGetProjectTeamMembers(lProjectId);
        grdView.DataBind();
        
    }
    private void getDRBMembers(long lProjectId)
    {
        grdViewDRB.DataSource = oMainProjectHelper.dtGetProjectDRBMembers(lProjectId);
        grdViewDRB.DataBind();

    }
    private void getProjectLeanCoaches(long lProjectId)
    {
        grdViewPrjCoach.DataSource = oMainProjectHelper.dtGetProjectProjectCoach(lProjectId);
        grdViewPrjCoach.DataBind();
    }

    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lProjectId = long.Parse(grdView.DataKeys[e.RowIndex].Values[0].ToString());

        Label lblTeamMember = (Label)grdView.Rows[e.RowIndex].FindControl("lblTeamMember");
        long lTeamId = long.Parse(lblTeamMember.Attributes["IDTEAM"].ToString());

        oMainProjectHelper.deleteProjectTeamMember(lTeamId);
        getTeamMembers(lProjectId);
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ProjectTeamMembers oProjectTeamMembers = new ProjectTeamMembers();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        if (e.CommandName.Equals("Insert"))
        {
            ASP.usercontrols_userfinder_search4localuser2_ascx ddlTeamMember = (ASP.usercontrols_userfinder_search4localuser2_ascx)grdView.FooterRow.FindControl("ddlTeamMember");
            oProjectTeamMembers.lProjectId = lProjectId;
            oProjectTeamMembers.iUserId = int.Parse(ddlTeamMember.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectTeamMember(oProjectTeamMembers);
            getTeamMembers(lProjectId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

            ASP.usercontrols_userfinder_search4localuser2_ascx ddlTeamMember = (ASP.usercontrols_userfinder_search4localuser2_ascx)emptyRow.FindControl("ddlTeamMember");
            oProjectTeamMembers.lProjectId = lProjectId;
            oProjectTeamMembers.iUserId = int.Parse(ddlTeamMember.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectTeamMember(oProjectTeamMembers);

            //if (Convert.ToString(((TextBox)emptyRow.FindControl("activityDescTextBox")).Text) != "")
            //{
            //    ActivityTimeLine.createActivityTimeLine(iActivityInfo, eTimeLine);
            //}
            //else
            //{
            //    ajaxWebExtension.showJscriptAlertCx(Page, this, "Activity Description is required.");
            //}

            getTeamMembers(lProjectId);
        }
    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grdView_Init(object sender, EventArgs e)
    {
       
    }
    protected void grdView_DataBinding(object sender, EventArgs e)
    {
        
    }

    #region DRB Members
    protected void grdViewDRB_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lProjectId = long.Parse(grdViewDRB.DataKeys[e.RowIndex].Values[0].ToString());

        Label lblDRBMember = (Label)grdViewDRB.Rows[e.RowIndex].FindControl("lblDRBMember"); //lblDRBMember
        long lDrbId = long.Parse(lblDRBMember.Attributes["IDDRB"].ToString());

        oMainProjectHelper.deleteProjectDRBMember(lDrbId);
        getDRBMembers(lProjectId);
    }

    protected void grdViewDRB_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ProjectDrbMembers oProjectDrbMembers = new ProjectDrbMembers();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        if (e.CommandName.Equals("Insert"))
        {
            ASP.usercontrols_userfinder_search4localuser2_ascx ddlDRBMember = (ASP.usercontrols_userfinder_search4localuser2_ascx)grdViewDRB.FooterRow.FindControl("ddlDRBMember");
            oProjectDrbMembers.lProjectId = lProjectId;
            oProjectDrbMembers.iUserId = int.Parse(ddlDRBMember.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectDrbMember(oProjectDrbMembers);
            getDRBMembers(lProjectId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdViewDRB.Controls[0].Controls[0] as GridViewRow;

            ASP.usercontrols_userfinder_search4localuser2_ascx ddlDRBMember = (ASP.usercontrols_userfinder_search4localuser2_ascx)emptyRow.FindControl("ddlDRBMember");
            oProjectDrbMembers.lProjectId = lProjectId;
            oProjectDrbMembers.iUserId = int.Parse(ddlDRBMember.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectDrbMember(oProjectDrbMembers);
            getDRBMembers(lProjectId);
        }
    }

    protected void grdViewDRB_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewDRB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void grdViewDRB_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdViewDRB_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void grdViewDRB_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grdViewDRB_Init(object sender, EventArgs e)
    {

    }
    protected void grdViewDRB_DataBinding(object sender, EventArgs e)
    {

    }

    #endregion

    #region Project Coaches

    protected void grdViewPrjCoach_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lProjectId = long.Parse(grdViewPrjCoach.DataKeys[e.RowIndex].Values[0].ToString());

        Label lblCoach = (Label)grdViewPrjCoach.Rows[e.RowIndex].FindControl("lblCoach");
        long lCoachId = long.Parse(lblCoach.Attributes["IDCOACH"].ToString());

        oMainProjectHelper.deleteProjectCoach(lCoachId);
        getProjectLeanCoaches(lProjectId);
    }

    protected void grdViewPrjCoach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ProjectCoaches oProjectCoaches = new ProjectCoaches();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        if (e.CommandName.Equals("Insert"))
        {
            ASP.usercontrols_userfinder_search4localuser2_ascx ddlCoach = (ASP.usercontrols_userfinder_search4localuser2_ascx)grdViewPrjCoach.FooterRow.FindControl("ddlCoach");
            oProjectCoaches.lProjectId = lProjectId;
            oProjectCoaches.iUserId = int.Parse(ddlCoach.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectCoach(oProjectCoaches);
            getProjectLeanCoaches(lProjectId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            GridViewRow emptyRow = grdViewPrjCoach.Controls[0].Controls[0] as GridViewRow;

            ASP.usercontrols_userfinder_search4localuser2_ascx ddlCoach = (ASP.usercontrols_userfinder_search4localuser2_ascx)emptyRow.FindControl("ddlCoach");
            oProjectCoaches.lProjectId = lProjectId;
            oProjectCoaches.iUserId = int.Parse(ddlCoach.thisDropDownList.SelectedValue);

            oMainProjectHelper.AddProjectCoach(oProjectCoaches);
            getProjectLeanCoaches(lProjectId);
        }
    }

    protected void grdViewPrjCoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewPrjCoach_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void grdViewPrjCoach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //ASP.usercontrols_userfinder_search4localuser2_ascx ddlCoach = (ASP.usercontrols_userfinder_search4localuser2_ascx)grdViewPrjCoach.FooterRow.FindControl("ddlCoach");
        //ddlCoach.editMode();
    }
    protected void grdViewPrjCoach_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void grdViewPrjCoach_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grdViewPrjCoach_Init(object sender, EventArgs e)
    {

    }
    protected void grdViewPrjCoach_DataBinding(object sender, EventArgs e)
    {

    }
    #endregion
}