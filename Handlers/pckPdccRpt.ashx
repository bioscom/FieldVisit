<%@ WebHandler Language="C#" Class="pckPdccRpt" %>

using System;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class pckPdccRpt : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string sArgs = context.Request.QueryString["Msg"];
        int iYear = int.Parse(context.Request.QueryString["iYr"]);
        string sFileName = "";
        string sContType = "";
        ExcelPackage pck = new ExcelPackage();
        ExportDashBoardData sReportx = new ExportDashBoardData();
        
        switch (sArgs.ToLower())
        {
            case "wrkdn":
                
                sFileName = "WorkDone.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                sReportx.ExportProjectsWorkDoneByFunction(pck, iYear);
                break;

            case "prjmatrphs":
                sFileName = "ProjectMaturationPhase.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                sReportx.ExportProjectsMaturationPhase(pck, iYear);
                break;

            case "bnft":
                sFileName = "Benefit.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                sReportx.ExportBenefit(pck);
                break;
                
            case "prjcomong":
                sFileName = "CompletedOngoingProjects.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                sReportx.ExportCompletedOngoingProjects(pck, iYear);
                break;
                
            case "prjbnft":
                sFileName = "ProjectBenefits.xlsx";
                sContType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                sReportx.ExportProjectsBenefit(pck, iYear);
                break;
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
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }
}