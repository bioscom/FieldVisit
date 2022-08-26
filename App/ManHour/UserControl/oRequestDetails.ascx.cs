using System;
using Microsoft.Security.Application;

public partial class UserControl_oRequestDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Init_Control(CostReductionRequest oBI500Request)
    {
        //lblRequestNumber.Text = Encoder.HtmlEncode(oBI500Request.m_sRequestNumber);
        //lblDateInit.Text = Encoder.HtmlEncode(oBI500Request.m_sDateCreated);
        //lblCategory.Text = Encoder.HtmlEncode(Category.objGetCategoryByCatId(oBI500Request.m_iCategoryId).m_sCategory);
        //lblFacility.Text = Encoder.HtmlEncode(Facility.objGetFacilityById(oBI500Request.m_iFacilityId).m_sFacility);

        //lblStartDate.Text = Encoder.HtmlEncode(oBI500Request.m_sStartDate);
        //lblStartTime.Text = Encoder.HtmlEncode(oBI500Request.m_sStartTime);
        //lblEndDate.Text = Encoder.HtmlEncode(oBI500Request.m_sEndDate);
        //lblEndTime.Text = Encoder.HtmlEncode(oBI500Request.m_sEndTime);

        //lblReason.Text = Encoder.HtmlEncode(oBI500Request.m_sReason);
        //lblJustification.Text = Encoder.HtmlEncode(oBI500Request.m_sJustification);
        //lblPostEvent.Text = Encoder.HtmlEncode(oBI500Request.m_sPostEvent);

        //lblInitiator.Text = Encoder.HtmlEncode(oappUsersHelper.objGetUserByUserID(oBI500Request.m_iUserId).m_sFullName);
    }
}