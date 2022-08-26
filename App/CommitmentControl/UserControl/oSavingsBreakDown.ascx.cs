using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BONGACCP_UserControl_oSavingsBreakDown : System.Web.UI.UserControl
{
    CommitmentsMgt o = new CommitmentsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadDetailsByOuId(int iOuId)
    {
        try
        {
            List<Commitments> oLst = o.lstCommitmentsByOuId(iOuId);

            lblNoCommitment.Text = oLst.Count.ToString();
            lblApproved.Text = oLst.Where(t => t.eDecision.m_sDecision.Contains("APPROV")).ToList().Count().ToString();
            lblPending.Text = oLst.Where(t => t.eDecision.m_sDecision.Contains("TBD")).ToList().Count().ToString();

            lblCommitments.Text = "$" + stringRoutine.formatAsBankMoney(oLst.Sum(t => t.COMMITMENT));
            lblSavings.Text = "$" + stringRoutine.formatAsBankMoney(oLst.Sum(t => t.SAVINGS));
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}