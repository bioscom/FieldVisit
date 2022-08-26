using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TellUrStories
/// </summary>
public class TellYourStories
{
    public long m_lStoryId { get; set; }
    public string m_sStory { get; set; }
    public string m_sUserName { get; set; }
    public string m_sTitle { get; set; }
    public DateTime m_dtDateTold { get; set; }
    public string m_sTime { get; set; }
    public decimal m_dAmtSaved { get; set; }
    public string m_sFileName1 { get; set; }
    public string m_sFileName2 { get; set; }
    public string m_sFileName3 { get; set; }
    public string m_sFileName4 { get; set; }


	public TellYourStories()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public TellYourStories(DataRow dr)
    {
        decimal i = 0;
        try
        {
            m_lStoryId = long.Parse(dr["IDSTORY"].ToString());
            m_sStory = dr["STORY"].ToString();
            m_sUserName = dr["USERNAME"].ToString();
            m_sTitle = dr["TITLE"].ToString();
            m_dtDateTold = DateTime.Parse(dr["DATETOLD"].ToString());
            m_sTime = dr["STIME"].ToString();
            m_dAmtSaved = decimal.TryParse(dr["AMTSAVED"].ToString(), out i) ? decimal.Parse(dr["AMTSAVED"].ToString()) : 0;
            m_sFileName1 = dr["FILE1"].ToString();
            m_sFileName2 = dr["FILE2"].ToString();
            m_sFileName3 = dr["FILE3"].ToString();
            m_sFileName4 = dr["FILE4"].ToString();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}