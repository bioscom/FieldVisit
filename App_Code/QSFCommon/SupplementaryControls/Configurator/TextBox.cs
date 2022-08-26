using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for TextBox
    /// </summary>
    public class TextBox : RadTextBox
    {
        public TextBox() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
            LabelWidth = Unit.Empty;
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
                WrapperCssClass = "fb-sized fb-size-" + value.ToString().ToLower();
                Width = Unit.Pixel( (int)value );
            }
        }
    }

    /// <summary>
    /// Summary description for MaskedTextBox
    /// </summary>
    public class MaskedTextBox : RadMaskedTextBox
    {
        public MaskedTextBox() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
            LabelWidth = Unit.Empty;
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
                WrapperCssClass = "fb-sized fb-size-" + value.ToString().ToLower();
                Width = Unit.Pixel( (int)value );
            }
        }
    }
}