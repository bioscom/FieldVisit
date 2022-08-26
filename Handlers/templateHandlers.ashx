<%@ WebHandler Language="C#" Class="templateHandlers" %>

using System;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class templateHandlers : IHttpHandler {

    public void ProcessRequest(HttpContext context) //: IHttpHandler.ProcessRequest
    {
        string sArgs = context.Request.QueryString["Msg"];
        string sFileUrl = "";
        string sFileName = "";
        string sContType = "";
        ExcelPackage pck = new ExcelPackage();
        BulkLoading oDMgr = new BulkLoading();

        switch (sArgs.ToLower())
        {
            case "vsmasis":
                sFileUrl = context.Server.MapPath("~/Resources/vsmasis.xlsx");
                sFileName = "vsmasis.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                break;
                
            case "imprvrec":
                sFileUrl = context.Server.MapPath("~/Resources/imprvrec.xlsx");
                sFileName = "imprvrec.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                break;

            case "fnct": 
                sFileName = "Functions.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                oDMgr.downLoadFunctions(pck);
                break;
            case "ltvat":
                sFileName = "ProcessLTVatUnits.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                oDMgr.downLoadProcessLTVatUnits(pck);
                break;
            case "wstcat":
                sFileName = "WasteCategories.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                oDMgr.downLoadWasteCategory(pck);
                break;
        }
        
        try
        {
            if (sFileUrl.Length > 0)
            {
                context.Response.Clear();
                context.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", sFileName));
                context.Response.ContentType = sContType;

                webFileSystem oFileSys = new webFileSystem();
                context.Response.BinaryWrite(oFileSys.streamFileToByte(sFileUrl));
                context.Response.Flush();
            }

            if (sFileName.Length > 0)
            {
                context.Response.Clear();
                context.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", sFileName));
                context.Response.ContentType = sContType;
                //pck.Save()                                    
                pck.SaveAs(context.Response.OutputStream);
                context.Response.Flush();
            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        //if (sFileName.Length > 0)
        //{
        //    context.Response.Clear();
        //    context.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", sFileName));
        //    context.Response.ContentType = sContType;
        //    //pck.Save()                                    
        //    pck.SaveAs(context.Response.OutputStream);
        //    context.Response.Flush();
        //}
    }
    
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}