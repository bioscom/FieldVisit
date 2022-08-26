using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_CommitmentControl_UserControl_oDocsUploaded : System.Web.UI.UserControl
{
    CommitmentsDocsMgt oT = new CommitmentsDocsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void LoadDocuments(long lCommitmentId)
    {
        DocumentsGrid.DataSource = oT.dtGetDocsByCommitmentId(lCommitmentId);
        DocumentsGrid.DataBind();

        CommitmentIdHF.Value = lCommitmentId.ToString();
    }

    protected void DocumentsGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            long lCommitmentId = long.Parse(CommitmentIdHF.Value);
            (sender as RadGrid).DataSource = oT.dtGetDocsByCommitmentId(lCommitmentId);

            //if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
            //{
            //    long lCommitmentId = long.Parse(CommitmentIdHF.Value);
            //    (sender as RadGrid).DataSource = oT.dtGetDocsByCommitmentId(lCommitmentId);
            //}
            //else
            //{
            //    (sender as RadGrid).DataSource = oT.dtGetDocsByCommitmentId(-1);
            //}
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnDocument_Click(object sender, EventArgs e)
    {
        var lb = (LinkButton)sender;
        var item = (GridDataItem)lb.NamingContainer;
        if (item != null)
        {
            long lDocId = long.Parse(lb.Attributes["IDDOCS"].ToString());
            DownloadFile(lDocId);
        }
    }

    private void DownloadFile(long lDocId)
    {
        CommitmentDocs o = oT.objGetCommitmentDocByDocId(lDocId);
        string strfn = o.m_sFileName;
        byte[] blob = o.m_bDocs;
        var oK = new RadAjaxPanel();

        HttpContext.Current.Response.ContentType = o.m_sFileType;
        HttpContext.Current.Response.AddHeader("content-disposition", "Attachment; filename=" + strfn);
        HttpContext.Current.Response.AddHeader("content-length", blob.Length.ToString());
        HttpContext.Current.Response.BinaryWrite(blob);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        HttpContext.Current.Response.End();
    }
}