using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_BaseData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void grdView_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Cancel edit mode
        grdView.EditIndex = -1;
        // Reload the grid
        BindGrid();
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        grdView.EditIndex = e.NewEditIndex;

        // Reload the grid
        BindGrid();
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        bool bRet = false;
        int iBaseId = grdView.DataKeys[e.RowIndex].Value.ToString() == "" ? 0 : int.Parse(grdView.DataKeys[e.RowIndex].Value.ToString());
        int iNoOfPersonnel = int.Parse(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNoOfPersonnel")).Text);
        int iBaseLoadPerMonth = int.Parse(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtBaseLoad")).Text);

        Label Discipline = (Label)grdView.Rows[e.RowIndex].FindControl("lblDiscipline");
        int iDiscipline = int.Parse(Discipline.Attributes["IDDISCIPLINE"].ToString());

        if (iBaseId == 0)
        {
            bRet = BasedataHelper.InsertIntoBaseData(iDiscipline, iNoOfPersonnel, iBaseLoadPerMonth);
        }
        else
        {
            bRet = BasedataHelper.UpdateBaseData(iBaseId, iDiscipline, iNoOfPersonnel, iBaseLoadPerMonth);
        }

        // Cancel edit mode
        grdView.EditIndex = -1;
        // Display status message
        string sMessage = bRet ? "Update successful" : "Update failed";
        ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
        // Reload the grid

        BindGrid();
    }

    private void BindGrid()
    {
       grdView.DataSource = BasedataHelper.dtGetBaseData();
       grdView.DataBind();
    }
}