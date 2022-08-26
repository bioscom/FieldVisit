using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class LPswReset : System.Web.UI.Page
{
    Encryption encryptPassword = new Encryption();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loginButton.Visible = false;
            saveButton.Visible = true;
        }
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        appUsers me = appUsersHelper.objGetUserByGuidPswEx(txtGuidPassword.Text.Trim());
        if (me.m_sUserMail != null)
        {
            if (Encryption.IsStrongPassword(txtPassword.Text.Trim()))
            {
                if (txtPassword.Text.Trim() != txtRetryPassword.Text.Trim())
                {
                    string message = "Password not the same, try re-enter your password.";
                    mssgLabel.Text = message;
                    ajaxWebExtension.showJscriptAlert(Page, this, message);
                }
                else
                {
                    string EncryptedPaswd = encryptPassword.encryptPassword(txtPassword.Text.Trim());

                    bool success = appUsersHelper.ResetUserGuidAccountPswEx(EncryptedPaswd, me.m_sUserMail);
                    if (success == true)
                    {
                        string mssg = "Password reset successful. You can now login to user the portal.";
                        mssgLabel.Text = mssg;

                        ajaxWebExtension.showJscriptAlert(Page, this, mssg);
                        loginButton.Visible = true;
                        saveButton.Visible = false;
                    }
                }
            }
            else
            {
                string mssg = "Minimum and Maximum Length of field - 6 to 25 Characters. Special Characters Not Allowed. Spaces Not Allowed. At least one Numeric Character. At least one Capital Letter.";

                mssgLabel.Text = mssg;
                ajaxWebExtension.showJscriptAlert(Page, this, mssg);
            }
        }
        else
        {
            string mssg = txtGuidPassword.Text + " not found! Please properly copy the password sent to you in the email, and try again.";

            mssgLabel.Text = Encoder.HtmlEncode(mssg);
            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
        }
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}