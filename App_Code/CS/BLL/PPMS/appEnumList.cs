using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for appEnumList
/// </summary>

namespace CS.BLL.PPMS
{
    public class appEnumList
    {
        public enum mImportance
        {
            H = 1, M = 2, L = 3,
        };

        public static string ImportanceDesc(mImportance eImportance)
        {
            string sRet = "NILL";
            try
            {
                switch (eImportance)
                {
                    case mImportance.H: sRet = "High"; break;
                    case mImportance.M: sRet = "Medium"; break;
                    case mImportance.L: sRet = "Low"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }


        public enum mUrgency
        {
            OverDue = 1, Ok = 2, Na = 3
        };

        public static string UrgencyDesc(mUrgency eUrgency)
        {
            string sRet = "NILL";
            try
            {
                switch (eUrgency)
                {
                    case mUrgency.OverDue: sRet = "OVERDUE"; break;
                    case mUrgency.Ok: sRet = "OK"; break;
                    case mUrgency.Na: sRet = "N/A"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }


        public enum mProjectStatus
        {
            NotStated = 1, InProgress = 2, Completed = 3,
        };

        public static string ProjectStatusDesc(mProjectStatus eProjectStatus)
        {
            string sRet = "NILL";
            try
            {
                switch (eProjectStatus)
                {
                    case mProjectStatus.NotStated: sRet = "Not Stated"; break;
                    case mProjectStatus.InProgress: sRet = "In Progress"; break;
                    case mProjectStatus.Completed: sRet = "Completed"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }

        public enum mOthers
        {
            Others = 0
        };

        public static string OthersDesc(mOthers emOthers)
        {
            string sRet = "NILL";
            try
            {
                switch (emOthers)
                {
                    case mOthers.Others: sRet = "Others"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }
}
