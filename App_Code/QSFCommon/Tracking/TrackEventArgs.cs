using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TrackEventArgs : EventArgs
{
    private readonly object data;

    /// <summary>
    /// Initializes a new instance of the <see cref="TrackEventArgs"/> class.
    /// </summary>
    /// <param name="data">The data that has been tracked.</param>
    public TrackEventArgs(object data)
    {
        this.data = data;
    }

    /// <summary>
    /// Gets the data that has been tracked.
    /// </summary>
    /// <value>The data that has been tracked.</value>
    public object Data
    {
        get
        {
            return data;
        }
    }
}
