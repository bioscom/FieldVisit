using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_MainForm : aspnetPage
{
    PDR.MainReport oMainReport = new PDR.MainReport();
    PDR.MainReportHelper oMainReportHelper = new PDR.MainReportHelper();

    long lReportId = 0;
    string filename1 = ""; string filename2 = ""; string filename3 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            pnlForm.Visible = false;
            oMainReportHelper.FillMenu(XmlMenuDataSource, mnuTreeView);
        }
    }

    protected string UploadFolderPath = "~/App/PDR/Uploads/";

    protected void FileUploadComplete(object sender, EventArgs e)
    {
        filename1 = System.IO.Path.GetFileName(SnapShot1.FileName);
        SnapShot1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename1);
    }
    protected void FileUploadComplete2(object sender, EventArgs e)
    {
        filename2 = System.IO.Path.GetFileName(SnapShot2.FileName);
        SnapShot2.SaveAs(Server.MapPath(this.UploadFolderPath) + filename2);
    }
    protected void FileUploadComplete3(object sender, EventArgs e)
    {
        filename3 = System.IO.Path.GetFileName(SnapShot3.FileName);
        SnapShot3.SaveAs(Server.MapPath(this.UploadFolderPath) + filename3);
    }

    protected void mnuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            pnlForm.Visible = true;
            lblAssetDistrict.Text = mnuTreeView.SelectedNode.Parent.Text + "(" + mnuTreeView.SelectedNode.Text + ")";
            lblDate.Text = DateTime.Now.ToLongDateString();

            int iDistrictId = District.objGetDistrictByName(mnuTreeView.SelectedNode.Text).m_iDistrictId;
            oMainReport.iDistrict = iDistrictId;
            oMainReport.iUserId = oSessnx.getOnlineUser.m_iUserId;

            if (oMainReportHelper.dtGetMaiReportByDistrictDate(iDistrictId).Rows.Count == 0)
            {
                //It means the Report for today does not exist, then create it.
                bool bRet = oMainReportHelper.InsertMainReport(oMainReport, ref lReportId);
                lReportIdHF.Value = lReportId.ToString();
                if (bRet)
                {
                    AGOStatus1.Init_Page(iDistrictId, lReportId);
                    AlarmRate1.Init_Page(iDistrictId, lReportId);
                    CathodicProtection1.Init_Page(iDistrictId, lReportId);
                    GeneratorAirCompressorStatus1.Init_Page(iDistrictId, lReportId);
                    HSSE1.Init_Page(iDistrictId, lReportId);
                    MeterStatus1.Init_Page(iDistrictId, lReportId);
                    POB1.Init_Page(iDistrictId, lReportId);
                    PTWSummary1.Init_Page(iDistrictId, lReportId);
                    TechnicalIntegrity1.Init_Page(iDistrictId, lReportId);
                    WellTest1.Init_Page(iDistrictId, lReportId);
                }
            }
            else
            {
                oMainReport = oMainReportHelper.objGetMaiReportByDistrictNameDate(mnuTreeView.SelectedNode.Text);
                lReportIdHF.Value = oMainReport.lReportId.ToString();

                imgLoader1.ImageUrl = UploadFolderPath + oMainReport.sSnapShot1;
                imgLoader2.ImageUrl = UploadFolderPath + oMainReport.sSnapShot2;
                imgLoader3.ImageUrl = UploadFolderPath + oMainReport.sSnapShot3;

                txtHighlights.Text = oMainReport.sHighLight;
                txtLowlights.Text = oMainReport.sLowLight;
                txtLookahead.Text = oMainReport.sLookAhead;

                AGOStatus1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                AlarmRate1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                CathodicProtection1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                GeneratorAirCompressorStatus1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                HSSE1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                MeterStatus1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                POB1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                PTWSummary1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                TechnicalIntegrity1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
                WellTest1.Init_Page(oMainReport.iDistrict, oMainReport.lReportId);
            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        //The preview button calls the UPDATE method. Because, when the user selects the District on which PRD is to be reported, it automatically creates/Inserts PDR report for that day.
        //MainReport oMainReport = new MainReport();

        try
        {
            oMainReport.iUserId = oSessnx.getOnlineUser.m_iUserId;
            oMainReport.lReportId = long.Parse(lReportIdHF.Value);
            oMainReport.sHighLight = txtHighlights.Text;
            oMainReport.sLookAhead = txtLookahead.Text;
            oMainReport.sLowLight = txtLowlights.Text;

            filename1 = System.IO.Path.GetFileName(SnapShot1.FileName);
            filename2 = System.IO.Path.GetFileName(SnapShot2.FileName);
            filename3 = System.IO.Path.GetFileName(SnapShot3.FileName);

            oMainReport.sSnapShot1 = filename1;
            oMainReport.sSnapShot2 = filename2;
            oMainReport.sSnapShot3 = filename3;
            oMainReport.sSnapShot4 = "";
            oMainReport.sSnapShot5 = "";

            bool bRet = oMainReportHelper.UpdateMainReport(oMainReport);
            if (bRet)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Update Successful!!!");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        //Response.Redirect("~/App/PDR/PreviewForm.aspx?lReportId=" + lReportIdHF.Value);
    }


    //private string LoadSnapShot(FileUpload flSnapshot, Label statusLabel)
    //{
    //    string fileName = "";
    //    TimeDateCulture ourCulture = new TimeDateCulture();
    //    // Get CategoryID from the query string
    //    long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());

    //    if (flSnapshot.HasFile)
    //    {
    //        try
    //        {
    //            fileName = flSnapshot.FileName;

    //            string location = Server.MapPath("./Documents/") + fileName;
    //            // save image to server
    //            flSnapshot.SaveAs(location);
    //            bool success = false;
    //            //bool success = CatalogAccess.CreateDocument(lProjectId, txtTitle.Text, txtDescription.Text, fileName);
    //            // Display status message
    //            statusLabel.Text = success ? "Insert successful" : "Insert failed";
    //        }
    //        catch
    //        {
    //            statusLabel.Text = "Uploading image 1 failed";
    //        }
    //    }
    //    else
    //    {
    //        ajaxWebExtension.showJscriptAlert(Page, this, "No file selected for upload");
    //    }

    //    return fileName;
    //}
    protected void btnBroadcast_Click(object sender, EventArgs e)
    {
        //Send mail class here...
    }
}