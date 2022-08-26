<%@ WebHandler Language="C#" Class="CostSavingStories" %>

using System;
using System.Web;

public class CostSavingStories : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string sArgs = context.Request.QueryString["Msg"];
        string sFileUrl = "";
        string sFileName = "";
        string sContType = "Application/vnd.ms-powerpoint";

        switch (sArgs.ToLower())
        {
            case "typeone":
                sFileUrl = context.Server.MapPath("~/Resources/SavingsStoryTemplate.pptx");
                sFileName = "SavingsStoryTemplate.pptx";
                break;

            case "TypeTwo":
                sFileUrl = context.Server.MapPath("~/Resources/TypeTwo.pptx");
                sFileName = "TypeTwo.pptx";
                break;

            case "TypeThree":
                sFileUrl = context.Server.MapPath("~/Resources/TypeThree.pptx");
                sFileName = "TypeThree.pptx";
                break;
        }

        try
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            
            if (sFileUrl.Length > 0)
            {
                context.Response.Clear();
                context.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", sFileName));
                context.Response.ContentType = sContType;

                webFileSystem oFileSys = new webFileSystem();
                context.Response.BinaryWrite(oFileSys.streamFileToByte(sFileUrl));
                context.Response.Flush();
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
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}