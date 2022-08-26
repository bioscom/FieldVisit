using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class mMonthEnuem
    {
        public enum mMonth
        {
            jan = 1,
            feb = 2,
            mar = 3,
            apr = 4,
            may = 5,
            jun = 6,
            jul = 7,
            aug = 8,
            sep = 9,
            oct = 10,
            nov = 11,
            dec = 12
        };


        public static string monthDesc(mMonth eMonth)
        {
            string sRet = "Unknown Month";
            try
            {
                switch (eMonth)
                {
                    case mMonth.jan: sRet = "January"; break;
                    case mMonth.feb: sRet = "February"; break;
                    case mMonth.mar: sRet = "March"; break;
                    case mMonth.apr: sRet = "April"; break;
                    case mMonth.may: sRet = "May"; break;
                    case mMonth.jun: sRet = "June"; break;
                    case mMonth.jul: sRet = "July"; break;
                    case mMonth.aug: sRet = "August"; break;
                    case mMonth.sep: sRet = "September"; break;
                    case mMonth.oct: sRet = "October"; break;
                    case mMonth.nov: sRet = "November"; break;
                    case mMonth.dec: sRet = "December"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }

        public static string monthOtherDesc(mMonth eMonth)
        {
            string sRet = "Unknown Month";
            try
            {
                switch (eMonth)
                {
                    case mMonth.jan: sRet = "JAN"; break;
                    case mMonth.feb: sRet = "FEB"; break;
                    case mMonth.mar: sRet = "MAR"; break;
                    case mMonth.apr: sRet = "APR"; break;
                    case mMonth.may: sRet = "MAY"; break;
                    case mMonth.jun: sRet = "JUN"; break;
                    case mMonth.jul: sRet = "JUL"; break;
                    case mMonth.aug: sRet = "AUG"; break;
                    case mMonth.sep: sRet = "SEP"; break;
                    case mMonth.oct: sRet = "OCT"; break;
                    case mMonth.nov: sRet = "NOV"; break;
                    case mMonth.dec: sRet = "DEC"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }

        public static string getMonth(int iMonth)
        {
            string sRet = "Unknown Month";
            try
            {
                if ((int)mMonth.jan == iMonth) sRet = monthOtherDesc(mMonth.jan);
                if ((int)mMonth.feb == iMonth) sRet = monthOtherDesc(mMonth.feb);
                if ((int)mMonth.mar == iMonth) sRet = monthOtherDesc(mMonth.mar);
                if ((int)mMonth.apr == iMonth) sRet = monthOtherDesc(mMonth.apr);
                if ((int)mMonth.may == iMonth) sRet = monthOtherDesc(mMonth.may);
                if ((int)mMonth.jun == iMonth) sRet = monthOtherDesc(mMonth.jun);
                if ((int)mMonth.jul == iMonth) sRet = monthOtherDesc(mMonth.jul);
                if ((int)mMonth.aug == iMonth) sRet = monthOtherDesc(mMonth.aug);
                if ((int)mMonth.sep == iMonth) sRet = monthOtherDesc(mMonth.sep);
                if ((int)mMonth.oct == iMonth) sRet = monthOtherDesc(mMonth.oct);
                if ((int)mMonth.nov == iMonth) sRet = monthOtherDesc(mMonth.nov);
                if ((int)mMonth.dec == iMonth) sRet = monthOtherDesc(mMonth.dec);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }