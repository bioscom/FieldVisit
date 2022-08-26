using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace CS.BLL.FlareWaiver
{
    /// <summary>
    /// Summary description for SaveFile
    /// </summary>
    /// ]
    
    

    public class fileProperty
    {
        public bool controlHasFile;
        public string fileType;
        public string sFileName;
        public bool bRet;

        public fileProperty()
        {
            controlHasFile = false;
            fileType = "";
            sFileName = "";
            bRet = false;
        }
    }


    /// <summary>
    /// Summary description for SaveFile
    /// </summary>
    public partial class SaveFile
    {
        public SaveFile()
        {

        }

        public fileProperty UploadFileToTempFolder(FileUpload ProposalLoader, ref string sMessage)
        {
            TimeDateCulture ourCulture = new TimeDateCulture();

            fileProperty MyFileProperties = getDocType(ProposalLoader);

            if (MyFileProperties.controlHasFile)
            {
                if (MyFileProperties.fileType == "application/pdf")
                {
                    //Delete Existing file(s) before saving the newly updated IP
                    //ListFiles Myproposals = new ListFiles();
                    //Myproposals.DeleteExistingFiles(AppConfiguration.InvestmentProposalsFileLocation, proposal);

                    //Save a new IP
                    MyFileProperties.sFileName = ourCulture.GetTodaysDateInBritishFormat().Replace("/", "-") + "#" + System.Guid.NewGuid().ToString() + ".pdf";
                    //string SaveLocation = AppConfiguration.InvestmentProposalsFileLocation + MyFileProperties.sFileName;
                    string SaveLocation2 = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/TempDocs/" + MyFileProperties.sFileName);
                    try
                    {
                        ProposalLoader.PostedFile.SaveAs(SaveLocation2);
                        sMessage = "The file has been successfully uploaded.";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
                    }
                }
                else
                {
                    sMessage = "The attached is not in PDF format. Please attach a PDF copy and try again.";
                }
            }
            else
            {
                sMessage = "You did not attach a copy of your work plan. Please attach a copy and try again.";
            }

            return MyFileProperties;
        }

        public fileProperty UploadFile(FileUpload ProposalLoader, string sProjectNumber, ref string sMessage)
        {
            TimeDateCulture ourCulture = new TimeDateCulture();

            fileProperty MyFileProperties = getDocType(ProposalLoader);

            if (MyFileProperties.controlHasFile)
            {
                if (MyFileProperties.fileType == "application/pdf")
                {
                    //Delete Existing file(s) before saving the newly updated IP
                    //ListFiles Myproposals = new ListFiles();
                    //Myproposals.DeleteExistingFiles(AppConfiguration.InvestmentProposalsFileLocation, proposal);

                    //Save a new IP
                    MyFileProperties.sFileName = sProjectNumber + "#" + ourCulture.GetTodaysDateInBritishFormat().Replace("/", "-") + "#" + System.Guid.NewGuid().ToString() + ".pdf";
                    //string SaveLocation = AppConfiguration.InvestmentProposalsFileLocation + MyFileProperties.sFileName;
                    string SaveLocation2 = HttpContext.Current.Server.MapPath("~/App/FlareWaiver/WorkOrder/" + MyFileProperties.sFileName);
                    try
                    {
                        ProposalLoader.PostedFile.SaveAs(SaveLocation2);
                        sMessage = "The file has been successfully uploaded.";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
                    }
                }
                else
                {
                    sMessage = "The attached is not in PDF format. Please attach a PDF copy and try again.";
                }
            }
            else
            {
                sMessage = "You did not attach a copy of your work plan. Please attach a copy and try again.";
            }

            return MyFileProperties;
        }

        public fileProperty UploadFile(FileUpload fileLoader, int iWk, DateTime sFrom, DateTime sTo, ref string sMessage)
        {
            //fileProperty myFileProperties = getDocType(fileLoader);
            const string virtualPath = "~/WeeklyHighlight/";
            fileProperty myFileProperties = getDocType(fileLoader);

            if (myFileProperties.controlHasFile)
            {
                if (myFileProperties.fileType == "application/pdf")
                {
                    string sFileName = Guid.NewGuid() + "#" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + "#- Wk" + iWk + " (" + sFrom.Date.ToShortDateString().Replace("/", "-") + " - " + sTo.Date.ToShortDateString().Replace("/", "-") + ")" + ".pdf";
                    string saveLocation = HttpContext.Current.Server.MapPath(virtualPath + sFileName);
                    try
                    {
                        fileLoader.PostedFile.SaveAs(saveLocation);
                        sMessage = "The file has been successfully uploaded.";
                        //ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
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
                }
            }
            else
            {
                sMessage = "You did not attach a copy of your work plan. Please attach a copy and try again.";
            }
            return myFileProperties;
        }

        private fileProperty getDocType(FileUpload UploadProposal)
        {
            fileProperty MyFile = new fileProperty();
            if (UploadProposal.HasFile)
            {
                string theProposal = UploadProposal.PostedFile.FileName;
                MyFile.fileType = UploadProposal.PostedFile.ContentType;
                MyFile.controlHasFile = true;

                if (MyFile.fileType == "application/pdf") MyFile.bRet = true;
                else MyFile.bRet = false;
            }
            return MyFile;
        }
    }
}