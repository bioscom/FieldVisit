using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_statusSelectorControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Page_Init()
    {
        ddlSelector.Items.Clear();
        ddlSelector.Items.Add(new ListItem("Select", "-1"));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.NV), ((int)mVerificationEnuem.mVerification.NV).ToString()));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.Red), ((int)mVerificationEnuem.mVerification.Red).ToString()));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.Bronze), ((int)mVerificationEnuem.mVerification.Bronze).ToString()));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.Silver), ((int)mVerificationEnuem.mVerification.Silver).ToString()));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.Gold), ((int)mVerificationEnuem.mVerification.Gold).ToString()));
        ddlSelector.Items.Add(new ListItem(mVerificationEnuem.VerificationDesc(mVerificationEnuem.mVerification.NA), ((int)mVerificationEnuem.mVerification.NA).ToString()));
    }

    public void Init_Control()
    {

    }

    public string SelectedStatus
    {
        get
        {
            return statusDrp.SelectedValue;
        }
    }

    public DropDownList ddlSelector
    {
        get
        {
            return statusDrp;
        }
    }

    public void _SelectedValue(int iSelectedValue)
    {
        statusDrp.SelectedValue = iSelectedValue.ToString();
    }
}
