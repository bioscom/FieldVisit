using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.QuickStart
{

    /// <summary>
    /// Summary description for CheckboxList
    /// </summary>
    public class CheckBoxList : System.Web.UI.WebControls.CheckBoxList
    {

        #region Props

        public Orientation Orientation { get; set; }

        public String Label { get; set; }

        #endregion


        #region Constructor
        public CheckBoxList() : base()
        {
            RepeatLayout = System.Web.UI.WebControls.RepeatLayout.UnorderedList;
            Orientation = Orientation.Vertical;
        }
        #endregion


        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            var orientationCssClass =  Orientation == Orientation.Vertical
                ? "checkbox-list"
                : "checkbox-list-h";

            if (String.IsNullOrEmpty( CssClass) ) {
                CssClass = orientationCssClass;
            }
            else {
                CssClass = String.Format( "{0} {1}", CssClass, orientationCssClass);
            }

            if ( !String.IsNullOrEmpty( Label ) ) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "label");
                writer.RenderBeginTag(HtmlTextWriterTag.H4);
                writer.Write( Label );
                writer.RenderEndTag();
            }

            base.Render(writer);
        }

        #endregion
    }

}