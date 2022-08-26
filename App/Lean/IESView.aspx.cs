using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_IESView : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProjectId"] != null)
            {
                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);

                oLeanProjectDetails1.Init_Control(oMainProject);

                Identify oIdentify = oIdentifyHelper.objGetIdentifyByProjectId(lProjectId);
                Eliminate oEliminate = oEliminateHelper.objGetEliminateByProjectId(lProjectId);
                Sustain oSustain = oSustainHelper.objGetSustainByProjectId(lProjectId);

                //Identify
                ddlIdentifyKickOffMeeting.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlIdentifyKickOffMeeting.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlIdentifyKickOffMeeting.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                ddlIdentifyProjectCharterCompleted.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlIdentifyProjectCharterCompleted.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlIdentifyProjectCharterCompleted.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                ddlIdentifyProcessWalk.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlIdentifyProcessWalk.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlIdentifyProcessWalk.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                ddlIdentifyVSM.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlIdentifyVSM.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing20), ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()));
                ddlIdentifyVSM.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes40), ((int)ProjectStatus.ProjStatus.Yes40).ToString()));

                //Eliminate
                ddlEliminatePlanInPlace.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlEliminatePlanInPlace.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlEliminatePlanInPlace.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                ddlEliminateKaizenEvent.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlEliminateKaizenEvent.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing20), ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()));
                ddlEliminateKaizenEvent.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes40), ((int)ProjectStatus.ProjStatus.Yes40).ToString()));

                ddlEliminateRecommendationSignedOff.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlEliminateRecommendationSignedOff.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlEliminateRecommendationSignedOff.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                ddlEliminateImplement.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlEliminateImplement.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlEliminateImplement.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                //Sustain
                ddlSustainSOP.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlSustainSOP.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing20), ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()));
                ddlSustainSOP.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes40), ((int)ProjectStatus.ProjStatus.Yes40).ToString()));

                ddlSustainVisualMeasures.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlSustainVisualMeasures.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing20), ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()));
                ddlSustainVisualMeasures.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes40), ((int)ProjectStatus.ProjStatus.Yes40).ToString()));

                ddlSustainHandOver.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted), ((int)ProjectStatus.ProjStatus.NotStarted).ToString()));
                ddlSustainHandOver.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10), ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()));
                ddlSustainHandOver.ddlSelector.Items.Add(new ListItem(ProjectStatus.status(ProjectStatus.ProjStatus.Yes20), ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()));

                LoadIdentify(oIdentify);
                LoadEliminate(oEliminate);
                LoadSustain(oSustain);

                ddlIdentifyKickOffMeeting.ddlSelector.Enabled = false;
                ddlIdentifyProjectCharterCompleted.ddlSelector.Enabled = false;
                    ddlIdentifyProcessWalk.ddlSelector.Enabled = false;
                    ddlIdentifyVSM.ddlSelector.Enabled = false;


                ddlEliminateRecommendationSignedOff.ddlSelector.Enabled = false;
                ddlEliminatePlanInPlace.ddlSelector.Enabled = false;
                ddlEliminateKaizenEvent.ddlSelector.Enabled = false;
                ddlEliminateImplement.ddlSelector.Enabled = false;

                ddlSustainHandOver.ddlSelector.Enabled = false;
                ddlSustainSOP.ddlSelector.Enabled = false;
                ddlSustainVisualMeasures.ddlSelector.Enabled = false;

                //bool bRet = ddlEliminateImplement.BeginEliminate(int.Parse(ddlIdentifyKickOffMeeting.SelectedStatus),
                //     int.Parse(ddlIdentifyProjectCharterCompleted.SelectedStatus),
                //     int.Parse(ddlIdentifyProcessWalk.SelectedStatus),
                //     int.Parse(ddlIdentifyVSM.SelectedStatus));
                //if (bRet == true)
                //{
                //    ddlEliminateRecommendationSignedOff.ddlSelector.Enabled = true;
                //    ddlEliminatePlanInPlace.ddlSelector.Enabled = true;
                //    ddlEliminateKaizenEvent.ddlSelector.Enabled = true;
                //    ddlEliminateImplement.ddlSelector.Enabled = true;

                //    ddlSustainHandOver.ddlSelector.Enabled = true;
                //    ddlSustainSOP.ddlSelector.Enabled = true;
                //    ddlSustainVisualMeasures.ddlSelector.Enabled = true;
                //}
                //else
                //{
                    
                //}

                //if (Request.QueryString["VIW"] == "V")
                //{
                //    //btnSubmit.Visible = false;

                //    //Identify
                //    if (ddlIdentifyKickOffMeeting.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlIdentifyKickOffMeeting.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlIdentifyKickOffMeeting.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlIdentifyKickOffMeeting.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlIdentifyKickOffMeeting.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlIdentifyKickOffMeeting.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlIdentifyProjectCharterCompleted.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlIdentifyProjectCharterCompleted.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlIdentifyProjectCharterCompleted.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlIdentifyProjectCharterCompleted.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlIdentifyProjectCharterCompleted.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlIdentifyProjectCharterCompleted.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlIdentifyProcessWalk.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlIdentifyProcessWalk.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlIdentifyProcessWalk.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlIdentifyProcessWalk.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlIdentifyProcessWalk.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlIdentifyProcessWalk.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlIdentifyVSM.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlIdentifyVSM.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlIdentifyVSM.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()) ddlIdentifyVSM.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlIdentifyVSM.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes40).ToString()) ddlIdentifyVSM.Attributes.Add("style", "color:GREEN; Font-Bold:True");


                //    //Eliminate
                //    if (ddlEliminatePlanInPlace.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlEliminatePlanInPlace.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlEliminatePlanInPlace.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlEliminatePlanInPlace.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlEliminatePlanInPlace.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlEliminatePlanInPlace.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlEliminateKaizenEvent.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlEliminateKaizenEvent.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlEliminateKaizenEvent.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()) ddlEliminateKaizenEvent.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlEliminateKaizenEvent.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes40).ToString()) ddlEliminateKaizenEvent.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlEliminateRecommendationSignedOff.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlEliminateRecommendationSignedOff.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlEliminateRecommendationSignedOff.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlEliminateRecommendationSignedOff.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlEliminateRecommendationSignedOff.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlEliminateRecommendationSignedOff.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlEliminateImplement.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlEliminateImplement.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlEliminateImplement.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlEliminateImplement.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlEliminateImplement.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlEliminateImplement.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    //Sustain
                //    if (ddlSustainSOP.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlSustainSOP.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlSustainSOP.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()) ddlSustainSOP.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlSustainSOP.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes40).ToString()) ddlSustainSOP.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlSustainVisualMeasures.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlSustainVisualMeasures.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlSustainVisualMeasures.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing20).ToString()) ddlSustainVisualMeasures.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlSustainVisualMeasures.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes40).ToString()) ddlSustainVisualMeasures.Attributes.Add("style", "color:GREEN; Font-Bold:True");

                //    if (ddlSustainHandOver.SelectedStatus == ((int)ProjectStatus.ProjStatus.NotStarted).ToString()) ddlSustainHandOver.Attributes.Add("style", "color:RED; Font-Bold:True");
                //    else if (ddlSustainHandOver.SelectedStatus == ((int)ProjectStatus.ProjStatus.Ongoing10).ToString()) ddlSustainHandOver.Attributes.Add("style", "color:ORANGE; Font-Bold:True");
                //    else if (ddlSustainHandOver.SelectedStatus == ((int)ProjectStatus.ProjStatus.Yes20 - 1).ToString()) ddlSustainHandOver.Attributes.Add("style", "color:GREEN; Font-Bold:True");
                //}
            }
        }
    }

    private void LoadIdentify(Identify oIdentify)
    {
        ddlIdentifyKickOffMeeting._SelectedValue(oIdentify.iKickOffMeetingV);
        ddlIdentifyProjectCharterCompleted._SelectedValue(oIdentify.iCharterSignOffV);
        ddlIdentifyProcessWalk._SelectedValue(oIdentify.iProcessWalkV);
        ddlIdentifyVSM._SelectedValue(oIdentify.iVSMV);
    }

    private void LoadEliminate(Eliminate oEliminate)
    {
        ddlEliminateRecommendationSignedOff._SelectedValue(oEliminate.iRecommendationSignedoffV);
        ddlEliminateKaizenEvent._SelectedValue(oEliminate.iHoldKaizenEventV);
        ddlEliminatePlanInPlace._SelectedValue(oEliminate.iPIPV);
        ddlEliminateImplement._SelectedValue(oEliminate.iImplementV);
    }

    private void LoadSustain(Sustain oSustain)
    {
        ddlSustainSOP._SelectedValue(oSustain.iSPOP_V);
        ddlSustainHandOver._SelectedValue(oSustain.iHandOverV);
        ddlSustainVisualMeasures._SelectedValue(oSustain.iVisual_MeasuresV);
    }
}