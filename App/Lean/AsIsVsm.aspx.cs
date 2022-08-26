using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_AsIsVsm : aspnetPage
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    VSMASISHelper oVSMASISHelper = new VSMASISHelper();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    LkUpLeanTimeHelper oLkUpLeanTimeHelper = new LkUpLeanTimeHelper();
    LkUpWasteCategoryHelper oLkUpWasteCategoryHelper = new LkUpWasteCategoryHelper();
    LkUpSuppliersHelper oLkUpSuppliersHelper = new LkUpSuppliersHelper();
    LkUpCustomersHelper oLkUpCustomersHelper = new LkUpCustomersHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProjectId"] != null)
        {
            long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
            if (!IsPostBack)
            {
                pnlUpload.Visible = false;

                MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);
                oLeanProjectDetails1.Init_Control(oMainProject);

                List<Functions> lstGetFunction = oFunctionMgt.lstGetFunctions();
                foreach (Functions oFunction in lstGetFunction)
                {
                    ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                }

                List<LkUpLeanTime> lstLeanTime = oLkUpLeanTimeHelper.lstGetLkUpLeanTime();
                foreach (LkUpLeanTime oLkUpLeanTime in lstLeanTime)
                {
                    ddlPLTUnit.Items.Add(new ListItem(oLkUpLeanTime.sUnit, oLkUpLeanTime.iTimeId.ToString()));
                    ddlPVatUnit.Items.Add(new ListItem(oLkUpLeanTime.sUnit, oLkUpLeanTime.iTimeId.ToString()));
                }

                List<LkUpWasteCategory> lstWasteCategory = oLkUpWasteCategoryHelper.lstGetWasteCategory();
                foreach (LkUpWasteCategory oLkUpWasteCategory in lstWasteCategory)
                {
                    ddlWasteCategory.Items.Add(new ListItem(oLkUpWasteCategory.sWaste, oLkUpWasteCategory.iWasteId.ToString()));
                }
            }
            LoadVSM(lProjectId);
        } 
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnkEdit = (LinkButton)row.FindControl("lnkEdit");

            long lAsIsId = long.Parse(lnkEdit.Attributes["IDVSMASIS"]);
            lVsmAsIsIdHF.Value = lAsIsId.ToString();

            VSMASIS oASISVsm = oVSMASISHelper.objGetVSMASISByVsmAsIsId(lAsIsId);

            lblProject.Text = oMainProjectHelper.objGetLeanProjectsByProjectId(oASISVsm.lProjectId).sTitle;
            ddlFunction.SelectedValue = oASISVsm.iFunctionId.ToString();
            txtActivityDesc.Text = oASISVsm.sActivityDesc;
            txtCustomer.Text = oASISVsm.sCustomer;
            txtImprovement.Text = oASISVsm.sImprovement;
            txtInput.Text = oASISVsm.sInput;
            txtOutput.Text = oASISVsm.sOutPut;
            lblLtMin.Text = "";//oASISVsm.dProcessLtMin.ToString();
            txtProcessLT.Text = oASISVsm.dProcessLt.ToString();
            txtProcessVat.Text = oASISVsm.dProcessVat.ToString();
            lblVatMin.Text = "";//oASISVsm.dProcessVatMin.ToString();
            txtWasteCode.Text = oASISVsm.sWasteCode;
            ddlPLTUnit.SelectedValue = oASISVsm.iProcessLtUnit.ToString();
            ddlPVatUnit.SelectedValue = oASISVsm.iProcessVatUnit.ToString();
            txtSupplier.Text = oASISVsm.sSupplier;
            ddlWasteCategory.SelectedValue = oASISVsm.iWasteCat.ToString();

            //Show ModalPopUpExtender
            MPE.Show();
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            LinkButton lnkDelete = (LinkButton)row.FindControl("lnkDelete");

            long lAsIsId = long.Parse(lnkDelete.Attributes["IDVSMASIS"]);
            bool bRet = oVSMASISHelper.DeleteVsmAsIs(lAsIsId);

            if(bRet)
            {
                LoadVSM(lProjectId);
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Delete not successful, try again later.");
            }
        }
    }

    protected void EditLinkButton_Click(object sender, EventArgs e)
    {
        //Show ModalPopUpExtender
        MPE.Show();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //VSMASIS oVSMASIS = oVSMASISHelper.objGetVSMASISByVsmAsIsId(lAsIsId);
        VSMASIS oVSMASIS = new VSMASIS();
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());

        lblProject.Text = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId).sTitle;

        oVSMASIS.sCustomer = txtCustomer.Text;
        oVSMASIS.iFunctionId = int.Parse(ddlFunction.SelectedValue);
        oVSMASIS.iProcessLtUnit = int.Parse(ddlPLTUnit.SelectedValue);
        oVSMASIS.iProcessVatUnit = int.Parse(ddlPVatUnit.SelectedValue);
        oVSMASIS.iSeqId = 1; //TODO: Please sort out this code, it is very important. It is sequencial in the Bulk Upload, trying to see how to resolve this.
        oVSMASIS.sSupplier = txtSupplier.Text;
        oVSMASIS.iWasteCat = int.Parse(ddlWasteCategory.SelectedValue);
        oVSMASIS.lProjectId = lProjectId;
        oVSMASIS.sActivityDesc = txtActivityDesc.Text;
        oVSMASIS.sImprovement = txtImprovement.Text;
        oVSMASIS.sInput = txtInput.Text;
        oVSMASIS.sOutPut = txtOutput.Text;
        oVSMASIS.dProcessLt = decimal.Parse(txtProcessLT.Text);
        oVSMASIS.dProcessVat = decimal.Parse(txtProcessVat.Text);
        oVSMASIS.sWasteCode = txtWasteCode.Text;
        
        if ((lVsmAsIsIdHF.Value == null) || (lVsmAsIsIdHF.Value == ""))
        {
            oVSMASISHelper.InsertVsmAsIs(oVSMASIS);
        }
        else
        {
            oVSMASIS.lVsmAsIsId = long.Parse(lVsmAsIsIdHF.Value);
            oVSMASISHelper.UpdateVsmAsIs(oVSMASIS);

            lVsmAsIsIdHF.Value = "";
        }

        LoadVSM(lProjectId);
    }
    protected void grdGridView_Load(object sender, EventArgs e)
    {

    }
    protected void grdGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGridView.PageIndex = e.NewPageIndex;
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        LoadVSM(lProjectId);
    }
    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grdGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void closeButton_Click(object sender, EventArgs e)
    {

    }
    private void LoadVSM(long lProjectId)
    {
        grdGridView.DataSource = oVSMASISHelper.dtGetVSMASISByProjectId(lProjectId);
        grdGridView.DataBind();

        if (Request.QueryString["VIW"] == "V")
        {
            EditLinkButton.Visible = false;
            btnVSM.Visible = false;
            grdGridView.Columns[1].Visible = false;
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
    protected void btnVSM_Click(object sender, EventArgs e)
    {
        pnlUpload.Visible = true;
        btnVSM.Visible = false;
        hpkSample.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=vsmasis";
        hpkFunction.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=Fnct";
        hpkProcessLTVATUnit.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=LtVat";
        hpkWasteCategory.NavigateUrl = "~/Handlers/templateHandlers.ashx?Msg=WstCat";
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlUpload.Visible = false;
        btnVSM.Visible = true;
    }
    private string readUploadExcleFile(string sFilePath, appUsers eUserx, int iYear)
    {
        BulkLoading oBook = new BulkLoading();
        string sRet = "There was an Error Uploading the Specified Data File";
        try
        {
            string sErrList = "!";
            string sErrFile = Server.MapPath(urlRoutines.appendFileSysSlash("~/App/Lean/tempPrevXls/") + Guid.NewGuid().ToString() + ".txt");

            dataManager.dbItemErrorList myData = oBook.verifyVSMAsIsBulkLoad(sFilePath, sErrFile, sErrList, iYear);
            if ((myData.iItems > 0) && (myData.sErrorList == ""))
            {
                int iLoad = oBook.saveVSMAsIsBulkLoad(sFilePath, iYear);
                sRet = iLoad + " Total Entries were successfully Uploaded";
                //oBook.setOpexStatistics(eUserx.sUserId);
            }
            else
            {
                sRet = "Unable to Load the requested file. An email was sent to " + eUserx.m_sUserMail + " listing invalid entries";
                performanceMail oMail = new performanceMail(performanceMail.eManager());
                oMail.sendBulkLoadError(eUserx.structUserIdx, sErrFile, "CI Dashboard As Is VSM bulk upload Mail:", "As Is VSM");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return sRet;
    }
    protected void close_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
}