using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    static Proficiency tProficiency = new Proficiency();
    static Group tGroup = new Group();
    static Competencies tCompetencies = new Competencies();
    //KnowledgeSkill tKnowledgeSkill = new KnowledgeSkill();
	static Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void LoadGroups(DropDownList ddlGroup)
    {
        var lstGroup = tGroup.LstGroups();
        foreach (Group oGroup in lstGroup)
        {
            ddlGroup.Items.Add(new ListItem(oGroup.sGroups, oGroup.iGroupId.ToString()));
        }
    }
    public static void LoadProficiencies(DropDownList ddlProficiency)
    {
        ddlProficiency.Items.Clear();
        ddlProficiency.Items.Add(new ListItem("Select Proficiency", "-1"));

        var lstProficiency = tProficiency.LstProficiency();
        foreach (Proficiency oProficiency in lstProficiency)
        {
            ddlProficiency.Items.Add(new ListItem(oProficiency.sProficiency, oProficiency.iProficiencyId.ToString()));
        }
    }
    public static void LoadCompetenciesByGroup(int iGroupId, DropDownList ddlCompetency)
    {
        ddlCompetency.Items.Clear();
        ddlCompetency.Items.Add(new ListItem("Select Competency", "-1"));

        var lstCompetencies = tCompetencies.LstCompetenciesByGroup(iGroupId);
        foreach (Competencies oCompetence in lstCompetencies)
        {
            ddlCompetency.Items.Add(new ListItem(oCompetence.sCompetence, oCompetence.iCompetenceId.ToString()));
        }
    }
}