using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_CostReductionStageGaters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStageGaters();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //int i = 0;
        try
        {
            //

            //int kount = revieweresCkbLst.Items.Count;
            //foreach (ListItem li in revieweresCkbLst.Items)
            //{
            //    if (li.Selected == false)
            //    {
            //        i++;
            //    }
            //}

            //if (i == kount)
            //{
            //    string sRet = "At least, a Business Improvement/Lean Team member must be selected before submit can be successful.";
            //    ajaxWebExtension.showJscriptAlert(Page, this, sRet);
            //}
            //else
            //{
            //    foreach (ListItem li in revieweresCkbLst.Items)
            //    {
            //        if (li.Selected == true)
            //        {
            //            //If the selected user has been inserted previously, don't insert again.
            //            bool bRet = BuzBILeanReviewers.dtGetBILeanReviewerByUserId(int.Parse(li.Value)).Rows.Count == 0;
            //            if (bRet)
            //            {
            //                BuzBILeanReviewers.Insert(int.Parse(li.Value));
            //            }
            //        }
            //    }

            bool bRet = BuzBILeanReviewers.dtGetCRStageGaterByUserId(int.Parse(Reviewers._SelectedValue)).Rows.Count == 0;
            if (bRet)
            {
                BuzBILeanReviewers.InsertCRStageGater(int.Parse(Reviewers._SelectedValue));
            }
            else
            {
                string sRet = "Selected user is already a member of Cost Improvement Stage Gate Managers.";
                ajaxWebExtension.showJscriptAlert(Page, this, sRet);
            }
            LoadStageGaters();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadStageGaters()
    {
        grdView.DataSource = BuzBILeanReviewers.dtGetCRStageGaters();
        grdView.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        int iUserId = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        bool success = BuzBILeanReviewers.RemoveFromStageGaters(iUserId);
        if (success)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User successfully removed from Cost Improvement Stage Gaters.");
            LoadStageGaters();
        }
    }
}