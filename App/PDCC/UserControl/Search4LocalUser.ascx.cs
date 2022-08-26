using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_userFinder_Search4LocalUser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void ErrorMssg(string sErrMssg)
    {
        valdtUserRequired.ErrorMessage = sErrMssg;
    }

    public void validationGroup()
    {
        valdtUserRequired.ValidationGroup = "xxx";
    }

    public void Page_Init()
    {
        UnResetUserInfo();
        List<appUsers> lstappUsers = appUsersHelper.lstGetUsers();
        foreach (appUsers oAppUser in lstappUsers)
        {
            drpUserx.Items.Add(new ListItem(oAppUser.m_sFullName, oAppUser.m_iUserId.ToString()));
        }
    }

    public void LoadMe()
    {
        
    }

    public void InitPage()
    {
        if (!IsPostBack)
        {
            drpUserx.Visible = false;
            imbEdit.Visible = false;
        }
    }

    public void editMode()
    {
        UnResetUserInfo();        
    }

    public appUsers selectedUserDetailsFromLocalTable
    {
        get
        {
            appUsers oAppUser = appUsersHelper.objGetAppUserByUserName(drpUserx.SelectedValue);
            return oAppUser;
        }
    }

    public DropDownList thisDropDownList
    {
        get
        {
            return drpUserx;
        }
    }

    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        txtUserx.Text = "";
        txtUserx.Visible = true;
        imbFind.Visible = true;
        drpUserx.Visible = false;
        imbEdit.Visible = false;

        if (drpUserx.Items.Count > 1)
        {
            resetUserInfo();
        }        
    }
    
    protected void imbFind_Click(object sender, ImageClickEventArgs e)
    {
        List<appUsers> staffs = appUsersHelper.lstGetUsersByName(txtUserx.Text.ToUpper());

        drpUserx.Visible = true;
        imbEdit.Visible = true;

        txtUserx.Visible = false;
        imbFind.Visible = false;

        drpUserx.Items.Clear();
        drpUserx.Items.Add(new ListItem("Please Select...", "-1"));
        foreach (appUsers staff in staffs)
        {
            drpUserx.Items.Add(new ListItem(staff.m_sFullName, staff.m_iUserId.ToString()));
        }

        if (staffs.Count == 0)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, "["+ txtUserx.Text + "] no match found!!!");
            resetUserInfo();
        }
    }

    public void resetUserInfo()
    {
        txtUserx.Visible = true;
        txtUserx.Text = "";
        imbFind.Visible = true;

        drpUserx.Visible = false;
        drpUserx.Items.Clear();
        imbEdit.Visible = false;

        ListItem oDefItem = new ListItem();
        oDefItem.Value = "-1";
        if (drpUserx.ToolTip == "")
        {
            oDefItem.Text = "[Select User]";
        }
        else
        {
            oDefItem.Text = "[" + drpUserx.ToolTip + "]";
        }
        drpUserx.Items.Add(oDefItem);
    }

    public void initUserInfo(string sToolTip, int xWidth)
    {
        txtUserx.Width = (Unit) (xWidth - (imbEdit.Width.Value * 1.6));
        drpUserx.Width = txtUserx.Width;
        drpUserx.ToolTip = sToolTip;

        resetUserInfo();
    }

    public void editUserInfo(string sToolTip, int xWidth)
    {
        txtUserx.Width = (Unit)(xWidth - (imbEdit.Width.Value * 1.6));
        drpUserx.Width = txtUserx.Width;
        drpUserx.ToolTip = sToolTip;

        UnResetUserInfo();
    }

    public void UnResetUserInfo()
    {
        txtUserx.Visible = false;
        txtUserx.Text = "";
        imbFind.Visible = false;

        drpUserx.Visible = true;
        drpUserx.Items.Clear();
        imbEdit.Visible = true;

        ListItem oDefItem = new ListItem();
        oDefItem.Value = "-1";
        if (drpUserx.ToolTip == "")
        {
            oDefItem.Text = "[Select User]";
        }
        else
        {
            oDefItem.Text = "[" + drpUserx.ToolTip + "]";
        }
        drpUserx.Items.Add(oDefItem);
    }

    public bool userIsValid
    {
        get
        {
            if (drpUserx.SelectedValue == "-1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public string _SelectedValue
    {
        get
        {
            return drpUserx.SelectedValue;
        }
    }

    public int setWidth
    {
        set
        {
            txtUserx.Width = (Unit) (value - (imbEdit.Width.Value * 1.6));
            drpUserx.Width = txtUserx.Width;
        }
    }
}