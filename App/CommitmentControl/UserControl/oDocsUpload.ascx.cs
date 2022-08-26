using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class App_CommitmentControl_UserControl_oDocsUpload : System.Web.UI.UserControl
{
    CommitmentDocs o = new CommitmentDocs();
    CommitmentsDocsMgt oT = new CommitmentsDocsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["lCommitmentId"]))
        {
            long lCommitmentId = long.Parse(Request.QueryString["lCommitmentId"]);
            CommitmentIdHF.Value = lCommitmentId.ToString();

            LoadDocuments(lCommitmentId);
        }
        else
        {
            if (!string.IsNullOrEmpty(CommitmentIdHF.Value))
            {
                long Id = long.Parse(CommitmentIdHF.Value);
                LoadDocuments(Id);
            }
        }
    }

    public void LoadDocuments(long lCommitmentId)
    {
        DocumentsGrid.DataSource = oT.dtGetDocsByCommitmentId(lCommitmentId);
        DocumentsGrid.DataBind();

        CommitmentIdHF.Value = lCommitmentId.ToString();
    }

    public bool UploadDocuments()
    {
        try
        {
            foreach (UploadedFile file in AsyncUpload1.UploadedFiles)
            {
                var bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, bytes.Length);

                o.m_iRequestId = long.Parse(CommitmentIdHF.Value);
                o.m_bDocs = bytes;
                o.m_sFileName = file.FileName;
                o.m_sFileType = file.ContentType;

                oT.CreateCommitmentDocs(o.m_iRequestId, o.m_bDocs, o.m_sFileName, o.m_sFileType);
            }
            LoadDocuments(o.m_iRequestId);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UploadDocuments();
    }

    protected void DocumentsGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(CommitmentIdHF.Value))
            {
                long lCommitmentId = long.Parse(CommitmentIdHF.Value);
                (sender as RadGrid).DataSource = oT.dtGetDocsByCommitmentId(lCommitmentId);
            }
            else
            {
                (sender as RadGrid).DataSource = oT.dtGetDocsByCommitmentId(-1);
            }
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
        //try
        //{
        CommitmentDocs o = oT.objGetCommitmentDocByDocId(lDocId);

        //string strfn = Convert.ToString(DateTime.Now.ToFileTime()) + ok.m_sFileName;
        string strfn = o.m_sFileName;

        //retrieving binary data of pdf from datatable to byte array
        byte[] blob = o.m_bDocs;

        var oK = new RadAjaxPanel();

        //o.ResponseScripts.Add()

        HttpContext.Current.Response.ContentType = o.m_sFileType;
        HttpContext.Current.Response.AddHeader("content-disposition", "Attachment; filename=" + strfn);
        HttpContext.Current.Response.AddHeader("content-length", blob.Length.ToString());
        HttpContext.Current.Response.BinaryWrite(blob);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        HttpContext.Current.Response.End();
        //}
        //catch (Exception ex)
        //{
        //    appMonitor.logAppExceptions(ex);
        //}
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
        {
            long lId = long.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["DOCSID"].ToString());
            oT.deleteDocById(lId);
            //grdView.Rebind();
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Deleted successful!!!");
        }
    }
}