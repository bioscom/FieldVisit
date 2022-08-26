using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_SEPCiN_MyRequests : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        //approvedRequestLinkButton.Text = ActivityInfo.dtGetMyApprovedActivityInfo(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
        approvedRequestLinkButton.Text = ActivityInfo.dtGetMyApprovedPEC(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
        pendingRequestsLnk.Text = ActivityInfo.dtGetActivityInfoByOriginator(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
        deletedLinkButton.Text = ActivityInfo.dtGetDeletedActivityInfoByOriginator(oSessnx.getOnlineUser.m_iUserId).Rows.Count.ToString();
    }
}
