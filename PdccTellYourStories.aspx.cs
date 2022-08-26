using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;

public partial class PdccTellYourStories : System.Web.UI.Page
{
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    readonly AppsVisitorsHelper oAppsVisitorsHelper = new AppsVisitorsHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                _opportunityCostHelper.SiteVisitors();
                LoadReport();
                LoadReportBiding();
                LoggedOnUsers();
                MPE.Show();
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }  
    }

    private void LoggedOnUsers()
    {
        AppsVisitors oAppVisitor = oAppsVisitorsHelper.ObjGetLogonUsersToday();

        int iTotalCurrentlyLogonUsers = oAppVisitor.UsersNames.Split(',').Length - 1;
        string[] UsersNames = oAppVisitor.UsersNames.Split(',');

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (string s in UsersNames)
        {
            sb.Append(s + ", ");
        }

        string sLogonUsers = sb.ToString();

        lblLoggedOnUsers.Text = sb.ToString();
        lblTotalLoggedOnUsers.Text = stringRoutine.formatAsNumber(iTotalCurrentlyLogonUsers);

        lblDateLoggedIn.Text = oAppVisitor.DateLogon.ToLongDateString();
        lblTimeLoggedIn.Text = oAppVisitor.TimeLogon;
    }

    private void LoadReport()
    {
        try
        {
            lblDate.Text = " Date: " + DateTime.Today.ToLongDateString();
            lblMembers.Text = _opportunityCostHelper.iGetNumberOfMembers().ToString() + " members";
            lnkTopics.Text = _opportunityCostHelper.iGetNumberOfTopics().ToString() + " topics.";
            lnkMyTopics.Text = "My Topics(" + _opportunityCostHelper.iGetMyTopics(Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name)).ToString() + ")";

            grdView.DataSource = _opportunityCostHelper.dtGetStories();
            grdView.DataBind();            
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void LoadReportBiding()
    {
        try
        {
            foreach (GridViewRow grdRow in grdView.Rows)
            {
                Label lblAmtSaved = (Label)grdRow.FindControl("lblAmtSaved");
                if (!string.IsNullOrEmpty(lblAmtSaved.Text))
                {
                    lblAmtSaved.Text = "Amount Saved: $" + stringRoutine.formatAsBankMoney(decimal.Parse(lblAmtSaved.Text));
                }

                Repeater RepeaterImages = (Repeater)grdRow.FindControl("RepeaterImages");
                List<string> imgs = new List<string>();

                long lStoryId = Convert.ToInt64(grdView.DataKeys[grdRow.RowIndex].Values[0].ToString());
                TellYourStories oStory = _opportunityCostHelper.objGetStoryById(lStoryId);

                if (!string.IsNullOrEmpty(oStory.m_sFileName1)) imgs.Add(String.Format("~/App/PDCC/Data/{0}", oStory.m_sFileName1));
                if (!string.IsNullOrEmpty(oStory.m_sFileName2)) imgs.Add(String.Format("~/App/PDCC/Data/{0}", oStory.m_sFileName2));
                if (!string.IsNullOrEmpty(oStory.m_sFileName3)) imgs.Add(String.Format("~/App/PDCC/Data/{0}", oStory.m_sFileName3));
                if (!string.IsNullOrEmpty(oStory.m_sFileName4)) imgs.Add(String.Format("~/App/PDCC/Data/{0}", oStory.m_sFileName4));

                RepeaterImages.DataSource = imgs;
                RepeaterImages.DataBind();
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;

        LoadReport();
        LoadReportBiding();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            decimal dResult = 0;
            TellYourStories oTellUrStories = new TellYourStories();
            if (e.CommandName.Equals("Insert"))
            {
                oTellUrStories.m_sTitle = ((TextBox)grdView.FooterRow.FindControl("txtTitle")).Text;
                oTellUrStories.m_dAmtSaved = decimal.TryParse(((TextBox)grdView.FooterRow.FindControl("txtAmtSaved")).Text, out dResult)? decimal.Parse(((TextBox)grdView.FooterRow.FindControl("txtAmtSaved")).Text) : 0;
                oTellUrStories.m_sStory = ((TextBox)grdView.FooterRow.FindControl("txtStory")).Text;
                FileUpload FUpl1 = (FileUpload)grdView.FooterRow.FindControl("FUpl1");
                FileUpload FUpl2 = (FileUpload)grdView.FooterRow.FindControl("FUpl2");
                FileUpload FUpl3 = (FileUpload)grdView.FooterRow.FindControl("FUpl3");
                FileUpload FUpl4 = (FileUpload)grdView.FooterRow.FindControl("FUpl4");

                if (FUpl1.HasFile) oTellUrStories.m_sFileName1 = LoadFiles(FUpl1).sFileName; else oTellUrStories.m_sFileName1 = "";
                if (FUpl2.HasFile) oTellUrStories.m_sFileName2 = LoadFiles(FUpl2).sFileName; else oTellUrStories.m_sFileName2 = "";
                if (FUpl3.HasFile) oTellUrStories.m_sFileName3 = LoadFiles(FUpl3).sFileName; else oTellUrStories.m_sFileName3 = "";
                if (FUpl4.HasFile) oTellUrStories.m_sFileName4 = LoadFiles(FUpl4).sFileName; else oTellUrStories.m_sFileName4 = "";

                oTellUrStories.m_sUserName = Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name);

                _opportunityCostHelper.InsertStory(oTellUrStories);
                LoadReport();
                LoadReportBiding();
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

                oTellUrStories.m_sTitle = ((TextBox)emptyRow.FindControl("txtTitle")).Text;
                oTellUrStories.m_dAmtSaved = decimal.TryParse(((TextBox)emptyRow.FindControl("txtAmtSaved")).Text, out dResult) ? decimal.Parse(((TextBox)emptyRow.FindControl("txtAmtSaved")).Text) : 0;
                oTellUrStories.m_sStory = ((TextBox)emptyRow.FindControl("txtStory")).Text;
                FileUpload FUpl1 = (FileUpload)emptyRow.FindControl("FUpl1");
                FileUpload FUpl2 = (FileUpload)emptyRow.FindControl("FUpl2");
                FileUpload FUpl3 = (FileUpload)emptyRow.FindControl("FUpl3");
                FileUpload FUpl4 = (FileUpload)emptyRow.FindControl("FUpl4");

                if (FUpl1.HasFile) oTellUrStories.m_sFileName1 = LoadFiles(FUpl1).sFileName; else oTellUrStories.m_sFileName1 = "";
                if (FUpl2.HasFile) oTellUrStories.m_sFileName2 = LoadFiles(FUpl2).sFileName; else oTellUrStories.m_sFileName2 = "";
                if (FUpl3.HasFile) oTellUrStories.m_sFileName3 = LoadFiles(FUpl3).sFileName; else oTellUrStories.m_sFileName3 = "";
                if (FUpl4.HasFile) oTellUrStories.m_sFileName4 = LoadFiles(FUpl4).sFileName; else oTellUrStories.m_sFileName4 = "";

                oTellUrStories.m_sUserName = Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name);

                _opportunityCostHelper.InsertStory(oTellUrStories);
                LoadReport();
                LoadReportBiding();
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdView.EditIndex = -1;
        LoadReport();
        LoadReportBiding();
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        //    ResourceUtilisation MyResourceUtil = oResourceUtil.objGetResourceUtilisationByResourceId(long.Parse(grdView.DataKeys[e.Row.RowIndex].Values[0].ToString()));

        //    Disciplines oDisciplines = new Disciplines();
        //    List<Disciplines> lstDisciplines = oDisciplines.lstGetDisciplines();

        //    DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
        //    if (drpDiscipline != null)
        //    {
        //        drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
        //        foreach (Disciplines discipline in lstDisciplines)
        //        {
        //            drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
        //        }

        //        drpDiscipline.SelectedValue = MyResourceUtil.m_iDisciplineId.ToString();
        //    }
        //}
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            long lStoryId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
            TellYourStories oStory = _opportunityCostHelper.objGetStoryById(lStoryId);

            if(oStory.m_sUserName == Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name))
            {
                grdView.EditIndex = e.NewEditIndex;
                LoadReport();
                //LoadReportBiding();
            }
            else
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "This is not your story, you can not modify it. Tell your success stories.");
            }            
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            decimal dResult = 0;
            long lStoryId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            
            TellYourStories oTellUrStories = new TellYourStories();

            oTellUrStories = _opportunityCostHelper.objGetStoryById(lStoryId);

            oTellUrStories.m_lStoryId = lStoryId;
            oTellUrStories.m_sTitle = ((TextBox)grdView.Rows[e.RowIndex].FindControl("txtTitle")).Text;
            oTellUrStories.m_dAmtSaved = decimal.TryParse(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAmtSaved")).Text, out dResult) ? decimal.Parse(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAmtSaved")).Text) : 0;
            oTellUrStories.m_sStory = ((TextBox)grdView.Rows[e.RowIndex].FindControl("txtStory")).Text;

            FileUpload FUpl1 = (FileUpload)grdView.Rows[e.RowIndex].FindControl("FUpl1");
            FileUpload FUpl2 = (FileUpload)grdView.Rows[e.RowIndex].FindControl("FUpl2");
            FileUpload FUpl3 = (FileUpload)grdView.Rows[e.RowIndex].FindControl("FUpl3");
            FileUpload FUpl4 = (FileUpload)grdView.Rows[e.RowIndex].FindControl("FUpl4");

            if (FUpl1.HasFile) oTellUrStories.m_sFileName1 = LoadFiles(FUpl1).sFileName; //else oTellUrStories.m_sFileName1 = oTellUrStories.m_sFileName1;
            if (FUpl2.HasFile) oTellUrStories.m_sFileName2 = LoadFiles(FUpl2).sFileName; //else oTellUrStories.m_sFileName2 = oTellUrStories.m_sFileName2;
            if (FUpl3.HasFile) oTellUrStories.m_sFileName3 = LoadFiles(FUpl3).sFileName; //else oTellUrStories.m_sFileName3 = oTellUrStories.m_sFileName3;
            if (FUpl4.HasFile) oTellUrStories.m_sFileName4 = LoadFiles(FUpl4).sFileName; //else oTellUrStories.m_sFileName4 = oTellUrStories.m_sFileName4;

            _opportunityCostHelper.UpdateStory(oTellUrStories);

            grdView.EditIndex = -1;
            LoadReport();
            LoadReportBiding();

        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ////long lInitiativeId = long.Parse(lInitiativeHF.Value);
        //long lResourceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());

        //ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        //oResourceUtil.deleteInitiative(lResourceId);
        //LoadReport();
    }

    protected void grdView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Disciplines oDisciplines = new Disciplines();
        //List<Disciplines> lstDisciplines = oDisciplines.lstGetDisciplines();

        //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        //{
        //    DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
        //    if (drpDiscipline != null)
        //    {
        //        drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
        //        foreach (Disciplines discipline in lstDisciplines)
        //        {
        //            drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
        //        }
        //    }
        //}
        //else if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
        //    if (drpDiscipline != null)
        //    {
        //        drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
        //        foreach (Disciplines discipline in lstDisciplines)
        //        {
        //            drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
        //        }
        //    }
        //}
    }
    protected void lnkMyTopics_Click(object sender, EventArgs e)
    {
        try
        {
            grdView.DataSource = _opportunityCostHelper.dtGetStoryByUserName(Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name));
            grdView.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            grdView.DataSource = _opportunityCostHelper.dtGetStoryBySearch(txtSearch.Text);
            grdView.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private xfileProperty LoadFiles(FileUpload flName)
    {
        xfileProperty MyFileProperties = new xfileProperty();
        try
        {
            string oMessage = "";
            UploadFile oSaveFile = new UploadFile(); //UploadFile
            MyFileProperties = oSaveFile.UploadSelectedFile(flName, ref oMessage); //at this stage, the Project number has not been generated.

            ajaxWebExtension.showJscriptAlert(Page, this, oMessage);

            //oSaveFile.UploadSelectedFile()
            //WorkOrder1.LoadFileFromWorkOrder(MyFileProperties.sFileName);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return MyFileProperties;
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        decimal dResult = 0;
        TellYourStories oTellUrStories = new TellYourStories();

        oTellUrStories.m_sTitle = txtTitle.Text;
        oTellUrStories.m_dAmtSaved = decimal.TryParse(txtAmtSaved.Text, out dResult) ? decimal.Parse(txtAmtSaved.Text) : 0;
        oTellUrStories.m_sStory = txtStory.Text;

        if (FUpl1.HasFile) oTellUrStories.m_sFileName1 = LoadFiles(FUpl1).sFileName; else oTellUrStories.m_sFileName1 = "";
        if (FUpl2.HasFile) oTellUrStories.m_sFileName2 = LoadFiles(FUpl2).sFileName; else oTellUrStories.m_sFileName2 = "";
        if (FUpl3.HasFile) oTellUrStories.m_sFileName3 = LoadFiles(FUpl3).sFileName; else oTellUrStories.m_sFileName3 = "";
        if (FUpl4.HasFile) oTellUrStories.m_sFileName4 = LoadFiles(FUpl4).sFileName; else oTellUrStories.m_sFileName4 = "";

        oTellUrStories.m_sUserName = Apps.LoginIDNoDomain(System.Web.HttpContext.Current.User.Identity.Name);

        _opportunityCostHelper.InsertStory(oTellUrStories);

        LoadReport();
        LoadReportBiding();
    }
    protected void lnkTopics_Click(object sender, EventArgs e)
    {
        LoadReport();
        LoadReportBiding();
    }
    protected void lnkNewStory_Click(object sender, EventArgs e)
    {

    }
}