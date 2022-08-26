using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Contract_UserControls_Start14DaysContract : aspnetUserControl
{
    ContractActivitiesHelper oContractActivitiesHelper = new ContractActivitiesHelper();
    ContractActivitiesRecordedHelper oContractActivitiesRecordedHelper = new ContractActivitiesRecordedHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oContractActivitiesHelper.LoadDistrict(ddlDistrict);
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(dtTripStart.SelectedDate))
        {
            lblAssetArea.Text = ddlDistrict.SelectedItem.Text;

            if (oSessnx.getOnlineUser.m_iRoleIdContract == (int)appUsersRoles.userRole.admin)
            {
                LoadData();
            }
            else
            {
                SuperintendentFunctionalAcctUser MySuperintendents = SuperintendentFunctionalAcctUser.objGetSuperintendentFunctionalAcctByUserId(oSessnx.getOnlineUser.m_iUserId);
                if (MySuperintendents.superintendentId == 0)
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, "Sorry, You do not have right to enter data for " + ddlDistrict.SelectedItem.Text + " District. Contact the System Administrator.");
                }
                else
                {
                    LoadData();
                }
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "Please select trip start date!!!");
            ddlDistrict.ClearSelection();
        }
    }

    private void LoadData()
    {
        grdView.Columns[4].HeaderText = dtTripStart.dtSelectedDate.AddDays(1).ToString("ddd, MMM d");
        grdView.Columns[5].HeaderText = dtTripStart.dtSelectedDate.AddDays(2).ToString("ddd, MMM d");
        grdView.Columns[6].HeaderText = dtTripStart.dtSelectedDate.AddDays(3).ToString("ddd, MMM d");
        grdView.Columns[7].HeaderText = dtTripStart.dtSelectedDate.AddDays(4).ToString("ddd, MMM d");
        grdView.Columns[8].HeaderText = dtTripStart.dtSelectedDate.AddDays(5).ToString("ddd, MMM d");
        grdView.Columns[9].HeaderText = dtTripStart.dtSelectedDate.AddDays(6).ToString("ddd, MMM d");
        grdView.Columns[10].HeaderText = dtTripStart.dtSelectedDate.AddDays(7).ToString("ddd, MMM d");
        grdView.Columns[11].HeaderText = dtTripStart.dtSelectedDate.AddDays(8).ToString("ddd, MMM d");
        grdView.Columns[12].HeaderText = dtTripStart.dtSelectedDate.AddDays(9).ToString("ddd, MMM d");
        grdView.Columns[13].HeaderText = dtTripStart.dtSelectedDate.AddDays(10).ToString("ddd, MMM d");
        grdView.Columns[14].HeaderText = dtTripStart.dtSelectedDate.AddDays(11).ToString("ddd, MMM d");
        grdView.Columns[15].HeaderText = dtTripStart.dtSelectedDate.AddDays(12).ToString("ddd, MMM d");
        grdView.Columns[16].HeaderText = dtTripStart.dtSelectedDate.AddDays(13).ToString("ddd, MMM d");
        grdView.Columns[17].HeaderText = dtTripStart.dtSelectedDate.AddDays(14).ToString("ddd, MMM d");

        System.Data.DataTable dt = oContractActivitiesRecordedHelper.dtGet14DayContract();

        dt.Columns.Add("TARGET");
        dt.Columns.Add("DAY1");
        dt.Columns.Add("DAY2");
        dt.Columns.Add("DAY3");
        dt.Columns.Add("DAY4");
        dt.Columns.Add("DAY5");
        dt.Columns.Add("DAY6");
        dt.Columns.Add("DAY7");
        dt.Columns.Add("DAY8");
        dt.Columns.Add("DAY9");
        dt.Columns.Add("DAY10");
        dt.Columns.Add("DAY11");
        dt.Columns.Add("DAY12");
        dt.Columns.Add("DAY13");
        dt.Columns.Add("DAY14");

        grdView.DataSource = dt;
        grdView.DataBind();
        PaintGrid();
    }

    private void PaintGrid()
    {
        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbActivity = (Label)grdRow.FindControl("lbActivity");
            TextBox txtTarget = (TextBox)grdRow.FindControl("txtTarget"); txtTarget.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay1 = (TextBox)grdRow.FindControl("txtDay1"); txtDay1.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay2 = (TextBox)grdRow.FindControl("txtDay2"); txtDay2.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay3 = (TextBox)grdRow.FindControl("txtDay3"); txtDay3.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay4 = (TextBox)grdRow.FindControl("txtDay4"); txtDay4.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay5 = (TextBox)grdRow.FindControl("txtDay5"); txtDay5.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay6 = (TextBox)grdRow.FindControl("txtDay6"); txtDay6.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay7 = (TextBox)grdRow.FindControl("txtDay7"); txtDay7.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay8 = (TextBox)grdRow.FindControl("txtDay8"); txtDay8.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay9 = (TextBox)grdRow.FindControl("txtDay9"); txtDay9.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay10 = (TextBox)grdRow.FindControl("txtDay10"); txtDay10.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay11 = (TextBox)grdRow.FindControl("txtDay11"); txtDay11.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay12 = (TextBox)grdRow.FindControl("txtDay12"); txtDay12.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay13 = (TextBox)grdRow.FindControl("txtDay13"); txtDay13.Attributes.Add("onkeypress", "return numericOnly(this);");
            TextBox txtDay14 = (TextBox)grdRow.FindControl("txtDay14"); txtDay14.Attributes.Add("onkeypress", "return numericOnly(this);");
            //int iSubActivityId = int.Parse(lbActivity.Attributes["IDSUBACTIVITIES"].ToString());

            if (string.IsNullOrEmpty(lbActivity.Attributes["IDSUBACTIVITIES"].ToString()))
            {
                grdRow.BackColor = System.Drawing.Color.PaleGreen;
                grdRow.Font.Bold = true;

                txtTarget.Visible = false;
                txtDay1.Visible = false; txtDay2.Visible = false; txtDay3.Visible = false; txtDay4.Visible = false; txtDay5.Visible = false; txtDay6.Visible = false;
                txtDay7.Visible = false; txtDay8.Visible = false; txtDay9.Visible = false; txtDay10.Visible = false; txtDay11.Visible = false; txtDay12.Visible = false;
                txtDay13.Visible = false; txtDay14.Visible = false;
            }
            else if (lbActivity.Attributes["IDSUBACTIVITIES"].ToString() == lbActivity.Attributes["IDACTIVITIES"].ToString())
            {
                grdRow.BackColor = System.Drawing.Color.PaleGreen;
            }
        }
        grdView.Columns[2].ItemStyle.BackColor = System.Drawing.Color.Yellow;
        grdView.Columns[3].ItemStyle.BackColor = System.Drawing.Color.LightBlue;
        grdView.GridLines = GridLines.Both;
    }

    protected void txtSubmitUpper_Click(object sender, EventArgs e)
    {
        SaveMesage();
    }
    protected void txtSubmitLower_Click(object sender, EventArgs e)
    {
        SaveMesage();
    }

    private void SaveMesage()
    {
        bool bRet = Save();
        if (bRet)

            Response.Redirect("~/App/Contract/Star14DayContract.aspx?bRet=1&dt=" + dtTripStart.dtSelectedDate + "&dstrt=" + ddlDistrict.SelectedValue);
        //ajaxWebExtension.showJscriptAlert(Page, this, "Successfully submitted.");
        else
            ajaxWebExtension.showJscriptAlert(Page, this, "Submit not successful, try again later!!!");
    }

    private bool Save()
    {
        bool bRet = false;
        ContractActivitiesRecorded oContractActivitiesRecorded = new ContractActivitiesRecorded();

        oContractActivitiesRecorded.iDistrictId = int.Parse(ddlDistrict.SelectedValue);
        oContractActivitiesRecorded.iUserId = oSessnx.getOnlineUser.m_iUserId;
        oContractActivitiesRecorded.iDistrictId = int.Parse(ddlDistrict.SelectedValue);
        oContractActivitiesRecorded.dtTripStartDate = dtTripStart.dtSelectedDate;

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbActivity = (Label)grdRow.FindControl("lbActivity");
            TextBox txtTarget = (TextBox)grdRow.FindControl("txtTarget");
            TextBox txtDay1 = (TextBox)grdRow.FindControl("txtDay1");
            TextBox txtDay2 = (TextBox)grdRow.FindControl("txtDay2");
            TextBox txtDay3 = (TextBox)grdRow.FindControl("txtDay3");
            TextBox txtDay4 = (TextBox)grdRow.FindControl("txtDay4");
            TextBox txtDay5 = (TextBox)grdRow.FindControl("txtDay5");
            TextBox txtDay6 = (TextBox)grdRow.FindControl("txtDay6");
            TextBox txtDay7 = (TextBox)grdRow.FindControl("txtDay7");
            TextBox txtDay8 = (TextBox)grdRow.FindControl("txtDay8");
            TextBox txtDay9 = (TextBox)grdRow.FindControl("txtDay9");
            TextBox txtDay10 = (TextBox)grdRow.FindControl("txtDay10");
            TextBox txtDay11 = (TextBox)grdRow.FindControl("txtDay11");
            TextBox txtDay12 = (TextBox)grdRow.FindControl("txtDay12");
            TextBox txtDay13 = (TextBox)grdRow.FindControl("txtDay13");
            TextBox txtDay14 = (TextBox)grdRow.FindControl("txtDay14");

            oContractActivitiesRecorded.iActivityId = int.Parse(lbActivity.Attributes["IDACTIVITIES"].ToString());

            if (string.IsNullOrEmpty(txtTarget.Text)) oContractActivitiesRecorded.dTarget = null; else oContractActivitiesRecorded.dTarget = decimal.Parse(txtTarget.Text);
            if (string.IsNullOrEmpty(txtDay1.Text)) oContractActivitiesRecorded.dDay1 = null; else oContractActivitiesRecorded.dDay1 = decimal.Parse(txtDay1.Text);
            if (string.IsNullOrEmpty(txtDay2.Text)) oContractActivitiesRecorded.dDay2 = null; else oContractActivitiesRecorded.dDay2 = decimal.Parse(txtDay2.Text);
            if (string.IsNullOrEmpty(txtDay3.Text)) oContractActivitiesRecorded.dDay3 = null; else oContractActivitiesRecorded.dDay3 = decimal.Parse(txtDay3.Text);
            if (string.IsNullOrEmpty(txtDay4.Text)) oContractActivitiesRecorded.dDay4 = null; else oContractActivitiesRecorded.dDay4 = decimal.Parse(txtDay4.Text);
            if (string.IsNullOrEmpty(txtDay5.Text)) oContractActivitiesRecorded.dDay5 = null; else oContractActivitiesRecorded.dDay5 = decimal.Parse(txtDay5.Text);
            if (string.IsNullOrEmpty(txtDay6.Text)) oContractActivitiesRecorded.dDay6 = null; else oContractActivitiesRecorded.dDay6 = decimal.Parse(txtDay6.Text);
            if (string.IsNullOrEmpty(txtDay7.Text)) oContractActivitiesRecorded.dDay7 = null; else oContractActivitiesRecorded.dDay7 = decimal.Parse(txtDay7.Text);
            if (string.IsNullOrEmpty(txtDay8.Text)) oContractActivitiesRecorded.dDay8 = null; else oContractActivitiesRecorded.dDay8 = decimal.Parse(txtDay8.Text);
            if (string.IsNullOrEmpty(txtDay9.Text)) oContractActivitiesRecorded.dDay9 = null; else oContractActivitiesRecorded.dDay9 = decimal.Parse(txtDay9.Text);
            if (string.IsNullOrEmpty(txtDay10.Text)) oContractActivitiesRecorded.dDay10 = null; else oContractActivitiesRecorded.dDay10 = decimal.Parse(txtDay10.Text);
            if (string.IsNullOrEmpty(txtDay11.Text)) oContractActivitiesRecorded.dDay11 = null; else oContractActivitiesRecorded.dDay11 = decimal.Parse(txtDay11.Text);
            if (string.IsNullOrEmpty(txtDay12.Text)) oContractActivitiesRecorded.dDay12 = null; else oContractActivitiesRecorded.dDay12 = decimal.Parse(txtDay12.Text);
            if (string.IsNullOrEmpty(txtDay13.Text)) oContractActivitiesRecorded.dDay13 = null; else oContractActivitiesRecorded.dDay13 = decimal.Parse(txtDay13.Text);
            if (string.IsNullOrEmpty(txtDay14.Text)) oContractActivitiesRecorded.dDay14 = null; else oContractActivitiesRecorded.dDay14 = decimal.Parse(txtDay14.Text);

            bRet = oContractActivitiesRecordedHelper.Insert14DayContract(oContractActivitiesRecorded);
        }

        return bRet;
    }

    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        PriorityHelper oPriorityHelper = new PriorityHelper();
        int iColumns = grdView.Columns.Count;
        int iPriorityIdA = 0;
        int iPriorityIdB = 0;

        foreach (GridViewRow grdRow in grdView.Rows)
        {
            Label lbActivityA = (Label)grdRow.FindControl("lbActivity");
            iPriorityIdA = int.Parse(lbActivityA.Attributes["IDPRIORITY"].ToString());

            GridViewRow gvrow = e.Row;
            if (gvrow.RowType == DataControlRowType.Header)
            {
                Label lbActivityB = (Label)gvrow.FindControl("lbActivity");
                iPriorityIdB = int.Parse(lbActivityB.Attributes["IDPRIORITY"].ToString());

                if (iPriorityIdA != iPriorityIdB)
                {
                    GridViewRow gvRow = new GridViewRow(gvrow.RowIndex + 1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableCell oCell = new TableCell();
                    oCell.ColumnSpan = 4;
                    oCell.Text = oPriorityHelper.objGetPriorityById(int.Parse(lbActivityB.Attributes["IDPRIORITY"].ToString())).sPriority;
                    oCell.HorizontalAlign = HorizontalAlign.Center;
                    oCell.ColumnSpan = 3;
                    oCell.Font.Bold = true;
                    oCell.BackColor = System.Drawing.Color.Transparent;

                    gvRow.Cells.Add(oCell);
                    grdView.Controls[0].Controls.AddAt(gvrow.RowIndex + 1, gvRow);
                }
            }
        }
    }
}