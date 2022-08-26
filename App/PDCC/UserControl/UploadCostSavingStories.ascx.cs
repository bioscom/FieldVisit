using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDCC_UserControl_UploadCostSavingStories : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uploadButton_Click(object sender, EventArgs e)
    {
        //UploadFile(xyFileUpload);
    }

    private void UploadFile(FileUpload fileLoader)
    {
        try
        {
            if (fileLoader.HasFile)
            {
                fileLoader.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/CostSavingStories/" + fileLoader.FileName));
                ajaxWebExtension.showJscriptAlert(Page, this, "File successfully uploaded.");
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "No file found!!!");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }
}