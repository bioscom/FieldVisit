using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_ApprovalReview : aspnetPage
{
    BI500ApprovalHelper oBI500ApprovalHelper = new BI500ApprovalHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        oRequestsPendingMyApproval.LoadBIPendingMyApprovalSupport(oSessnx.getOnlineUser);
        //oPndgRqst1.LoadBIPendingMyApprovalSupport(oSessnx.getOnlineUser);
        oAprdgRqst1.LoadBIRequestsIApprovedOrSupported(oSessnx.getOnlineUser);
        //oAprdgRqst1.LoadBIRequestsISupported(oSessnx.getOnlineUser);
    }
}