using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_UserControl_oFlareTarget : System.Web.UI.UserControl
{
    FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();
    FlareTargetHelper oHlp = new FlareTargetHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitPage()
    {
        if (!IsPostBack)
        {
            try
            {
                System.Data.DataTable dt = oHlp.dtGetFlareTarget(DateTime.Now.Year);
                grdView.DataSource = dt;
                grdView.DataBind();
            }
            catch (Exception ex)
            {
                appMonitor.logAppExceptions(ex);
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
        }
    }

    protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
        {
            string ButtonClicked = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            int iYear = DateTime.Now.Year;

            if (ButtonClicked == "Jan")
            {
                LinkButton lnkJan = (LinkButton)grdView.Rows[index].FindControl("lnkJan");
                string sCode = lnkJan.Attributes["CODE"].ToString();
                int iMonth = 01;
                decimal dFlareTarget = decimal.Parse(lnkJan.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Feb")
            {
                LinkButton lnkFeb = (LinkButton)grdView.Rows[index].FindControl("lnkFeb");
                string sCode = lnkFeb.Attributes["CODE"].ToString();
                int iMonth = 02;
                decimal dFlareTarget = decimal.Parse(lnkFeb.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Mar")
            {
                LinkButton lnkMar = (LinkButton)grdView.Rows[index].FindControl("lnkMar");
                string sCode = lnkMar.Attributes["CODE"].ToString();
                int iMonth = 03;
                decimal dFlareTarget = decimal.Parse(lnkMar.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Apr")
            {
                LinkButton lnkApr = (LinkButton)grdView.Rows[index].FindControl("lnkApr");
                string sCode = lnkApr.Attributes["CODE"].ToString();
                int iMonth = 04;
                decimal dFlareTarget = decimal.Parse(lnkApr.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "May")
            {
                LinkButton lnkMay = (LinkButton)grdView.Rows[index].FindControl("lnkMay");
                string sCode = lnkMay.Attributes["CODE"].ToString();
                int iMonth = 05;
                decimal dFlareTarget = decimal.Parse(lnkMay.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Jun")
            {
                LinkButton lnkJun = (LinkButton)grdView.Rows[index].FindControl("lnkJun");
                string sCode = lnkJun.Attributes["CODE"].ToString();
                int iMonth = 06;
                decimal dFlareTarget = decimal.Parse(lnkJun.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Jul")
            {
                LinkButton lnkJul = (LinkButton)grdView.Rows[index].FindControl("lnkJul");
                string sCode = lnkJul.Attributes["CODE"].ToString();
                int iMonth = 07;
                decimal dFlareTarget = decimal.Parse(lnkJul.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Aug")
            {
                LinkButton lnkAug = (LinkButton)grdView.Rows[index].FindControl("lnkAug");
                string sCode = lnkAug.Attributes["CODE"].ToString();
                int iMonth = 08;
                decimal dFlareTarget = decimal.Parse(lnkAug.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Sep")
            {
                LinkButton lnkSep = (LinkButton)grdView.Rows[index].FindControl("lnkSep");
                string sCode = lnkSep.Attributes["CODE"].ToString();
                int iMonth = 09;
                decimal dFlareTarget = decimal.Parse(lnkSep.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Oct")
            {
                LinkButton lnkOct = (LinkButton)grdView.Rows[index].FindControl("lnkOct");
                string sCode = lnkOct.Attributes["CODE"].ToString();
                int iMonth = 10;
                decimal dFlareTarget = decimal.Parse(lnkOct.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Nov")
            {
                LinkButton lnkNov = (LinkButton)grdView.Rows[index].FindControl("lnkNov");
                string sCode = lnkNov.Attributes["CODE"].ToString();
                int iMonth = 11;
                decimal dFlareTarget = decimal.Parse(lnkNov.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
            if (ButtonClicked == "Dec")
            {
                LinkButton lnkDec = (LinkButton)grdView.Rows[index].FindControl("lnkDec");
                string sCode = lnkDec.Attributes["CODE"].ToString();
                int iMonth = 12;
                decimal dFlareTarget = decimal.Parse(lnkDec.Text);

                Response.Redirect("~/App/FlareWaiver/ECFlareAnalyser.aspx?iM=" + iMonth + "&iY=" + iYear + "&sCd=" + sCode + "&Tgt=" + dFlareTarget);
            }
        }
    }

    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<Facility> lstFac = Facility.lstGetFacilities();

            FlareTarget o = oHlp.objGetFlareTargetByTargetId(long.Parse(grdView.DataKeys[e.Row.RowIndex].Values[0].ToString()));

            DropDownList ddlFacility = (DropDownList)e.Row.FindControl("drpFacilities");
            if (ddlFacility != null)
            {
                ddlFacility.Items.Add(new ListItem("Select Facility", "-1"));

                foreach (Facility lFac in lstFac)
                {
                    ddlFacility.Items.Add(new ListItem(lFac.m_sFacility, lFac.m_iFacilityId.ToString()));
                }
                ddlFacility.SelectedValue = o.iFacilityId.ToString();
            }
        }
    }
    protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdView.EditIndex = e.NewEditIndex;

        System.Data.DataTable dt = oHlp.dtGetFlareTarget(DateTime.Now.Year);
        grdView.DataSource = dt;
        grdView.DataBind();
    }

    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            FlareTarget oT = new FlareTarget();

            oT.lTargetId = long.Parse(grdView.DataKeys[e.RowIndex].Values[0].ToString());
            oT.iFacilityId = Convert.ToInt32(((DropDownList)grdView.Rows[e.RowIndex].FindControl("drpFacilities")).SelectedValue);
            oT.iJan = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJan")).Text);
            oT.iFeb = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtFeb")).Text);
            oT.iMar = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMar")).Text);
            oT.iApr = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtApr")).Text);
            oT.iMay = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtMay")).Text);
            oT.iJun = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJun")).Text);
            oT.iJul = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtJul")).Text);
            oT.iAug = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtAug")).Text);
            oT.iSep = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtSep")).Text);
            oT.iOct = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtOct")).Text);
            oT.iNov = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtNov")).Text);
            oT.iDec = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtDec")).Text);
            oT.iYTD = Convert.ToDecimal(((TextBox)grdView.Rows[e.RowIndex].FindControl("txtYTD")).Text);

            oHlp.Update(oT);

            grdView.EditIndex = -1;

            System.Data.DataTable dt = oHlp.dtGetFlareTarget(DateTime.Now.Year);
            grdView.DataSource = dt;
            grdView.DataBind();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdView.EditIndex = -1;
        InitPage();
    }
}