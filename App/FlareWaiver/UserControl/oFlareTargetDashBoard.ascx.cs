using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using Telerik.Web.UI;


public partial class App_FlareWaiver_UserControl_oFlareTargetDashBoard : aspnetUserControl
{
    FlareWaiverRequestHelper o = new FlareWaiverRequestHelper();
    FlareTargetHelper oHlp = new FlareTargetHelper();
    FlareViolationMailList oViolation = new FlareViolationMailList();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    public void InitPage()
    {
        var oYears = FlareWaiverRpt.LstYearsExt();
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("--Select Year--", "1"));
        foreach (var i in oYears)
        {
            ddlYear.Items.Add(i.ToString());
        }
        int iYear = DateTime.Now.Year;
        LoadResultByYear(iYear);
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadResultByYear(int.Parse(ddlYear.SelectedValue));
    }

    protected void grdView_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            var lnkJan = (LinkButton)e.Item.FindControl("lnkJan");
            var lnkFeb = (LinkButton)e.Item.FindControl("lnkFeb");
            var lnkMar = (LinkButton)e.Item.FindControl("lnkMar");
            var lnkApr = (LinkButton)e.Item.FindControl("lnkApr");
            var lnkMay = (LinkButton)e.Item.FindControl("lnkMay");
            var lnkJun = (LinkButton)e.Item.FindControl("lnkJun");
            var lnkJul = (LinkButton)e.Item.FindControl("lnkJul");
            var lnkAug = (LinkButton)e.Item.FindControl("lnkAug");
            var lnkSep = (LinkButton)e.Item.FindControl("lnkSep");
            var lnkOct = (LinkButton)e.Item.FindControl("lnkOct");
            var lnkNov = (LinkButton)e.Item.FindControl("lnkNov");
            var lnkDec = (LinkButton)e.Item.FindControl("lnkDec");

            GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
            GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");

            var item = e.Item as GridDataItem;

            string sFacility = item.Cells[Facility.OrderIndex].Text;
            string sCode = item.Cells[Code.OrderIndex].Text;

            int iYear = DateTime.Now.Year;

            int iFacilityId = int.Parse((e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDFACILITY"]).ToString());


            if (!string.IsNullOrEmpty(lnkJan.Text)) TheLogicTest(01, iYear, sCode, lnkJan, item, 4, iFacilityId);
            if (!string.IsNullOrEmpty(lnkFeb.Text)) TheLogicTest(02, iYear, sCode, lnkFeb, item, 5, iFacilityId);
            if (!string.IsNullOrEmpty(lnkMar.Text)) TheLogicTest(03, iYear, sCode, lnkMar, item, 6, iFacilityId);
            if (!string.IsNullOrEmpty(lnkApr.Text)) TheLogicTest(04, iYear, sCode, lnkApr, item, 7, iFacilityId);
            if (!string.IsNullOrEmpty(lnkMay.Text)) TheLogicTest(05, iYear, sCode, lnkMay, item, 8, iFacilityId);
            if (!string.IsNullOrEmpty(lnkJun.Text)) TheLogicTest(06, iYear, sCode, lnkJun, item, 9, iFacilityId);
            if (!string.IsNullOrEmpty(lnkJul.Text)) TheLogicTest(07, iYear, sCode, lnkJul, item, 10, iFacilityId);
            if (!string.IsNullOrEmpty(lnkAug.Text)) TheLogicTest(08, iYear, sCode, lnkAug, item, 11, iFacilityId);
            if (!string.IsNullOrEmpty(lnkSep.Text)) TheLogicTest(09, iYear, sCode, lnkSep, item, 12, iFacilityId);
            if (!string.IsNullOrEmpty(lnkOct.Text)) TheLogicTest(10, iYear, sCode, lnkOct, item, 13, iFacilityId);
            if (!string.IsNullOrEmpty(lnkNov.Text)) TheLogicTest(11, iYear, sCode, lnkNov, item, 14, iFacilityId);
            if (!string.IsNullOrEmpty(lnkDec.Text)) TheLogicTest(12, iYear, sCode, lnkDec, item, 15, iFacilityId);
        }
    }

    protected void grdView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int rowCounter = new int();
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            rowCounter = grdView.MasterTableView.PageSize * grdView.MasterTableView.CurrentPageIndex;
            lbl.Text = (e.Item.ItemIndex + 1 + rowCounter).ToString();

            GridColumn Agg = grdView.MasterTableView.Columns.FindByUniqueName("Agg");
            var item = e.Item as GridDataItem;

            if (item.Cells[Agg.OrderIndex].Text == "1")
            {
                item.Cells[Agg.OrderIndex].ForeColor = System.Drawing.Color.Navy;
                item.Cells[Agg.OrderIndex].Text = "Active";
            }
            else if (item.Cells[Agg.OrderIndex].Text == "2")
            {
                item.Cells[Agg.OrderIndex].ForeColor = System.Drawing.Color.Red;
                item.Cells[Agg.OrderIndex].Text = "No AGG";
            }
        }
    }

    public void LoadResultByYear(int iYear)
    {
        System.Data.DataTable dt = oHlp.dtGetFlareTarget(iYear);
        grdView.DataSource = dt;
        //grdView.DataBind();

        //Check if Energy Component is available
        FlareWaiverRequestHelper oReq = new FlareWaiverRequestHelper();
        bool bRet = oReq.dtEnergyComponentAvailable(iYear);
        if (bRet)
        {
            //DrillDownEC(iYear);
        }
        else
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Energy Component database not available, please try again later!");
        }
    }

    private bool LookForFlareWaiverApproval(int iMonth, int iYear,  int iFacilityId)
    {
        bool bRet = false;
        FlareWaiver fw = o.objGetFlareWaiverRequestByFacilityYearMonth(iFacilityId, iYear, iMonth);
        if (fw.m_lRequestId != 0)
        {
            //Check if the request is approved
            if ((int)RequestStatusReporter.RequestStatusRpt.Approved == fw.m_iStatus) bRet = true; //It means the facility have an approved flare waiver.               
            else if ((int)RequestStatusReporter.RequestStatusRpt.Approved != fw.m_iStatus) bRet = false; //It means the facility have no approved flare waiver.
        }
        return bRet;
    }

    private void ViolationMail(int iMonth, decimal dFlareLimit, int iFacilityId, decimal API)
    {
        List<structUserMailIdx> oReceivers = oViolation.lstViolationMailReceivers();
        List<structUserMailIdx> oCopy = new List<structUserMailIdx>();
        //oCopy.Add(oSessnx.getOnlineUser.structUserIdx);

        FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);
        oSendMail.FlareLimitViolation(iMonth, dFlareLimit, iFacilityId, API, oReceivers, oCopy);
    }

    protected void grdView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
           
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdView.MasterTableView.SortExpressions.Clear();
            grdView.MasterTableView.GroupByExpressions.Clear();
            grdView.MasterTableView.CurrentPageIndex = grdView.MasterTableView.PageCount - 1;
            grdView.Rebind();
        }
    }

    protected void grdView_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
    {

    }

    protected void lnkJan_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkJan = (LinkButton)dataItem.FindControl("lnkJan");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 01;
                decimal dFlareTarget = decimal.Parse(lnkJan.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkFeb_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkFeb = (LinkButton)dataItem.FindControl("lnkFeb");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 02;
                decimal dFlareTarget = decimal.Parse(lnkFeb.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkMar_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkMar = (LinkButton)dataItem.FindControl("lnkMar");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 03;
                decimal dFlareTarget = decimal.Parse(lnkMar.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkApr_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkApr = (LinkButton)dataItem.FindControl("lnkApr");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 04;
                decimal dFlareTarget = decimal.Parse(lnkApr.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkMay_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkMay = (LinkButton)dataItem.FindControl("lnkMay");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 05;
                decimal dFlareTarget = decimal.Parse(lnkMay.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkJun_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkJun = (LinkButton)dataItem.FindControl("lnkJun");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 06;
                decimal dFlareTarget = decimal.Parse(lnkJun.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkJul_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkJul = (LinkButton)dataItem.FindControl("lnkJul");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 07;
                decimal dFlareTarget = decimal.Parse(lnkJul.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkAug_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkAug = (LinkButton)dataItem.FindControl("lnkAug");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 08;
                decimal dFlareTarget = decimal.Parse(lnkAug.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkSep_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkSep = (LinkButton)dataItem.FindControl("lnkSep");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 09;
                decimal dFlareTarget = decimal.Parse(lnkSep.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkOct_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkOct = (LinkButton)dataItem.FindControl("lnkOct");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 10;
                decimal dFlareTarget = decimal.Parse(lnkOct.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkNov_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkNov = (LinkButton)dataItem.FindControl("lnkNov");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 11;
                decimal dFlareTarget = decimal.Parse(lnkNov.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void lnkDec_Click(object sender, EventArgs e)
    {
        int iYear = DateTime.Now.Year;

        try
        {
            using (GridDataItem dataItem = (GridDataItem)((LinkButton)sender).Parent.Parent)
            {
                int iFacilityId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"].ToString());
                LinkButton lnkDec = (LinkButton)dataItem.FindControl("lnkDec");

                GridColumn Facility = grdView.MasterTableView.Columns.FindByUniqueName("Facility");
                var item = dataItem as GridDataItem;
                string sFacility = item.Cells[Facility.OrderIndex].Text;

                GridColumn Code = grdView.MasterTableView.Columns.FindByUniqueName("Code");
                string sCode = item.Cells[Code.OrderIndex].Text;

                int iMonth = 12;
                decimal dFlareTarget = decimal.Parse(lnkDec.Text);
                dataItem.Attributes["href"] = "javascript:void(0);";
                dataItem.Attributes["onclick"] = string.Format("return ShowActionForm('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["IDFACILITY"], iYear, iMonth, sFacility, dFlareTarget, sCode, dataItem.ItemIndex);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    //private void DrillDownEC(int iYear)
    //{
    //    //FlareWaiverRequestHelper oReq = new FlareWaiverRequestHelper();
    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        Label labelCodes = (Label)grdRow.FindControl("labelCodes");
    //        string sCode = labelCodes.Text;

    //        HyperLink lnkJan = (HyperLink)grdRow.FindControl("lnkJan");
    //        HyperLink lnkFeb = (HyperLink)grdRow.FindControl("lnkFeb");
    //        HyperLink lnkMar = (HyperLink)grdRow.FindControl("lnkMar");
    //        HyperLink lnkApr = (HyperLink)grdRow.FindControl("lnkApr");
    //        HyperLink lnkMay = (HyperLink)grdRow.FindControl("lnkMay");
    //        HyperLink lnkJun = (HyperLink)grdRow.FindControl("lnkJun");
    //        HyperLink lnkJul = (HyperLink)grdRow.FindControl("lnkJul");
    //        HyperLink lnkAug = (HyperLink)grdRow.FindControl("lnkAug");
    //        HyperLink lnkSep = (HyperLink)grdRow.FindControl("lnkSep");
    //        HyperLink lnkOct = (HyperLink)grdRow.FindControl("lnkOct");
    //        HyperLink lnkNov = (HyperLink)grdRow.FindControl("lnkNov");
    //        HyperLink lnkDec = (HyperLink)grdRow.FindControl("lnkDec");
    //        Label lblFacility = (Label)grdRow.FindControl("labelFacilities");
    //        int iFacilityId = int.Parse(lblFacility.Attributes["IDFACILITY"]);

    //        //if (!string.IsNullOrEmpty(lnkJan.Text)) TheLogicTest(01, iYear, sCode, lnkJan, grdRow, 4, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkFeb.Text)) TheLogicTest(02, iYear, sCode, lnkFeb, grdRow, 5, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkMar.Text)) TheLogicTest(03, iYear, sCode, lnkMar, grdRow, 6, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkApr.Text)) TheLogicTest(04, iYear, sCode, lnkApr, grdRow, 7, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkMay.Text)) TheLogicTest(05, iYear, sCode, lnkMay, grdRow, 8, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkJun.Text)) TheLogicTest(06, iYear, sCode, lnkJun, grdRow, 9, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkJul.Text)) TheLogicTest(07, iYear, sCode, lnkJul, grdRow, 10, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkAug.Text)) TheLogicTest(08, iYear, sCode, lnkAug, grdRow, 11, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkSep.Text)) TheLogicTest(09, iYear, sCode, lnkSep, grdRow, 12, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkOct.Text)) TheLogicTest(10, iYear, sCode, lnkOct, grdRow, 13, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkNov.Text)) TheLogicTest(11, iYear, sCode, lnkNov, grdRow, 14, iFacilityId);
    //        //if (!string.IsNullOrEmpty(lnkDec.Text)) TheLogicTest(12, iYear, sCode, lnkDec, grdRow, 15, iFacilityId);
    //    }
    //}

    private void TheLogicTest(int iMonth, int iYear, string sCode, LinkButton lnkMonth, GridDataItem item, int iCellIndex, int iFacilityId)
    {
        try
        {
            //YTD actual
            List<EnergyComponent> GasFlareYTD = o.lstGetGasFlareYTDByFacility(sCode, iYear);
            var TotalFlaredYTD = GasFlareYTD.Sum(s => s.API);
            var FlareYTDactual = TotalFlaredYTD / DateTime.Now.Date.DayOfYear - 1;

            // Annual flare limit
            var AnnualFlareLimit = oHlp.objGetFlareAnnualTargetByFacilityId(iFacilityId, iYear).iYTD;
            if (FlareYTDactual > AnnualFlareLimit) item.Cells[item.Cells.Count - 1].BackColor = System.Drawing.Color.Red;
            else item.Cells[item.Cells.Count - 1].BackColor = System.Drawing.Color.Green;

            if (iMonth <= DateTime.Now.Month)
            {
                decimal dFlareLimit = decimal.Parse(lnkMonth.Text.Replace(",", ""));
                List<EnergyComponent> oLst = o.lstGetDailyFlaredGasFromEC(iMonth, iYear, sCode);

                if (Facility.objGetFacilityById(iFacilityId).m_iAgg == (int)commonEnums.YesNo.Yes) //Check if the Facility has AGG.
                {
                    var totActual = oLst.Sum(S => S.API);

                    //int iRows = oLst.Count;
                    int iRows = DateTime.DaysInMonth(iYear, iMonth);
                    if ((iMonth == DateTime.Now.Month) && (oLst.Count == DateTime.Now.Day)) iRows = oLst.Count - 1; //Remove 1 because the production day for yesterday is considered for today, this is required if in current month
                    else if ((iMonth == DateTime.Now.Month) && (oLst.Count > DateTime.Now.Day)) iRows = DateTime.Now.Day - 1; //Remove 1 because the production day for yesterday is considered for today, this is required if in current month

                    var AverageMonthlyActual = (iRows > 0) ? Math.Round((totActual / iRows), 2, MidpointRounding.AwayFromZero) : 0;

                    if (AverageMonthlyActual > dFlareLimit) item.Cells[iCellIndex].BackColor = System.Drawing.Color.Red;
                    else item.Cells[iCellIndex].BackColor = System.Drawing.Color.Green;

                    if (iMonth == DateTime.Now.Month)
                    {
                        int iLastDay = oLst.Count - 1;
                        if (iLastDay > 4)
                        {
                            if ((oLst[iLastDay].ProductionDay == (DateTime.Now.Date)) && (oLst[iLastDay].API > dFlareLimit))
                            {
                                //Then apply the flare 96 hours (4Days) principles
                                //Check the values in the previous four days and that the Flaring is continously beyond the flare limit.
                                if ((oLst[iLastDay - 4].API > dFlareLimit) && (oLst[iLastDay - 3].API > dFlareLimit) && (oLst[iLastDay - 2].API > dFlareLimit) && (oLst[iLastDay - 1].API > dFlareLimit))
                                {
                                    //Now check if flare approval exists for the facility with AGG for the month in consideration
                                    bool bRet = LookForFlareWaiverApproval(iMonth, iYear, iFacilityId);
                                    if (!bRet)
                                    {
                                        ViolationMail(iMonth, dFlareLimit, iFacilityId, oLst[iLastDay].API);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Facility.objGetFacilityById(iFacilityId).m_iAgg == (int)commonEnums.YesNo.No)
                {
                    var totActual = oLst.Sum(S => S.API);
                    int iRows = oLst.Count - 1; //Remove 1 because the production day for yesterday is considered for today

                    var AverageMonthlyActual = (iRows > 0) ? Math.Round((totActual / iRows), 2, MidpointRounding.AwayFromZero) : 0;

                    if (AverageMonthlyActual > dFlareLimit)
                    {
                        item.Cells[iCellIndex].BackColor = System.Drawing.Color.Red;
                        if (iMonth == DateTime.Now.Month) ViolationMail(iMonth, dFlareLimit, iFacilityId, AverageMonthlyActual); //Send violation mail for the current month only.
                    }
                    else
                    {
                        item.Cells[iCellIndex].BackColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}


//private void Common(object sender, EventArgs e, int iYear, HyperLink lnkMonth, string slnkMonth, int iMonth)
//{
//    try
//    {
//        using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//        {
//            lnkMonth = (HyperLink)row.FindControl("slnkMonth");
//            Label labelFacilities = (Label)row.FindControl("labelFacilities");

//            int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//            string sFacility = labelFacilities.Text;
//            string sCode = lnkMonth.Attributes["CODE"].ToString();
//            decimal dFlareTarget = decimal.Parse(lnkMonth.Text);

//            oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//        }
//    }
//    catch (Exception ex)
//    {
//        System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//    }
//}
//}




//  protected void lnkFeb_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkFeb = (HyperLink)row.FindControl("lnkFeb");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkFeb.Attributes["CODE"].ToString();
//              int iMonth = 02;
//              decimal dFlareTarget = decimal.Parse(lnkFeb.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkMar_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkMar = (HyperLink)row.FindControl("lnkMar");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkMar.Attributes["CODE"].ToString();
//              int iMonth = 03;
//              decimal dFlareTarget = decimal.Parse(lnkMar.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkApr_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkApr = (HyperLink)row.FindControl("lnkApr");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkApr.Attributes["CODE"].ToString();
//              int iMonth = 04;
//              decimal dFlareTarget = decimal.Parse(lnkApr.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkMay_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkMay = (HyperLink)row.FindControl("lnkMay");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkMay.Attributes["CODE"].ToString();
//              int iMonth = 05;
//              decimal dFlareTarget = decimal.Parse(lnkMay.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkJun_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkJun = (HyperLink)row.FindControl("lnkJun");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkJun.Attributes["CODE"].ToString();
//              int iMonth = 06;
//              decimal dFlareTarget = decimal.Parse(lnkJun.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkJul_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkJul = (HyperLink)row.FindControl("lnkJul");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkJul.Attributes["CODE"].ToString();
//              int iMonth = 07;
//              decimal dFlareTarget = decimal.Parse(lnkJul.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkAug_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkAug = (HyperLink)row.FindControl("lnkAug");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkAug.Attributes["CODE"].ToString();
//              int iMonth = 08;
//              decimal dFlareTarget = decimal.Parse(lnkAug.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkSep_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkSep = (HyperLink)row.FindControl("lnkSep");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkSep.Attributes["CODE"].ToString();
//              int iMonth = 09;
//              decimal dFlareTarget = decimal.Parse(lnkSep.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkOct_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkOct = (HyperLink)row.FindControl("lnkOct");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkOct.Attributes["CODE"].ToString();
//              int iMonth = 10;
//              decimal dFlareTarget = decimal.Parse(lnkOct.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkNov_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkNov = (HyperLink)row.FindControl("lnkNov");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkNov.Attributes["CODE"].ToString();
//              int iMonth = 11;
//              decimal dFlareTarget = decimal.Parse(lnkNov.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }

//  protected void lnkDec_Click(object sender, EventArgs e)
//  {
//      try
//      {
//          using (GridViewRow row = (GridViewRow)((HyperLink)sender).Parent.Parent)
//          {
//              int iYear = DateTime.Now.Year;
//              HyperLink lnkDec = (HyperLink)row.FindControl("lnkDec");
//              Label labelFacilities = (Label)row.FindControl("labelFacilities");

//              int iFacilityId = int.Parse(labelFacilities.Attributes["IDFACILITY"].ToString());
//              string sFacility = labelFacilities.Text;
//              string sCode = lnkDec.Attributes["CODE"].ToString();
//              int iMonth = 12;
//              decimal dFlareTarget = decimal.Parse(lnkDec.Text);

//              oFlareECAnalyser1.LoadECReport(iMonth, iYear, sCode, sFacility, dFlareTarget, iFacilityId);


//          }
//      }
//      catch (Exception ex)
//      {
//          System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
//      }
//  }
