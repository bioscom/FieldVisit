using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for ViewFile
/// </summary>

public class ViewFile
{
    public ViewFile()
    {

    }

    public void LoadFileFromWorkOrder(string sFileName)
    {
        try
        {
            if (sFileName != "No Work Order attached!!!")
            {
                string SourceFilePath = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/WorkOrder/" + sFileName);
                FileInfo SourceFile = new FileInfo(SourceFilePath);

                string DestinationPath = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/WorkOrder.pdf");
                FileInfo destination = new FileInfo(DestinationPath);

                SourceFile.CopyTo(DestinationPath, true);
                destination.Refresh();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            //appMonitor.logAppExceptions(ex);
        }
    }

    public void LoadFileForPreview(string sFileName, string sSourcePath, string sDestinationPath)
    {
        try
        {
            FileInfo SourceFile = new FileInfo(sSourcePath);

            string DestinationPath = HttpContext.Current.Server.MapPath(sDestinationPath);
            FileInfo destination = new FileInfo(DestinationPath);

            SourceFile.CopyTo(DestinationPath, true);
            destination.Refresh();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //public void LoadFileFromTemp(string sFileName)
    //{
    //    try
    //    {
    //        string SourceFilePath = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/TempDocs/" + sFileName);
    //        FileInfo SourceFile = new FileInfo(SourceFilePath);

    //        string DestinationPath = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/WorkOrder.pdf");
    //        FileInfo destination = new FileInfo(DestinationPath);

    //        SourceFile.CopyTo(DestinationPath, true);
    //        destination.Refresh();
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
    //        appMonitor.logAppExceptions(ex);
    //    }
    //}
}