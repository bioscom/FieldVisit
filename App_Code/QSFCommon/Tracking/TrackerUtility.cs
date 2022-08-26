using System;
using System.Configuration;
using System.Linq;
#if Tracking
using EQATEC.Analytics.Monitor;
using System.Web;
#endif


public class TrackerUtility
{
    private const string TrackerApplicationObjectKey = "Telerik.QSF.Tracker";
    private const string TrackingKey = "Telerik.QSF.TrackingKey";

    public static string TrackerPublicKey
    {
        get
        {
            return ConfigurationManager.AppSettings[TrackingKey];
        }
    }

    public static void InitializeTracker()
    {
#if Tracking
        IAnalyticsMonitor monitor = monitor = AnalyticsMonitorFactory.Create(TrackerPublicKey);
        try
        {
            monitor.Start();
            HttpContext.Current.Application[TrackerApplicationObjectKey] = monitor;

            Tracker.Track += (sender, args) =>
                {
                    var dataType = args.Data != null ? args.Data.GetType() : typeof(object);

                    if (typeof(Exception).IsAssignableFrom(dataType))
                    {
                        monitor.TrackException((Exception)args.Data);
                    }
                    else if (dataType == typeof(string))
                    {
                        monitor.TrackFeature((string)args.Data);
                    }
                };

            Tracker.IsEnabled = true;
        }
        catch (Exception)
        {
            if (monitor != null)
            {
                monitor.Dispose();
            }

            Tracker.IsEnabled = false;
        }
#else        
        Tracker.IsEnabled = false;
#endif
    }

    public static void DisposeTracker()
    {

         
    }
}