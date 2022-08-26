using System;
using Microsoft.Security.Application;
using System.Collections.Generic;

public partial class UserControl_oLeanProjectDetails : System.Web.UI.UserControl
{
    appUsersHelper oAppUsersHelper = new appUsersHelper();
    Department oDepartment = new Department();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    LkUpProjectType xLkUpProjectType = new LkUpProjectType();
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Init_Control(MainProjects oMainProjects)
    {
        lblProjectName.Text = Encoder.HtmlEncode(oMainProjects.sTitle);
        lblYear.Text = Encoder.HtmlEncode(oMainProjects.iYear.ToString());
        lblProjectType.Text = Encoder.HtmlEncode(xLkUpProjectType.objGetProjectTypeById(oMainProjects.iType).m_sProjectType);
        lblDepartment.Text = Encoder.HtmlEncode(oDepartment.objGetDeparmentById(oMainProjects.iDept).m_sDepartment);
        lblFunction.Text = Encoder.HtmlEncode(oFunctionMgt.objGetFunctionById(oMainProjects.iFunction).m_sFunction);

        lblChampion.Text = Encoder.HtmlEncode(oAppUsersHelper.objGetUserByUserID(oMainProjects.iChampion).m_sFullName);

        //lblCoach.Text = Encoder.HtmlEncode(oAppUsersHelper.objGetUserByUserID(oMainProjects.iCoach).m_sFullName);

        List<ProjectCoaches> lstProjectCoached = oMainProjectHelper.lstProjectCoaches(oMainProjects.lProjectId);
        foreach (ProjectCoaches oProjectCoach in lstProjectCoached)
        {
            lblCoach.Text += Encoder.HtmlEncode(oAppUsersHelper.objGetUserByUserID(oProjectCoach.iUserId).m_sFullName + "; ");
        }

        lblEndDate.Text = "";
        lblManager.Text = Encoder.HtmlEncode(oAppUsersHelper.objGetUserByUserID(oMainProjects.iManager).m_sFullName);
        lblSponsor.Text = Encoder.HtmlEncode(oAppUsersHelper.objGetUserByUserID(oMainProjects.iSponsor).m_sFullName);
    }
}