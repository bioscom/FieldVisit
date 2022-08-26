using System;

public partial class FlareWaiverRequestDetails : System.Web.UI.Page
{
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RequestId"] != null)
        {
            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
            oRequestDetails1.Init_Control(oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId));
        }
    }
}