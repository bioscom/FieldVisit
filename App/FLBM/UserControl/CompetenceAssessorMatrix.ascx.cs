using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_FLBM_UserControl_CompetenceAssessorMatrixControl : System.Web.UI.UserControl
{
    KnowledgeSkillManager oManager = new KnowledgeSkillManager();
    Proficiency oProf = new Proficiency();
    Competencies oCompetence = new Competencies();
    Assessors oAssessors = new Assessors();
    AssessorsRights oAssessorsRights = new AssessorsRights();
    Group oGroup = new Group();

    public class mAccessEnum
    {
        public enum mAccess
        {
            none = 0, knowledge = 1, skill = 2, both = 3
        };


        public static string AccessDesc(mAccess eAccess)
        {
            string sRet = "NILL";
            try
            {
                switch (eAccess)
                {
                    case mAccess.none: sRet = "None"; break;
                    case mAccess.knowledge: sRet = "Knowledge"; break;
                    case mAccess.skill: sRet = "Skill"; break;
                    case mAccess.both: sRet = "Both"; break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            return sRet;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init(object sender, EventArgs e)
    {
        //Load Assessors
        var tAssessors = oAssessors.LstAssessors();
        foreach (Assessors o in tAssessors)
        {
            ddlAssessors.Items.Add(new ListItem(o.sFullName, o.iUserId.ToString()));
        }
    }

    private void GetProficiency(GridView grd)
    {
        foreach (GridViewRow oRows in grd.Rows)
        {
            CheckBoxList ckbProficiency = (CheckBoxList)oRows.FindControl("ckbProficiency");
            var Profs = oProf.LstProficiency();
            foreach (Proficiency oP in Profs)
            {
                ckbProficiency.Items.Add(new ListItem(oP.sProficiency, oP.iProficiencyId.ToString()));
            }
        }
    }


    private void NewStyle()
    {
        grdView.DataSource = oGroup.DtGetGroups();
        grdView.DataBind();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lblGroup = (Label)grdRow.FindControl("lblGroup");
            int iGroupId = int.Parse(lblGroup.Attributes["GROUPID"].ToString());

            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");

            DataTable dt = oCompetence.DtGetCompetenciesByGroup(iGroupId);

            if (dt.Rows.Count > 0)
            {
                oSubGrdView.DataSource = dt;
                oSubGrdView.DataBind();
            }
        }
    }


    private void GetAssessorRights(GridView grd)
    {
        if (oAssessorsRights.DtGetAssessorsRight(int.Parse(ddlAssessors.SelectedValue)).Rows.Count > 0)
        {
            //var LstAssessorRights = oAssessorsRights.LstAssessorsRights(int.Parse(ddlAssessors.SelectedValue));

            foreach (GridViewRow oRows in grd.Rows)
            {
                Label lblCompetence = (Label)oRows.FindControl("lblCompetence");
                long lCompetenceId = long.Parse(lblCompetence.Attributes["COMPETENCEID"]);

                CheckBoxList ckbProficiency = (CheckBoxList)oRows.FindControl("ckbProficiency");
                var o = oAssessorsRights.objGetAssessorsRightsByCompetence(int.Parse(ddlAssessors.SelectedValue), lCompetenceId);

                //foreach (var o in LstAssessorRights)
                //{
                //ckbProficiency.Items[0].Selected = false;
                //ckbProficiency.Items[1].Selected = false;

                if (o.iRight == (int)mAccessEnum.mAccess.knowledge)
                {
                    ckbProficiency.Items[0].Selected = true;
                    ckbProficiency.Items[1].Selected = false;
                }
                else if (o.iRight == (int)mAccessEnum.mAccess.skill)
                {
                    ckbProficiency.Items[0].Selected = false;
                    ckbProficiency.Items[1].Selected = true;
                }
                else if (o.iRight == (int)mAccessEnum.mAccess.both)
                {
                    ckbProficiency.Items[0].Selected = true;
                    ckbProficiency.Items[1].Selected = true;
                }
                //}

                //var Profs = oProf.LstProficiency();
                //foreach (Proficiency oP in Profs)
                //{
                //    ckbProficiency.Items.Add(new ListItem(oP.sProficiency, oP.iProficiencyId.ToString()));
                //}
            }
        }
    }

    protected void ddlAssessors_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////Load Matrix table
        //DataTable dt = oManager.DtGetCompetenceGroup();
        //grdGridView.DataSource = dt;
        //grdGridView.DataBind();

        //GetProficiency(grdGridView);
        //GetAssessorRights(grdGridView);

        NewStyle();

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");

            GetProficiency(oSubGrdView);
            GetAssessorRights(oSubGrdView);
        }
    }

    protected void grdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //iCompetenceId, iUserId, iRight = 0 or 1 or 2 or 3

        int iUserId = int.Parse(ddlAssessors.SelectedValue);
        int iRight = (int)mAccessEnum.mAccess.none;
        bool bRet = false;

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            GridView oSubGrdView = (GridView)grdRow.FindControl("subGrdView");

            foreach (GridViewRow oRows in oSubGrdView.Rows)
            {
                //Competence
                Label lblCompetence = (Label)oRows.FindControl("lblCompetence");
                long lCompetenceId = long.Parse(lblCompetence.Attributes["COMPETENCEID"]);

                //Right assigned
                CheckBoxList ckbProficiency = (CheckBoxList)oRows.FindControl("ckbProficiency");
                if ((ckbProficiency.Items[0].Selected) && (!ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.knowledge;
                else if ((!ckbProficiency.Items[0].Selected) && (ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.skill;
                else if ((ckbProficiency.Items[0].Selected) && (ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.both;
                else if ((!ckbProficiency.Items[0].Selected) && (!ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.none;

                //if iUserId exists on the table against the iCompetence, update the row, else insert new row for the user

                if (oAssessorsRights.DtGetAssessorsRightByCompetence(lCompetenceId, iUserId).Rows.Count > 0)
                {
                    bRet = oAssessorsRights.UpdateAssessorRight(iUserId, lCompetenceId, iRight);
                }
                else
                {
                    bRet = oAssessorsRights.InsertAssessorRight(iUserId, lCompetenceId, iRight);
                }
            }
        }

        //foreach (GridViewRow oRows in grdGridView.Rows)
        //{
        //    //Competence
        //    Label lblCompetence = (Label)oRows.FindControl("lblCompetence");
        //    long lCompetenceId = long.Parse(lblCompetence.Attributes["COMPETENCEID"]);

        //    //Right assigned
        //    CheckBoxList ckbProficiency = (CheckBoxList)oRows.FindControl("ckbProficiency");
        //    if ((ckbProficiency.Items[0].Selected) && (!ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.knowledge;
        //    else if ((!ckbProficiency.Items[0].Selected) && (ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.skill;
        //    else if ((ckbProficiency.Items[0].Selected) && (ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.both;
        //    else if ((!ckbProficiency.Items[0].Selected) && (!ckbProficiency.Items[1].Selected)) iRight = (int)mAccessEnum.mAccess.none;

        //    //if iUserId exists on the table against the iCompetence, update the row, else insert new row for the user

        //    if (oAssessorsRights.DtGetAssessorsRightByCompetence(lCompetenceId, iUserId).Rows.Count > 0)
        //    {
        //        bRet = oAssessorsRights.UpdateAssessorRight(iUserId, lCompetenceId, iRight);
        //    }
        //    else
        //    {
        //        bRet = oAssessorsRights.InsertAssessorRight(iUserId, lCompetenceId, iRight);
        //    }
        //}

        if (bRet)
        {
            string oMessage = "Assessors Competence checklist access right successfully submitted!!!";
            ajaxWebExtension.showJscriptAlert(Page, this, oMessage);
        }
    }
}