using System;
using System.Linq;

public static class Tracker
{
    /// <summary>
    /// Raised when some collection item's property is changed.
    /// </summary>
    public static event EventHandler<TrackEventArgs> Track;

    /// <summary>
    /// Tracks data and raises the <see cref="Track"/> event.
    /// </summary>
    public static void TrackData(object sender, object data)
    {
        if (Tracker.Track != null)
        {
            Tracker.Track(sender, new TrackEventArgs(data));
        }
    }

    /// <summary>
    /// Gets or sets value indicating whether Tracker will raise Track event or not. True by default.
    /// </summary>
    public static bool IsEnabled { get; set; }
}
