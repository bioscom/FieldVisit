using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_IDD_Index : aspnetPage
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    EIdd.Analysts oAnal = new EIdd.Analysts();
    EIdd.Admins admin = new EIdd.Admins();   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
            EIdd.eIddUsers oa = oAnal.objGetAnalystByUserId(oSessnx.getOnlineUser.m_iUserId);
            System.Data.DataTable dt = admin.GetAdminByUserId(oSessnx.getOnlineUser.m_iUserId);

            if ((dt.Rows.Count == 0) && (oa.m_iUserId == 0) && (oCP.m_iUserId == 0))
            {
                Response.Redirect("~/App/IDD/Default.aspx");
            }
        }
    }
}