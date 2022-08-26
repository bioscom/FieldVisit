using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

/// <summary>
/// This class contains utility methods and fields.
/// </summary>

namespace Telerik.QuickStart
{
    public sealed class Utility
    {
        #region Fields

        private static readonly Utility _instance = new Utility();

        #endregion


        #region Constructors

        static Utility()
        {
        }

        private Utility()
        {
        }

        #endregion

        #region Properties

        public static Utility Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<DateTime> DbResetTimes
        {
            get
            {
                if (HttpRuntime.Cache["DbResetTimes"] == null)
                {
                    HttpRuntime.Cache.Insert("DbResetTimes", PopulateResetTimes(), null,
                                 new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1),
                                 TimeSpan.Zero);
                }

                return ((List<DateTime>)HttpRuntime.Cache["DbResetTimes"]);
            }
        }

        public int DBResetHours
        {
            get
            {
                string value = ConfigurationManager.AppSettings.Get("DBResetHours");
                if (string.IsNullOrEmpty(value))
                {
                    return 2;
                }
                return int.Parse(value);
            }
        }


        #endregion

        #region Methods


        public void InitDbReset(HtmlGenericControl textPlaceHolder)
        {
            DateTime timeToNextReset = DbResetTimes.Find(delegate(DateTime time) { return DateTime.Now < time; });

            TimeSpan timeSpan = (timeToNextReset - DateTime.Now);
            textPlaceHolder.InnerText = string.Format(CultureInfo.InvariantCulture,
                                                        "{0} hours, {1} minutes, {2} seconds", timeSpan.Hours,
                                                        timeSpan.Minutes, timeSpan.Seconds);
        }

        private List<DateTime> PopulateResetTimes()
        {
            List<DateTime> resetTimes = new List<DateTime>();
            DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime t = currentDate.AddDays(1);
            resetTimes.Add(currentDate);
            while (currentDate < t)
            {
                currentDate = currentDate.AddHours(DBResetHours);
                resetTimes.Add(currentDate);
            }
            return resetTimes;
        }

        #endregion
    }
}