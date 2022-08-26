using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CS.BLL.FlareWaiver;

public partial class FlareWaiverRequestEdt : aspnetPage
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();
    FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                List<appUsers> oappUsers = oappUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.LineManager); //Load Line Managers
                foreach (appUsers oAppUser in oappUsers)
                {
                    ddlManager.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
                }
                
                List<Category> oCategories = Category.lstGetCategories(); //Load Category
                foreach (Category oCategory in oCategories)
                {
                    ddlCategory.Items.Add(new ListItem(oCategory.m_sCategory, oCategory.m_iCategoryId.ToString()));
                }

                List<Facility> oFacilities = Facility.lstGetFacilities(); //Load Facilities
                foreach (Facility oFacility in oFacilities)
                {
                    facilitiesCkbLst.Items.Add(new ListItem(oFacility.m_sFacility, oFacility.m_iFacilityId.ToString()));
                }
                if (Request.QueryString["RequestId"] != null)
                {
                    long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
                    LoadRequest(lRequestId);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    private void LoadRequest(long lRequestId)
    {
        FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
        FlareWaiver oFlareWaiver = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);
        RequestFacilityHelper oRequestFacilityHelper = new RequestFacilityHelper();

        ddlManager.SelectedValue = oApprover.m_iUserId.ToString();// oFlareWaiver.m_iUserId.ToString();
        ddlCategory.SelectedValue = oFlareWaiver.m_iCategoryId.ToString();
        //ddlFacilities.SelectedValue = oFlareWaiver.m_iFacilityId.ToString();
        txtJustification.Text = oFlareWaiver.m_sJustification;
        txtOil.Text = oFlareWaiver.m_sOilProduced.ToString();
        txtPostEvent.Text = oFlareWaiver.m_sPostEvent;
        txtReason.Text = oFlareWaiver.m_sReason;
        txtVolume.Text = oFlareWaiver.m_sFlareVol.ToString();

        dtEndDate.SelectedDate = oFlareWaiver.m_sEndDate;
        dtStartDate.SelectedDate = oFlareWaiver.m_sStartDate;        
        startTime.SelectedTime = TimeSpan.Parse(oFlareWaiver.m_sStartTime);       
        endTime.SelectedTime = TimeSpan.Parse(oFlareWaiver.m_sEndTime);

       List<RequestFacility> lstRequestFacilities = oRequestFacilityHelper.lstGetFacilitiesByRequestId(lRequestId);
       foreach (RequestFacility oRequestFacility in lstRequestFacilities)
       {
           foreach (ListItem li in facilitiesCkbLst.Items)
           {
               if (li.Value == oRequestFacility.m_iFacilityId.ToString())
               {
                   li.Selected = true;
               }
           }
       }

        //Load Uploaded Work Plan
       WorkOrder1.LoadFileFromWorkOrder(oFlareWaiver.m_sWorkOrder);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            long lRequestId = long.Parse(Request.QueryString["RequestId"].ToString());
            appUsers oNextSupportApprover = oappUsersHelper.objGetUserByUserID(int.Parse(ddlManager.SelectedValue));

            //Get the user just created
           // oNextSupportApprover = oappUsersHelper.objGetUserByUserID(oNextSupportApprover.m_iUserId);

            //Then Raise the request
            RaiseRequest(oNextSupportApprover, lRequestId);
            
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void RaiseRequest(appUsers oNextSupportApprover, long lRequestId)
    {
        try
        {
            //long lRequestId = 0;
            string sRequestNumber = AutoNumber.GenerateAutoNumber();

            FlareWaiver oFlareWaiver = new FlareWaiver();
            oFlareWaiver.m_iCategoryId = int.Parse(ddlCategory.SelectedValue);
            //oFlareWaiver.m_iFacilityId = int.Parse(ddlFacilities.SelectedValue);

            //oFlareWaiver.m_iStatus = 1;
            oFlareWaiver.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
            //oFlareWaiver.m_sDateCreated = "";
            oFlareWaiver.m_sEndDate = dtEndDate.SelectedDate;
            oFlareWaiver.m_sEndTime = endTime.SelectedTime.ToString();
            oFlareWaiver.m_sFlareVol = decimal.Parse(txtVolume.Text);
            oFlareWaiver.m_sJustification = txtJustification.Text;
            oFlareWaiver.m_sOilProduced = decimal.Parse(txtOil.Text);
            oFlareWaiver.m_sPostEvent = txtPostEvent.Text;
            oFlareWaiver.m_sReason = txtReason.Text;
            oFlareWaiver.m_sRequestNumber = sRequestNumber;
            oFlareWaiver.m_sStartDate = dtStartDate.SelectedDate;
            oFlareWaiver.m_sStartTime = startTime.SelectedTime.ToString();
            oFlareWaiver.m_lRequestId = lRequestId;

            string sMessage = "";

            if ((WorkOrder1.WorkOrderFileName.Value == null) || (WorkOrder1.WorkOrderFileName.Value == ""))
            {
                oFlareWaiver.m_sWorkOrder = "No Work Order attached!!!";
            }
            else
            {
                oFlareWaiver.m_sWorkOrder = WorkOrder1.WorkOrderFileName.Value;
            }

            bool bRet = oFlareWaiverRequestHelper.UpdateFlareWaiverRequest(oFlareWaiver, UploadFile, lRequestId, ref sMessage);

            if (bRet)
            {
                //Note: you need to know if the Line Manager was changed to another person
                FlareApproval oApprover = oFlareApprovalHelper.objGetFlareApprovalbyRequestRoleId(lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager);
                if (oApprover.m_iUserId != int.Parse(ddlManager.SelectedValue))
                {
                    //Update Assign the request to the Line Manager into the RequestApproval(Workflow) Table
                    bRet = oFlareWaiverRequestHelper.UpdateAssignRequestToNextApprover(lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager, oNextSupportApprover.m_iUserId);
                    if (bRet)
                    {
                        //Send email to the selected Line Manager, that he has a pending Flare waiver request and copy the Initiator
                        oFlareWaiver = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);

                        FlareWaiverSendMail.sendMail oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);

                        List<structUserMailIdx> cCopy = new List<structUserMailIdx>();
                        List<appUsers> lstFlrWaiverAdmins = oappUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.Administrator);
                        foreach (appUsers oAppUser in lstFlrWaiverAdmins)
                        {
                            cCopy.Add(oAppUser.structUserIdx);
                        }

                        cCopy.Add(oSessnx.getOnlineUser.structUserIdx);

                        oSendMail.ForwardRequestForSupportApproval(oFlareWaiver, oNextSupportApprover, oSessnx.getOnlineUser.structUserIdx);

                    }
                    else
                    {
                        ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
                    }
                }
                else
                {
                    //Do nothing
                }

                //Response.Redirect("~/App/FlareWaiver/FlarePendingRequests.aspx");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
       // Response.Redirect("~/App/FlareWaiver/FlarePendingRequests.aspx");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //TODO: To clear all the objects on the web form
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string oMessage = "";
            SaveFile oSaveFile = new SaveFile(); //UploadFile
            fileProperty MyFileProperties = oSaveFile.UploadFile(UploadFile, "", ref oMessage); //at this stage, the Project number has not been generated.

            WorkOrder1.LoadFileFromWorkOrder(MyFileProperties.sFileName);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}