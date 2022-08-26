using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_ProjectRecommendation : aspnetPage
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    appUsersHelper oappUsersHelper = new appUsersHelper();
    RecommendationsHelper oRecommendationsHelper = new RecommendationsHelper();
    LkUpLeanTeamHelper oLkUpLeanTeamHelper = new LkUpLeanTeamHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ProjectId"] != null)
        {
            long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
            if (!IsPostBack)
            {
                MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);
                oLeanProjectDetails1.Init_Control(oMainProject);

                List<Functions> lstGetFunction = oFunctionMgt.lstGetFunctions();
                foreach (Functions oFunction in lstGetFunction)
                {
                    ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                    ddlActionParty.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                    ddlActionFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                }

                Status.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                Status.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                Status.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                pnlUpload.Visible = false;
                //List<appUsers> oappUsers = appUsersHelper.lstGetUsers();
                //foreach (appUsers oAppUser in oappUsers)
                //{
                //    ddlActionParty.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
                //}
            }
            LoadRecommendations(lProjectId);
        }
    }

    private void LoadRecommendations(long lProjectId)
    {
        grdGridView.DataSource = oRecommendationsHelper.dtGetLeanProjectRecommendationsByProjectId(lProjectId);
        grdGridView.DataBind();

        int i = 0;

        foreach (GridViewRow grdRow in grdGridView.Rows)
        {
            Label lblStatus = (Label)grdRow.FindControl("labelStatus");
            int iStatus = int.TryParse(lblStatus.Attributes["STATUS"].ToString(), out i) ? i : int.Parse(lblStatus.Attributes["STATUS"].ToString());
            if (iStatus == (int)ProjectStatus.ProjStatus.Ongoing10)
            {
                lblStatus.Text = ProjectStatus.status((ProjectStatus.ProjStatus)iStatus);
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                lblStatus.Font.Bold = true;
            }
            else if (iStatus == (int)ProjectStatus.ProjStatus.Yes20 - 1)
            {
                lblStatus.Text = ProjectStatus.status((ProjectStatus.ProjStatus)(int)ProjectStatus.ProjStatus.Yes20); //Please this place is very trickish
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Font.Bold = true;
            }
            else if (iStatus == (int)ProjectStatus.ProjStatus.NotStarted)
            {
                lblStatus.Text = ProjectStatus.status((ProjectStatus.ProjStatus)iStatus);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Font.Bold = true;
            }
        }

        if (Request.QueryString["VIW"] == "V")
        {
            EditLinkButton.Visible = false;
            grdGridView.Columns[1].Visible = false;
            //foreach (GridViewRow grdRow in grdGridView.Rows)
            //{
            //    LinkButton lnkEdit = (LinkButton)grdRow.FindControl("lnkEdit");
            //    lnkEdit.Visible = false;
            //}
        }
    }

    protected void cmdUpload_Click(object sender, EventArgs e)
    {
        string sRet = "There was an Error Processing Bulk-Load Operation. Task is Aborted";
        try
        {
            if (FUpBulkExcel.HasFile)
            {
                if (pathRoutines.fileExtnIsValid(FUpBulkExcel.FileName, pathRoutines.fileExtension.docXlsX))
                {
                    string sPath = Server.MapPath("~/App/Lean/eXls/");
                    string sTemp = dateRoutine.dateShort(DateTime.Now, "") + "_" + dateRoutine.timeLong(DateTime.Now);
                    sTemp = sTemp.Replace(":", ".");
                    sTemp = sTemp.Replace(" ", "");
                    sPath = sPath + this.oSessnx.getOnlineUser.m_sUserName + "_" + sTemp + ".xlsx";
                    FUpBulkExcel.PostedFile.SaveAs(sPath);

                    long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                    MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);

                    sRet = readUploadExcleFile(sPath, this.oSessnx.getOnlineUser, oMainProject.iYear);
                }
                else
                {
                    sRet = "An Invalid Microsoft Excel File (*.xlsx) provided for the requested Bulk-Load Operation. Task is Aborted";
                }
            }
            else
            {
                sRet = "No file was provided for the requested Bulk-Load Operation. Task is Aborted";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        ajaxWebExtension.showJscriptAlert(Page, this, sRet);
    }

    private string readUploadExcleFile(string sFilePath, appUsers eUserx, int iYear)
    {
        BulkLoading oBook = new BulkLoading();
        string sRet = "There was an Error Uploading the Specified Data File";
        try
        {
            string sErrList = "!";
            string sErrFile = Server.MapPath(urlRoutines.appendFileSysSlash("~/App/Lean/tempPrevXls/") + Guid.NewGuid().ToString() + ".txt");

            dataManager.dbItemErrorList myData = oBook.verifyImprovementRecommendationBulkLoad(sFilePath, sErrFile, sErrList, iYear);
            if ((myData.iItems > 0) && (myData.sErrorList == ""))
            {
                int iLoad = oBook.saveImprovementRecommendationBulkLoad(sFilePath, iYear);
                sRet = iLoad + " Total Entries were successfully Uploaded";
                //oBook.setOpexStatistics(eUserx.sUserId);
            }
            else
            {
                sRet = "Unable to Load the requested file. An email was sent to " + eUserx.m_sUserMail + " listing invalid entries";
                performanceMail oMail = new performanceMail(performanceMail.eManager());
                oMail.sendBulkLoadError(eUserx.structUserIdx, sErrFile, "CI Dashboard Improvement Recommendation bulk upload Mail:", "Improvement Recommendation");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return sRet;
    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        DataSorter sortMe = new DataSorter();

        try
        {
            if ((ButtonClicked == "Sort") || (ButtonClicked == "Page"))
            {
                
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

                if (ButtonClicked == "Benefit")
                {
                    LinkButton lbBenefit = (LinkButton)grdGridView.Rows[index].FindControl("BenefitLinkButton");
                    long lRecommendationId = long.Parse(lbBenefit.Attributes["RECOMMENDATIONID"].ToString());
                    long ProjectId = long.Parse(lbBenefit.Attributes["IDPROJECT"].ToString());
                    Response.Redirect("~/App/Lean/Benefit.aspx" + "?ProjectId=" + ProjectId + "&RecommendationId=" + lRecommendationId, false);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Recommendations oRecommendation = new Recommendations();

            oRecommendation.lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
            oRecommendation.iSeqId = 1;
            oRecommendation.iActionParty = int.Parse(ddlActionParty.SelectedValue);
            oRecommendation.iActionFunction = int.Parse(ddlActionFunction.SelectedValue);
            oRecommendation.iFunctionId = int.Parse(ddlFunction.SelectedValue);
            oRecommendation.iStatus = int.Parse(Status.SelectedStatus);
            oRecommendation.sChampionComment = txtChampionComment.Text;
            oRecommendation.sRecommendations = txtRecommendation.Text;
            oRecommendation.sSponsorComment = txtSponsorComment.Text;
            oRecommendation.dtTargetDate = targetDate.dtSelectedDate;
            oRecommendation.sComments = txtComments.Text;
            oRecommendation.sOtherBenefits = txtBenefit.Text;

            oRecommendation.dCostReduction = string.IsNullOrEmpty(txtCostReduction.Text) ? 0 : Convert.ToSingle(txtCostReduction.Text);
            oRecommendation.dCTReduction = string.IsNullOrEmpty(txtCTR.Text) ? 0 : Convert.ToSingle(txtCTR.Text);
            oRecommendation.dProductionBarrel = string.IsNullOrEmpty(txtProdEnhancmt.Text) ? 0 : Convert.ToSingle(txtProdEnhancmt.Text);
            oRecommendation.dNumber = string.IsNullOrEmpty(txtNumber.Text) ? 0 : Convert.ToSingle(txtNumber.Text);

            if ((lRecommendationIdHF.Value == null) || (lRecommendationIdHF.Value == ""))
            {
                oRecommendationsHelper.InsertRecommendation(oRecommendation);
            }
            else
            {
                oRecommendation.lRecommendationId = long.Parse(lRecommendationIdHF.Value);
                oRecommendationsHelper.UpdateRecommendation(oRecommendation);

                lRecommendationIdHF.Value = "";
            }

            LoadRecommendations(oRecommendation.lProjectId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void close_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton lnkEdit = (LinkButton)row.FindControl("lnkEdit");
                long lRecommendationId = long.Parse(lnkEdit.Attributes["RECOMMENDATIONID"]);

                lRecommendationIdHF.Value = lRecommendationId.ToString();

                Recommendations xRecommendation = new Recommendations();
                RecommendationsHelper oRecommendationsHelper = new RecommendationsHelper();

                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                Recommendations oRecommendations = oRecommendationsHelper.objGetLeanProjectRecommendationById(lRecommendationId);

                ddlFunction.SelectedValue = oRecommendations.iFunctionId.ToString();
                Status._SelectedValue(oRecommendations.iStatus);
                txtChampionComment.Text = oRecommendations.sChampionComment;
                txtRecommendation.Text = oRecommendations.sRecommendations;
                txtSponsorComment.Text = oRecommendations.sSponsorComment;
                targetDate.setDate(oRecommendations.dtTargetDate.ToString("dd/MMM/yyyy"));

                txtBenefit.Text = oRecommendations.sOtherBenefits;
                txtComments.Text = oRecommendations.sComments;
                txtCostReduction.Text = oRecommendations.dCostReduction.ToString();
                txtCTR.Text = oRecommendations.dCTReduction.ToString();
                txtProdEnhancmt.Text = oRecommendations.dProductionBarrel.ToString();
                txtNumber.Text = oRecommendations.dNumber.ToString();
                ddlActionParty.SelectedValue = oRecommendations.iActionParty.ToString();
                ddlActionFunction.SelectedValue = oRecommendations.iActionFunction.ToString();

                //oRecommendationsHelper.UpdateRecommendation(xRecommendation);

                //LoadRecommendations(lProjectId);

                //Show ModalPopUpExtender
                MPE.Show();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                LinkButton lnkEdit = (LinkButton)row.FindControl("lnkDelete");
                long lRecommendationId = long.Parse(lnkEdit.Attributes["RECOMMENDATIONID"]);

                RecommendationsHelper oRecommendationsHelper = new RecommendationsHelper();

                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                bool bRet = oRecommendationsHelper.DeleteRecommendation(lRecommendationId);
                if (bRet)
                {
                    LoadRecommendations(lProjectId);
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Delete not successful, try again later.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void EditLinkButton_Click(object sender, EventArgs e)
    {
        ddlFunction.ClearSelection();
        Status.ddlSelector.ClearSelection();
        txtChampionComment.Text = "";
        txtRecommendation.Text = "";
        txtSponsorComment.Text = "";
        targetDate.txtDateTextBox.Text = "";

        txtBenefit.Text = "";
        txtComments.Text = "";
        txtCostReduction.Text = "";
        txtCTR.Text = "";
        txtProdEnhancmt.Text = "";
        txtNumber.Text = "";
        ddlActionParty.ClearSelection();
        ddlActionFunction.ClearSelection();

        //Show ModalPopUpExtender
        MPE.Show();
    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlUpload.Visible = false;
        btnImprvRecommendation.Visible = true;
    }
    protected void btnImprvRecommendation_Click(object sender, EventArgs e)
    {
        pnlUpload.Visible = true;
        btnImprvRecommendation.Visible = false;
        hpkSample.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=imprvrec";
        hpkFunction.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=Fnct";
    }
}