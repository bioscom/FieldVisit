using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_CostReductionMyIdeas : System.Web.UI.Page
{
    BenefitsMgt oBnft = new BenefitsMgt();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    BI500RequestHelper oBI500RequestHelper = new BI500RequestHelper();
    CostReductionRequest o = new CostReductionRequest();
    BITeams oT = new BITeams();
    BIDepartments oD = new BIDepartments();

    protected void Page_Load(object sender, EventArgs e)
    {
        Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
        if (!IsPostBack)
        {
            
        }
    }
    protected void Wizard1_PreRender(object sender, EventArgs e)
    {
        Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
        SideBarList.DataSource = Wizard1.WizardSteps;
        SideBarList.DataBind();
    }
    protected string GetClassForWizardStep(object wizardStep)
    {
        WizardStep step = wizardStep as WizardStep;

        if (step == null)
        {
            return "";
        }
        int stepIndex = Wizard1.WizardSteps.IndexOf(step);

        if (stepIndex < Wizard1.ActiveStepIndex)
        {
            return "prevStep";
        }
        else if (stepIndex > Wizard1.ActiveStepIndex)
        {
            return "nextStep";
        }
        else
        {
            return "currentStep";
        }
    }

    protected void OnFinish(object sender, WizardNavigationEventArgs e)
    {
        WizardStepType t = Wizard1.WizardSteps[e.NextStepIndex].StepType;
        if (t == WizardStepType.Finish)
        {
            //Wizard1.Visible = false;
            //btnstart.Visible = true;
        }
    }

    protected void Step_Click(object sender, EventArgs e)
    {
        LinkButton btnStep = (LinkButton)sender;
        string id = btnStep.Text;

        WizardStepBase Pending = (WizardStepBase)Wizard1.FindControl("Pending");
        WizardStepBase Approved = (WizardStepBase)Wizard1.FindControl("Approved");
        WizardStepBase Rejected = (WizardStepBase)Wizard1.FindControl("Rejected");
        WizardStepBase RequestDetails = (WizardStepBase)Wizard1.FindControl("RequestDetails");

        if (btnStep.CssClass == "prevStep" || btnStep.CssClass == "nextStep" || btnStep.CssClass == "currentStep")
        {
            switch (id)
            {
                case "My Pending Improvement Ideas": Wizard1.MoveTo(Pending); break;
                case "My Approved Improvement Ideas": Wizard1.MoveTo(Approved); break;
                case "My Rejected Improvement Ideas": Wizard1.MoveTo(Rejected); break;
                case "Project Progress": ajaxWebExtension.showJscriptAlert(Page, this, "Click any of the previous tabs, Click on View Progress... against any of the items you want to view Progress Report."); break;
                default: Wizard1.MoveTo(Pending); break;
            }
        }
    }

}