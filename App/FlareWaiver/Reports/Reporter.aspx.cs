using System;
using System.Collections.Generic;

public partial class App_FlareWaiver_Reports_Reporter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<int> iYears = FlareWaiverRpt.LstYearsExt();
            foreach (int iYear in iYears)
            {
                ddlYear.Items.Add(iYear.ToString());
            }

            cVerificationHeatMapHelper.getMonths(ddlMonthFrom);
            cVerificationHeatMapHelper.getMonths(ddlMonthTo);
        }
    }

    protected void btnRpt_Click(object sender, EventArgs e)
    {
        if ((int.Parse(ddlMonthTo.SelectedValue) - int.Parse(ddlMonthFrom.SelectedValue)) != 2)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Invalid Month range selection. Select on a quarterly basis.");
        }
        else
        {
            try
            {

                FlareApprovalHelper oApproval = new FlareApprovalHelper();
                FlareApproval oApp = new FlareApproval();


                List<FlareWaiver> LstApprovedReport = FlareWaiverRpt.LstGetApprovedNotApprovedByGmp((int) RequestStatusReporter.RequestStatusRpt.Approved, int.Parse(ddlYear.SelectedValue), (int) appUserRolesFlrWaiver.userRole.Approval);
                List<FlareWaiver> LstNotApprovedReport = FlareWaiverRpt.LstGetApprovedNotApprovedByGmp((int) RequestStatusReporter.RequestStatusRpt.NotApprovedByGMProduction, int.Parse(ddlYear.SelectedValue), (int) appUserRolesFlrWaiver.userRole.Approval);
                List<FlareWaiver> LstPendingLineRport = FlareWaiverRpt.LstGetPendingLineSupport((int) RequestStatusReporter.RequestStatusRpt.AwaitLineManagerSupport, int.Parse(ddlYear.SelectedValue));

                int iStartMonth = int.Parse(ddlMonthFrom.SelectedValue);
                int iNextMonth = ++iStartMonth;
                int iLastMonth = ++iNextMonth;

                int iGmApprovedStartMonth = 0;
                int iGmApprovedNextMonth = 0;
                int iGmApprovedLastMonth = 0;

                int iGmNtApprovedStartMonth = 0;
                int iGmNtApprovedNextMonth = 0;
                int iGmNtApprovedLastMonth = 0;

                int iLineStartMonth = 0;
                int iLineNextMonth = 0;
                int iLineLastMonth = 0;

                decimal iTotalVolApprovedMnt1 = 0;
                decimal iTotalVolApprovedMnt2 = 0;
                decimal iTotalVolApprovedMnt3 = 0;

                DateTime DateReviewed = new DateTime();

                foreach (var gmApproved in LstApprovedReport)
                {
                    oApp = oApproval.objGetFlareApprovalbyRequestRoleId(gmApproved.m_lRequestId, (int) appUserRolesFlrWaiver.userRole.Approval);

                    DateReviewed = (!string.IsNullOrEmpty(oApp.m_sDateReviewed))
                        ? DateTime.Parse(oApp.m_sDateReviewed)
                        : DateTime.Today.Date;

                    if (iStartMonth == DateReviewed.Month)
                    {
                        iGmApprovedStartMonth++;
                        iTotalVolApprovedMnt1 += gmApproved.m_sFlareVol;
                    }
                    else if (iNextMonth == DateReviewed.Month)
                    {
                        iGmApprovedNextMonth++;
                        iTotalVolApprovedMnt2 += gmApproved.m_sFlareVol;
                    }
                    else if (iLastMonth == DateReviewed.Month)
                    {
                        iGmApprovedLastMonth++;
                        iTotalVolApprovedMnt3 += gmApproved.m_sFlareVol;
                    }
                }

                foreach (var gmNotApproved in LstNotApprovedReport)
                {
                    DateReviewed = (!string.IsNullOrEmpty(oApp.m_sDateReviewed))
                        ? DateTime.Parse(oApp.m_sDateReviewed)
                        : DateTime.Today.Date;

                    oApp = oApproval.objGetFlareApprovalbyRequestRoleId(gmNotApproved.m_lRequestId, (int) appUserRolesFlrWaiver.userRole.Approval);

                    if (iStartMonth == DateReviewed.Month)
                    {
                        iGmNtApprovedStartMonth++;
                    }
                    else if (iNextMonth == DateReviewed.Month)
                    {
                        iGmNtApprovedNextMonth++;
                    }
                    else if (iLastMonth == DateReviewed.Month)
                    {
                        iGmNtApprovedLastMonth++;
                    }
                }

                foreach (var linePending in LstPendingLineRport)
                {
                    oApp = oApproval.objGetFlareApprovalbyRequestRoleId(linePending.m_lRequestId, (int) appUserRolesFlrWaiver.userRole.LineManager);

                    if (iStartMonth == DateTime.Parse(oApp.m_sDateReceived).Month)
                    {
                        iLineStartMonth++;
                    }
                    else if (iNextMonth == DateTime.Parse(oApp.m_sDateReceived).Month)
                    {
                        iLineNextMonth++;
                    }
                    else if (iLastMonth == DateTime.Parse(oApp.m_sDateReceived).Month)
                    {
                        iLineLastMonth++;
                    }
                }

                lbAprdMnt1.Text = iGmApprovedStartMonth.ToString();
                lbAprdMnt2.Text = iGmApprovedNextMonth.ToString();
                lbAprdMnt3.Text = iGmApprovedLastMonth.ToString();

                lbNtAprdMnt1.Text = iGmNtApprovedStartMonth.ToString();
                lbNtAprdMnt2.Text = iGmNtApprovedNextMonth.ToString();
                lbNtAprdMnt3.Text = iGmNtApprovedLastMonth.ToString();

                lbPndgMnt1.Text = iLineStartMonth.ToString();
                lbPndgMnt2.Text = iLineNextMonth.ToString();
                lbPndgMnt3.Text = iLineLastMonth.ToString();

                lbTotal1.Text = (iGmApprovedStartMonth + iGmNtApprovedStartMonth + iLineStartMonth).ToString();
                lbTotal2.Text = (iGmApprovedNextMonth + iGmNtApprovedNextMonth + iLineNextMonth).ToString();
                lbTotal3.Text = (iGmApprovedLastMonth + iGmNtApprovedLastMonth + iLineLastMonth).ToString();

                lbVolAppr1.Text = iTotalVolApprovedMnt1.ToString();
                lbVolAppr2.Text = iTotalVolApprovedMnt2.ToString();
                lbVolAppr3.Text = iTotalVolApprovedMnt3.ToString();

                lbVolAnalzd1.Text = Math.Round((iTotalVolApprovedMnt1/365), 2).ToString();
                lbVolAnalzd2.Text = Math.Round((iTotalVolApprovedMnt2/365), 2).ToString();
                lbVolAnalzd3.Text = Math.Round((iTotalVolApprovedMnt3/365), 2).ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }
}