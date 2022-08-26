using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class App_PDCC_ViewDetails : System.Web.UI.Page
{
    //readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        ActivityLogCntl1.InitPage();
        //if (Request.QueryString["lOpCost"] != null)
        //{
        //    long lOpCost = long.Parse(Request.QueryString["lOpCost"]);
        //    RetrieveData(lOpCost);
        //}
    }

    //private void RetrieveData(long lOpCost)
    //{
    //    OpportunityCost oOpportunityCost = _opportunityCostHelper.ObjGetOpportunityCostById(lOpCost);

    //    lblDepartment.Text = oOpportunityCost.iDept.ToString();
    //    lblActSavings.Text = oOpportunityCost.dActSavings.ToString(CultureInfo.InvariantCulture);
    //    lblPotSavings.Text = oOpportunityCost.dPotSavings.ToString(CultureInfo.InvariantCulture);
    //    lblAcceptPark.Text = oOpportunityCost.iAcceptPark.ToString();
    //    lblActionParty.Text = oOpportunityCost.iActionParty.ToString();
    //    lblAserv.Text = oOpportunityCost.iAsService.ToString();
    //    lblDepartment.Text = oOpportunityCost.iDept.ToString();
    //    lblFecto.Text = oOpportunityCost.iFecto.ToString();
    //    lblImprovement.Text = oOpportunityCost.iImprovement.ToString();
    //    lblPriority.Text = oOpportunityCost.iPriority.ToString();
    //    lblSponsor.Text = oOpportunityCost.iSponsor.ToString();
    //    lblComments.Text = oOpportunityCost.sComments;
    //    lblCostCentre.Text = oOpportunityCost.sCostCentre;
    //    lblOpportunity.Text = oOpportunityCost.sOpportunity;
    //    GetItemsStringValues();

    //    lblCompleteBy.Text = dateRoutine.dateShort(DateTime.Parse(oOpportunityCost.dtCompletedBy.ToString())); //DateTime.Parse(oOpportunityCost.dtCompletedBy.ToString()).ToString("dd/MM/yyyy");  oOpportunityCost.dtCompletedBy.ToString();
    //    lblStartBy.Text = dateRoutine.dateShort(DateTime.Parse(oOpportunityCost.dtCompletedBy.ToString())); //DateTime.Parse(oOpportunityCost.dtStartedBy.ToString()).ToString("dd/MM/yyyy"); //oOpportunityCost.dtStartedBy.ToString();
    //}

    //private void GetItemsStringValues()
    //{
    //    appUsersHelper oAppUserHelper = new appUsersHelper();
    //    Department oDepartment = new Department();
    //    lblDepartment.Text = oDepartment.objGetDeparmentById(int.Parse(lblDepartment.Text)).m_sDepartment;

    //    if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Accept) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Accept);
    //    else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Park) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Park);
    //    else if (int.Parse(lblAcceptPark.Text) == (int)ItemStatus.ItStatus.Done) lblAcceptPark.Text = ItemStatus.status(ItemStatus.ItStatus.Done);

    //    if (int.Parse(lblFecto.Text) == (int)ItemStatus.ItStatus.Yes) lblFecto.Text = ItemStatus.status(ItemStatus.ItStatus.Yes);
    //    else if (int.Parse(lblFecto.Text) == (int)ItemStatus.ItStatus.No) lblFecto.Text = ItemStatus.status(ItemStatus.ItStatus.No);

    //    if (int.Parse(lblImprovement.Text) == (int)ItemStatus.ItStatus.Yes) lblImprovement.Text = ItemStatus.status(ItemStatus.ItStatus.Yes);
    //    else if (int.Parse(lblImprovement.Text) == (int)ItemStatus.ItStatus.No) lblImprovement.Text = ItemStatus.status(ItemStatus.ItStatus.No);

    //    if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.All) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.All);
    //    else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.Offshore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.Offshore);
    //    else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.Onshore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.Onshore);
    //    else if (int.Parse(lblAserv.Text) == (int)ItemStatus.ItStatus.OnShoreOffShore) lblAserv.Text = ItemStatus.status(ItemStatus.ItStatus.OnShoreOffShore);

    //    lblSponsor.Text = oAppUserHelper.objGetUserByUserID(int.Parse(lblSponsor.Text)).m_sFullName;
    //    lblActionParty.Text = oAppUserHelper.objGetUserByUserID(int.Parse(lblActionParty.Text)).m_sFullName;
    //}
}