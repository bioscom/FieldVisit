using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupSepcin_TradeTypes : aspnetPage
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
            idTradeTypeHF.Value = lbEdit.Attributes["ID_TRADE_TYPE"].ToString();

            if ((idTradeTypeHF.Value != null) || (idTradeTypeHF.Value != ""))
            {
                TradeType types = TradeType.objGetTradeTypeById(int.Parse(idTradeTypeHF.Value));
                txtTradeType.Text = types.m_sTRADE_TYPE;
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if ((idTradeTypeHF.Value == null) || (idTradeTypeHF.Value == ""))
        {
            bool bRet = TradeType.createTradeType(txtTradeType.Text);
            if (bRet == true)
            {
                loadData();

                string message = txtTradeType.Text + " successfully submitted.";
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
        }
        else
        {
            bool bRet = TradeType.updateTradeType(int.Parse(idTradeTypeHF.Value), txtTradeType.Text);
            if (bRet == true)
            {
                loadData();

                string updateMessage = txtTradeType.Text + " successfully updated.";
                ajaxWebExtension.showJscriptAlert(Page, this, updateMessage);
            }
        }
        Clear();
    }

    private void loadData()
    {
        grdView.DataSource = TradeType.dtGetTradeType();
        grdView.DataBind();
    }

    private void Clear()
    {
        txtTradeType.Text = "";
        idTradeTypeHF.Value = "";
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
