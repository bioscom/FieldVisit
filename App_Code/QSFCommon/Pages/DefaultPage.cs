using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Telerik.QuickStart
{
    public class DefaultPage : Page
    {
        protected string CurrentLanguage
        {
            get
            {
                return (string)(Session[QSFConstants.NavigationLanguageLiteral] ?? "CS");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            //try to find the control name (if we are in a /Control/Default.aspx file)
            string controlPath = this.Request.CurrentExecutionFilePath;
            int lastSlashIndex = controlPath.LastIndexOf("/") - 1;
            int controlSlashIndex = lastSlashIndex > 0 ? controlPath.Substring(0, lastSlashIndex).LastIndexOf("/") + 1 : -1;
            string controlName = string.Empty;
            if (controlSlashIndex > 0)
            {
                controlName = controlPath.Substring(controlSlashIndex, lastSlashIndex - controlSlashIndex + 1).ToLower().Replace("-", string.Empty);
            }

            string exampleUrl = GetDefaultExampleUrl(controlName);
            PermanentRedirect(exampleUrl);
        }

        private string GetDefaultExampleUrl(string controlName)
        {
            List<XmlNode> exampleList = ExamplesProvider.Instance.CategoryList;
            XmlNode exampleNode = exampleList.Find(x => x.Attributes["text"].Value.Equals(controlName, StringComparison.OrdinalIgnoreCase)).SelectSingleNode(".//example[@default='true']");

            if (exampleNode != null)
            {
                //use lowercase for the application path! solves telerik.com site problem
                string exampleUrl = Request.ApplicationPath.ToLower();
                if (!exampleUrl.EndsWith("/"))
                {
                    exampleUrl += "/";
                }
                exampleUrl += exampleNode.Attributes["path"].Value + "/Default.aspx";
                return GetLanguageSpecificUrl(exampleUrl);
            }
            else
            {
                //no default example found
                return string.Empty;
            }
        }

        private void PermanentRedirect(string exampleUrl)
        {
            //add a permanent redirect header or display error message if no url is given
            System.Web.HttpContext.Current.Response.Clear();
            if (!string.IsNullOrEmpty(exampleUrl))
            {
                System.Web.HttpContext.Current.Response.Status = "301 Moved Permanently";
                System.Web.HttpContext.Current.Response.AddHeader("Location", exampleUrl);
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("Cannot redirect to default example..");
            }
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }

        private string GetLanguageSpecificUrl(string rawUrl)
        {
            return Regex.Replace(rawUrl,
                ".aspx", CurrentLanguage + ".aspx",
                RegexOptions.IgnoreCase).ToLower(); ;
        }
    }
}