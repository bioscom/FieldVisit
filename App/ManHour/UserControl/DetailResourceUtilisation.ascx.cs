using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_DetailResourceUtilisation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(long lInitiativeId)
    {
        ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        ChildGrdView.DataSource = oResourceUtil.dtGetResourceUtilisationByInitiative(lInitiativeId);
        ChildGrdView.DataBind();
        lInitiativeHF.Value = lInitiativeId.ToString();
    }

    protected void ChildGrdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }

    protected void ChildGrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert"))
        {
            long lInitiativeId = long.Parse(lInitiativeHF.Value);

            ResourceUtilisation oResourceUtil = new ResourceUtilisation();
            int iDisciplineId = Convert.ToInt32(((DropDownList)ChildGrdView.FooterRow.FindControl("drpDiscipline")).SelectedValue);
            int iNoOfStaff = Convert.ToInt32(((TextBox)ChildGrdView.FooterRow.FindControl("txtNoOfStaff")).Text);
            int iMaxWorkHr = 10; // TODO: max work hr depends on the typr of staff selected, 10 for field staff, 8 for office staff. Convert.ToInt32(((Label)emptyRow.FindControl("lblMaxWrkHr")).Text);
            int iStaffUtilisation = Convert.ToInt32(((TextBox)ChildGrdView.FooterRow.FindControl("txtWrkHrUtil")).Text);

            oResourceUtil.CreateResourceUtilisation(lInitiativeId, iDisciplineId, iNoOfStaff, iStaffUtilisation, iMaxWorkHr);
            Init_Control(lInitiativeId);
        }

        if (e.CommandName.Equals("emptyInsert"))
        {
            long lMasterId = long.Parse(lInitiativeHF.Value);

            GridViewRow emptyRow = ChildGrdView.Controls[0].Controls[0] as GridViewRow;

            ResourceUtilisation oResourceUtil = new ResourceUtilisation();
            int iDisciplineId = Convert.ToInt32(((DropDownList)emptyRow.FindControl("drpDiscipline")).SelectedValue);
            int iNoOfStaff = Convert.ToInt32(((TextBox)emptyRow.FindControl("txtNoOfStaff")).Text);
            int iMaxWorkHr = 10; // TODO: max work hr depends on the typr of staff selected, 10 for field staff, 8 for office staff. Convert.ToInt32(((Label)emptyRow.FindControl("lblMaxWrkHr")).Text);
            int iStaffUtilisation = Convert.ToInt32(((TextBox)emptyRow.FindControl("txtWrkHrUtil")).Text);

            oResourceUtil.CreateResourceUtilisation(lMasterId, iDisciplineId, iNoOfStaff, iStaffUtilisation, iMaxWorkHr);
            Init_Control(lMasterId);
        }
    }

    protected void ChildGrdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lInitiativeId = long.Parse(lInitiativeHF.Value);
        ChildGrdView.EditIndex = -1;
        Init_Control(lInitiativeId);
    }
    protected void ChildGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ResourceUtilisation oResourceUtil = new ResourceUtilisation();
            ResourceUtilisation MyResourceUtil = oResourceUtil.objGetResourceUtilisationByResourceId(long.Parse(ChildGrdView.DataKeys[e.Row.RowIndex].Values[0].ToString()));

            Disciplines oDisciplines = new Disciplines();
            List<Disciplines> lstDisciplines = oDisciplines.lstGetDisciplines();

            DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
            if (drpDiscipline != null)
            {
                drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
                foreach (Disciplines discipline in lstDisciplines)
                {
                    drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
                }

                drpDiscipline.SelectedValue = MyResourceUtil.m_iDisciplineId.ToString();
            }
        }
    }
    protected void ChildGrdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lInitiativeId = long.Parse(lInitiativeHF.Value);
        ChildGrdView.EditIndex = e.NewEditIndex;
        Init_Control(lInitiativeId);

        long lResourceId = Convert.ToInt64(ChildGrdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        ResourceUtilisation ThisResourceUtil = oResourceUtil.objGetResourceUtilisationByResourceId(lResourceId);
    }
    protected void ChildGrdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        long lInitiativeId = long.Parse(lInitiativeHF.Value);

        ResourceUtilisation oResourceUtil = new ResourceUtilisation();

        long lResourceId = Convert.ToInt64(ChildGrdView.DataKeys[e.RowIndex].Values[0].ToString());
        int iDisciplineId = Convert.ToInt32(((DropDownList)ChildGrdView.Rows[e.RowIndex].FindControl("drpDiscipline")).SelectedValue);
        int iNoOfStaff = Convert.ToInt32(((Label)ChildGrdView.Rows[e.RowIndex].FindControl("lblNoOfStaff")).Text);
        int iMaxWorkHr = Convert.ToInt32(((Label)ChildGrdView.Rows[e.RowIndex].FindControl("lblMaxWrkHr")).Text);
        int iStaffUtilisation = Convert.ToInt32(((TextBox)ChildGrdView.Rows[e.RowIndex].FindControl("txtWrkHrUtil")).Text);

        oResourceUtil.UpdateResourceUtilisation(lResourceId, iDisciplineId, iNoOfStaff, iStaffUtilisation, iMaxWorkHr);

        ChildGrdView.EditIndex = -1;
        Init_Control(lInitiativeId);
    }

    protected void ChildGrdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lInitiativeId = long.Parse(lInitiativeHF.Value);
        long lResourceId = Convert.ToInt64(ChildGrdView.DataKeys[e.RowIndex].Values[0].ToString());

        ResourceUtilisation oResourceUtil = new ResourceUtilisation();
        oResourceUtil.deleteInitiative(lResourceId);
        Init_Control(lInitiativeId);
    }

    protected void ChildGrdView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        Disciplines oDisciplines = new Disciplines();
        List<Disciplines> lstDisciplines = oDisciplines.lstGetDisciplines();

        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
            if (drpDiscipline != null)
            {
                drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
                foreach (Disciplines discipline in lstDisciplines)
                {
                    drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList drpDiscipline = (DropDownList)e.Row.FindControl("drpDiscipline");
            if (drpDiscipline != null)
            {
                drpDiscipline.Items.Add(new ListItem("Select Discipline...", "-1"));
                foreach (Disciplines discipline in lstDisciplines)
                {
                    drpDiscipline.Items.Add(new ListItem(discipline.m_sDiscipline, discipline.m_iDisciplineId.ToString()));
                }
            }
        }
    }
    protected void drpDiscipline_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        DropDownList drpDiscipline = (DropDownList)gvr.FindControl("drpDiscipline");

        Disciplines oDisciplines = new Disciplines();
        Disciplines thisDisciplines = oDisciplines.objGetDisciplineById(Convert.ToInt32(((DropDownList)gvr.FindControl("drpDiscipline")).SelectedValue));

        Label lblMaxWrkHr = (Label)gvr.FindControl("lblMaxWrkHr");
        Label lblNoOfStaff = (Label)gvr.FindControl("lblNoOfStaff");
        //lblMaxWrkHr.Text = thisDisciplines.m_iMaxWkHr.ToString();
        //lblNoOfStaff.Text = thisDisciplines.m_iNoofStaff.ToString();
    }
}