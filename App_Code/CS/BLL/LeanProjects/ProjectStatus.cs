using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProjectStatus
/// </summary>
public class ProjectStatus
{
    public ProjectStatus()
    {
        //
        // 
        //
    }

    public enum ProjStatus
    {
        NotStarted = 0,
        Ongoing10 = 10,
        Ongoing20 = 20,
        Yes20 = 21,
        Yes40 = 40,
    };

    public static string status(ProjStatus eProjectStatus)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eProjectStatus)
            {
                case ProjStatus.NotStarted: sRet = "Not Started"; break;
                case ProjStatus.Ongoing10: sRet = "Ongoing"; break;
                case ProjStatus.Ongoing20: sRet = "Ongoing"; break;
                case ProjStatus.Yes20: sRet = "Completed"; break;
                case ProjStatus.Yes40: sRet = "Completed"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}