using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_BONGACCP_Default : aspnetPage
{
    CommitmentsMgt o = new CommitmentsMgt();
    ActivityDetailsMgt oMgt = new ActivityDetailsMgt();
    ApprovalDecisionMgt oApproval = new ApprovalDecisionMgt();

    protected void Page_Init(object sender, EventArgs e)
    {
        //List<ApprovalDecision> oLst = oApproval.lstGetApprovalDecisions();
        //foreach (var listItem in oLst.Select(r => new ListItem(r.m_sDecision, r.m_iApprovalId.ToString())))
        //    ddlApprovalDecision.Items.Add(listItem);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadDataForRadGrid1();
        //if (!IsPostBack)
        //{

        //}
    }

    protected void ApprovalDecisionChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (ddlApprovalDecision.SelectedItem.Text == "ALL")
        //    {
        //        List<Commitments> olst = o.lstCommitments();
        //        o.ExporttoExcel(olst);
        //    }
        //    else
        //    {
        //        int iApprovalId = int.Parse(ddlApprovalDecision.SelectedValue);
        //        List<Commitments> olst = o.lstCommitmentsByApprovalDecision(iApprovalId);
        //        o.ExporttoExcel(olst);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    appMonitor.logAppExceptions(ex);
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }

    //protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    //{
    //    LoadDataForRadGrid1();
    //}

    //protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
    //{
    //    LoadDataForRadGrid1();
    //}

    //protected void RadGrid1_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
    //{
    //    LoadDataForRadGrid1();
    //}

    //private void LoadDataForRadGrid1()
    //{
    //    RadGrid1.DataSource = o.dtGetCommitments();
    //}

    
}