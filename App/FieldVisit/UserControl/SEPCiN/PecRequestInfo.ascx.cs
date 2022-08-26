using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_SEPCiN_PecRequestInfo : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(long iActivityInfoId)
    {
        ActivityInfo PECRequest = ActivityInfo.objGetActivityInfoByActivityId(iActivityInfoId);

        activityIDLabel.Text = Encoder.HtmlEncode(PECRequest.m_sActivityId);
        taskDescriptionLabel.Text = Encoder.HtmlEncode(PECRequest.m_sActivityDescription);
        fieldLabel.Text = Encoder.HtmlEncode(PECRequest.eFacility.m_sFacility);
        districtLabel.Text = Encoder.HtmlEncode(PECRequest.eFacility.eDistrict.m_sDistrict);
        superintendentLabel.Text = Encoder.HtmlEncode(PECRequest.eFacility.eSuperintendent.m_sSuperintendent);
        justificationLabel.Text = Encoder.HtmlEncode(PECRequest.m_sJustification);
        initiatorLabel.Text = Encoder.HtmlEncode(PECRequest.eInitiator.m_sFullName);
    }
}