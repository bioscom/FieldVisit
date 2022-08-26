using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_VisaType : aspnetPage
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
            idVisaTypeHF.Value = lbEdit.Attributes["ID_VISA"].ToString();

            if ((idVisaTypeHF.Value != null) || (idVisaTypeHF.Value != ""))
            {
                FieldVisaType oVisaType = FieldVisaType.objGetVisaTypeId(int.Parse(idVisaTypeHF.Value));
                txtVisaType.Text = oVisaType.m_sVISA_TYPE;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idVisaTypeHF.Value == null) || (idVisaTypeHF.Value == ""))
        {
            bool bRet = FieldVisaType.createVisaType(txtVisaType.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtVisaType.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = FieldVisaType.updateVisaType(int.Parse(idVisaTypeHF.Value), txtVisaType.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtVisaType.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = FieldVisaType.dtGetVisaType();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtVisaType.Text = "";
        idVisaTypeHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
