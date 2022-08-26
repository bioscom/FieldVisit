using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class App_FLBM_UserControl_GroupControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        Group oGroup = new Group();
        grdGridView.DataSource = oGroup.DtGetGroups();
        grdGridView.DataBind();
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Group oGroup = new Group();

        oGroup.sGroups = Encoder.HtmlEncode(txtGroup.Text);

        bool bRet = oGroup.Insert(oGroup);
        if(bRet)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Successful!!!");
        }
    }
}