using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for commonEnums
/// </summary>
public class commonEnums
{
	public commonEnums()
	{
		
	}

    public enum YesNo
    {
        Yes = 1,
        No = 2,
        notApplicatble = 3,
        inprogress = 4,
        notDone = 5,
    };

    public static string yesNoDesc(YesNo eYesNo)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eYesNo)
            {
                case YesNo.Yes: sRet = "YES"; break;
                case YesNo.No: sRet = "NO"; break;
                case YesNo.notApplicatble: sRet = "NOT APPLICABLE"; break;
                case YesNo.inprogress: sRet = "IN PROGRESS"; break;
                case YesNo.notDone: sRet = "NOT DONE"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public enum gender
    {
        male = 1,
        female = 2,
    };

    public static string genderDesc(gender eGender)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eGender)
            {
                case gender.female: sRet = "Female"; break;
                case gender.male: sRet = "Male"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public enum planWindow
    {
        VST = 1,
        ST = 2,
        MT1 = 3,
        MT2 = 4,
    };

    public static string planWindowDesc(planWindow ePlanWindow)
    {
         string sRet = "UnKnown Account";
        try
        {
            switch (ePlanWindow)
            {
                case planWindow.VST: sRet = "VST 28 Days"; break;
                case planWindow.ST: sRet = "ST 90 Days"; break;
                case planWindow.MT1: sRet = "MT 5-12Mths"; break;
                case planWindow.MT2: sRet = "MT 13-24 Mths"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }


    public enum CapexOpex
    {
        Capex = 1,
        Opex = 2,
    };

    public static string CapexOpexDesc(CapexOpex eCapexOpex)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eCapexOpex)
            {
                case CapexOpex.Capex: sRet = "Capex"; break;
                case CapexOpex.Opex: sRet = "Opex"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public enum OU
    {
        SPDC = 1,
        SNEPCO = 2,
    };

    public static string OUDesc(OU eOU)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eOU)
            {
                case OU.SPDC: sRet = "SPDC"; break;
                case OU.SNEPCO: sRet = "SNEPCO"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    //For Gas Flare Waiver
    public enum BusinessPlan
    {
        Scheduled = 1,
        Unscheduled = 2,
    };

    public static string BusinessPlanDesc(BusinessPlan eBusinessPlan)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eBusinessPlan)
            {
                case BusinessPlan.Scheduled: sRet = "Captured in Business Plan"; break;
                case BusinessPlan.Unscheduled: sRet = "Not Captured in Business Plan"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}