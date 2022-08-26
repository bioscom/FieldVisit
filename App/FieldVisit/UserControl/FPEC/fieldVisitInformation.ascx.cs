using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_fieldVisitInformation : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage(long iActivity)
    {
        fieldVisitDetails visitDetails = fieldVisitDetails.objGetFieldVisitDetailsByActivityId(iActivity);

        activityIDLabel.Text = Encoder.HtmlEncode(visitDetails.m_sActivityId);
        taskDescriptionLabel.Text = Encoder.HtmlEncode(visitDetails.m_sTaskDescription);
        fromDateLabel.Text = Encoder.HtmlEncode(visitDetails.m_sDateFrom);
        toDateLabel.Text = Encoder.HtmlEncode(visitDetails.m_sDateTo);
        fieldLabel.Text = Encoder.HtmlEncode(visitDetails.eFacility.m_sFacility);
        acctToChargeLabel.Text = Encoder.HtmlEncode(visitDetails.m_sAccountToCharge);
        districtLabel.Text = Encoder.HtmlEncode(visitDetails.eFacility.eDistrict.m_sDistrict);
        superintendentLabel.Text = Encoder.HtmlEncode(visitDetails.eFacility.eSuperintendent.m_sSuperintendent);
        generalCommentsLabel.Text = Encoder.HtmlEncode(visitDetails.m_sGeneralComment);
    }
}