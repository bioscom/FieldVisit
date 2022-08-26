using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_FieldContact : aspnetPage
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
            idContactPersonHF.Value = lbEdit.Attributes["ID_CONTACT"].ToString();

            if ((idContactPersonHF.Value != null) || (idContactPersonHF.Value != ""))
            {
                FieldContactPerson oContactPerson = FieldContactPerson.objGetContactPersonById(int.Parse(idContactPersonHF.Value));
                txtContactPerson.Text = oContactPerson.m_sCONTACT_PERSON;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idContactPersonHF.Value == null) || (idContactPersonHF.Value == ""))
        {
            bool bRet = FieldContactPerson.createContactPerson(txtContactPerson.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtContactPerson.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = FieldContactPerson.updateContactPerson(int.Parse(idContactPersonHF.Value), txtContactPerson.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtContactPerson.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = FieldContactPerson.dtGetContactPerson();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtContactPerson.Text = "";
        idContactPersonHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
