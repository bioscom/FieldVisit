using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;

public partial class App_IDD_UserControl_oDueDiligenceAuditTrail : System.Web.UI.UserControl
{
    EIdd.IDDRequestMgt o = new EIdd.IDDRequestMgt();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void ViewAuditTrail(long lRequestId)
    {
        RequestIdHF.Value = lRequestId.ToString();
        LoadDataForgrdView(lRequestId);
    }

    private void LoadDataForgrdView(long lRequestId)
    {
        System.Data.DataTable dt = o.GetAuditTrailByRequestId(lRequestId);
        grdView.DataSource = dt;
        grdView.Rebind();
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            if (!string.IsNullOrEmpty(RequestIdHF.Value))
            {
                long lRequestId = long.Parse(RequestIdHF.Value);
                (sender as RadGrid).DataSource = o.GetAuditTrailByRequestId(lRequestId);
            }
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lbl = e.Item.FindControl("numberLabel") as Label;
            if (lbl != null)
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

            var item = e.Item as GridDataItem;
            o.DueDiligenceAuditTrailStatusManager(item, "Remarks", 4);

            //if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.ContactVMIDDLead).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.ContactVMIDDLead);
            //    item.Cells[5].ForeColor = Color.Navy;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.Deadlocked).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Deadlocked);
            //    item.Cells[5].ForeColor = Color.Red;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.Expired).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Expired);
            //    item.Cells[5].ForeColor = Color.Red;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.FinalBlacklisted).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.FinalBlacklisted);
            //    item.Cells[5].ForeColor = Color.Black;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.GIscreened).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.GIscreened);
            //    item.Cells[5].ForeColor = Color.Green;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.Interim).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Interim);
            //    item.Cells[5].ForeColor = Color.Blue;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.MitigationOngoing).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.MitigationOngoing);
            //    item.Cells[5].ForeColor = Color.Brown;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.OutstandingStatutoryDocuments);
            //    item.Cells[5].ForeColor = Color.Red;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.Processinitiated).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.Processinitiated);
            //    item.Cells[5].ForeColor = Color.Chocolate;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.SiteVisitOngoing).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.SiteVisitOngoing);
            //    item.Cells[5].ForeColor = Color.Green;
            //}
            //else if (item.Cells[5].Text == ((int) EIdd.StageEnums.IddStage.UndergoingGSSscreening).ToString())
            //{
            //    item.Cells[5].Text = EIdd.StageEnums.IddStageDesc(EIdd.StageEnums.IddStage.UndergoingGSSscreening);
            //    item.Cells[5].ForeColor = Color.DarkGoldenrod;
            //}


            //if (item.Cells[4].Text == ((int) EIdd.ReportStatusEnums.VendorStatus.Amber).ToString())
            //{
            //    item.Cells[4].Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Amber);
            //    item.Cells[4].BackColor = Color.Gold;
            //}
            //else if (item.Cells[4].Text == ((int) EIdd.ReportStatusEnums.VendorStatus.Gray).ToString())
            //{
            //    item.Cells[4].Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Gray);
            //    item.Cells[4].BackColor = Color.Gray;
            //}
            //if (item.Cells[4].Text == ((int) EIdd.ReportStatusEnums.VendorStatus.Green).ToString())
            //{
            //    item.Cells[4].Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Green);
            //    item.Cells[4].BackColor = Color.Green;
            //}
            //if (item.Cells[4].Text == ((int) EIdd.ReportStatusEnums.VendorStatus.Purple).ToString())
            //{
            //    item.Cells[4].Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Purple);
            //    item.Cells[4].BackColor = Color.Purple;
            //}
            //if (item.Cells[4].Text == ((int) EIdd.ReportStatusEnums.VendorStatus.Red).ToString())
            //{
            //    item.Cells[4].Text = EIdd.ReportStatusEnums.VendorStatusDesc(EIdd.ReportStatusEnums.VendorStatus.Red);
            //    item.Cells[4].BackColor = Color.Red;
            //}
        }
    }
}