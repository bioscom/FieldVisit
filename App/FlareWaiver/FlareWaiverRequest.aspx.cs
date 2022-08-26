using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CS.BLL.FlareWaiver;

public partial class FlareWaiverRequest : aspnetPage
{
    appUsersHelper oappUsersHelper = new appUsersHelper();
    FlareWaiverRequestHelper oFlareWaiverRequestHelper = new FlareWaiverRequestHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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

            List<appUsers> oappUsers = oappUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.LineManager); //Load Line Managers
            foreach (appUsers oAppUser in oappUsers)
            {
                ddlManager.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
            }

            ddlSchedule.Items.Add(new ListItem(commonEnums.BusinessPlanDesc(commonEnums.BusinessPlan.Scheduled), ((int)commonEnums.BusinessPlan.Scheduled).ToString()));
            ddlSchedule.Items.Add(new ListItem(commonEnums.BusinessPlanDesc(commonEnums.BusinessPlan.Unscheduled), ((int)commonEnums.BusinessPlan.Unscheduled).ToString()));

            //txtOil.Attributes.Add("onkeypress", "return isNumberKey(event)");
            //txtVolume.Attributes.Add("onkeypress", "return isNumberKey(event)");
            //txtOil.Attributes.Add("onkeypress", "return checkForSecondDecimal(this, event)");
            //txtVolume.Attributes.Add("onkeypress", "return checkForSecondDecimal(this, event)");

            //WorkOrder1.InitWorkOrder();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int i = 0;
        try
        {
            int kount = facilitiesCkbLst.Items.Count;
            foreach (ListItem li in facilitiesCkbLst.Items)
            {
                if (li.Selected == false)
                {
                    i++;
                }
            }

            if (i == kount)
            {
                string sRet = "At least, a facility must be selected before you can submit this flare waiver request.";
                ajaxWebExtension.showJscriptAlert(Page, this, sRet);
            }
            else
            {
                appUsers oNextSupportApprover = oappUsersHelper.objGetUserByUserID(int.Parse(ddlManager.SelectedValue));

                //Raise the request
                RaiseRequest(oNextSupportApprover);
            }
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    private void RaiseRequest(appUsers oNextSupportApprover)
    {
        try
        {
            long lRequestId = 0;
            string sRequestNumber = AutoNumber.GenerateAutoNumber();

            var oFlareWaiver = new FlareWaiver();
            oFlareWaiver.m_iCategoryId = int.Parse(ddlCategory.SelectedValue);
            //oFlareWaiver.m_iFacilityId = int.Parse(ddlFacilities.SelectedValue);

            
            //oFlareWaiver.m_iStatus = 1;
            oFlareWaiver.m_iUserId = oSessnx.getOnlineUser.m_iUserId;
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
            oFlareWaiver.m_iInOutBusinessPlan = int.Parse(ddlSchedule.SelectedValue);
            
            string sMessage = "";

            if ((WorkOrder1.WorkOrderFileName.Value == null) || (WorkOrder1.WorkOrderFileName.Value == ""))
            {
                oFlareWaiver.m_sWorkOrder = "No Work Order attached!!!";
            }
            else
            {
                oFlareWaiver.m_sWorkOrder = WorkOrder1.WorkOrderFileName.Value;
            }

            bool bRet = oFlareWaiverRequestHelper.RaiseFlareWaiverRequest(oFlareWaiver, UploadFile, ref lRequestId, ref sMessage);
            if (bRet)
            {
                // Insert the Facilities selected against the Request
                var oRequestFacilityHelper = new RequestFacilityHelper();
                foreach (ListItem li in facilitiesCkbLst.Items)
                {
                    if (li.Selected == true)
                    {
                        oRequestFacilityHelper.InsertFacilityForRequest(lRequestId, int.Parse(li.Value));
                    }
                }

                //Assign the request to the Line Manager into the RequestApproval(Workflow) Table
                bRet = oFlareWaiverRequestHelper.AssignRequestToNextApprover(lRequestId, (int)appUserRolesFlrWaiver.userRole.LineManager, oNextSupportApprover.m_iUserId);
                if (bRet)
                {
                    btnSubmit.Enabled = false; //Lock the Submit button to prevent users from double entry.
                    //Send email to the selected Line Manager, that he has a pending Flare waiver request and copy the Initiator
                    oFlareWaiver = oFlareWaiverRequestHelper.objGetFlareWaiverRequestById(lRequestId);

                    var oSendMail = new FlareWaiverSendMail.sendMail(oSessnx.getOnlineUser.structUserIdx);

                    var cCopy = new List<structUserMailIdx>();
                    List<appUsers> lstFlrWaiverAdmins = oappUsersHelper.lstGetFlareWaiverUserByRole((int)appUserRolesFlrWaiver.userRole.Administrator);
                    foreach(appUsers oAppUser in lstFlrWaiverAdmins)
                    {
                        cCopy.Add(oAppUser.structUserIdx);
                    }

                    cCopy.Add(oSessnx.getOnlineUser.structUserIdx);

                    oSendMail.ForwardRequestForSupportApproval(oFlareWaiver, oNextSupportApprover, cCopy);

                    //Response.Redirect("~/App/FlareWaiver/FlarePendingRequests.aspx");
                }
                else
                {
                    ajaxWebExtension.showJscriptAlert(Page, this, sMessage);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/App/FlareWaiver/FlarePendingRequests.aspx");
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
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
}