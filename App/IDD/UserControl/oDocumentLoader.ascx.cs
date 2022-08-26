using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


public partial class App_IDD_UserControl_oDocumentLoader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool UploadDocuments(long lRequestId)
    {
        var o = new EIdd.RequestDocs();
        var oT = new EIdd.IDDRequestDocsMgt();

        try
        {
            foreach (UploadedFile file in AsyncUpload1.UploadedFiles)
            {
                var bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, bytes.Length);

                o.m_iRequestId = lRequestId;
                o.m_bDocs = bytes;
                o.m_sFileName = file.FileName;
                o.m_sFileType = file.ContentType;

                oT.CreateRequestDocs(o.m_iRequestId, o.m_bDocs, o.m_sFileName, o.m_sFileType);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }
}