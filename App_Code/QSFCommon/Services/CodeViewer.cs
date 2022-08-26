using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Telerik.QuickStart;
using System.IO;

[WebService(Namespace = "http://www.telerik.com/webservices/")]
[ScriptService]
public class CodeViewer : WebService {

    [WebMethod(EnableSession=true)]
    public string GetFileContent(string path, string fileName)
    {
        string absolutePath = Server.MapPath(path);
        string currentAbsolutePath = Context.Request.PhysicalApplicationPath;

        if (string.IsNullOrEmpty(fileName) || !absolutePath.ToLower().StartsWith(currentAbsolutePath.ToLower()) || 
            fileName.ToLowerInvariant().Contains("web.config"))
        {
            throw new HttpException(403, "Unauthorized");
        }

        return CodeViewerHelper.Instance.RenderFile(Path.Combine(absolutePath, fileName));
    }
}
