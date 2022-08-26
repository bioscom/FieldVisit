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
    public class RangeSlider : Slider
    {
        public RangeSlider() : base()
        {
            IsSelectionRangeEnabled = true;
            SelectionStart = MinimumValue;
            SelectionEnd = MaximumValue;
        }
    }
}