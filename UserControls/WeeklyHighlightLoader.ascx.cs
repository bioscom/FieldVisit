using System;
using System.Web.UI.WebControls;
using CS.BLL.FlareWaiver;
using System.IO;
using System.Web;

public partial class UserControls_WeeklyHighlightLoader : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uploadButton_Click(object sender, EventArgs e)
    {
        //UploadFile(xyFileUpload, Convert.ToInt16(ddlWk.SelectedValue), dtFrom.DateSelectedDate, dtTo.DateSelectedDate);
        const string MyPath = "~/WeeklyHighlight/";
        try
        {
            if (xyFileUpload.PostedFile.ContentType == "application/pdf")
            {
                WeeklyHighlights oWeeklyHighlights = new WeeklyHighlights();

                oWeeklyHighlights.dDateFrom = dtFrom.DateSelectedDate;
                oWeeklyHighlights.dDateTo = dtTo.DateSelectedDate;
                oWeeklyHighlights.dDateSubmit = DateTime.Today.Date;
                oWeeklyHighlights.iWeek = Convert.ToInt16(ddlWk.SelectedValue);
                oWeeklyHighlights.iUserId = oSessnx.getOnlineUser.m_iUserId;
                oWeeklyHighlights.iYear = DateTime.Today.Year;

                oWeeklyHighlights.sFileName = "Week" + ddlWk.SelectedValue + "highlight.pdf";
                string saveLocation = HttpContext.Current.Server.MapPath(MyPath + oWeeklyHighlights.sFileName);
                xyFileUpload.PostedFile.SaveAs(saveLocation);

                oWeeklyHighlights.bBlob = (xyFileUpload.HasFile) ? File.ReadAllBytes(saveLocation) : null;
                

                //Check to see if the weekly highlight for the week selected already exist for the year.
                bool bRet = true;
                if (WeeklyHighlightsHelper.DtGetWeeklyHighlightByWeekYear(int.Parse(ddlWk.SelectedValue), DateTime.Today.Year).Rows.Count > 0)
                {
                    //Update
                    bRet = WeeklyHighlightsHelper.Update(oWeeklyHighlights, DateTime.Today.Year);
                    if (bRet)
                    {
                        ajaxWebExtension.showJscriptAlertCx(Page, this, "Week " + ddlWk.SelectedValue + " Highlight Successfully uploaded.");
                    }
                }
                else
                {
                    //Insert 
                    bRet = WeeklyHighlightsHelper.Insert(oWeeklyHighlights);
                    if (bRet)
                    {
                        ajaxWebExtension.showJscriptAlertCx(Page, this, "Week " + ddlWk.SelectedValue + " Highlight Successfully uploaded.");
                    }
                }
            }
            else
            {
                ajaxWebExtension.showJscriptAlertCx(Page, this, "The attached file is not in PDF format. Please attach a PDF copy and try again!!!");
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void UploadFile(FileUpload fileLoader, int iWk, DateTime sFrom, DateTime sTo)
    {
        const string MyPath = "~/WeeklyHighlight/";
        string oMessage = "";
        SaveFile oSaveFile = new SaveFile();
        fileProperty myFileProperties = oSaveFile.UploadFile(fileLoader, iWk, sFrom, sTo, ref oMessage);

        ajaxWebExtension.showJscriptAlert(Page, this, oMessage);
        //if (myFileProperties.bRet)
        //{
        //    ajaxWebExtension.showJscriptAlert(Page, this, oMessage);
        //}


        //fileProperty myFileProperties = getDocType(fileLoader);
        string sMessage = "";
        if (fileLoader.HasFile)
        {
            if (fileLoader.PostedFile.ContentType == "application/pdf")
            {
                string sFileName = Guid.NewGuid() + "#" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + "#- Wk" + iWk + " (" + sFrom.Date.ToShortDateString().Replace("/", "-") + " - " + sTo.Date.ToShortDateString().Replace("/", "-") + ")" + ".pdf";
                string saveLocation = HttpContext.Current.Server.MapPath(MyPath + sFileName);
                try
                {
                    fileLoader.PostedFile.SaveAs(saveLocation);
                    sMessage = "The file has been successfully uploaded.";
                    ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
                    //Clear();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
                }
            }
            else
            {
                sMessage = "The attached is not in PDF format. Please attach a PDF copy and try again.";
                ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
            }
        }
        else
        {
            sMessage = "You did not attach a copy of your work plan. Please attach a copy and try again.";
            ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
        }

    }
}