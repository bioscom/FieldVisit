using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_IES : System.Web.UI.Page
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

                EnableDisableControls();
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

    private void EnableDisableControls()
    {
        bool bRet = ddlEliminateImplement.BeginEliminate(int.Parse(ddlIdentifyKickOffMeeting.SelectedStatus),
                     int.Parse(ddlIdentifyProjectCharterCompleted.SelectedStatus),
                     int.Parse(ddlIdentifyProcessWalk.SelectedStatus),
                     int.Parse(ddlIdentifyVSM.SelectedStatus));
        if (bRet == true)
        {
            ddlEliminateRecommendationSignedOff.ddlSelector.Enabled = true;
            ddlEliminatePlanInPlace.ddlSelector.Enabled = true;
            ddlEliminateKaizenEvent.ddlSelector.Enabled = true;
            ddlEliminateImplement.ddlSelector.Enabled = true;

            ddlSustainHandOver.ddlSelector.Enabled = true;
            ddlSustainSOP.ddlSelector.Enabled = true;
            ddlSustainVisualMeasures.ddlSelector.Enabled = true;
        }
        else
        {
            ddlEliminateRecommendationSignedOff.ddlSelector.Enabled = false;
            ddlEliminatePlanInPlace.ddlSelector.Enabled = false;
            ddlEliminateKaizenEvent.ddlSelector.Enabled = false;
            ddlEliminateImplement.ddlSelector.Enabled = false;

            ddlSustainHandOver.ddlSelector.Enabled = false;
            ddlSustainSOP.ddlSelector.Enabled = false;
            ddlSustainVisualMeasures.ddlSelector.Enabled = false;
        }


        bRet = ddlEliminateImplement.BeginSustain(int.Parse(ddlEliminateImplement.SelectedStatus));
        if (bRet == true)
        {
            ddlSustainHandOver.ddlSelector.Enabled = true;
            ddlSustainSOP.ddlSelector.Enabled = true;
            ddlSustainVisualMeasures.ddlSelector.Enabled = true;
        }

        //bool bRet = ddlEliminateImplement.EliminateCanBeImplemented(int.Parse(ddlIdentifyKickOffMeeting.SelectedStatus),
        //     int.Parse(ddlIdentifyProjectCharterCompleted.SelectedStatus),
        //     int.Parse(ddlIdentifyProcessWalk.SelectedStatus),
        //     int.Parse(ddlIdentifyVSM.SelectedStatus),
        //     int.Parse(ddlEliminatePlanInPlace.SelectedStatus),
        //     int.Parse(ddlEliminateKaizenEvent.SelectedStatus),
        //     int.Parse(ddlEliminateRecommendationSignedOff.SelectedStatus));
        //if (bRet == true)
        //{
        //    ddlEliminateImplement.ddlSelector.Enabled = true;
        //}
        //else
        //{
        //    ddlEliminateImplement.ddlSelector.Enabled = true; //todo: Change to false when you are done with the update
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());

            //Insert 
            Identify oIdentify = new Identify();
            IdentifyHelper oIdentifyHelper = new IdentifyHelper();

            oIdentify.lProjectId = lProjectId;
            oIdentify.iCharterSignOffV = int.Parse(ddlIdentifyKickOffMeeting.SelectedStatus);
            oIdentify.iKickOffMeetingV = int.Parse(ddlIdentifyProjectCharterCompleted.SelectedStatus);
            oIdentify.iProcessWalkV = int.Parse(ddlIdentifyProcessWalk.SelectedStatus);
            oIdentify.iVSMV = int.Parse(ddlIdentifyVSM.SelectedStatus);

            Identify xIdentify = oIdentifyHelper.objGetIdentifyByProjectId(lProjectId);
            if (xIdentify.lProjectId == 0)
            {
                oIdentifyHelper.InsertIdentify(oIdentify);
            }
            else
            {
                oIdentifyHelper.UpdateIdentify(oIdentify);
            }

            //Insert Eliminate
            Eliminate oEliminate = new Eliminate();
            EliminateHelper oEliminateHelper = new EliminateHelper();

            oEliminate.lProjectId = lProjectId;
            oEliminate.iPIPV = int.Parse(ddlEliminatePlanInPlace.SelectedStatus);
            oEliminate.iHoldKaizenEventV = int.Parse(ddlEliminateKaizenEvent.SelectedStatus);
            oEliminate.iRecommendationSignedoffV = int.Parse(ddlEliminateRecommendationSignedOff.SelectedStatus);
            oEliminate.iImplementV = int.Parse(ddlEliminateImplement.SelectedStatus);

            Eliminate xEliminate = oEliminateHelper.objGetEliminateByProjectId(lProjectId);
            if (xEliminate.lProjectId == 0)
            {
                oEliminateHelper.InsertEliminate(oEliminate);
            }
            else
            {
                oEliminateHelper.UpdateEliminate(oEliminate);
            }

            //Insert Sustain
            Sustain oSustain = new Sustain();
            SustainHelper oSustainHelper = new SustainHelper();

            oSustain.lProjectId = lProjectId;
            oSustain.iHandOverV = int.Parse(ddlSustainHandOver.SelectedStatus);
            oSustain.iSPOP_V = int.Parse(ddlSustainSOP.SelectedStatus);
            oSustain.iVisual_MeasuresV = int.Parse(ddlSustainVisualMeasures.SelectedStatus);

            Sustain xSustain = oSustainHelper.objGetSustainByProjectId(lProjectId);
            if (xSustain.lProjectId == 0)
            {
                oSustainHelper.InsertSustain(oSustain);
            }
            else
            {
                oSustainHelper.UpdateSustain(oSustain);
            }

            EnableDisableControls();

            ajaxWebExtension.showJscriptAlert(Page, this, "Update successful.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
}