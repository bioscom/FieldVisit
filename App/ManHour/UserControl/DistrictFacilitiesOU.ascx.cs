using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using System.Data;

public partial class UserControl_DistrictFacilitiesOU : aspnetUserControl
{
    InitiativeOUDistrictFacilities oInitiativeOUDistrictFacilities = new InitiativeOUDistrictFacilities();
    OUMgt oOuMgt = new OUMgt();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Control(long lInitiativeId)
    {
        lInitiativeHF.Value = lInitiativeId.ToString();

        OUMgt oOUMgt = new OUMgt();
        //int x = 1;
        //List<OU> ous = oOUMgt.lstGetOUS();
        //foreach (OU ou in ous)
        //{
        //    ddlOU.Items.Add(new ListItem(Encoder.HtmlEncode(ou.m_sOUS), Encoder.HtmlEncode(ou.m_iOUId.ToString())));
        //    //OUCheckBoxList.Items.Add(new ListItem(x + ". " + "  <b><font color='Navy'>" + Encoder.HtmlEncode(ou.m_sOUS) + "</font></b>", Encoder.HtmlEncode(ou.m_iOUId.ToString())));
        //    x++;
        //}

        RetrieveData();
    }

    protected void ddlOU_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAssets();
        //loadDistrictsFacilities();
    }

    private void GetAssets()
    {
        grdViewOU.DataSource = oOuMgt.dtGetOus();
        grdViewOU.DataBind(); //Successful

        foreach (GridViewRow grdRow in grdViewOU.Rows)
        {
            CheckBox OUCkB = (CheckBox)grdRow.FindControl("OUCkB");
            int iOuId = int.Parse(OUCkB.Attributes["IDOU"].ToString());

            GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");

            DataTable dtAsset = Assets.dtGetAssetByOUId(iOuId);
            if (dtAsset.Rows.Count > 0)
            {
                oGrdViewAsset.DataSource = dtAsset;
                oGrdViewAsset.DataBind();

                foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
                {
                    GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
                    CheckBox AssetsCkB = (CheckBox)grdRowAsset.FindControl("AssetsCkB");
                    int iAssetId = int.Parse(AssetsCkB.Attributes["IDASSET"].ToString());

                    DataTable dtDistrict = District.dtGetDistrictByAssetId(iAssetId);
                    if (dtDistrict.Rows.Count > 0)
                    {
                        oGrdViewDistrict.DataSource = dtDistrict;
                        oGrdViewDistrict.DataBind();

                        foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
                        {
                            GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
                            CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");
                            int iDistrictId = int.Parse(DistrictCkB.Attributes["ID_DISTRICT"].ToString());

                            DataTable dtFacilities = facility.dtGetFacilityByDistrictId(iDistrictId);

                            if (dtFacilities.Rows.Count > 0)
                            {
                                subGrdViewFacilities.DataSource = dtFacilities;
                                subGrdViewFacilities.DataBind();
                            }
                        }
                    }
                    //}
                }
            }
        }
    }

    //private void loadDistrictsFacilities()
    //{
    //    grdView.DataSource = District.dtGetDistrictByOU();
    //    grdView.DataBind();

    //    foreach (GridViewRow grdRow in grdView.Rows)
    //    {
    //        //Label lblDistrict = (Label)grdRow.FindControl("lblDistrict");
    //        Label lblDistrict = (Label)grdRow.FindControl("lblDistrict");
    //        int iDistrictId = int.Parse(lblDistrict.Attributes["ID_DISTRICT"].ToString());

    //        //BulletedList DistrictLst = (BulletedList)grdRow.FindControl("DistrictLst");
    //        //BulletedList FacilityLst = (BulletedList)grdRow.FindControl("FacilityLst");
    //        //BulletedList PlannerLst = (BulletedList)grdRow.FindControl("PlannerLst");
    //        GridView subGrdView = (GridView)grdRow.FindControl("subGrdView");

    //        DataTable dt = facility.dtGetFacilityByDistrictId(iDistrictId);
    //        if (dt.Rows.Count > 0)
    //        {
    //            subGrdView.DataSource = dt;
    //            subGrdView.DataBind();
    //        }
    //    }
    //}

    private void RetrieveData()
    {
        //Get the OU selected
        try
        {
            Initiative oInitiative = Initiative.objGetInitiativeById(long.Parse(lInitiativeHF.Value));
            //ddlOU.SelectedValue = oInitiative.m_iOuId.ToString();
            GetAssets();
            //loadDistrictsFacilities();

            //Fill the selected facilities
            //////FacilitiesForThisInitiative(long.Parse(lInitiativeHF.Value));

            //InitiativeOUDistrictFacilities oInitiativeOUDistrictFacilities = new InitiativeOUDistrictFacilities();
            //List<Initiative_Dist_Facilities> oFacilities = oInitiativeOUDistrictFacilities.lstGetDistrictFacilitiesByInitiative(long.Parse(lInitiativeHF.Value));
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        bool bRet = test();
        ////AssignOU();
        ////AssignFacilities();
        //bool bRet = false;

        //foreach (GridViewRow grdRow in grdViewOU.Rows)
        //{
        //    GridView subGrdView = (GridView)grdRow.FindControl("subGrdView");

        //    if (subGrdView != null)
        //    {
        //        foreach (GridViewRow grdSubRow in subGrdView.Rows)
        //        {
        //            CheckBox FacilitiesCkb = (CheckBox)grdSubRow.FindControl("FacilitiesCkB");
        //            int iFacilityId = int.Parse(FacilitiesCkb.Attributes["ID_FACILITIES"].ToString());
        //            if (FacilitiesCkb.Checked)
        //            {
        //                bRet = oInitiativeOUDistrictFacilities.AssignFacilitiesToInitiative(long.Parse(lInitiativeHF.Value), iFacilityId);
        //            }
        //        }
        //    }
        //}
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "Successful.");
        }
    }

    //private void AssignOU()
    //{
    //    oInitiativeOUDistrictFacilities.AssignOUsToInitiative(long.Parse(lInitiativeHF.Value), int.Parse(ddlOU.SelectedValue));

    //    string mssg = "Selected OUs were successully assigned.";
    //        ajaxWebExtension.showJscriptAlert(Page, this, mssg);

    //    //int i = 0;
    //    //foreach (ListItem li in OUCheckBoxList.Items)
    //    //{
    //    //    if (li.Selected == false)
    //    //    {
    //    //        i++;
    //    //    }
    //    //}

    //    //if (i == OUCheckBoxList.Items.Count)
    //    //{
    //    //    ajaxWebExtension.showJscriptAlert(Page, this, "Atleast, an Organisational Unit Must be selected.");
    //    //}
    //    //else
    //    //{
    //    //    foreach (ListItem li in OUCheckBoxList.Items)
    //    //    {
    //    //        //OU Selected and not found in the previous list of selected OU for an Initiative
    //    //        if ((li.Selected == true) && (OuFoundInInitiative(li) == false))
    //    //        {
    //    //            oInitiativeOUDistrictFacilities.AssignOUsToInitiative(long.Parse(lInitiativeHF.Value), int.Parse(li.Value));
    //    //        }
    //    //        //OU not selected or deselected and found in the list of selected OU for an Initiative, remove.
    //    //        else if ((li.Selected == false) && (OuFoundInInitiative(li) == true))
    //    //        {
    //    //            oInitiativeOUDistrictFacilities.RemoveAssignedOUToInitiative(long.Parse(lInitiativeHF.Value), int.Parse(li.Value));
    //    //        }
    //    //    }


    //    //}
    //}

    private bool OuFoundInInitiative(ListItem li)
    {
        bool bRet = false;
        List<Initiative_OU> lstInitiative = oInitiativeOUDistrictFacilities.lstGetOuByInitiative(long.Parse(lInitiativeHF.Value));
        if (lstInitiative.Count > 0)
        {
            foreach (Initiative_OU oInitiative in lstInitiative)
            {
                if (oInitiative.m_iIdOU == int.Parse(li.Value))
                {
                    bRet = true;
                }
            }
        }

        return bRet;
    }

    private void FacilitiesForThisInitiative(long lInitiativeId)
    {
        List<facility> lstFacilities = facility.lstGetFacilityByInitiative(lInitiativeId);
        foreach (GridViewRow grdRow in grdViewOU.Rows)
        {
            //Label lblDistrict = (Label)grdRow.FindControl("lblDistrict");
            //Label lblDistrict = (Label)grdRow.FindControl("lblDistrict");
            //int iDistrictId = int.Parse(lblDistrict.Attributes["ID_DISTRICT"].ToString());

            GridView subGrdViewFacilities = (GridView)grdRow.FindControl("subGrdViewFacilities");
            foreach (GridViewRow subGrdRow in subGrdViewFacilities.Rows)
            {
                foreach (facility oFacility in lstFacilities)
                {
                    CheckBox oCheckBox = (CheckBox)subGrdRow.FindControl("FacilitiesCkB"); //
                    if (oFacility.m_iFacilityId == int.Parse(oCheckBox.Attributes["ID_FACILITIES"].ToString()))
                    {
                        oCheckBox.Checked = true;
                    }
                }
            }
        }
    }

    protected void grdViewOU_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void OUCkB_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            using (GridViewRow row = (GridViewRow)((CheckBox)sender).Parent.Parent)
            {
                CheckBox OUCkB = (CheckBox)row.FindControl("OUCkB");
                if (OUCkB.Checked)
                {
                    foreach (GridViewRow grdRow in grdViewOU.Rows)
                    {
                        GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");

                        foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
                        {
                            GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
                            CheckBox AssetsCkB = (CheckBox)grdRowAsset.FindControl("AssetsCkB");

                            AssetsCkB.Checked = true;

                            foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
                            {
                                GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
                                CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");

                                DistrictCkB.Checked = true;

                                foreach (GridViewRow grdRowFacilities in subGrdViewFacilities.Rows)
                                {
                                    CheckBox FacilitiesCkB = (CheckBox)grdRowFacilities.FindControl("FacilitiesCkB");
                                    FacilitiesCkB.Checked = true;
                                }
                            }
                        }
                    }
                }
                else if (!OUCkB.Checked)
                {
                    foreach (GridViewRow grdRow in grdViewOU.Rows)
                    {
                        GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");
                        foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
                        {
                            GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
                            CheckBox AssetsCkB = (CheckBox)grdRowAsset.FindControl("AssetsCkB");

                            AssetsCkB.Checked = false;

                            foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
                            {
                                GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
                                CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");

                                DistrictCkB.Checked = false;

                                foreach (GridViewRow grdRowFacilities in subGrdViewFacilities.Rows)
                                {
                                    CheckBox FacilitiesCkB = (CheckBox)grdRowFacilities.FindControl("FacilitiesCkB");
                                    FacilitiesCkB.Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void AssetsCkB_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //    using (GridViewRow row = (GridViewRow)((CheckBox)sender).Parent.Parent)
            //    {
            //        foreach (GridViewRow grdRow in grdViewOU.Rows)
            //        {
            //            GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");
            //            CheckBox AssetsCkB = (CheckBox)oGrdViewAsset.FindControl("AssetsCkB");
            //            if (AssetsCkB.Checked)
            //            {
            //                foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
            //                {
            //                    GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
            //                    foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
            //                    {
            //                        GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
            //                        CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");

            //                        DistrictCkB.Checked = true;

            //                        foreach (GridViewRow grdRowFacilities in subGrdViewFacilities.Rows)
            //                        {
            //                            CheckBox FacilitiesCkB = (CheckBox)grdRowFacilities.FindControl("FacilitiesCkB");
            //                            FacilitiesCkB.Checked = true;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //}


            //}
            //else if (!OUCkB.Checked)
            //{
            //    foreach (GridViewRow grdRow in grdViewOU.Rows)
            //    {
            //        GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");
            //        foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
            //        {
            //            GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
            //            CheckBox AssetsCkB = (CheckBox)grdRowAsset.FindControl("AssetsCkB");

            //            AssetsCkB.Checked = false;

            //            foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
            //            {
            //                GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
            //                CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");

            //                DistrictCkB.Checked = false;

            //                foreach (GridViewRow grdRowFacilities in subGrdViewFacilities.Rows)
            //                {
            //                    CheckBox FacilitiesCkB = (CheckBox)grdRowFacilities.FindControl("FacilitiesCkB");
            //                    FacilitiesCkB.Checked = false;
            //                }
            //            }
            //        }
            //    }
            //}
            //}
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void grdViewOU_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    private bool test()
    {
        bool bRet = false;
        foreach (GridViewRow grdRow in grdViewOU.Rows)
        {
            CheckBox OUCkB = (CheckBox)grdRow.FindControl("OUCkB");
            int iOuId = int.Parse(OUCkB.Attributes["IDOU"].ToString());
            
            if (OUCkB.Checked)
            {
                //check if InitiativeId exists for this Update else Insert
                oInitiativeOUDistrictFacilities.findOUToInitiative(long.Parse(lInitiativeHF.Value), iOuId);

                bRet = oInitiativeOUDistrictFacilities.AssignOUToInitiative(long.Parse(lInitiativeHF.Value), iOuId);
                
                //Seek the Asset GridView in the OU GridView
                GridView oGrdViewAsset = (GridView)grdRow.FindControl("subGrdViewAsset");
                foreach (GridViewRow grdRowAsset in oGrdViewAsset.Rows)
                {
                    CheckBox AssetsCkB = (CheckBox)grdRowAsset.FindControl("AssetsCkB");
                    int iAssetId = int.Parse(AssetsCkB.Attributes["IDASSET"].ToString());
                    if (AssetsCkB.Checked)
                    {
                        bRet = oInitiativeOUDistrictFacilities.AssignAssetToInitiative(long.Parse(lInitiativeHF.Value), iAssetId);
                        GridView oGrdViewDistrict = (GridView)grdRowAsset.FindControl("subGrdViewDistrict");
                        
                        foreach (GridViewRow grdRowDistrict in oGrdViewDistrict.Rows)
                        {
                            CheckBox DistrictCkB = (CheckBox)grdRowDistrict.FindControl("DistrictCkB");
                            int iDistrictId = int.Parse(DistrictCkB.Attributes["ID_DISTRICT"].ToString());
                            if (DistrictCkB.Checked)
                            {
                                bRet = oInitiativeOUDistrictFacilities.AssignDistrictToInitiative(long.Parse(lInitiativeHF.Value), iDistrictId);

                                GridView subGrdViewFacilities = (GridView)grdRowDistrict.FindControl("subGrdViewFacilities");
                                foreach (GridViewRow grdRowFacilities in subGrdViewFacilities.Rows)
                                {
                                    CheckBox FacilitiesCkb = (CheckBox)grdRowFacilities.FindControl("FacilitiesCkB");
                                    int iFacilityId = int.Parse(FacilitiesCkb.Attributes["ID_FACILITIES"].ToString());
                                    if (FacilitiesCkb.Checked)
                                    {
                                        bRet = oInitiativeOUDistrictFacilities.AssignFacilitiesToInitiative(long.Parse(lInitiativeHF.Value), iFacilityId);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return bRet;
    }
}