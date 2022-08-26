using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class App_IDD_UserControl_oIDDProgressReport : aspnetUserControl
{
    EIdd.IDDRequestProgressReport o = new EIdd.IDDRequestProgressReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadControls();
    }

    private void LoadControls()
    {
        var item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.ContactVMIDDLead);
        item.Value = ((int) (EIdd.StageEnums.IddStage.ContactVMIDDLead)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Deadlocked);
        item.Value = ((int) (EIdd.StageEnums.IddStage.Deadlocked)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Expired);
        item.Value = ((int) (EIdd.StageEnums.IddStage.Expired)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.FinalBlacklisted);
        item.Value = ((int) (EIdd.StageEnums.IddStage.FinalBlacklisted)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.GIscreened);
        item.Value = ((int) (EIdd.StageEnums.IddStage.GIscreened)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Interim);
        item.Value = ((int) (EIdd.StageEnums.IddStage.Interim)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.MitigationOngoing);
        item.Value = ((int) (EIdd.StageEnums.IddStage.MitigationOngoing)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments);
        item.Value = ((int) (EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Processinitiated);
        item.Value = ((int) (EIdd.StageEnums.IddStage.Processinitiated)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.SiteVisitOngoing);
        item.Value = ((int) (EIdd.StageEnums.IddStage.SiteVisitOngoing)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();

        item = new RadComboBoxItem();
        item.Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.UndergoingGSSscreening);
        item.Value = ((int) (EIdd.StageEnums.IddStage.UndergoingGSSscreening)).ToString();
        ddlStatusFilter.Items.Add(item);
        item.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var rpt = new EIdd.RequestProgressReport();

        rpt.m_dDateComment = DateTime.Today.Date;
        rpt.m_iAnalystId = oSessnx.getOnlineUser.m_iUserId;
        rpt.m_iRequestId = 1;
        rpt.m_iStatus = int.Parse(ddlStatusFilter.SelectedValue);


        o.AddComment(rpt);
    }
}