using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_UserControl_BenefitActual : aspnetUserControl
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    BenefitActualsHelper oBenefitActualsHelper = new BenefitActualsHelper();

    public void Init_Control(long lProjectId)
    {
        List<int> iYears = oMainProjectHelper.lstYearsExt();
        foreach (int iYear in iYears)
        {
            ddlYear.Items.Add(iYear.ToString());
        }

        ProjectIdHF.Value = lProjectId.ToString();
        LoadActualBenefits(lProjectId);

        if (oSessnx.getOnlineUser.m_iRoleIdLean != (int)appUsersLeanRoles.userRole.Administrator)
        {
            grdViewProjectBenefit.Columns[0].Visible = false;
            grdViewProjectBenefit.Columns[8].Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            BenefitActuals oBenefitActuals = new BenefitActuals();
            BenefitActuals thisBenefitActuals = new BenefitActuals();
            BenefitActualsHelper oBenefitActualsHelper = new BenefitActualsHelper();

            long lProjectId = long.Parse(ProjectIdHF.Value);

            //Get Project Benefit Actual for the selected Year By ProjectId
            //If found, then concatenate texts and add up values to reflect new status
            thisBenefitActuals = oBenefitActualsHelper.objGetProjectBenefitsByYear(lProjectId, int.Parse(ddlYear.SelectedValue));
            if (thisBenefitActuals.iYear != 0)
            {
                //Add up values, concatenate strings and update

                oBenefitActuals.iYear = int.Parse(ddlYear.SelectedValue);
                oBenefitActuals.lProjectId = lProjectId;

                oBenefitActuals.sCostSavings = thisBenefitActuals.sCostSavings + (string.IsNullOrEmpty(txtCostSavings.Text) ? 0 : decimal.Parse(txtCostSavings.Text));
                oBenefitActuals.sCTSavings = thisBenefitActuals.sCTSavings + (string.IsNullOrEmpty(txtCTSavings.Text) ? 0 : decimal.Parse(txtCTSavings.Text));
                oBenefitActuals.sProductionBarrel = thisBenefitActuals.sProductionBarrel + (string.IsNullOrEmpty(txtProdBarrel.Text) ? 0 : decimal.Parse(txtProdBarrel.Text));
                oBenefitActuals.sNumber = thisBenefitActuals.sNumber + (string.IsNullOrEmpty(txtNumber.Text) ? 0 : decimal.Parse(txtNumber.Text));

                oBenefitActuals.sOtherBenefits = thisBenefitActuals.sOtherBenefits + "[ ]" + txtBenefit.Text;
                oBenefitActuals.sComments = thisBenefitActuals.sComments + "[ ]" + txtComments.Text;

                oBenefitActualsHelper.UpdateBenefitActual(oBenefitActuals);
                LoadActualBenefits(lProjectId);
            }
            else
            {
                //Insert
                oBenefitActuals.iYear = int.Parse(ddlYear.SelectedValue);
                oBenefitActuals.lProjectId = lProjectId;

                oBenefitActuals.sCostSavings = string.IsNullOrEmpty(txtCostSavings.Text) ? 0 : decimal.Parse(txtCostSavings.Text);
                oBenefitActuals.sCTSavings = string.IsNullOrEmpty(txtCTSavings.Text) ? 0 : decimal.Parse(txtCTSavings.Text);

                oBenefitActuals.sProductionBarrel = string.IsNullOrEmpty(txtProdBarrel.Text) ? 0 : decimal.Parse(txtProdBarrel.Text);
                oBenefitActuals.sNumber = string.IsNullOrEmpty(txtNumber.Text) ? 0 : decimal.Parse(txtNumber.Text);

                oBenefitActuals.sComments = txtComments.Text;
                oBenefitActuals.sOtherBenefits = txtBenefit.Text;

                oBenefitActualsHelper.InsertBenefitActual(oBenefitActuals);
                LoadActualBenefits(lProjectId);
            }
            Clear();
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void Clear()
    {
        ddlYear.ClearSelection();
        //ProjectIdHF.Value = "";
        txtComments.Text = "";
        txtCostSavings.Text = "";
        txtCTSavings.Text = "";
        txtBenefit.Text = "";
        txtProdBarrel.Text = "";
        txtNumber.Text = "";
    }


    public void LoadActualBenefits(long lProjectId)
    {
        grdViewProjectBenefit.DataSource = oBenefitActualsHelper.dtProjectBenefits(lProjectId);
        grdViewProjectBenefit.DataBind();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
    protected void grdViewProjectBenefit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdViewProjectBenefit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lProjectId = long.Parse(ProjectIdHF.Value);
        grdViewProjectBenefit.EditIndex = -1;
        LoadActualBenefits(lProjectId);
    }
    protected void grdViewProjectBenefit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Delete
    }
    protected void grdViewProjectBenefit_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdViewProjectBenefit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        BenefitActuals oBenefitActuals = new BenefitActuals();
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("lnkDelete");
        long lActualId = long.Parse(lnkDelete.Attributes["ACTUALID"].ToString());
        long lProjectId = long.Parse(lnkDelete.Attributes["IDPROJECT"].ToString());

        oBenefitActuals.lActualId = lActualId;

        bool success = oBenefitActualsHelper.DeleteBenefitActual(oBenefitActuals);

        if (success)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Benefit Actual successfully deleted.");
        }
        LoadActualBenefits(lProjectId);
    }


    protected void grdViewProjectBenefit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lProjectId = long.Parse(ProjectIdHF.Value);
        grdViewProjectBenefit.EditIndex = e.NewEditIndex;
        LoadActualBenefits(lProjectId);
    }
    protected void grdViewProjectBenefit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            BenefitActuals oBenefitActuals = new BenefitActuals();

            oBenefitActuals.iYear = Convert.ToInt32(((Label)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("lbYear")).Text);
            oBenefitActuals.lProjectId = long.Parse(ProjectIdHF.Value);

            oBenefitActuals.sCostSavings = Convert.ToDecimal(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtCostSavings")).Text);
            oBenefitActuals.sCTSavings = Convert.ToDecimal(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtCTSavings")).Text);
            oBenefitActuals.sProductionBarrel = Convert.ToDecimal(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtProdBarrel")).Text);
            oBenefitActuals.sNumber = Convert.ToDecimal(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtNumber")).Text);

            oBenefitActuals.sOtherBenefits = Convert.ToString(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtBenefit")).Text);
            oBenefitActuals.sComments = Convert.ToString(((TextBox)grdViewProjectBenefit.Rows[e.RowIndex].FindControl("txtComments")).Text);

            oBenefitActualsHelper.UpdateBenefitActual(oBenefitActuals);

            grdViewProjectBenefit.EditIndex = -1;
            LoadActualBenefits(oBenefitActuals.lProjectId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}