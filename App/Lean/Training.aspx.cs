using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_Training : aspnetPage
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    Department xDepartment = new Department();
    TrainingHelper oTrainingHelper = new TrainingHelper();
    TrainingTypeHelper oTrainingTypeHelper = new TrainingTypeHelper();


    protected void Page_Load(object sender, EventArgs e)
    {
        bool bRet = false;
        try
        {
            string[] sPageAccess = { appUsersLeanRoles.userRole.Administrator.ToString(), appUsersLeanRoles.userRole.LeanCoach.ToString() };
            appUsersLeanRoles oAccess = new appUsersLeanRoles();
            bRet = oAccess.grantPageAccess(sPageAccess, (appUsersLeanRoles.userRole)this.oSessnx.getOnlineUser.m_iRoleIdLean);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
        if (!bRet) Response.Redirect("~/Profiles/pageDenied.aspx");


        if (!IsPostBack)
        {
            try
            {
                List<int> iYears = oMainProjectHelper.lstYears();
                foreach (int iYear in iYears)
                {
                    ddlYear.Items.Add(iYear.ToString());
                }

                ddlYear.SelectedValue = DateTime.Today.Year.ToString();

                List<TrainingType> oTrainingTypes = oTrainingTypeHelper.lstTrainingTypes();
                foreach (TrainingType oTrainingType in oTrainingTypes)
                {
                    ddlTrainingType.Items.Add(new ListItem(oTrainingType.sType, oTrainingType.iTypeId.ToString()));
                }

                List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
                foreach (Functions oFunction in oFunctions)
                {
                    ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                }

                List<Department> oDepartments = xDepartment.lstGetDeparments();
                foreach (Department oDepartment in oDepartments)
                {
                    ddlDept.Items.Add(new ListItem(oDepartment.m_sDepartment, oDepartment.m_iDepartmentId.ToString()));
                }
                getPersonsTrainedByYear();
                infoPanel.Visible = false;
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(AppConfiguration.LeanSiteName, ex.ToString());
            }
        }
    }
    protected void addButton_Click(object sender, EventArgs e)
    {
        try
        {
            Training oTraining = new Training();

            if (int.Parse(PersonTrained.thisDropDownList.SelectedValue) < 0)
            {
                ajaxWebExtension.showJscriptAlert(Page, this, "Please search for the person trained.");
            }
            else
            {
                oTraining.iDept = int.Parse(ddlDept.SelectedValue);
                oTraining.iFunction = int.Parse(ddlFunction.SelectedValue);
                oTraining.iTrainingType = int.Parse(ddlTrainingType.SelectedValue);
                oTraining.iUserId = int.Parse(PersonTrained.thisDropDownList.SelectedValue);
                oTraining.iYear = int.Parse(ddlYear.SelectedValue);
                oTraining.sTrainers = txtTrainers.Text;

                oTrainingHelper.InsertPersonTrained(oTraining);
                getPersonsTrainedByYear();

                infoPanel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void getPersonsTrainedByYear()
    {
        grdView.DataSource = oTrainingHelper.dtGetPersonsTrainedByYear(int.Parse(ddlYear.SelectedValue));
        grdView.DataBind();
    }

    protected void addLinkButton_Click(object sender, EventArgs e)
    {
        infoPanel.Visible = true;
    }
    protected void cancleButton_Click(object sender, EventArgs e)
    {
        infoPanel.Visible = false;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPersonsTrainedByYear();
    }


    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        getPersonsTrainedByYear();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdView.EditIndex = -1;
        getPersonsTrainedByYear();
    }

    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Training oTraining = oTrainingHelper.objGetPersonTrainedById(int.Parse(grdView.DataKeys[e.Row.RowIndex].Values[0].ToString()));

                //Person Trained
                //oTraining.iUserId = int.Parse(((UserControl_userFinder_Search4LocalUser2)grdView.Rows[e.RowIndex].FindControl("PersonTrained")).thisDropDownList.SelectedValue); 
                //int.Parse(PersonTrained.thisDropDownList.SelectedValue); 
                //((DropDownList)grdView.Rows[e.RowIndex].FindControl("drpBaggage")).SelectedValue

                ASP.usercontrols_userfinder_search4localuser2_ascx ddlPersonTrained = (ASP.usercontrols_userfinder_search4localuser2_ascx)e.Row.FindControl("ddlPersonTrained");
                appUsers oPersonTrained = appUsersHelper.objGetUserByUserId(oTraining.iUserId);
                if (ddlPersonTrained != null)
                {
                    ddlPersonTrained.editMode();
                    ddlPersonTrained.thisDropDownList.Items.Add(new ListItem(oPersonTrained.m_sFullName, oPersonTrained.m_iUserId.ToString()));
                    ddlPersonTrained.thisDropDownList.SelectedValue = oTraining.iUserId.ToString();
                }
                
                DropDownList ddlTrainingType = (DropDownList)e.Row.FindControl("ddlTrainingType");
                if (ddlTrainingType != null)
                {
                    ddlTrainingType.Items.Add(new ListItem("Select Training Type...", "-1"));
                    List<TrainingType> oTrainingTypes = oTrainingTypeHelper.lstTrainingTypes();
                    foreach (TrainingType oTrainingType in oTrainingTypes)
                    {
                        ddlTrainingType.Items.Add(new ListItem(oTrainingType.sType, oTrainingType.iTypeId.ToString()));
                    }

                    ddlTrainingType.SelectedValue = oTraining.iTrainingType.ToString();
                }

                DropDownList ddlFunction = (DropDownList)e.Row.FindControl("ddlFunction");
                if (ddlFunction != null)
                {
                    ddlFunction.Items.Add(new ListItem("Select Function...", "-1"));
                    List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
                    foreach (Functions oFunction in oFunctions)
                    {
                        ddlFunction.Items.Add(new ListItem(oFunction.m_sFunction, oFunction.m_iFunctionId.ToString()));
                    }
                    ddlFunction.SelectedValue = oTraining.iFunction.ToString();
                }

                DropDownList ddlDept = (DropDownList)e.Row.FindControl("ddlDept");
                if (ddlDept != null)
                {
                    ddlDept.Items.Add(new ListItem("Select Department...", "-1"));

                    List<Department> oDepartments = xDepartment.lstGetDeparments();
                    foreach (Department oDepartment in oDepartments)
                    {
                        ddlDept.Items.Add(new ListItem(oDepartment.m_sDepartment, oDepartment.m_iDepartmentId.ToString()));
                    }
                    ddlDept.SelectedValue = oTraining.iDept.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdView.EditIndex = e.NewEditIndex;
        getPersonsTrainedByYear();

        //PersonnelInfo personnelInfo = PersonnelInfo.objGetPersonnelInfoById(int.Parse(grdView.DataKeys[e.NewEditIndex].Values[0].ToString()));
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Training oTraining = new Training();

            oTraining.lTrainingId = long.Parse(grdView.DataKeys[e.RowIndex].Values[0].ToString());

            oTraining.iDept = int.Parse(((DropDownList)grdView.Rows[e.RowIndex].FindControl("ddlDept")).SelectedValue);
            oTraining.iFunction = int.Parse(((DropDownList)grdView.Rows[e.RowIndex].FindControl("ddlFunction")).SelectedValue);
            oTraining.iTrainingType = int.Parse(((DropDownList)grdView.Rows[e.RowIndex].FindControl("ddlTrainingType")).SelectedValue);
            oTraining.iUserId = int.Parse(((ASP.usercontrols_userfinder_search4localuser2_ascx)grdView.Rows[e.RowIndex].FindControl("ddlPersonTrained")).thisDropDownList.SelectedValue); //int.Parse(PersonTrained.thisDropDownList.SelectedValue); //((DropDownList)grdView.Rows[e.RowIndex].FindControl("drpBaggage")).SelectedValue
            oTraining.iYear = int.Parse(ddlYear.SelectedValue);
            oTraining.sTrainers = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtTrainers")).Text);

            oTrainingHelper.UpdatePersonTrained(oTraining);
            getPersonsTrainedByYear();

            grdView.EditIndex = -1;
            getPersonsTrainedByYear();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(AppConfiguration.appNameId, ex.ToString());
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //long lActivityId = long.Parse(ActivityIDHF.Value);

            //bool success = oTrainingHelper.DeletePersonTrained(lTrainingId);
            getPersonsTrainedByYear();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/Default.aspx");
    }
}