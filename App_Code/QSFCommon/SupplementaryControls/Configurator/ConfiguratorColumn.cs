using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.QuickStart
{
    /// <summary>
    /// This class encapsulates its content in a column.
    /// </summary>
    public class ConfiguratorColumn : Panel
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public ColumnSize Size { get; set; }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (Visible)
            {
                var className = String.Format("{0} {1}", QSFConstants.ConfiguratorColumn.WrapperClassName, "col-" + Size.ToString().ToLower());
                writer.AddAttribute(HtmlTextWriterAttribute.Class, className);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                {
                    if (!string.IsNullOrEmpty(Title))
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);
                        {
                            writer.RenderBeginTag(HtmlTextWriterTag.Legend);
                            {
                                writer.Write(Title);
                            };
                            writer.RenderEndTag();

                            RenderChildren(writer);
                        };
                        writer.RenderEndTag();
                    }
                    else
                    {
                        RenderChildren(writer);
                    }
                };
                writer.RenderEndTag();
            }
        }
    }

    public enum ColumnSize {
        Auto,
        Narrow,
        Medium,
        Wide
    }
}