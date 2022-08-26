using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_CommitmentControl_UserControl_actForm : System.Web.UI.UserControl
{
    OUMgt o = new OUMgt();
    CommitmentsMgt oMgt = new CommitmentsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlSnepco.Visible = false;
            pnlSPDC.Visible = false;

            LoadControl();

            if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
            {
                long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);
                Commitments o = oMgt.objGetCommitmentById(lCommitmentId);
                ddlOU.SelectedValue = o.IDOU.ToString();

                //InputUpdateCommitmentDetails1.LoadDetails(lCommitmentId);
                //oDocsUpload.LoadDocuments(lCommitmentId);
            }

            //else if (!string.IsNullOrEmpty(CommitmentHF.Value))
            //{
            //    long lCommitmentId = long.Parse(CommitmentHF.Value);
            //    Commitments o = oMgt.objGetCommitmentById(lCommitmentId);
            //    ddlOU.SelectedValue = o.IDOU.ToString();
            //}

            //Subscribe to the event of the UserControl, to receive notification of its execution
        }
        Snepco1.GetDataFromChild += new App_CommitmentControl_UserControl_Snepco.ChildControlDelegate(Snepco1_GetDataFromChild);
        ShowHide();
    }

    void Snepco1_GetDataFromChild(long lCommitmentId)
    {
        InputUpdateCommitmentDetails1.LoadDetails(lCommitmentId);
        oDocsUpload.LoadDocuments(lCommitmentId);
    }

    private void LoadControl()
    {
        List<OU> olstOU = o.lstGetOUS();
        foreach (var listItem in olstOU.Select(r => new RadComboBoxItem(r.m_sOUS, r.m_iOUId.ToString())))
        {
            ddlOU.Items.Add(listItem);
            ddlOU.DataBind();
        }
    }

    private void ShowHide()
    {
        if (ddlOU.SelectedValue == ((int)commonEnums.OU.SPDC).ToString())
        {
            pnlSnepco.Visible = false;
            pnlSPDC.Visible = true;
        }
        else if (ddlOU.SelectedValue == ((int)commonEnums.OU.SNEPCO).ToString())
        {
            pnlSnepco.Visible = true;
            pnlSPDC.Visible = false;
        }
    }
}