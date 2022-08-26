using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using Microsoft.Security.Application;

public partial class UserControl_oBusinessInitiative : aspnetUserControl
{
    OUMgt oOuMgt = new OUMgt();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    TimeDateCulture ourCulture = new TimeDateCulture();

    //private struct fileProperties
    //{
    //    public string fileExtension;
    //    public string mimeType;
    //}

    //protected string UploadFolderPath = "~/ImageFiles/";

    //protected void FileUploadComplete(object sender, EventArgs e)
    //{
    //    fileProperties MyProperties = getFileProperties();
    //    if (MyProperties.fileExtension != "")
    //    {
    //        string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName); //+MyProperties.fileExtension;
    //        AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
    //    }
    //    else
    //    {
    //        ajaxWebExtension.showJscriptAlert(Page, this, MyProperties.mimeType + " format, is not a supported file format. Save your file with JPG, JPEG, GIF or PNG format.");
    //    }
    //}

    //private fileProperties getFileProperties()
    //{
    //    fileProperties MyProperties = new fileProperties();
    //    if (AsyncFileUpload1.HasFile)
    //    {
    //        MyProperties.mimeType = AsyncFileUpload1.PostedFile.ContentType;

    //        if (MyProperties.mimeType == "image/jpeg") { MyProperties.fileExtension = ".jpg"; }
    //        else if (MyProperties.mimeType == "image/pjpeg") { MyProperties.fileExtension = ".jpg"; }
    //        else if (MyProperties.mimeType == "image/gif") { MyProperties.fileExtension = ".gif"; }
    //        else if (MyProperties.mimeType == "image/png") { MyProperties.fileExtension = ".png"; }
    //    }

    //    return MyProperties;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page(long lInitiativeId)
    {
        try
        {
            List<OU> ous = oOuMgt.lstGetOUS();
            foreach (OU ou in ous)
            {
                drpOUs.Items.Add(new ListItem(ou.m_sOUS, ou.m_iOUId.ToString()));
            }

            List<Functions> Functions = oFunctionMgt.lstGetFunctions();
            foreach (Functions Function in Functions)
            {
                drpFunction.Items.Add(new ListItem(Function.m_sFunction, Function.m_iFunctionId.ToString()));
            }

            if (Request.QueryString["xMod"].ToString() == "Nor")
            {
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
                //ApproveSupportTabPanel.Visible = false;
            }
            else if (Request.QueryString["xMod"].ToString() == "Edt")
            {
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                //ApproveSupportTabPanel.Visible = false;

                lInitiativeMainPgHF.Value = lInitiativeId.ToString();

                //DistrictFacilitiesOU1.Init_Control(long.Parse(lInitiativeMainPgHF.Value.ToString()));

                LoadMyManHrInitiative(long.Parse(lInitiativeMainPgHF.Value.ToString()));
            }
            else if (Request.QueryString["xMod"].ToString() == "Viw")
            {
                btnSubmit.Visible = false;
                btnUpdate.Visible = false;
                //approvalTabPanel.Visible = false;

                txtBusinessCase.Enabled = false; txtScope.Enabled = false; txtSuccessFactors.Enabled = false;
                txtObjectives.Enabled = false; txtDeliverables.Enabled = false; txtTeamMember.Enabled = false;
                txtBenefit.Enabled = false; txtMeasures.Enabled = false; txtTitle.Enabled = false;
                txtKeyActivities.Enabled = false; drpOUs.Enabled = false; //drpFacilities.Enabled = false;drpDistrict.Enabled = false;
                drpFunction.Enabled = false;

                lInitiativeMainPgHF.Value = Encoder.HtmlEncode(Request.QueryString["IntiativeId"].ToString());

                LoadMyManHrInitiative(long.Parse(lInitiativeMainPgHF.Value.ToString()));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Initiative oInitiative = new Initiative();

        //bool suceess = oInitiative.UpdateInitiative(long.Parse(lInitiativeMainPgHF.Value.ToString()), oSessnx.getOnlineUser.m_iUserId, txtBusinessCase.Text,
        //    txtScope.Text, txtSuccessFactors.Text, txtObjectives.Text, txtDeliverables.Text, txtTeamMember.Text, txtBenefit.Text, txtMeasures.Text,
        //    txtTitle.Text, int.Parse(drpOUs.SelectedValue), int.Parse(drpFunction.SelectedValue), txtKeyActivities.Text, filenameHF.Value);
        bool suceess = oInitiative.UpdateInitiative(long.Parse(lInitiativeMainPgHF.Value.ToString()), oSessnx.getOnlineUser.m_iUserId, txtBusinessCase.Text,
            txtScope.Text, txtSuccessFactors.Text, txtObjectives.Text, txtDeliverables.Text, txtTeamMember.Text, txtBenefit.Text, txtMeasures.Text,
            txtTitle.Text, int.Parse(drpOUs.SelectedValue), int.Parse(drpFunction.SelectedValue), txtKeyActivities.Text, "");
        if (suceess)
        {
            LoadMyManHrInitiative(long.Parse(lInitiativeMainPgHF.Value.ToString()));
            ajaxWebExtension.showJscriptAlert(Page, this, "Initiative successfully updated.");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Initiative oInitiative = new Initiative();
        lInitiativeMainPgHF.Value = Initiative.getInitiativeId().ToString();

        oInitiative.m_lInitiativeId = long.Parse(lInitiativeMainPgHF.Value.ToString());
        oInitiative.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
        oInitiative.m_sBusinessCase = txtBusinessCase.Text;
        oInitiative.m_sScope = txtScope.Text;
        oInitiative.m_sSuccessFactor = txtSuccessFactors.Text;
        oInitiative.m_sObjectives = txtObjectives.Text;
        oInitiative.m_sDeliverables = txtDeliverables.Text;
        oInitiative.m_sTeamMembers = txtTeamMember.Text;
        oInitiative.m_sBenefits = txtBenefit.Text;
        oInitiative.m_sMeasures = txtMeasures.Text;
        oInitiative.m_sTitle = txtTitle.Text;
        oInitiative.m_iOuId = int.Parse(drpOUs.SelectedValue);
        //oInitiative.m_iFacilityId = int.Parse(drpFacilities.SelectedValue);
        oInitiative.m_iFunctionId = int.Parse(drpFunction.SelectedValue);
        oInitiative.m_sKeyActivities = txtKeyActivities.Text;

        //bool suceess = oInitiative.CreateInitiative(oInitiative.m_lInitiativeId, oInitiative.m_iUserId, oInitiative.m_sBusinessCase, oInitiative.m_sScope,
        //    oInitiative.m_sSuccessFactor, oInitiative.m_sObjectives, oInitiative.m_sDeliverables, oInitiative.m_sTeamMembers, oInitiative.m_sBenefits,
        //    oInitiative.m_sMeasures, oInitiative.m_sTitle, oInitiative.m_iOuId, oInitiative.m_iFunctionId, oInitiative.m_sKeyActivities, filenameHF.Value);
        bool suceess = oInitiative.CreateInitiative(oInitiative.m_lInitiativeId, oInitiative.m_iUserId, oInitiative.m_sBusinessCase, oInitiative.m_sScope,
            oInitiative.m_sSuccessFactor, oInitiative.m_sObjectives, oInitiative.m_sDeliverables, oInitiative.m_sTeamMembers, oInitiative.m_sBenefits,
            oInitiative.m_sMeasures, oInitiative.m_sTitle, oInitiative.m_iOuId, oInitiative.m_iFunctionId, oInitiative.m_sKeyActivities, "");
        if (suceess)
        {
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            //ResourceUtilisation1.Init_Control(long.Parse(lInitiativeMainPgHF.Value.ToString()));
            ajaxWebExtension.showJscriptAlert(Page, this, "Successfully Submitted, continue to Resource Utilisation.");

            Response.Redirect("~/App/ManHour/Forms/Default.aspx?xMod=Edt&IntiativeId=" + lInitiativeMainPgHF.Value.ToString());
        }
    }

    private void LoadMyManHrInitiative(long lInitiative)
    {
        Initiative ThisInitiative = Initiative.objGetInitiativeById(lInitiative);

        //Load Initiative
        //lblInitiativeTitle.Text = ThisInitiative.m_sTitle;

        txtBusinessCase.Text = ThisInitiative.m_sBusinessCase;
        txtScope.Text = ThisInitiative.m_sScope;
        txtSuccessFactors.Text = ThisInitiative.m_sSuccessFactor;
        txtObjectives.Text = ThisInitiative.m_sObjectives;
        txtDeliverables.Text = ThisInitiative.m_sDeliverables;
        txtTeamMember.Text = ThisInitiative.m_sTeamMembers;
        txtBenefit.Text = ThisInitiative.m_sBenefits;
        txtMeasures.Text = ThisInitiative.m_sMeasures;
        txtTitle.Text = ThisInitiative.m_sTitle;
        txtKeyActivities.Text = ThisInitiative.m_sKeyActivities;

        drpOUs.SelectedValue = ThisInitiative.m_iOuId.ToString();
        drpFunction.SelectedValue = ThisInitiative.m_iFunctionId.ToString();

        ////imgDisplay.Style.Clear();

        //if (ThisInitiative.m_sPixName != "")
        //{
        //    filenameHF.Value = ThisInitiative.m_sPixName;
        //    imgLoaderAlt.Attributes["style"] = "{ border:1px solid black; height:125px; width:250px; margin-top:2px }";
        //    imgLoaderAlt.ImageUrl = UploadFolderPath + ThisInitiative.m_sPixName;
        //}
    }

    [WebMethodAttribute(), ScriptMethodAttribute()]
    public string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        List<string> MyItems = new List<string>();

        Initiative oInitiative = new Initiative();
        List<Initiative> Initiatives = oInitiative.lstGetBusinessInitiativeByPrefixText(contextKey);
        foreach (Initiative initiative in Initiatives)
        {
            MyItems.Add(initiative.m_sTitle);
            //MyItems.Add(new ListItem(initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
        }

        return MyItems.ToArray();
    }
}