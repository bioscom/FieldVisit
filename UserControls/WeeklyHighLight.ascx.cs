using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_WeeklyHighLight : aspnetUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Init_Page()
    {
        GetFiles();
    }

    //private void Clear()
    //{
    //    ddlWk.ClearSelection();
    //    xyFileUpload.FileContent.Close();
        
    //    dtFrom.setDate("");
    //    dtTo.setDate("");
    //}

    private void GetFiles()
    {
        gviw.DataSource = WeeklyHighlightsHelper.DtGetWeeklyHighlights();
        gviw.DataBind();

        //if (oSessnx.getOnlineUser.m_iRolePdcc == (int)appUsersRoles.userRole.admin)
        //{
        //    gviw.Columns[2].Visible = true;
        //}
        //else
        //{
        //    gviw.Columns[2].Visible = false;
        //}

        //foreach (GridViewRow grdRow in gviw.Rows)
        //{
        //    LinkButton lbDelete = (LinkButton)grdRow.FindControl("deleteLinkButton");
        //    lbDelete.OnClientClick = "return confirm('Are you sure you want to delete the file?')";
        //}
    }

    protected void gviw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gviw.PageIndex = e.NewPageIndex;
        GetFiles();
    }
    protected void gviw_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            var buttonClicked = e.CommandName;

            var index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row
            if (buttonClicked == "View")
            {
                var lbView = (LinkButton) gviw.Rows[index].FindControl("ViewLinkButton");
                long HighlightById = long.Parse(lbView.Attributes["HIGHLIGHTID"]);

                WeeklyHighlights o = WeeklyHighlightsHelper.objGetWeeklyHighlightById(HighlightById);

                string strfn = Convert.ToString(DateTime.Now.ToFileTime()) + o.sFileName;

                //retrieving binary data of pdf from datatable to byte array
                byte[] blob = (byte[])o.bBlob;

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("content-disposition", "Attachment; filename=" + strfn);
                HttpContext.Current.Response.AddHeader("content-length", blob.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(blob);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest(); //instead of Response.End()
                HttpContext.Current.Response.End();
            }

            //if (buttonClicked == "deleteThis")
            //{
            //    LinkButton lbDelete = (LinkButton)gviw.Rows[index].FindControl("deleteLinkButton");
            //    string fileName = lbDelete.Attributes["fileName"];

            //    //string path = Server.MapPath(VirtualPath + fileName);
            //    //if (File.Exists(path))
            //    //{
            //    //    File.Delete(path);
            //    //    GetFiles();
            //    //}
            //}
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }
    }
}