using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_Benefit : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProjectId"] != null)
            {
                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);

                oLeanProjectDetails1.Init_Control(oMainProject);
                BenefitActual.Init_Control(lProjectId);

                if (Request.QueryString["VIW"] == "V")
                {
                    Panel pnlBenefitActual = (Panel)BenefitActual.FindControl("bntActual");
                    pnlBenefitActual.Visible = false;
                }
            }
        }
    }
}