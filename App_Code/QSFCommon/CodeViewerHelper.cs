using System;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Telerik.QuickStart
{
    /// <summary>
    /// A helper class for the Code Viewer.
    /// </summary>
    public sealed class CodeViewerHelper
    {
        #region Fields

        private const string htmlOpenTag = "<html xmlns='http://www.w3.org/1999/xhtml'>";
        private const string htmlCloseTag = "</html>";
        private const string headOpenTag = "<head runat=\"server\">";
        private const string title = "    <title>Telerik ASP.NET Example</title>";
        private const string headCloseTag = "</head>";
        private const string bodyOpenTag = "<body>";
        private const string bodyCloseTag = "</body>";
        private const string formOpenTag = "    <form id=\"form1\" runat=\"server\">";
        private const string formCloseTag = "    </form>";
        private const string radScriptManager = "    <telerik:RadScriptManager runat=\"server\" ID=\"RadScriptManager1\" />";
        private const string radSkinManager = "    <telerik:RadSkinManager ID=\"RadSkinManager1\" runat=\"server\" ShowChooser=\"true\" />";
        private const string TabString = "&nbsp;&nbsp;&nbsp;&nbsp;";
        private const string SpaceString = "&nbsp;";
        private string doctype = string.Empty;

        private static readonly CodeViewerHelper _instance = new CodeViewerHelper();

        #endregion

        #region Constructors

        static CodeViewerHelper()
        {
        }

        private CodeViewerHelper()
        {
        }

        public static CodeViewerHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Methods

        public string RenderFile(string fileName)
        {
            string result = string.Empty;

            if (Regex.IsMatch(Path.GetExtension(fileName), "htm", RegexOptions.IgnoreCase))
            {
                result = RenderHtmlFile(fileName);
            }

            try
            {
                if (fileName != null && fileName != String.Empty)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    HtmlTextWriter hsr = GetContentWriter(strBuilder);
                    StreamReader sr = GetStreamReader(fileName);
                    RenderContent(sr, hsr, fileName.ToLower());
                    sr.Close();
                    result = strBuilder.ToString();
                }
            }
            catch (Exception)
            {
                result = "Error displaying file: " + fileName;
            }

            return result;
        }

        public string RenderHtmlFile(string fileName)
        {
            string result = string.Empty;

            try
            {
                if (fileName != null && fileName != String.Empty)
                {
                    StreamReader sr = GetStreamReader(fileName);
                    result = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception)
            {
                result = "Cannot Render Html file!";
            }

            return result;
        }

        internal HtmlTextWriter GetContentWriter(StringBuilder contentBuilder)
        {
            StringWriter strWriter = new StringWriter(contentBuilder);
            return new HtmlTextWriter(strWriter, "    ");
        }

        internal StreamReader GetStreamReader(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return new StreamReader(fs);
        }

        internal void WriteCodeStart(HtmlTextWriter writer, string attributeContent)
        {
            string className = string.Format("brush: {0}", attributeContent.ToLower());
            writer.WriteBeginTag("pre");
            writer.WriteAttribute("class", className);
            writer.Write(HtmlTextWriter.TagRightChar);
        }

        internal void WriteCodeEnd(HtmlTextWriter writer)
        {
            writer.WriteEndTag("pre");
        }

        private void RenderContent(StreamReader sr, HtmlTextWriter textBuffer, string fileName)
        {
            string codeType = "xml";
            bool hasMasterPageDirective = Regex.IsMatch(fileName.ToLower(), @"default(cs.aspx)$|default(vb.aspx)$");

            if (fileName.EndsWith(".cs"))
            {
                codeType = "c-sharp, csharp";
            }
            else if (fileName.EndsWith(".js"))
            {
                codeType = "js, jscript, javascript";
            }
            else if (fileName.EndsWith(".vb"))
            {
                codeType = "vb, vbnet";
            }
            else if (fileName.EndsWith(".css"))
            {
                codeType = "css";
            }

            WriteCodeStart(textBuffer, codeType);

            if (hasMasterPageDirective)
            {
                RenderFileMasterPageDirective(sr, textBuffer);
            }
            else
            {
                RenderFile(sr, textBuffer);
            }

            WriteCodeEnd(textBuffer);
        }

        private void RenderFile(StreamReader sr, HtmlTextWriter textBuffer)
        {
            String sourceLine = String.Empty;

            while ((sourceLine = sr.ReadLine()) != null)
            {
                textBuffer.Write(FixCodeLine(sourceLine));
                textBuffer.Write("\n");
            }
        }

        private void RenderFileMasterPageDirective(StreamReader sr, HtmlTextWriter textBuffer)
        {
            string sourceLine = String.Empty;

            bool headerPlaceHolderMatched = false;
            bool headerTagClosed = false;
            bool qrPlaceHolderMatched = false;
            bool configuratorPlaceHolderMatched = false;
            bool contentPlaceHolderMatched = false;
            bool footPlaceHolderMatched = false;
            bool masterPageMatched = false;

            Action renderHeadOpeningTag = () => 
            {
                headerPlaceHolderMatched = true;
                textBuffer.Write(FixCodeLine(doctype));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(htmlOpenTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(headOpenTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(title));
                textBuffer.Write("\n");
            };

            Action renderHeadClosingTag = () =>
            {
                headerTagClosed = true;
                textBuffer.Write(FixCodeLine(headCloseTag));
                textBuffer.Write("\n");
            };

            Action renderOpeningBodyTag = () =>
            {
                textBuffer.Write(FixCodeLine(bodyOpenTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(formOpenTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(radScriptManager));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(radSkinManager));
                textBuffer.Write("\n");
            };

            Action renderClosingBodyTag = () =>
            {
                textBuffer.Write(FixCodeLine(formCloseTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(bodyCloseTag));
                textBuffer.Write("\n");
                textBuffer.Write(FixCodeLine(htmlCloseTag));
            };

            Action<Match> setDocType = (match) =>
            {
                if (Regex.IsMatch(match.Value, "\\s*MasterPage5.master\"", RegexOptions.IgnoreCase))
                {
                    doctype = "<!DOCTYPE html>";
                }
                else if (Regex.IsMatch(match.Value, "\\s*MasterPage10.master\"", RegexOptions.IgnoreCase))
                {
                    doctype = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
                }
                else
                {
                    doctype = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">";
                }

                masterPageMatched = true;
            };

            while ((sourceLine = sr.ReadLine()) != null)
            {

                if (qrPlaceHolderMatched)
                {
                    break;
                }

                if (!masterPageMatched)
                {
                    var match = GetMasterPageMatch(sourceLine);

                    if (match.Captures.Count > 0)
                    {
                        sourceLine = sourceLine.TrimStart().Replace(match.Value, string.Empty);
                        setDocType(match);
                    }
                }

                if (!headerPlaceHolderMatched && sourceLine.Contains("ContentPlaceHolderID=\"head\""))
                {
                    renderHeadOpeningTag();
                    continue;
                }

                if (masterPageMatched && sourceLine.Contains("</asp:Content"))
                {
                    if (headerPlaceHolderMatched && !headerTagClosed)
                    {
                        renderHeadClosingTag();
                    }

                    continue;
                }

                if (!contentPlaceHolderMatched && sourceLine.Contains("ContentPlaceHolderID=\"ContentPlaceholder1\""))
                {
                    contentPlaceHolderMatched = true;

                    if (!headerPlaceHolderMatched)
                    {
                        renderHeadOpeningTag();
                        renderHeadClosingTag();
                    }

                    renderOpeningBodyTag();
                    continue;
                }

                if (!configuratorPlaceHolderMatched && sourceLine.Contains("ContentPlaceHolderID=\"ConfiguratorPlaceholder\""))
                {
                    configuratorPlaceHolderMatched = true;
                    continue;
                }

                if (!footPlaceHolderMatched && sourceLine.Contains("ContentPlaceHolderID=\"FootPlaceholder\""))
                {
                    footPlaceHolderMatched = true;
                    continue;
                }

                if (!qrPlaceHolderMatched && sourceLine.Contains("ContentPlaceHolderID=\"QrPlaceholder\""))
                {
                    qrPlaceHolderMatched = true;
                    continue;
                }

                textBuffer.Write(FixCodeLine(sourceLine));

                if (masterPageMatched)
                {
                    textBuffer.Write("\n");
                }
            }

            renderClosingBodyTag();
        }

        private string FixCodeLine(string sourceLine)
        {
            if (sourceLine == null)
            {
                return null;
            }

            sourceLine = HttpUtility.HtmlEncode(sourceLine);
            sourceLine = FixTabs(sourceLine);

            return sourceLine;
        }

        private string FixTabs(string sourceLine)
        {
            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", TabString);
            sourceLine = Regex.Replace(sourceLine, "(?i)(\\s)", SpaceString);

            return sourceLine;
        }

        protected Match GetMasterPageMatch(String source)
        {
            return Regex.Match(source, "MasterPageFile=\"~/MasterPage.*.master\"");
        }

        #endregion
    }
}
