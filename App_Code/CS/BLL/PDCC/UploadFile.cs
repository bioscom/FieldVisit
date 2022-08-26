using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UploadFile
/// </summary>
/// 


public class xfileProperty
{
    public bool controlHasFile;
    public string fileType;
    public string sFileName;
    public bool bRet;

    public xfileProperty()
    {
        controlHasFile = false;
        fileType = "";
        sFileName = "";
        //bRet = false;
    }
}

public class UploadFile
{
    public UploadFile()
    {

    }

    public xfileProperty UploadSelectedFile(FileUpload FileLoader, ref string sMessage)
    {
        TimeDateCulture ourCulture = new TimeDateCulture();

        xfileProperty MyFileProperties = getDocType(FileLoader);

        if (MyFileProperties.controlHasFile)
        {
            //string fn = System.IO.Path.GetFileName(FileLoader.PostedFile.FileName);
            //MyFileProperties.sFileName = "#" + ourCulture.GetTodaysDateInBritishFormat().Replace("/", "-") + "#" + System.Guid.NewGuid().ToString() + ".jpg";
            string SaveLocation = HttpContext.Current.Server.MapPath("~/App/PDCC/Data/" + MyFileProperties.sFileName);
            try
            {
                FileLoader.PostedFile.SaveAs(SaveLocation);
                sMessage = "The file has been uploaded.";
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
        else
        {
            sMessage = "Please select a file to upload.";
        }

        return MyFileProperties;
    }

    private xfileProperty getDocType(FileUpload FileLoader)
    {
        string filters = "*.jpj;*.png;*.gif;*.jpeg";
        //string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"].ToString();

        xfileProperty MyFile = new xfileProperty();
        try
        {

            if (FileLoader.HasFile)
            {
                MyFile.sFileName = FileLoader.FileName; //FileLoader.PostedFile.FileName;
                MyFile.fileType = FileLoader.PostedFile.ContentType;
                MyFile.controlHasFile = true;

                foreach (string filter in filters.Split(';'))
                {

                }

                //if (MyFile.fileType == "application/pdf") MyFile.bRet = true;
                //else MyFile.bRet = false;
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return MyFile;
    }

}