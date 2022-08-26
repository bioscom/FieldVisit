using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class App_BONGACCP_UserControl_InputUpdateCommitmentDetailsUpdt : System.Web.UI.UserControl
{
    DataTable dt = new DataTable();
    ActivityDetails o = new ActivityDetails();
    ActivityDetailsMgt dtlMgt = new ActivityDetailsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public void LoadDetails(long lCommitmentId)
    {
        CommitmentHF.Value = lCommitmentId.ToString();
        grdView.DataSource = dtlMgt.dtGetCommitmentDetailsByCommitmentId(lCommitmentId);
        grdView.DataBind();
    }

    public bool SaveDetails(long lCommitmentId)
    {
        bool bRet = false;
        try
        {
            dt = (DataTable) Session["dt"];
            foreach (DataRow dr in dt.Rows)
            {
                o.m_lCommitmentId = lCommitmentId;
                o.m_sDescription = dr["DESCRIPTION"].ToString();
                o.m_dRate = string.IsNullOrEmpty(dr["RATE"].ToString()) ? 0 : decimal.Parse(dr["RATE"].ToString());
                o.m_dQuantity = string.IsNullOrEmpty(dr["QUANTITY"].ToString()) ? 0 : decimal.Parse(dr["QUANTITY"].ToString());

                bRet = dtlMgt.Insert(o);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }

    public bool UpdateDetails(long lCommitmentId)
    {
        bool bRet = false;
        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                o.m_lCommitmentId = lCommitmentId;
                o.m_sDescription = dr["DESCRIPTION"].ToString();
                o.m_dRate = string.IsNullOrEmpty(dr["RATE"].ToString()) ? 0 : decimal.Parse(dr["RATE"].ToString());
                o.m_dQuantity = string.IsNullOrEmpty(dr["QUANTITY"].ToString()) ? 0 : decimal.Parse(dr["QUANTITY"].ToString());

                bRet = dtlMgt.Update(o);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            appMonitor.logAppExceptions(ex);
        }
        return bRet;
    }



    #region //Working with gridcontrol commands

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            long lCommitmentId = (!string.IsNullOrEmpty(CommitmentHF.Value) ? long.Parse(CommitmentHF.Value) : 0);
            if (e.CommandName.Equals("Insert"))
            {
                o.m_lCommitmentId = lCommitmentId;
                o.m_sDescription = Convert.ToString(((TextBox) grdView.FooterRow.FindControl("txtActivity")).Text);
                o.m_dRate = Convert.ToDecimal(((TextBox) grdView.FooterRow.FindControl("txtRate")).Text);
                o.m_dQuantity = Convert.ToDecimal(((TextBox) grdView.FooterRow.FindControl("txtQty")).Text);
                dtlMgt.Insert(o);

                LoadByCommitmentId(lCommitmentId);
            }

            if (e.CommandName.Equals("emptyInsert"))
            {
                GridViewRow emptyRow = grdView.Controls[0].Controls[0] as GridViewRow;

                o.m_lCommitmentId = lCommitmentId;
                o.m_sDescription = Convert.ToString(((TextBox)emptyRow.FindControl("txtActivity")).Text);
                o.m_dRate = Convert.ToDecimal(((TextBox) emptyRow.FindControl("txtRate")).Text);
                o.m_dQuantity = Convert.ToDecimal(((TextBox) emptyRow.FindControl("txtQty")).Text);
                dtlMgt.Insert(o);

                LoadByCommitmentId(lCommitmentId);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            appMonitor.logAppExceptions(ex);
        }
    }

    private void LoadByCommitmentId(long lCommitmentId)
    {
        dt = dtlMgt.dtGetCommitmentDetailsByCommitmentId(lCommitmentId);

        grdView.DataSource = dt;
        grdView.DataBind();
    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        long lCommitmentId = long.Parse(CommitmentHF.Value);
        grdView.EditIndex = -1;
        LoadByCommitmentId(lCommitmentId);
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        long lCommitmentId = long.Parse(CommitmentHF.Value);
        grdView.EditIndex = e.NewEditIndex;
        LoadByCommitmentId(lCommitmentId);

        //long lDetailsId = Convert.ToInt64(grdView.DataKeys[e.NewEditIndex].Values[0].ToString());
        //ActivityDetails o = dtlMgt.objGetActivityDetailsById(lDetailsId);

        //ASP.usercontrols_datecontrol_ascx FD = (ASP.usercontrols_datecontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("FDdateControl");
        //FD.setDate(oC.dFinishDate.ToString());

        //ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx)grdView.Rows[e.NewEditIndex].FindControl("oStatusControl");
        //ddlStatus.thisDropDown.SelectedValue = oC.iStatus.ToString();
    }
    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            long lCommitmentId = long.Parse(CommitmentHF.Value);
            o.m_lCommitmentId = lCommitmentId;
            o.m_lDetailsId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            o.m_sDescription = Convert.ToString(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtActivity")).Text);
            o.m_dRate = Convert.ToDecimal(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtRate")).Text);
            o.m_dQuantity = Convert.ToDecimal(((TextBox) grdView.Rows[e.RowIndex].FindControl("txtQty")).Text);

            dtlMgt.Update(o);
            grdView.EditIndex = -1;

            LoadByCommitmentId(lCommitmentId);

            //o.lCadenceId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            //o.sAction = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAction")).Text);
            //o.sActionParty = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtActionParty")).Text);
            //o.sThreat = Convert.ToString(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtThreat")).Text);
            //o.dFinishDate = FD.dtSelectedDate;

            //ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx ddlStatus = (ASP.app_bi500_usercontrol_cost_ostatuscontrol_ascx)grdView.Rows[e.RowIndex].FindControl("oStatusControl");
            //o.iStatus = Convert.ToInt16(ddlStatus.thisDropDown.SelectedValue);

            //oMS.UpdateCadence(o);

            //grdView.EditIndex = -1;
            //LoadCadenceByRequestId(lRequestId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long lCommitmentId = long.Parse(CommitmentHF.Value);
        o.m_lCommitmentId = lCommitmentId;
        long lDetailId = Convert.ToInt64(grdView.DataKeys[e.RowIndex].Values[0].ToString());

        dtlMgt.Delete(lDetailId);
        grdView.EditIndex = -1;

        LoadByCommitmentId(lCommitmentId);
    }

    #endregion

}