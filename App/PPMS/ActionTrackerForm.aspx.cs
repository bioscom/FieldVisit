using System;
using System.Web.UI.WebControls;
using CS.BLL.PPMS;

public partial class App_PPMS_ActionTrackerForm : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Disable Table rows
            tr2.Visible = false;
            tr4.Visible = false;
            tr6.Visible = false;

            //Load all the dropdown list controls
            var lstCategories = CategoryHelper.LstGetCategoryCategories();
            foreach (var oCategories in lstCategories)
            {
                ddlCategory.Items.Add(new ListItem(oCategories.SCategory, oCategories.CategoryId.ToString()));
            }
            ddlCategory.Items.Add(new ListItem(appEnumList.OthersDesc(appEnumList.mOthers.Others), ((int)appEnumList.mOthers.Others).ToString()));

            var lstThemeses = ThemesHelper.LstGeThemeses();
            foreach (var oTheme in lstThemeses)
            {
                ddlTheme.Items.Add(new ListItem(oTheme.STheme, oTheme.ThemeId.ToString()));
            }
            ddlTheme.Items.Add(new ListItem(appEnumList.OthersDesc(appEnumList.mOthers.Others), ((int)appEnumList.mOthers.Others).ToString()));

            var lstAsset = FunctionAssetHelper.LstGetAssets();
            foreach (var oAsset in lstAsset)
            {
                ddlAsset.Items.Add(new ListItem(oAsset.SAsset, oAsset.AssetId.ToString()));
            }
            ddlAsset.Items.Add(new ListItem(appEnumList.OthersDesc(appEnumList.mOthers.Others), ((int)appEnumList.mOthers.Others).ToString()));

            ddlImportance.Items.Add(new ListItem(appEnumList.ImportanceDesc(appEnumList.mImportance.H), ((int)appEnumList.mImportance.H).ToString()));
            ddlImportance.Items.Add(new ListItem(appEnumList.ImportanceDesc(appEnumList.mImportance.M), ((int)appEnumList.mImportance.M).ToString()));
            ddlImportance.Items.Add(new ListItem(appEnumList.ImportanceDesc(appEnumList.mImportance.L), ((int)appEnumList.mImportance.L).ToString()));

            ddlUrgency.Items.Add(new ListItem(appEnumList.UrgencyDesc(appEnumList.mUrgency.OverDue), ((int)appEnumList.mUrgency.OverDue).ToString()));
            ddlUrgency.Items.Add(new ListItem(appEnumList.UrgencyDesc(appEnumList.mUrgency.Ok), ((int)appEnumList.mUrgency.Ok).ToString()));
            ddlUrgency.Items.Add(new ListItem(appEnumList.UrgencyDesc(appEnumList.mUrgency.Na), ((int)appEnumList.mUrgency.Na).ToString()));

            ddlStatus.Items.Add(new ListItem(appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.NotStated), ((int)appEnumList.mProjectStatus.NotStated).ToString()));
            ddlStatus.Items.Add(new ListItem(appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.InProgress), ((int)appEnumList.mProjectStatus.InProgress).ToString()));
            ddlStatus.Items.Add(new ListItem(appEnumList.ProjectStatusDesc(appEnumList.mProjectStatus.Completed), ((int)appEnumList.mProjectStatus.Completed).ToString()));

            ddlActionParty.ErrorMssg("Action Party is required. Please, select N/A if Action Party not found, can be updated later.");
        }
    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
        ActionTrackerRegister oActionTracker = new ActionTrackerRegister();

        oActionTracker.ActionParty = appUsersHelper.objGetUserByUserId(int.Parse(ddlActionParty._SelectedValue));
        oActionTracker.Activities = txtActivities.Text;
        oActionTracker.Comments = txtComments.Text;
        oActionTracker.DateClosedOut = dtCloseOutDate.dtSelectedDate;
        oActionTracker.DateLastActioned = DateTime.Now.Date;
        oActionTracker.DateSubmitted = DateTime.Now.Date;
        oActionTracker.FocalPoint = appUsersHelper.objGetUserByUserId(oSessnx.getOnlineUser.m_iUserId);
        oActionTracker.Importance = int.Parse(ddlImportance.SelectedValue);
        oActionTracker.NextSteps = txtNextSteps.Text;
        oActionTracker.ProjectStatus = int.Parse(ddlStatus.SelectedValue);

        if (int.Parse(ddlCategory.SelectedValue) == (int) appEnumList.mOthers.Others)
        {
            var iCategoryId = 0;
            CategoryHelper.InsertCategory(txtCategory.Text, ref iCategoryId);
            oActionTracker.Tcategory = CategoryHelper.ObjGetCategoryById(iCategoryId);
        }
        else
        {
            oActionTracker.Tcategory = CategoryHelper.ObjGetCategoryById(int.Parse(ddlCategory.SelectedValue));
        }

        if (int.Parse(ddlAsset.SelectedValue) == (int) appEnumList.mOthers.Others)
        {
            var iAssetId = 0;
            FunctionAssetHelper.InsertAsset(txtFuncAsset.Text, ref iAssetId);
            oActionTracker.TfunctionAsset = FunctionAssetHelper.ObjGetAssetById(iAssetId);
        }
        else
        {
            oActionTracker.TfunctionAsset = FunctionAssetHelper.ObjGetAssetById(int.Parse(ddlAsset.SelectedValue));
        }

        if (int.Parse(ddlTheme.SelectedValue) == (int)appEnumList.mOthers.Others)
        {
            var iThemeId = 0;
            ThemesHelper.InsertTheme(txtTheme.Text, ref iThemeId);
            oActionTracker.Theme = ThemesHelper.ObjGetThemeById(iThemeId);
        }
        else
        {
            oActionTracker.Theme = ThemesHelper.ObjGetThemeById(int.Parse(ddlTheme.SelectedValue));
        }

        oActionTracker.Urgency = int.Parse(ddlUrgency.SelectedValue);
        oActionTracker.sAction = txtAction.Text;

        var bRet = ActionTrackerRegisterHelper.InsertActionTracker(oActionTracker);
        ajaxWebExtension.showJscriptAlert(Page, this,
            bRet
                ? "Your project was successfully submitted. Notification has been sent to the Action party."
                : "Your project was not submitted, try again later.");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/PPMS/Default.aspx");
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr2.Visible = int.Parse(ddlCategory.SelectedValue) == (int) appEnumList.mOthers.Others;
    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr4.Visible = int.Parse(ddlTheme.SelectedValue) == (int)appEnumList.mOthers.Others;
    }

    protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr6.Visible = int.Parse(ddlAsset.SelectedValue) == (int)appEnumList.mOthers.Others;
    }
}