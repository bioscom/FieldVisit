using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FieldVisit_Forms_FieldVisit_Approvers_oRejectedFieldVisitRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fieldVisitRequestsPendingMyApproval1.RejectedRequests();
    }
}