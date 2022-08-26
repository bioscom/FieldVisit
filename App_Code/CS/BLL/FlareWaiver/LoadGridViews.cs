using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for LoadGridViews
/// </summary>
public class LoadGridViews
{
    public LoadGridViews()
    {
        
    }

    public void LoadMyGridView(GridView grd, DataTable dt, string SortExpression)
    {
        if (dt.Rows.Count > 0)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = SortExpression;
            grd.DataSource = dv;
            grd.DataBind();
        }
    }

    public void PageIndexChanging(GridView grdView, GridViewPageEventArgs e, string CurrentSortExpression)
    {
        grdView.PageIndex = e.NewPageIndex;
        DataSorter SortMe = new DataSorter();
    }

    public void GridViewRowCommands(GridView grdView, GridViewCommandEventArgs e, string CurrentSortExpression, structUserMailIdx fromEmail, ref string oMessage)
    {
        //sendMail eMail = new sendMail(fromEmail);
        //eCTR ctr = new eCTR();
        //eCTRMgt oCTRMgt = new eCTRMgt();
        //long lCtrId = 0;

        //string USERID = "";
        //string ButtonClicked = e.CommandName;
        //DataSorter SortMe = new DataSorter();

        //try
        //{
        //    if ((ButtonClicked == "Sort") || (ButtonClicked == "Page") || (ButtonClicked == "Last"))
        //    {
        //        CurrentSortExpression = SortMe.MySortExpression(e);
        //    }
        //    else
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        if (ButtonClicked == "ViewStatus")
        //        {
        //            LinkButton lbViewStatus = (LinkButton)grdView.Rows[index].FindControl("ViewStatusLinkButton");
        //            lCtrId = long.Parse(lbViewStatus.Attributes["CTRID"].ToString());
        //            HttpContext.Current.Response.Redirect("~/Common/CTRStatus.aspx" + "?CTRID=" + lCtrId, false);
        //        }

        //        if (ButtonClicked == "ViewCTR")
        //        {
        //            LinkButton lbCTR = (LinkButton)grdView.Rows[index].FindControl("CTRLinkButton");
        //            lCtrId = long.Parse(lbCTR.Attributes["CTRID"].ToString());
        //            HttpContext.Current.Response.Redirect("~/Common/ViewCTR.aspx" + "?CTRID=" + lCtrId, false);
        //        }

        //        if (ButtonClicked == "RerouteCTR")
        //        {
        //            LinkButton lbRerouteCTR = (LinkButton)grdView.Rows[index].FindControl("RerouteCTRLinkButton");
        //            lCtrId = long.Parse(lbRerouteCTR.Attributes["CTRID"].ToString());
        //            HttpContext.Current.Response.Redirect("~/Common/CTRRouter.aspx" + "?lCtrId=" + lCtrId, false);
        //        }

        //        if (ButtonClicked == "forwardCTR")
        //        {
        //            LinkButton lbForwardCTR = (LinkButton)grdView.Rows[index].FindControl("forwardCTRLinkButton");
        //            lCtrId = long.Parse(lbForwardCTR.Attributes["CTRID"].ToString());

        //            ctr = oCTRMgt.objGetCtrByCtrId(lCtrId);

        //            bool success = eMail.ForwardCTR(ctr, fromEmail);
        //            if (success == true)
        //            {
        //                oMessage = "CTR successfully forwarded.";
        //            }
        //            else
        //            {
        //                oMessage = "CTR not forwarded, try again later.";
        //            }
        //        }

        //        if (ButtonClicked == "AddComment")
        //        {
        //            LinkButton lbAddComment = (LinkButton)grdView.Rows[index].FindControl("AddCommentLinkButton");
        //            lCtrId = long.Parse(lbAddComment.Attributes["CTRID"].ToString());
        //            HttpContext.Current.Response.Redirect("~/Common/CTRApproval.aspx" + "?CTRID=" + lCtrId, false);
        //        }

        //        if (ButtonClicked == "EditThisCTR")
        //        {
        //            LinkButton lbEditCTR = (LinkButton)grdView.Rows[index].FindControl("EditCTRLinkButton");
        //            lCtrId = long.Parse(lbEditCTR.Attributes["CTRID"].ToString());
        //            ctr = oCTRMgt.objGetCtrByCtrId(lCtrId);
                    
        //            //if (Convert.ToInt32(ctr.m_sSTATUS) == ctrStatus.iBusinessFinanceUnit)
        //            //{
        //            //    MessageBox.Show(ctr.m_sCTRNO + " CTR has been approved by Category Lead Man Power, can no longer be edited.");
        //            //}
        //            //else
        //            //{
        //                HttpContext.Current.Response.Redirect("~/CTRInitiator/EditCTR.aspx?CTRID=" + lCtrId, false);
        //            //}
        //        }                

        //        if (ButtonClicked == "EditThisUser")
        //        {
        //            Button btnEditUser = (Button)grdView.Rows[index].FindControl("editUserLinkButton");
        //            USERID = btnEditUser.Attributes["USERID"].ToString();
        //            HttpContext.Current.Response.Redirect("~/BusinessProcessOwner/EditUser.aspx?USERID=" + USERID, false);
        //        }

        //        if (ButtonClicked == "EditAffliate")
        //        {
        //            Button btnEditAffliate = (Button)grdView.Rows[index].FindControl("editAffliateLinkButton");
        //            string AFFLIATEID = btnEditAffliate.Attributes["AFFLIATEID"].ToString();
        //            HttpContext.Current.Response.Redirect("~/BusinessProcessOwner/CTRNumbering.aspx?AffliateID=" + AFFLIATEID, false);
        //        }

        //        if (ButtonClicked == "EditOU")
        //        {
        //            Button btnEditOU = (Button)grdView.Rows[index].FindControl("editOULinkButton");
        //            string OUSID = btnEditOU.Attributes["OUSID"].ToString();
        //            HttpContext.Current.Response.Redirect("~/BusinessProcessOwner/CTRNumbering.aspx?OUSID=" + OUSID, false);
        //        }

        //        if (ButtonClicked == "DeleteThisUser")
        //        {
        //            Button delete = (Button)grdView.Rows[index].FindControl("deleteLinkButton");
        //            USERID = delete.Attributes["USERID"].ToString();

        //            BusinessProcessOwner BPO = new BusinessProcessOwner();
        //            bool success = BPO.DeleteUser(USERID);
        //            if (success == true)
        //            {
        //                oMessage = "User Successfully Deleted";
        //            }
        //            else
        //            {
        //                oMessage = "User was not deleted, please try again later.";
        //            }
        //        }

        //        if (ButtonClicked == "ViewPendingApprovals")
        //        {
        //            LinkButton PendingApprovals = (LinkButton)grdView.Rows[index].FindControl("PendingApprovalsLinkButton");
        //            string UserId = PendingApprovals.Attributes["USERID"].ToString();
        //            HttpContext.Current.Response.Redirect("~/Common/CtrAwaitingApprover.aspx?UserId=" + UserId);
        //        }

        //        if (ButtonClicked == "ViewCTRInvolved")
        //        {
        //            LinkButton CTRInvolved = (LinkButton)grdView.Rows[index].FindControl("ViewCTRInvolvedLinkButton");
        //            string UserId = CTRInvolved.Attributes["USERID"].ToString();
        //            HttpContext.Current.Response.Redirect("~/Common/CTRSInvolved.aspx?UserId=" + UserId);
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        //}
    }
}