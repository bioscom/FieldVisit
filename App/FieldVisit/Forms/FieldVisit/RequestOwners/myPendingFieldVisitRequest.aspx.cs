using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myPendingFieldVisitRequest : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pendingFieldVisitRequests1.InitPage();
            
            string message = "";

            if (Request.QueryString["Msg"] != null)
            {
                if (Request.QueryString["Msg"].ToString() == "xActSub")
                {
                    message = "Your field visit request successfully submitted and mail sent to Planner for approval. You will receive email as other approvals are received on your request.";
                }
                else if (Request.QueryString["Msg"].ToString() == "xActUpd")
                {
                    message = "Your field visit request successfully updated and mail sent to Planner for approval. You will receive email as other approvals are received on your request.";
                }
            }

            ajaxWebExtension.showJscriptAlert(Page, this, message);
        }
    }
}
