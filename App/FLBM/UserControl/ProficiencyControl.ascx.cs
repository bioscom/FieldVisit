using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_UserControl_ProficiencyControl : System.Web.UI.UserControl
{
    Proficiency oProficiency = new Proficiency();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init(object sender, EventArgs e)
    {
        //Get Proficiencies
        
        grdGridView.DataSource = oProficiency.DtGetProficiencies();
        grdGridView.DataBind();
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //oProficiency.
    }
}