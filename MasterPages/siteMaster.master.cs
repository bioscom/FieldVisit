using System;
using Microsoft.Security.Application;
using Telerik.Web.UI;
using System.Data;

public partial class MasterPages_siteMaster : aspnetMaster
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Head.Title = AppConfiguration.siteNameFlareWaiver;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblSiteName.Text = AppConfiguration.siteNameFlareWaiver;
        //logoutHyperLink.Attributes.Add("onclick", "return LogoutMessage()");
        loggedinUserLabel.Text = Encoder.HtmlEncode(oSessnx.getOnlineUser.m_sFullName) + " [" + Encoder.HtmlEncode(System.Web.HttpContext.Current.User.Identity.Name) + "]";

        if ((oSessnx.getOnlineUser.m_iRoleIdFlr == 0) || (oSessnx.getOnlineUser.m_iRoleIdFlr == null))
        {
            adminMenu1.Visible = false; //.InitMenu();
            Response.Redirect("~/Support/pageDenied.aspx?Msg=");
        }
        else
        {
            if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Administrator) adminMenu1.Init_Page(AppConfiguration.AdminMenuFlareWaiver);
            else if (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Initiator) adminMenu1.Init_Page(AppConfiguration.InitiatorMenuFlareWaiver);
            else if ((oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.LineManager)
                || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssurancePSMgr)
                || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOffshore)
                || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.AssuranceOnshore)
                || (oSessnx.getOnlineUser.m_iRoleIdFlr == (int)appUserRolesFlrWaiver.userRole.Approval))
                adminMenu1.Init_Page(AppConfiguration.ApproverMenuFlareWaiver);

            lblRole.Text = Encoder.HtmlEncode(appUserRolesFlrWaiver.userRoleDesc((appUserRolesFlrWaiver.userRole)oSessnx.getOnlineUser.m_iRoleIdFlr));
        }

        dateLabel.Text = DateTime.Today.Date.ToLongDateString();
    }
    //protected void searchButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    //{
    //    Response.Redirect("~/App/FlareWaiver/eSearch.aspx?xNo=" + txtFlarewaiverNum.Text.Trim());
    //}




    protected void ddlSearch_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        FlareApprovalHelper oFlareApprovalHelper = new FlareApprovalHelper();
        DataTable dt = !string.IsNullOrEmpty(e.Text) ? oFlareApprovalHelper.dtGetFlareWaiverByRequestNumber(e.Text) : null;
        RadComboControlLoader(dt, ddlSearch);
    }

    public static void RadComboControlLoader(DataTable dt, RadComboBox RadDdl)
    {
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var item = new RadComboBoxItem();
                item.Text = (string)dr["REQUESTNO"];
                item.Value = dr["IDREQUEST"].ToString();

                string email = dr["REQUESTNO"].ToString();
                string refInd = dr["REASON"].ToString();

                item.Attributes.Add("REQUESTNO", email);
                item.Attributes.Add("REASON", refInd);

                RadDdl.Items.Add(item);
                item.DataBind();
            }
        }
    }

    protected void ddlSearch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Response.Redirect("~/App/FlareWaiver/eSearch.aspx?lRequestId=" + ddlSearch.SelectedValue);//e.Value
    }
}
