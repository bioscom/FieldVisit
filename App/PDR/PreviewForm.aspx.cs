using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_PDR_PreviewForm : aspnetPage
{
    PDR.MainReport oMainReport = new PDR.MainReport();
    PDR.MainReportHelper oMainReportHelper = new PDR.MainReportHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oMainReportHelper.FillMenu(XmlMenuDataSource, mnuTreeView);

            if (Request.QueryString["lReportId"] != null)
            {
                long lReportId = long.Parse(Request.QueryString["lReportId"].ToString());
                PDR.MainReport oMainReport = oMainReportHelper.objGetMaiReportByReportId(lReportId);
            }
        }
    }

    protected void mnuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblAssetDistrict.Text = mnuTreeView.SelectedNode.Parent.Text + "(" + mnuTreeView.SelectedNode.Text + ")";
        //lblDate.Text = DateTime.Now.ToLongDateString();

        int iDistrictId = District.objGetDistrictByName(mnuTreeView.SelectedNode.Text).m_iDistrictId;
        PDR.MainReport oMainReport = oMainReportHelper.objGetMaiReportByDistrictDate(iDistrictId);
        

        ///Load the Record from Database
        //HSSE1.LoadData(iDistrictId);
        //POB1.LoadData(iDistrictId);
        //PTWSummary1.LoadData(iDistrictId);
        //MeterStatus1.LoadData(iDistrictId); 
        //AlarmRate1.LoadData(iDistrictId); 
        //WellTest1.LoadData(iDistrictId); 
        //TechnicalIntegrity1.LoadData(iDistrictId); 
        //CathodicProtection1.LoadData(iDistrictId); 
        //AGOStatus1.LoadData(iDistrictId); 
        //GeneratorAirCompressorStatus1.LoadData(iDistrictId);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {

    }
}