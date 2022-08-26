using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_LastVisit : aspnetPage
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
            idLastVisitHF.Value = lbEdit.Attributes["ID_LAST_VISIT"].ToString();

            if ((idLastVisitHF.Value != null) || (idLastVisitHF.Value != ""))
            {
                FieldLastVisit oLastVisit = FieldLastVisit.objGetLastVisitById(int.Parse(idLastVisitHF.Value));
                txtLastVisit.Text = oLastVisit.m_sLAST_VISIT;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idLastVisitHF.Value == null) || (idLastVisitHF.Value == ""))
        {
            bool bRet = FieldLastVisit.createLastVisit(txtLastVisit.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtLastVisit.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = FieldLastVisit.updateLastVisit(int.Parse(idLastVisitHF.Value), txtLastVisit.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtLastVisit.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = FieldLastVisit.dtGetLastVisit();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtLastVisit.Text = "";
        idLastVisitHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
