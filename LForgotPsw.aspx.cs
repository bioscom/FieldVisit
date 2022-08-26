using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class LForgotPsw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            msgPanel.Visible = false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        appUsers me = appUsersHelper.UpdateUserAccountPswEx(txtEmailAddress.Text.Trim());
        if (me.m_sUserMail != null)
        {
            //Send mail to the user for successful password reset
            sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
            oMail.UserPasswordReset(new structUserMailIdx(me.m_sUserName, txtEmailAddress.Text, me.m_iUserId.ToString()), me);

            msgPanel.Visible = true;
            mssgImg.ImageUrl = "~/Images/approved.png";
            mssgLabel.Text = "Your account password has been successfully updated and an email sent to " + Encoder.HtmlEncode(txtEmailAddress.Text) + ". Follow the instruction in the email to reset your password.";
        }
        else
        {
            msgPanel.Visible = true;
            mssgImg.ImageUrl = "~/Images/smallFail.gif";
            mssgLabel.Text = "We couldn't find an account associated with " + Encoder.HtmlEncode(txtEmailAddress.Text);
        }
    }
}