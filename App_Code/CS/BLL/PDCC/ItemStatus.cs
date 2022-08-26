using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemStatus
/// </summary>
public class ItemStatus
{
	public ItemStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public enum ItStatus
    {
        Select = -1,
        Accept = 1,
        Park = 2,
        Done = 3,
        All = 6,
        Onshore = 7,
        Offshore = 8,
        OnShoreOffShore = 9,
    };

    public static string status(ItStatus eItemStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eItemStatus)
            {
                case ItStatus.Select: sRet = "Select Option"; break;
                case ItStatus.Accept: sRet = "Accept"; break;
                case ItStatus.Park: sRet = "Park"; break;
                case ItStatus.Done: sRet = "Done"; break;
                case ItStatus.All: sRet = "All"; break;
                case ItStatus.Onshore: sRet = "Onshore"; break;
                case ItStatus.Offshore: sRet = "Offshore"; break;
                case ItStatus.OnShoreOffShore: sRet = "OnShore/OffShore"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}
