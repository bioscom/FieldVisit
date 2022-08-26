using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_Baggage : aspnetPage
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
            idBaggageHF.Value = lbEdit.Attributes["ID_BAG"].ToString();

            if ((idBaggageHF.Value != null) || (idBaggageHF.Value != ""))
            {
                FieldBaggage oBaggage = FieldBaggage.objGetBaggageId(int.Parse(idBaggageHF.Value));
                txtBaggage.Text = oBaggage.m_sBAGGAGE;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idBaggageHF.Value == null) || (idBaggageHF.Value == ""))
        {
            bool bRet = FieldBaggage.createBaggage(txtBaggage.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtBaggage.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = FieldBaggage.updateBaggage(int.Parse(idBaggageHF.Value), txtBaggage.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtBaggage.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = FieldBaggage.dtGetBaggage();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtBaggage.Text = "";
        idBaggageHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
