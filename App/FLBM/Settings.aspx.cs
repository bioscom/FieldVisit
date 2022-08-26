using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnProficiency_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 0;
    }
    protected void btnGroupings_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 1;
    }
    protected void btnAssessment_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 2;
    }
    protected void btnChecklist_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 3;
    }

    protected void btnAssessorMngt_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 4;
    }

    protected void btnChecklistRightt_Click(object sender, EventArgs e)
    {
        FormMultiView.ActiveViewIndex = 5;
    }
}