using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class LRegister : System.Web.UI.Page
{
    Encryption encryptPassword = new Encryption();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addRoleToDropDown(appUsersRoles.userRole.initiator);
            addRoleToDropDown(appUsersRoles.userRole.planner);
            addRoleToDropDown(appUsersRoles.userRole.sponsor);
            addRoleToDropDown(appUsersRoles.userRole.superintendent);
        }
    }

    private void addRoleToDropDown(appUsersRoles.userRole eRole)
    {
        try
        {
            ListItem oItem = new ListItem();
            oItem.Text = appUsersRoles.userRoleDesc(eRole);
            oItem.Value = ((int)eRole).ToString();
            userRoleDropDownList.Items.Add(oItem);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        //try
        //{
            //Validate the User name before submitting.
            DataExistenceValidator bValidate = new DataExistenceValidator();
            bool exists = bValidate.bValidateDataEntry(txtUserName.Text.Replace("'", "''"), "USERNAME", "PROD_USERMGT");
            if (exists == true)
            {
                string message = txtUserName.Text + " is already in use, try another user name.";
                mssgLabel.Text = Encoder.HtmlEncode(message);
                ajaxWebExtension.showJscriptAlert(Page, this, message);
            }
            else
            {
                if (Encryption.IsStrongPassword(txtPassword.Text.Trim()))
                {
                    if (txtPassword.Text != txtRetryPassword.Text.Trim())
                    {
                        string message = "Password not the same, try re-enter your password.";
                        mssgLabel.Text = message;
                        ajaxWebExtension.showJscriptAlert(Page, this, message);
                    }
                    else
                    {
                        string EncryptedPaswd = encryptPassword.encryptPassword(txtPassword.Text.Trim());

                        appUsers oAppUser = new appUsers();
                        oAppUser.m_iRoleIdFieldVisit = int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRoleIdBI = null; //int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRoleIdContract = null; //int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRoleIdFlr = null; //int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRoleIdLean = null; //int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRoleIdManHr = null; //int.Parse(userRoleDropDownList.SelectedValue);
                        oAppUser.m_iRolePdcc = null; //int.Parse(userRoleDropDownList.SelectedValue);

                        oAppUser.m_sFullName = txtFullName.Text;
                        oAppUser.m_sRefInd = txtRefInd.Text;
                        oAppUser.m_sUserMail = txtEmailAddress.Text;
                        oAppUser.m_sUserName = txtUserName.Text.ToUpper();
                        oAppUser.m_sPassword = EncryptedPaswd;

                        bool success = appUsersHelper.CreateUserAccountEx(oAppUser);
                        if (success == true)
                        {
                            //Send mail to the defined user
                            sendMailFieldVisit oMail = new sendMailFieldVisit(sendMailFieldVisit.eManager());
                            oMail.UserDefinition(oAppUser);
                            Response.Redirect("~/Login.aspx");
                        }
                        else
                        {
                            string mssg = "Not successful, try again.";
                            ajaxWebExtension.showJscriptAlert(Page, this, mssg);
                        }
                    }
                }
                else
                {
                    string mssg = "Minimum and Maximum Length of field - 6 to 12 Characters. Special Characters Not Allowed. Spaces Not Allowed. At least one Numeric Character. At least one Capital Letter.";
       
                    
                    ajaxWebExtension.showJscriptAlert(Page, this, mssg);
                }
            }
            
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //    ajaxWebExtension.showJscriptAlert(Page, this, "User not successfully defined, please try again later.");
        //}
    }
}