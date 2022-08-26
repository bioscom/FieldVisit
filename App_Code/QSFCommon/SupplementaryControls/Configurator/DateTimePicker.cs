using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for DateTimePicker
    /// </summary>
    public class DatePicker : RadDatePicker
    {
        public DatePicker() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
            DateInput.LabelWidth = Unit.Empty;
            EnableShadows = false;
            Calendar.ShowRowHeaders = false;
            Calendar.DayNameFormat = DayNameFormat.Short;
            Calendar.SpecialDays.Add( new RadCalendarDay() {
                Repeatable = RecurringEvents.Today
            });
            Calendar.SpecialDays[0].ItemStyle.CssClass = "rcToday";
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

        public string Label
        {
            get { return DateInput.Label;}
            set { DateInput.Label = value;}
        }

    }

    /// <summary>
    /// Summary description for DateTimePicker
    /// </summary>
    public class TimePicker : RadTimePicker
    {
        public TimePicker() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
            DateInput.LabelWidth = Unit.Empty;
            EnableShadows = false;
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

        public string Label
        {
            get { return DateInput.Label;}
            set { DateInput.Label = value;}
        }

    }

    /// <summary>
    /// Summary description for DateTimePicker
    /// </summary>
    public class DateTimePicker : RadDateTimePicker
    {
        public DateTimePicker() : base()
        {
            Skin = "Qsf";
            EnableEmbeddedSkins = false;
            Width = Unit.Pixel(300);
            DateInput.LabelWidth = Unit.Empty;
            EnableShadows = false;
            Calendar.ShowRowHeaders = false;
            Calendar.DayNameFormat = DayNameFormat.Short;
            Calendar.SpecialDays.Add( new RadCalendarDay() {
                Repeatable = RecurringEvents.Today
            });
            Calendar.SpecialDays[0].ItemStyle.CssClass = "rcToday";
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

        public string Label
        {
            get { return DateInput.Label;}
            set { DateInput.Label = value;}
        }

    }
}