using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppTokens
/// This class is used to recognise each application in the web portal.
/// This can continue to increase based on the number of applications to be developed.
/// </summary>

public class AppTokens
{
    public enum appTokens
    {
        lean = 1,
        initiativeMgt = 2,
        BI500 = 3,
        pec = 4,
        FlareWaiver = 5,
        FourteenDayContract = 6,
        PDR = 7,
        pdcc = 8,
        prices = 9,
    };

    public static string AppDesc(appTokens eAppTokens)
    {
        string sRet = "UnKnown Application";
        try
        {
            switch (eAppTokens)
            {
                case appTokens.BI500: sRet = "BI"; break;
                case appTokens.initiativeMgt: sRet = "IMF"; break;
                case appTokens.lean: sRet = "Lean"; break;
                case appTokens.pec: sRet = "pec"; break;
                case appTokens.FlareWaiver: sRet = "flr"; break;
                case appTokens.FourteenDayContract: sRet = "ftnDay"; break;
                case appTokens.PDR: sRet = "DlyRpt"; break;
                case appTokens.pdcc: sRet = "pdcc"; break;
                case appTokens.prices: sRet = "pr"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static string AppFullDesc(appTokens eAppTokens)
    {
        string sRet = "UnKnown Application";
        try
        {
            switch (eAppTokens)
            {
                case appTokens.BI500: sRet = "Bright Ideas"; break;
                case appTokens.initiativeMgt: sRet = "Initiative Management Framework"; break;
                case appTokens.lean: sRet = "CI Dashboard and projects"; break;
                case appTokens.pec: sRet = "Plan Execution Criteria/Field Visit"; break;
                case appTokens.FlareWaiver: sRet = "Flare Waiver"; break;
                case appTokens.FourteenDayContract: sRet = "14 Day Contract"; break;
                case appTokens.PDR: sRet = "Production Daily Report"; break;
                case appTokens.pdcc: sRet = "Production Cost Challenge"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}
