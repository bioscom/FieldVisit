using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FieldVisit_Forms_MyRequets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pendingFieldVisitRequests1.InitPage();
        approvedFieldVisitRequests1.InitPage();

        MyApprovedPECRequests1.InitPage();
        MyPecRequests1.InitPage();
    }
}