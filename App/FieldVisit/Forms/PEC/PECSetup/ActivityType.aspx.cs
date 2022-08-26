using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_ActivityType : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdView.PageIndex = e.NewPageIndex;
        loadData();
    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

        if (ButtonClicked == "editThis")
        {
            LinkButton lbEdit = (LinkButton)grdView.Rows[index].FindControl("editLinkButton");
            idActivityTypeHF.Value = lbEdit.Attributes["ID_ACTIVITY_TYPE"].ToString();

            if ((idActivityTypeHF.Value != null) || (idActivityTypeHF.Value != ""))
            {
                ActivityType activity = ActivityType.objGetActivityTypeById(int.Parse(idActivityTypeHF.Value));
                activityTypeTextBox.Text = activity.m_sACTIVITY_TYPE;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idActivityTypeHF.Value == null) || (idActivityTypeHF.Value == ""))
        {
            bool bRet = ActivityType.createActivityType(activityTypeTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string message = activityTypeTextBox.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = ActivityType.updateActivityType(int.Parse(idActivityTypeHF.Value), activityTypeTextBox.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = activityTypeTextBox.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);

                //Response.Redirect("~/Setup/Superintendent.aspx");
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = ActivityType.dtGetActivityType();
        grdView.DataBind();
    }

    private void Clear()
    {
        activityTypeTextBox.Text = "";
        idActivityTypeHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
