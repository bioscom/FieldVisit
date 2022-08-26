using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_NewLeanProject : aspnetPage
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    MainProjects oMainProjects = new MainProjects();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    Department xDepartment = new Department();
    LkUpProjectType xLkUpProjectType = new LkUpProjectType();

    appUsersHelper oappUsersHelper = new appUsersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersLeanRoles.userRole.Administrator.ToString(), appUsersLeanRoles.userRole.LeanCoach.ToString(), appUsersLeanRoles.userRole.User.ToString() };
            appUsersLeanRoles oAccess = new appUsersLeanRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersLeanRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdLean);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");

        if (!IsPostBack)
        {
            sponsor.ErrorMssg("Project Sponsor is required. Please, select N/A if Sponsor not found, can be updated later.");
            manager.ErrorMssg("Project Manager is required. Please, select N/A if Manager not found, can be updated later.");
            //coach.ErrorMssg("Project Coach is required. Please, select N/A if Coach not found, can be updated later.");
            champion.ErrorMssg("Project Champion is required. Please, select N/A if Champion not found, can be updated later.");

            IdentifyStartDate.ErrorMssg("Identify Start Date is required.");
            IdentifyEndDate.ErrorMssg("Identify End Date is required.");

            EliminateStartDate.ErrorMssg("Eliminate Start Date is required.");
            EliminateEndDate.ErrorMssg("Eliminate End Date is required.");

            SustainStartDate.ErrorMssg("Sustain Start Date is required.");
            SustainEndDate.ErrorMssg("Sustain End Date is required.");

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
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Project Charter Header
        oMainProjects.sTitle = txtTitle.Text;
        oMainProjects.iType = int.Parse(ddlProjType.SelectedValue);
        oMainProjects.iYear = int.Parse(ddlYear.SelectedValue);
        oMainProjects.iDept = int.Parse(ddlDept.SelectedValue);
        oMainProjects.iFunction = int.Parse(ddlFunction.SelectedValue);

        //Project Governor
        oMainProjects.iChampion = int.Parse(champion._SelectedValue);
        //oMainProjects.iCoach = int.Parse(coach._SelectedValue); //appUsersHelper.objGetAppUser(coach.selectedUserDetails.m_sUserMail).m_iUserId;
        oMainProjects.iManager = int.Parse(manager._SelectedValue); // appUsersHelper.objGetAppUser(manager.selectedUserDetails.m_sUserMail).m_iUserId;
        oMainProjects.iSponsor = int.Parse(sponsor._SelectedValue); // appUsersHelper.objGetAppUser(sponsor.selectedUserDetails.m_sUserMail).m_iUserId;
        
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
        
        oMainProjects.iFocalPointId = oSessnx.getOnlineUser.m_iUserId;  //This is the owner of the project, he/she is also the Project Manager  
        
        bool bRet = oMainProjectHelper.AddLeanProject(oMainProjects);
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Project Successfully created!!!");
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Project not created!!!");
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
}