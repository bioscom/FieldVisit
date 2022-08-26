using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DivestmentEnum
/// </summary>
public class DivestmentEnum
{
    public DivestmentEnum()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum Divestment
    {
        Active = 1,
        Divested = 2
    };

    public static string DivestmentDesc(Divestment eDivestment)
    {
        string sRet = "UnKnown Account";
        try
        {
            switch (eDivestment)
            {
                case Divestment.Active: sRet = "Asset Operated by SCiN"; break;
                case Divestment.Divested: sRet = "Asset Divested"; break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
}

