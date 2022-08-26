using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


public partial class App_IDD_UserControl_oCPFocalPoint : aspnetUserControl
{

    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    appUsersHelper hlp = new appUsersHelper();
    EIdd.Analysts anal = new EIdd.Analysts();
    //EIdd.IDDRequestDocsMgt oM = new EIdd.IDDRequestDocsMgt();
    //EIdd.LeadFocalPoint cppFP = new EIdd.LeadFocalPoint();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EIdd.eIddUsers oCP = o.CheckIfLogInUserIsCpFocalPoint(oSessnx.getOnlineUser.m_iUserId);
        if (oCP.m_iUserId != 0)
        {
            LoadActionOptions();
            LoadAnalysts();
        }
        else
        {
            LabelClose.Text = "<script type='text/javascript'>Close()</" + "script>";
        }
    }

    private void LoadAnalysts()
    {
        List<EIdd.eIddUsers> analysts = anal.lstGetAnalysts();

        foreach (var o in analysts)
        {
            var item = new RadComboBoxItem();
            item.Text = o.m_sFullName;
            item.Value = o.m_iUserId.ToString();

            ddlAnalyst.Items.Add(item);
            item.DataBind();
        }
    }

    protected void ddlAnalyst_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        var o = (RadComboBox) sender;
        EIdd.Utilities.Search(e.Text, o);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = 0;
            var button = (Button) sender;
            //var nesteditem = (GridNestedViewItem) button.NamingContainer;

            if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
            {
                lRequestId = long.Parse(Request.QueryString["lRequestId"]);
                //Update the IDD_Request Table

                if (string.IsNullOrEmpty(ddlAction.SelectedValue))
                {
                    ajaxWebExtension.showJscriptAlertCx(Page, this, "Please, select your decision.");
                }
                else
                {
                    if (ddlAction.SelectedValue == ((int) EIdd.StageEnums.IddStage.RequestRejected).ToString())
                    {
                        bool bRet = o.RequestRejected(lRequestId, oSessnx.getOnlineUser.m_iUserId, txtComment.Text);
                        if (bRet)
                        {
                            EIdd.RequestForIDD r = o.objGetRequestById(lRequestId);
                            var cCopy = new List<structUserMailIdx>();

                            //Get the Request Request initiator
                            structUserMailIdx contractHolder = hlp.objGetUserByUserID(r.m_iUserId).structUserIdx;
                            cCopy.Add(contractHolder);

                            //Copy Category Lead and Request initiator.
                            List<structUserMailIdx> catLeads = o.LstGetCategoryLeads(r);
                            foreach (structUserMailIdx catLead in catLeads)
                            {
                                cCopy.Add(catLead);
                            }

                            //Send Mail
                            var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
                            oSend.RequestRejected(r, contractHolder, cCopy, txtComment.Text);

                            //ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Successfully rejected!!!");
                        }

                        if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
                    }
                    else
                    {
                        bool bRet = o.AssignAnalyst(lRequestId, oSessnx.getOnlineUser.m_iUserId, int.Parse(ddlAnalyst.SelectedValue));
                        if (bRet)
                        {
                            EIdd.RequestForIDD r = o.objGetRequestById(lRequestId);
                            var cCopy = new List<structUserMailIdx>();

                            //Get the Analyst
                            structUserMailIdx toAnalyst = hlp.objGetUserByUserID(int.Parse(ddlAnalyst.SelectedValue)).structUserIdx;

                            //Get the Request Request initiator
                            structUserMailIdx contractHolder = hlp.objGetUserByUserID(r.m_iUserId).structUserIdx;
                            cCopy.Add(contractHolder);

                            //Copy Category Lead
                            List<structUserMailIdx> catLeads = o.LstGetCategoryLeads(r);
                            foreach (structUserMailIdx catLead in catLeads)
                            {
                                cCopy.Add(catLead);
                            }

                            //Send Mail
                            var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
                            oSend.AssignAnalystToRequest(r, toAnalyst, cCopy);

                            //ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Successful!!!");
                        }

                        if (bRet) Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                        else ajaxWebExtension.showJscriptAlertCx(Page, this, "Not Successful, try again later!!!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnRejected_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = 0;
            var button = (Button) sender;

            if (!string.IsNullOrEmpty(Request.QueryString["lRequestId"]))
            {
                lRequestId = long.Parse(Request.QueryString["lRequestId"]);

                //Update the IDD_Request Table 
                bool bRet = o.RequestRejected(lRequestId, oSessnx.getOnlineUser.m_iUserId, txtComment.Text);
                if (bRet)
                {
                    EIdd.RequestForIDD req = o.objGetRequestById(lRequestId);

                    //Get the Request initiator 
                    structUserMailIdx contractHolder = hlp.objGetUserByUserID(req.m_iUserId).structUserIdx;

                    //Copy Category Lead.
                    List<structUserMailIdx> temp = o.LstGetCategoryLeads(req);
                    List<structUserMailIdx> cCopy = (temp.Count != 0) ? temp : new List<structUserMailIdx>();

                    //Send Mail
                    var oSend = new SendMailIDD(oSessnx.getOnlineUser.structUserIdx);
                    oSend.RequestRejected(req, contractHolder, cCopy, txtComment.Text);

                    ajaxWebExtension.showJscriptAlertCx(Page, this, sMessage: "Notification for your rejection has been sent to Request initiator!!!");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadActionOptions()
    {
        var item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.IddAnalystProgression);
        item.Value = ((int) EIdd.StageEnums.IddStage.IddAnalystProgression).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.RequestRejected);
        item.Value = ((int) EIdd.StageEnums.IddStage.RequestRejected).ToString();
        ddlAction.Items.Add(item);
        item.DataBind();
    }
}