using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CapexOpex
/// </summary>
public class CapexOpex
{
	public CapexOpex()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public enum CapexOpexx
    {
        Capex = 1,
        Opex = 2,
    };

    public static string CapexOpexDesc(CapexOpexx eCapexOpexx)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eCapexOpexx)
            {
                case CapexOpexx.Capex: sRet = "Capex"; break;
                case CapexOpexx.Opex: sRet = "Opex"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}