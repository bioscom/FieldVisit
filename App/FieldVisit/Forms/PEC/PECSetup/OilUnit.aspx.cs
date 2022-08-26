using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_OilUnit : aspnetPage
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
            idUnitHF.Value = lbEdit.Attributes["ID_UNIT"].ToString();

            if ((idUnitHF.Value != null) || (idUnitHF.Value != ""))
            {
                Units oilUnit = Units.objGetUnitsById(int.Parse(idUnitHF.Value));
                txtOil.Text = oilUnit.m_sUNITS;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idUnitHF.Value == null) || (idUnitHF.Value == ""))
        {
            bool bRet = Units.createUnits(txtOil.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtOil.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = Units.updateUnits(int.Parse(idUnitHF.Value), txtOil.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtOil.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = Units.dtGetUnits();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtOil.Text = "";
        idUnitHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
