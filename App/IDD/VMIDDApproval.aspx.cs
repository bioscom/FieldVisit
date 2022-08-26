using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_IDD_VMIDDApproval : System.Web.UI.Page
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadAprovalOptions();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool bRet = false;
            long lRequestId = 0;

            if (string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
            {
                lRequestId = long.Parse(Request.QueryString["lRequestId"]);
                if (int.Parse(rdbApproved.SelectedValue) == (int) EIdd.CompletedEnums.CompletedStatus.Yes)
                {
                    //bRet = o.VMIDDLeadApproval(lRequestId, int.Parse(rdbApproved.SelectedValue),, int.Parse(btnLstStatus.SelectedValue), txtComments.Text);
                    //Send mail to Request initiator (i.e. Initiator), copy IDD Analyst that the IDD request has been approved.
                }

                ///if (bRet) ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                //else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
            }
        }
        catch(Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadAprovalOptions()
    {
        var item = new ButtonListItem();
        item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.Yes);
        item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.Yes).ToString();
        rdbApproved.Items.Add(item);

        item = new ButtonListItem();
        item.Text = EIdd.CompletedEnums.CompletedStatusDesc(EIdd.CompletedEnums.CompletedStatus.No);
        item.Value = ((int) EIdd.CompletedEnums.CompletedStatus.No).ToString();
        rdbApproved.Items.Add(item);
    }
}