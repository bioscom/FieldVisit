using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for DropDownList
    /// </summary>
    public class DropDownList : RadDropDownList
    {
        public String Label { get; set; }

        public DropDownList() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
        }

        public override string Skin
        {
            get
            {
                return "Qsf";
            }
        }

        public InputSize Size
        {
            set
            {
                CssClass = "fb-sized fb-size-" + value.ToString().ToLower();
                Width = Unit.Pixel( (int)value );
            }
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);

            if (!String.IsNullOrWhiteSpace(Label)) { 
                writer.Write(String.Format("<span class='label'>{0}</span>", Label) );
            }
        }
    }
}