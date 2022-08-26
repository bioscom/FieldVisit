using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_LoadDocs : System.Web.UI.Page
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ProjectId"] != null) //ProjectId
            {
                long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
                MainProjects oMainProject = oMainProjectHelper.objGetLeanProjectsByProjectId(lProjectId);
                oLeanProjectDetails1.Init_Control(oMainProject);

                BindGrid();
            }
        }
    }

    // Populate the GridView with data
    private void BindGrid()
    {
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());
        grid.DataSource = CatalogAccess.GetAllDocumentsInProject(lProjectId);

        grid.DataBind();
        if (Request.QueryString["VIW"] != null)
        {
            oPanel.Visible = false;
            grid.Columns[3].Visible = false;
            grid.Columns[4].Visible = false;
        }
    }

    // Enter row into edit mode
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        grid.EditIndex = e.NewEditIndex;
        // Set status message 
        statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        BindGrid();
    }

    // Cancel edit mode
    protected void grid_RowCancelingEdit(object sender,
    GridViewCancelEditEventArgs e)
    {
        // Cancel edit mode
        grid.EditIndex = -1;
        // Set status message
        statusLabel.Text = "Editing canceled";
        // Reload the grid
        BindGrid();
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        try
        {
            long lDocumentId = long.Parse(grid.DataKeys[e.RowIndex].Value.ToString());
            string title = ((TextBox)grid.Rows[e.RowIndex].FindControl("nameTextBox")).Text;
            string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
            //string sFileName = ((TextBox)grid.Rows[e.RowIndex].FindControl("imageTextBox")).Text;

            bool success = CatalogAccess.UpdateDocument(lDocumentId, title, description); //, sFileName
            // Cancel edit mode
            grid.EditIndex = -1;
            // Display status message
            statusLabel.Text = success ? "Document update successful" : "Document update failed";
        }
        catch
        {
            // Display error
            statusLabel.Text = "Document update failed";
        }
        // Reload grid
        BindGrid();
    }

    // Create a new product
    protected void cmdUpload_Click(object sender, EventArgs e)
    {
        TimeDateCulture ourCulture = new TimeDateCulture();
        // Get CategoryID from the query string
        long lProjectId = long.Parse(Request.QueryString["ProjectId"].ToString());

        if (FUpload.HasFile)
        {
            try
            {
                string fileName = FUpload.FileName;

                string location = Server.MapPath("./Documents/") + fileName;
                // save image to server
                FUpload.SaveAs(location);

                bool success = CatalogAccess.CreateDocument(lProjectId, txtTitle.Text, txtDescription.Text, fileName);
                // Display status message
                statusLabel.Text = success ? "Insert successful" : "Insert failed";
                // Reload the grid
                BindGrid();
            }
            catch
            {
                statusLabel.Text = "Uploading image 1 failed";
            }
        }
        else
        {
            ajaxWebExtension.showJscriptAlert(Page, this, "No file selected for upload");
        }
    }

    //protected void cmdUpload_Click(object sender, EventArgs e)
    //{
    //    // proceed with uploading only if the user selected a file
    //    if (FUpload.HasFile)
    //    {
    //        try
    //        {
    //            //string fileName = FUpload.FileName;
    //            //string location = Server.MapPath("./Documents/") + fileName;
    //            //// save image to server
    //            //FUpload.SaveAs(location);
    //            //// update database with new product details
    //            //DocumentDetails dd = CatalogAccess.objGetDocumentDetails(currentProductId);
    //            //CatalogAccess.UpdateDocument(currentProductId, dd.Name, dd.Description, dd.Price.ToString(), fileName, dd.Image, dd.PromoDept.ToString(), dd.PromoFront.ToString());
    //            //// reload the page 
    //            //Response.Redirect("AdminProductDetails.aspx" +
    //            //        "?DepartmentID=" + currentDepartmentId +
    //            //        "&CategoryID=" + currentCategoryId +
    //            //        "&ProductID=" + currentProductId);
    //        }
    //        catch
    //        {
    //            statusLabel.Text = "Uploading image 1 failed";
    //        }
    //    }
    //}
    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ButtonClicked = e.CommandName; //Determines which button was clicked (stores the name of each button)
        if ((ButtonClicked == "Sort") || (ButtonClicked == "Page"))
        {
            //CurrentSortExpression = sortMe.MySortExpression(e);

            //int result;
            //if (Int32.TryParse(e.CommandArgument.ToString(), out result) == false)
            //{
            //    Session["SortExpression"] = e.CommandArgument.ToString();
            //}
            //CurrentSortExpression = Session["SortExpression"].ToString();
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument); //Command Argument stores the index of each row

            if (ButtonClicked == "view")
            {
                string file = e.CommandArgument.ToString();
                DownloadFile(file);
            }

            if (ButtonClicked == "deleteThis")
            {
                LinkButton lbDelete = (LinkButton)grid.Rows[index].FindControl("deleteLinkButton");
                long lDocumentId = long.Parse(lbDelete.Attributes["IDDOC"].ToString());
                bool success = CatalogAccess.DeleteDocument(lDocumentId);
                BindGrid();
            }
        }
    }

    protected void DownloadFile(string filepath)
    {
        System.IO.Stream iStream = null;
        //Buffer to read 10K bytes in chunk
        byte[] buffer = new Byte[10000];
        //length of the file:
        int length;

        //Total byte to read
        long dataToRead;

        //Identify the file name.
        string filename = System.IO.Path.GetFileName(filepath);
        try
        {
            //open the file
            iStream= new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

            //Total bytes to read
            dataToRead=iStream.Length;

            Response.AddHeader("Content-Disposition", "inline; filename="+filename);

            //read the bytes
            while(dataToRead>0)
            {
                //Verify that the client is connected.
                if(Response.IsClientConnected)
                {
                    //read the data in buffer.
                    length=iStream.Read(buffer, 0, 10000);

                    //write data to the current output stream.
                    Response.OutputStream.Write(buffer, 0, length);

                    //flush the data to the HTML Output
                    Response.Flush();
                    buffer=new Byte[10000];
                    dataToRead=dataToRead-length;
                }
                else{
                    //prevent infinite loop if user disconnects
                    dataToRead=-1;

                }
            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        finally
        {
            if(iStream!=null)
            {
                //close the file.
                iStream.Close();
            }
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/App/Lean/LeanProjects.aspx");
    }
}