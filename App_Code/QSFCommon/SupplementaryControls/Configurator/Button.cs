using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for Button
    /// </summary>
    public class Button : RadButton
    {
        public Button() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            ButtonType = RadButtonType.SkinnedButton;
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