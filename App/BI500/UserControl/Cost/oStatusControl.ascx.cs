using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_UserControl_Cost_oStatusControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        ddlStatus.Items.Add(new ListItem("Select Status...", ("-1")));
        ddlStatus.Items.Add(new ListItem(CadenceStatus.status(CadenceStatus.ProjStatus.New), ((int) CadenceStatus.ProjStatus.New).ToString()));
        ddlStatus.Items.Add(new ListItem(CadenceStatus.status(CadenceStatus.ProjStatus.OnTrack), ((int) CadenceStatus.ProjStatus.OnTrack).ToString()));
        ddlStatus.Items.Add(new ListItem(CadenceStatus.status(CadenceStatus.ProjStatus.AtRisk), ((int) CadenceStatus.ProjStatus.AtRisk).ToString()));
        ddlStatus.Items.Add(new ListItem(CadenceStatus.status(CadenceStatus.ProjStatus.Delayed), ((int) CadenceStatus.ProjStatus.Delayed).ToString()));
        ddlStatus.Items.Add(new ListItem(CadenceStatus.status(CadenceStatus.ProjStatus.Completed), ((int) CadenceStatus.ProjStatus.Completed).ToString()));
    }

    public DropDownList thisDropDown
    {
        get
        {
            return ddlStatus;
        }
    }

}