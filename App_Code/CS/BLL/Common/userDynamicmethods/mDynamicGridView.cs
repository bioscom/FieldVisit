using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

    /// <summary>
    /// Article: Dynamically Templated GridView with Edit,Insert and Delete Options
    /// Author: Isaac Bejide
    /// Brief Notes: This class implements ITemplate which is resposible to create template fields of 
    /// the GridView dynamically and also to add buttons for Edit,Delete and Insert.
    /// </summary>
    /// 
    public class mDynamicGridView : ITemplate
    {
        ListItemType ItemType;
        string FieldName;
        string InfoType;

        public mDynamicGridView(ListItemType item_type, string field_name, string info_type)
        {
            ItemType = item_type;
            InfoType = info_type;
            FieldName = field_name;
        }

        public void InstantiateIn(System.Web.UI.Control Container)
        {
            switch (ItemType)
            {
                case ListItemType.Header:
                    Literal header_ltrl = new Literal();
                    //header_ltrl.Text = "<b>" + FieldName + "</b>";
                    header_ltrl.Text = FieldName;
                    Container.Controls.Add(header_ltrl);
                    break;

                case ListItemType.Item:
                    switch (InfoType)
                    {
                        case "Command":
                            ImageButton edit_button = new ImageButton();
                            //define the propoerties and members of the editbutton
                            //
                            edit_button.ID = "edit_button";
                            edit_button.ImageUrl = "~/images/edit.gif";
                            edit_button.CommandName = "Edit";
                            edit_button.ValidationGroup = "MySelf";
                            //edit_button.CommandArgument = "Container.DisplayIndex"; //New idea
                            //CommandArgument='<%# Container.DisplayIndex %>'
                            edit_button.Click += new ImageClickEventHandler(edit_button_Click);
                            edit_button.ToolTip = "Edit";
                            //Add the edit_button to the gridView
                            //
                            Container.Controls.Add(edit_button);

                            //ImageButton delete_button = new ImageButton();
                            //delete_button.ID = "delete_button";
                            //delete_button.ImageUrl = "~/images/delete.gif";
                            //delete_button.CommandName = "Delete";
                            //delete_button.ToolTip = "Delete";
                            //delete_button.OnClientClick = "return confirm('Are you sure you want to delete the record?')";
                            //Container.Controls.Add(delete_button);

                            /* Similarly add button for insert.
                             * It is important to know when 'insert' button is added 
                             * its CommandName is set to "Edit"  like that of 'edit' button 
                             * only because we want the GridView enter into Edit mode, 
                             * and this time we also want the text boxes for corresponding fields empty*/
                            //ImageButton insert_button = new ImageButton();
                            //insert_button.ID = "insert_button";
                            //insert_button.ImageUrl = "~/images/insert.bmp";
                            //insert_button.CommandName = "Edit";
                            //insert_button.ToolTip = "Insert";
                            //insert_button.Click += new ImageClickEventHandler(insert_button_Click);
                            //Container.Controls.Add(insert_button);

                            break;

                        default:
                            Label field_lbl = new Label();
                            field_lbl.ID = FieldName;

                            if (FieldName == "Corporate Priorities")
                            {
                                //field_lbl.Font.Bold = true;
                                field_lbl.ForeColor = Color.Navy;
                            }

                            if (FieldName == "KPI Group")
                            {
                                //field_lbl.Font.Bold = true;
                                field_lbl.ForeColor = Color.Green;
                            }

                            if (FieldName == "Key Performance Indicators")
                            {
                                //field_lbl.Font.Bold = true;
                                //field_lbl.ForeColor = Color.DarkRed;
                            }

                            if (FieldName == "Unit")
                            {
                                //field_lbl.Font.Bold = true;
                                //field_lbl.ForeColor = Color.DarkRed;
                            }

                            field_lbl.Text = String.Empty; //we will bind it later through 'OnDataBinding' event
                            field_lbl.DataBinding += new EventHandler(OnDataBinding);
                            Container.Controls.Add(field_lbl);
                            break;
                    }
                    break;

                case ListItemType.EditItem:
                    if (InfoType == "Command")
                    {
                        ImageButton update_button = new ImageButton();
                        update_button.ID = "update_button";
                        update_button.CommandName = "Update";
                        update_button.ImageUrl = "~/images/update.gif";

                        if ((int)new Page().Session["InsertFlag"] == 1)
                        {
                            update_button.ToolTip = "Add";
                        }
                        else    //i.e. Session["InsertFlag"] == 0
                        {
                            update_button.ToolTip = "Update";
                            //update_button.ValidationGroup = "MySelf";
                            update_button.OnClientClick = "return confirm('Are you sure to update the record?')";
                            Container.Controls.Add(update_button);

                            ImageButton cancel_button = new ImageButton();
                            cancel_button.ImageUrl = "~/images/cancel.gif";
                            cancel_button.ID = "cancel_button";
                            cancel_button.CommandName = "Cancel";
                            cancel_button.ToolTip = "Cancel";
                            //cancel_button.ValidationGroup = "MySelf";
                            Container.Controls.Add(cancel_button);
                        }
                    }
                    else            // for other 'non-command' i.e. the key and non key fields, bind textboxes with corresponding field values
                    {
                        // if Inert is intended no need to bind it with text..keep them empty
                        if ((int)new Page().Session["InsertFlag"] == 0)
                        {
                            if ((FieldName == "Corporate Priorities") || (FieldName == "KPI Group") || (FieldName == "Key Performance Indicators") || (FieldName == "Unit") || (FieldName == "BP Target") || (FieldName == "Rating") || (FieldName == "Date Updated") || (FieldName == "Updated by") || (FieldName == "DNLT Owner"))
                            {
                                Label field_lbl = new Label();
                                field_lbl.ID = FieldName;

                                //if (FieldName == "KPIID") { field_lbl.Visible = false;  }
                                if (FieldName == "Corporate Priority") { field_lbl.Font.Bold = true; field_lbl.ForeColor = Color.Navy; }
                                if (FieldName == "KPI Group") { field_lbl.Font.Bold = true; }
                                if (FieldName == "Key Performance Index") { field_lbl.Font.Bold = true; }
                                //if (FieldName == "Unit") { field_lbl.Font.Bold = true; field_lbl.ForeColor = Color.DarkRed; }
                                //if (FieldName == "Target") { field_lbl.Font.Bold = true; field_lbl.ForeColor = Color.DarkRed; }                                

                                field_lbl.Text = String.Empty; //we will bind it later through 'OnDataBinding' event
                                ItemType = ListItemType.Item;  //this is a test
                                field_lbl.DataBinding += new EventHandler(OnDataBinding);
                                Container.Controls.Add(field_lbl);
                            }
                            else
                            {
                                TextBox field_txtbox = new TextBox();
                                field_txtbox.ID = FieldName;
                                field_txtbox.Text = String.Empty;
                                
                                if (FieldName == "Remarks")
                                {
                                    field_txtbox.TextMode = TextBoxMode.MultiLine;
                                    field_txtbox.Height = Unit.Pixel(80);
                                    field_txtbox.Width = Unit.Pixel(300);
                                    field_txtbox.Wrap = true;
                                }
                                                                    
                                if ((FieldName == "YTD Plan")||(FieldName == "YTD Actual")||(FieldName == "FYLE"))
                                {
                                    field_txtbox.Attributes.Add("onkeypress", "return isMoneyNumbKey(event,'" + field_txtbox.ClientID + "');");
                                    field_txtbox.Width = Unit.Pixel(50);
                                }

                                ItemType = ListItemType.EditItem;    //this is a test
                                field_txtbox.DataBinding += new EventHandler(OnDataBinding);
                                Container.Controls.Add(field_txtbox);
                            }
                        }
                    }
                    break;
            }

        }

        //just sets the insert flag ON so that we ll be able to decide in OnRowUpdating event whether to insert or update
        //protected void insert_button_Click(Object sender, EventArgs e)
        //{
        //    new Page().Session["InsertFlag"] = 1;
        //}

        //just sets the insert flag OFF so that we ll be able to decide in OnRowUpdating event whether to insert or update 
        protected void edit_button_Click(Object sender, EventArgs e)
        {
            new Page().Session["InsertFlag"] = 0;
        }

        private void OnDataBinding(object sender, EventArgs e)
        {

            object bound_value_obj = null;
            Control ctrl = (Control)sender;
            IDataItemContainer data_item_container = (IDataItemContainer)ctrl.NamingContainer;
            bound_value_obj = DataBinder.Eval(data_item_container.DataItem, FieldName);

            switch (ItemType)
            {
                case ListItemType.Item:
                    Label field_ltrl = (Label)sender;
                    field_ltrl.Text = bound_value_obj.ToString();

                    break;
                case ListItemType.EditItem:
                    TextBox field_txtbox = (TextBox)sender;
                    field_txtbox.Text = bound_value_obj.ToString();

                    break;
            }
        }
    }
