using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FLBM_Register : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        KnowledgeSkillManager o = new KnowledgeSkillManager();
        DataTable dt = new DataTable();
        if (oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int)appUsersRoles.userRole.admin)
            dt = o.DtLoadAssessmentRegister();
        else
            dt = o.DtLoadMyAssessments(oSessnx.getOnlineUser.m_iUserId);

        grdView.DataSource = dt;
        grdView.DataBind();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("EditLinkButton");
        long lAssessId = long.Parse(edit.Attributes["ASSESSID"].ToString());
        Response.Redirect("~/App/FLBM/Assessment.aspx?lAssessId=" + lAssessId);
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton edit = (LinkButton)row.FindControl("ReportLinkButton");
        long lAssessId = long.Parse(edit.Attributes["ASSESSID"].ToString());
        int iAssesseeId = 0;
        Response.Redirect("~/App/FLBM/Report.aspx?lAssessId=" + lAssessId + "&iUId=" + iAssesseeId);
    }
}