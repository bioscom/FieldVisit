using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_BI500_YourTeam : aspnetPage
{
    FunctionMgt oFunctionMgt = new FunctionMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Business Unit
            List<Functions> Functions = oFunctionMgt.lstGetFunctions();
            foreach (Functions Function in Functions)
            {
                if (Function.m_sFunction.ToUpper() != "N/A".ToUpper())
                {
                    drpBuzUnit.Items.Add(new ListItem(Function.m_sFunction, Function.m_iFunctionId.ToString()));
                }
            }

            ajaxWebExtension.showJscriptAlert(Page, this, "Please update your team information. You will not be able to submit Bright Idea until your team information is updated.");
        }
    }

    protected void drpBuzUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDepartment.Items.Clear();
        ddlDepartment.Items.Add(new ListItem("Select Department", "-1"));
        List<BIDepartments> oDepts = BIDepartments.lstGetDeparmentsByFunction(int.Parse(drpBuzUnit.SelectedValue));
        foreach (BIDepartments o in oDepts)
        {
            ddlDepartment.Items.Add(new ListItem(o.m_sDepartment, o.m_iDepartmentId.ToString()));
        }
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTeam.Items.Clear();
        ddlTeam.Items.Add(new ListItem("Select Team", "-1"));
        List<BITeams> oTeams = BITeams.lstGetTeamsByDepartment(int.Parse(ddlDepartment.SelectedValue));
        foreach (BITeams o in oTeams)
        {
            ddlTeam.Items.Add(new ListItem(o.m_sTeam, o.m_iTeamId.ToString()));
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BIUserTeam o = new BIUserTeam();

        o.m_iTeamId = int.Parse(ddlTeam.SelectedValue);
        o.m_iUserId = oSessnx.getOnlineUser.m_iUserId;

        bool bRet = o.AddNewTeamMember(o);
        if (bRet)
        {
            Response.Redirect("~/App/BI500/NewBizIntel.aspx");
        }
    }
}