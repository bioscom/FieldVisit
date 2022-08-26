using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class UserControls_Login : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            msgPanel.Visible = false;
            ajaxWebExtension.showJscriptAlert(Page, this, "Your profile does not exist on Staff Information Database. Please register your profile and keep your password safe.");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Encryption encryptPassword = new Encryption();
        string retrievedEncryptedPaswd = encryptPassword.encryptPassword(txtPassword.Text.Trim());
        bool bFound = appUsersHelper.LoginToUserAccountEx(txtUserName.Text.ToUpper().Trim(), retrievedEncryptedPaswd);

        appUsers eAppUserInfo = appUsersHelper.objGetUserByUserIdEx(txtUserName.Text.ToUpper().Trim(), retrievedEncryptedPaswd);
        if (bFound)
        {
            FormsAuthentication.RedirectFromLoginPage(eAppUserInfo.m_sUserName, true);
            httpSessionx oInitSessn = new httpSessionx(HttpContext.Current.Session, eAppUserInfo);

            msgPanel.Visible = true;
            string mssg = "Login successful, you can now continue to your choice application. Thank you.";
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
            mssgImg.ImageUrl = "~/Images/approved.png";
            mssgLabel.Text = mssg;
        }
        else
        {
            Session["PasswordTrial"] = int.Parse(Session["PasswordTrial"].ToString()) + 1;

            if (int.Parse(Session["PasswordTrial"].ToString()) > 3)
            {
                msgPanel.Visible = true;
                mssgImg.ImageUrl = "~/Images/smallFail.gif";
                mssgLabel.Text = "No of Password trial exceeded.";

                btnLogin.Enabled = false;
            }
            else
            {
                msgPanel.Visible = true;
                mssgImg.ImageUrl = "~/Images/smallFail.gif";
                mssgLabel.Text = "Invalid Username or Password. Try login again.";
            }
        }
    }
}