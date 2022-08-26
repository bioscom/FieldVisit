using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for Slider
    /// </summary>
    public class Slider : RadSlider
    {
        public Slider() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            IsSelectionRangeEnabled = false;
            ShowIncreaseHandle = true;
            ShowDecreaseHandle = true;
            Orientation = Orientation.Horizontal;
            Width = Unit.Pixel(300);
            Height = Unit.Pixel(36);
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
    }
}