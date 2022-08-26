<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="PdccTellYourStories.aspx.cs" Inherits="PdccTellYourStories" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>

    <script lang="javascript" type="text/javascript">
        //window.onload = toBottom;
        function toBottom() {
            //alert("Scrolling to bottom ...");
            window.scrollTo(0, document.body.scrollHeight);
        }

    </script>

    <div id="up" style="width: 80%; margin-left: 5em; margin-right: auto; border: 0px">
        <div class="box box-solid">
            <div class="box-header with-border">
                <h2 class="box-title">Tell your stories</h2>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="box-group" id="accordion">
                    <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                    <div class="panel box box-primary">
                        <div class="box-header with-border">
                            <div style="float:left">
                                <asp:LinkButton ID="lnkMyTopics" runat="server" ForeColor="#000066" OnClick="lnkMyTopics_Click"></asp:LinkButton>
                                &nbsp;/
                                <asp:LinkButton ID="lnkTopics" runat="server" ForeColor="#000066" OnClick="lnkTopics_Click"></asp:LinkButton>
                                /
                                <asp:Label ID="lblMembers" Font-Bold="true" runat="server" ForeColor="#000066"></asp:Label>.
                                <asp:Label ID="lblDate" Font-Bold="true" runat="server" ForeColor="Black"></asp:Label>
                                &nbsp;<br />
                                <asp:TextBox ID="txtSearch" runat="server" ToolTip="Enter topic" Width="200px"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                            <div style="float:right">
                                <asp:Button ID="lnkNewStory" runat="server" ForeColor="#000066" Text="Tell Cost Saving Story" OnClick="lnkNewStory_Click"></asp:Button>
                                <ajaxToolkit:ModalPopupExtender ID="MPE"
                                    runat="server"
                                    TargetControlID="lnkNewStory"
                                    PopupControlID="pnlModalPanel"
                                    CancelControlID="closeButton"
                                    BackgroundCssClass="modalBackground"
                                    DropShadow="true"
                                    PopupDragHandleControlID="pnlDragPanel"
                                    Drag="true" />
                            </div>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <%--</div>--%>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true" AllowPaging="true"
            OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand" PageSize="15"
            OnRowCancelingEdit="grdView_RowCancelingEdit" ShowHeader="false" BorderStyle="None"
            AlternatingRowStyle-BorderWidth="0" RowStyle-BorderStyle="None"
            OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting" BackColor="#ffffff"
            OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="IDSTORY"
            Width="100%" OnRowCreated="grdView_RowCreated">
            <Columns>

                <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <div class="box box-solid" style="background-color: silver; margin-bottom: 0">
                            <div class="box-header with-border">
                                <h3 class="box-title">
                                    <%# Eval("TITLE")%>
                                </h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="box-group" id="accordion">
                                    <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                                    <div class="panel box box-primary" style="border-bottom: none">
                                        <div class="box-header with-border">
                                            <%--<h4 class="box-title">--%>
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                                <%# Eval("USERNAME")%> :&nbsp;&nbsp;  <%# Eval("DATETOLD")%> at <%# Eval("STIME")%> (<%#  Eval("NOOFDAYS")%>) days ago    
                                                <asp:Label ID="lblAmtSaved" runat="server" Text='<%# Eval("AMTSAVED")%>' ForeColor="Red" Font-Size="10pt"></asp:Label>
                                                <%--<asp:Label ID="amtSaved" runat="server" Text='<%# Eval(stringRoutine.formatAsBankMoney("$", decimal.Parse("AMTSAVED")))%>' ForeColor="#000066" Font-Size="10pt"></asp:Label>--%>
                                            </a>
                                            <%--</h4>--%>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse in">
                                            <div class="box-body">
                                                <p>
                                                    <%# Eval("STORY")%>
                                                </p>

                                                <p>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="(Modify)"></asp:LinkButton>
                                                </p>
                                                <br />

                                                <asp:Repeater ID="RepeaterImages" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image" runat="server" ImageUrl='<%#Container.DataItem %>' />
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </ItemTemplate>

                    <EditItemTemplate>

                        <div class="box-body">
                            <div class="box-group" id="accordion">
                                <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                                <div class="panel box box-primary">
                                    <div class="box-header with-border">
                                        <h4 class="box-title">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Update Row#</a>
                                        </h4>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">
                                        <div class="box-body">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 100px">Title:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTitle" Text='<%# Eval("TITLE") %>' runat="server" Width="80%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                                            ErrorMessage="Please Enter title for your success stories" ForeColor="Red" SetFocusOnError="true"
                                                            ToolTip="Enter your story title" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp; &nbsp; </td>
                                                    <td>&nbsp; &nbsp; </td>
                                                </tr>
                                                <tr>
                                                    <td>Amount Saved:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmtSaved" runat="server" Text='<%# Eval("AMTSAVED") %>' Width="150px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmtSaved" ErrorMessage="Amount Saved is required" SetFocusOnError="True" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp; &nbsp; </td>
                                                    <td>&nbsp; &nbsp; </td>
                                                </tr>
                                                <tr>
                                                    <td>Story:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtStory" runat="server" TextMode="MultiLine" Text='<%# Eval("STORY") %>' Height="100px" Width="80%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfStaff" runat="server" ControlToValidate="txtStory"
                                                            ErrorMessage="Please tell your success stories" ForeColor="Red" SetFocusOnError="true"
                                                            ToolTip="Please tell your success stories" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <p>
                                                            <asp:FileUpload ID="FUpl1" runat="server" />
                                                        </p>
                                                        <p>
                                                            <asp:FileUpload ID="FUpl2" runat="server" />
                                                        </p>
                                                        <p>
                                                            <asp:FileUpload ID="FUpl3" runat="server" />
                                                        </p>
                                                        <p>
                                                            <asp:FileUpload ID="FUpl4" runat="server" />
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" Text="Update" CommandName="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update" />
                                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" Text="Cancel" CommandName="Cancel" />
                                                        <br />
                                                        <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </EditItemTemplate>

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                    <%--<ItemStyle Width="80%" />--%>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <br />

        <div class="box box-solid">
            <div class="box-header with-border">
                <h2 class="box-title">Users Statistics</h2>
                &nbsp;&nbsp;&nbsp;&nbsp; Date:
                <asp:Label ID="lblDateLoggedIn" runat="server" ForeColor="Black"></asp:Label>
                From:
                <asp:Label ID="lblTimeLoggedIn" runat="server" ForeColor="Black"></asp:Label>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="box-group">
                    <%-- id="accordion"--%>
                    <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                    <div class="panel box box-primary">
                        <div class="box-header with-border">
                            Logged on Users:&nbsp;
                            <asp:LinkButton ID="lblLoggedOnUsers" runat="server" ForeColor="Black"></asp:LinkButton>
                            <br />
                            Total Logged on Users:
                            <asp:Label ID="lblTotalLoggedOnUsers" runat="server" ForeColor="Black"></asp:Label>
                        </div>
                        <%--<div class="panel-collapse collapse in"><!--id="collapseOne" -->
                            
                        </div>--%>
                    </div>
                    <center>(<a href="#up"><b>Go Up</b></a>)</center>

                </div>
            </div>
        </div>

    </div>
    <br />
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;" CssClass="modalPopup" Width="800px">
        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
            <center><h3>Tell your cost saving stories</h3></center>
        </asp:Panel>
        <%--<div style="overflow: auto; width:100%; background-color: white; border: solid 1px gray">--%>
        <table style="width: 100%; background-color: white; border-collapse: separate; padding: 7px 4px 12px 4px" border="0" id="gvEG">
            <tr>
                <td>&nbsp; &nbsp; </td>
                <td>&nbsp; &nbsp; </td>
            </tr>

            <tr>
                <td style="width: 100px">Title:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="80%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtTitleRF" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="Please Enter title" ForeColor="Red" SetFocusOnError="true"
                        ToolTip="Enter your story title" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Amount Saved:</td>
                <td>


                    <asp:TextBox ID="txtAmtSaved" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmtSaved"
                        ErrorMessage="Amount Saved is required" SetFocusOnError="True" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>

                <td>Story:
                </td>

                <td>


                    <%--<div class='box'>
                            <div class='box-header'>
                                <h3 class='box-title'>Success Stories <small>Simple and fast</small></h3>
                                <!-- tools box -->
                                <div class="pull-right box-tools">
                                    <button class="btn btn-default btn-sm" data-widget='collapse' data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                                    <button class="btn btn-default btn-sm" data-widget='remove' data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                                </div>
                                <!-- /. tools -->
                            </div>
                            <!-- /.box-header -->
                            <div class='box-body pad'>
                                <textarea class="textarea" ID="txtStory2" runat="server" placeholder="Place some text here" style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
                            </div>
                        </div>--%>
                    <asp:TextBox ID="txtStory" runat="server" Height="100px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStory"
                        ErrorMessage="Please Enter your success stories" ForeColor="Red" SetFocusOnError="true"
                        ToolTip="Please Enter your success stories" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <p>
                        <asp:FileUpload ID="FUpl1" runat="server" />
                    </p>
                    <p>
                        <asp:FileUpload ID="FUpl2" runat="server" />
                    </p>
                    <p>
                        <asp:FileUpload ID="FUpl3" runat="server" />
                    </p>
                    <p>
                        <asp:FileUpload ID="FUpl4" runat="server" />
                    </p>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="lnkAdd" runat="server" Text="Submit" ValidationGroup="Add" Width="100px" OnClick="lnkAdd_Click" />&nbsp;&nbsp;
                    <asp:Button ID="closeButton" runat="server" Text="Close" ValidationGroup="xxxx" Width="100px" />
                    <asp:ValidationSummary ID="vsAdd" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Add" Enabled="true" HeaderText="Validation Summary..." />
                </td>
            </tr>
        </table>
        <%--</div>--%>
    </asp:Panel>

    <%-- <!-- CK Editor -->
    <script src="//cdn.ckeditor.com/4.4.3/standard/ckeditor.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // Replace the <textarea id="editor1"> with a CKEditor
            // instance, using default configuration.
            CKEDITOR.replace('txtStory2');
            //bootstrap WYSIHTML5 - text editor
            $(".textarea").wysihtml5();
        });
    </script>--%>
</asp:Content>

