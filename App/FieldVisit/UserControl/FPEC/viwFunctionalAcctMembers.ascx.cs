using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

public partial class UserControl_viwFunctionalAcctMembers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadSuperintendentAcctUserBySuperintendent(int superintendentId, string superintendent)
    {
        idSuperHF.Value = superintendentId.ToString();
        superintendentLabel.Text = Encoder.HtmlEncode(superintendent) + " Functional account members";
        grdView.DataSource = SuperintendentFunctionalAcctUser.dtGetSuperintendentFunctionalAcctUsersBySuperintendent(superintendentId);
        grdView.DataBind();
    }

    public void LoadOpsMgrAcctUserBySuperintendent(int superintendentId, string superintendent)
    {
        idSuperHF.Value = superintendentId.ToString();
        superintendentLabel.Text = Encoder.HtmlEncode(superintendent) + " Functional account members";
        grdView.DataSource = OpsMgrFunctionalAcctUser.dtGetOpsMgrFunctionalAcctUsersBySuperintendent(superintendentId);
        grdView.DataBind();
    }

    private void LoadSuperintendentAcctUser(int superintendentId)
    {
        grdView.DataSource = SuperintendentFunctionalAcctUser.dtGetSuperintendentFunctionalAcctUsersBySuperintendent(superintendentId);
        grdView.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);

        LinkButton lnkDelete = (LinkButton)row.FindControl("deleteLinkButton");
        int iUserID = int.Parse(lnkDelete.Attributes["USERID"].ToString());

        bool success = SuperintendentFunctionalAcctUser.RemoveFromSuperintendent(iUserID);
        if (success)
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "User successfully Removed from this superintendent.");
            LoadSuperintendentAcctUser(int.Parse(idSuperHF.Value));
        }
    }
}
