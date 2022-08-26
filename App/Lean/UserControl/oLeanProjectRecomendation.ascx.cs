using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_UserControl_oLeanProjectRecomendation : System.Web.UI.UserControl
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    LkUpLeanTeamHelper oLkUpLeanTeamHelper = new LkUpLeanTeamHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(Recommendations oRecommendations)
    {
        lblActionParty.Text = oFunctionMgt.objGetFunctionById(oRecommendations.iActionParty).m_sFunction;
        lblChampionComment.Text = oRecommendations.sChampionComment;
        lblFunction.Text = oFunctionMgt.objGetFunctionById(oRecommendations.iFunctionId).m_sFunction;
        lblActionFunction.Text = oFunctionMgt.objGetFunctionById(oRecommendations.iActionFunction).m_sFunction;
        lblRecommendation.Text = oRecommendations.sRecommendations;
        lblSponsorComment.Text = oRecommendations.sSponsorComment;
        lblStatus.Text = oRecommendations.iStatus.ToString();
        lblTargetDate.Text = oRecommendations.dtTargetDate.ToString("dd/MMM/yyyy");
    }
}