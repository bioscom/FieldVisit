using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class App_PDCC_UpdateMonthyPerformance : aspnetPage
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            ValidateNumeric();

            if (Request.QueryString["lOpCost"] != null)
            {
                long lOpCost = long.Parse(Request.QueryString["lOpCost"]);

                ActivityLogCntl1.InitPage();
                RetrieveData(lOpCost);

                //if(Request.QueryString["iMonth"] != null)
                //{
                //    int iMonth = int.Parse(Request.QueryString["iMonth"]);
                //    lblMonth.Text = OpportunityCostHelper.getMonth(iMonth);
                   
                //    ActivityLogCntl1.InitPage(iMonth);
                //    RetrieveData(lOpCost, iMonth);
                //}
                //else
                //{
                //    lblMonth.Text = OpportunityCostHelper.getMonth();
                //    ActivityLogCntl1.InitPage();
                //    RetrieveData(lOpCost, OpportunityCostHelper.getCurrentMonth());
                //}
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            OpportunityCost oOpportunityCost = new OpportunityCost
            {
                lOpCost = long.Parse(Request.QueryString["lOpCost"]),
                dActSavings = decimal.Parse(txtActSavings.Text),
                dPotSavings = decimal.Parse(txtPotSavings.Text),
                sComments = txtComment.Text,
                DtDateUpdated = DateTime.Today.Date,
                iLastUpdatedBy = oSessnx.getOnlineUser.m_iUserId
            };

            bRet = _opportunityCostHelper.UpdateOpportunityCost2(oOpportunityCost);

            //if (Request.QueryString["iMonth"] != null)
            //{
            //    int iMonth = int.Parse(Request.QueryString["iMonth"]);
            //    bRet = _opportunityCostHelper.UpdateOpportunityCost2(oOpportunityCost);
            //}
            //else
            //{
            //    bRet = _opportunityCostHelper.UpdateOpportunityCost2(oOpportunityCost);
            //}

            if (bRet)
            {
                ActivityLogCntl1.InitPage();
                //ActivityLogCntl1.InitPage();
                //if (Request.QueryString["iMonth"] != null)
                //{
                //    int iMonth = int.Parse(Request.QueryString["iMonth"]);
                //    ActivityLogCntl1.InitPage(iMonth);
                //}
                //else
                //{
                //    ActivityLogCntl1.InitPage();
                //}

                //Enter values into the Opportunity Cost log table
                //_opportunityCostHelper.CreateOpportunityCostLog(oOpportunityCost, oOpportunityCost.lOpCost);
                ajaxWebExtension.showJscriptAlert(Page, this, "Update successful!!!");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void RetrieveData(long lOpCost)
    {
        OpportunityCost oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostById(lOpCost);

        txtActSavings.Text = oOpportunityCost.dActSavings.ToString(CultureInfo.InvariantCulture);
        txtPotSavings.Text = oOpportunityCost.dPotSavings.ToString(CultureInfo.InvariantCulture);
        txtComment.Text = oOpportunityCost.sComments;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PDCC/OpportunityCostsChallenges.aspx");
    }

    private void ValidateNumeric()
    {
        //txtActSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event, " + txtActSavings.ClientID + ")");
        //txtPotSavings.Attributes.Add("onkeypress", "return isMoneyNumbKey(event, " + txtPotSavings.ClientID + ")");
        txtActSavings.Attributes.Add("onkeypress", "return isNumberKey(event)");
        txtPotSavings.Attributes.Add("onkeypress", "return isNumberKey(event)");
    }
}