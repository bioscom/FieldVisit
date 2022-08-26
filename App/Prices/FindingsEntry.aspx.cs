using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Prices_FindingsEntry : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["lRecommendId"]))
            {
                long lRecommendId = long.Parse(Request.QueryString["lRecommendId"]);

                RetrieveRecord(long.Parse(Request.QueryString["lRecommendId"]));
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bRet = false;
        if (string.IsNullOrEmpty(Request.QueryString["lRecommendId"]))
        {
            bRet = Save();
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Successfully submitted.");
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Not Successfully submitted, try again later!!!");
            }
        }
        else
        {
            long lRecommendId = long.Parse(Request.QueryString["lRecommendId"]);
            bRet = Update(lRecommendId);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Successfully updated.");
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Not Successfully updated, try again later!!!");
            }
        }

            
        //{
        //    ajaxWebExtension.showJscriptAlert(Page, this, "Findings and Recommendations successfully submitted!!!");
        //}
    }

    private void RetrieveRecord(long lRecommendId)
    {
        FindingsRecomendations o = FindingsRecomendationsHelper.objGetRecommendationById(lRecommendId);

        txtComments.Text = o.sComments;
        txtIssuesDescription.Text = o.sIssueDesc;
        txtMaterialDescription.Text = o.sMaterialDescription;
        txtMaterialNum.Text = o.sMaterialCode;
        txtNewPrice.Text = o.dNewPrice.ToString();
        txtOldPrice.Text = o.dOldPrice.ToString();
        txtPONum.Text = o.sPONumber;
        txtQty.Text = o.iQty.ToString();
        txtRecommendations.Text = o.sRecommendation;
    }

    private bool Save()
    {
        bool bRet = FindingsRecomendationsHelper.InsertRecommentdation(txtMaterialNum.Text, txtMaterialDescription.Text, txtPONum.Text, decimal.Parse(txtOldPrice.Text), decimal.Parse(txtNewPrice.Text),
            int.Parse(txtQty.Text), txtIssuesDescription.Text, txtComments.Text, txtRecommendations.Text, oSessnx.getOnlineUser.m_iUserId);

        return bRet;
    }


    private bool Update(long lRecommendId)
    {
        bool bRet = FindingsRecomendationsHelper.UpdateRecommentdation(lRecommendId, txtMaterialNum.Text, txtMaterialDescription.Text, txtPONum.Text, decimal.Parse(txtOldPrice.Text), decimal.Parse(txtNewPrice.Text),
            int.Parse(txtQty.Text), txtIssuesDescription.Text, txtComments.Text, txtRecommendations.Text, oSessnx.getOnlineUser.m_iUserId);

        return bRet;
    }

}