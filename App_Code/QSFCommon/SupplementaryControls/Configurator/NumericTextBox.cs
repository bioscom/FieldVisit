using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for NumericTextBox
    /// </summary>
    public class NumericTextBox : RadNumericTextBox
    {
        public NumericTextBox() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            ShowSpinButtons = true;
            ShowButton = false;
            Width = Unit.Pixel(71);
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