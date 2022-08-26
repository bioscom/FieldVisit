using System;
using System.Configuration;
using System.Linq;


/// <summary>
/// The device tracker record the user agent, width and height in CSS pixels of the mobile device visiting our demos
/// </summary>
public class DeviceInfoTracker
{
    private const string _deviceInfoTrackingKey = "Telerik.QSF.DeviceInfoTrackingKey";

    private static string DeviceInfoTrackingKey
    {
        get
        {
            return ConfigurationManager.AppSettings[_deviceInfoTrackingKey];
        }
    }

    public static bool ShouldTrackDeviceInfo()
    {
        if (DeviceInfoTrackingKey != null && DeviceInfoTrackingKey.ToString().ToLower() == "enabled")
        {
            return true;
        }

        return false;
    }
}