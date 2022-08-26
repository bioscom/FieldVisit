using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MyInitiativesTreeView : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control()
    {
        //Initiative oInitiative = new Initiative();
        //System.Data.DataSet ds = oInitiative.dsGetInitiativeByUserId(oSessnx.getOnlineUser.m_iUserId);
        //BusInitMgt.Initiatives(BIXmlDS, ds);
    }
    
    protected void BusinessInitLinkButton_Click(object sender, EventArgs e)
    {
        Init_Control();
    }
    protected void newInitBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Forms/Default.aspx?xMod=Nor");
    }
}