<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="AsIsVsm.aspx.cs" Inherits="App_Lean_AsIsVsm" %>

<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: 12px;
            color: #1F4078;
            font-family: Tahoma;
            vertical-align: top;
            text-align: right;
        }

        .auto-style2 {
            font-size: 12px;
            color: #1F4078;
            font-family: Tahoma;
            vertical-align: top;
            text-align: center;
            width: 9px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="smtAjaxManager" />
    <asp:Panel ID="pnlUpload" runat="server">

        <table cellpadding="2" cellspacing="0" class="tSubGray" style="width: 650px">
            <tr>
                <td class="cHeadLeft" colspan="2">Excel VSM Data Bulk Upload</td>
            </tr>
            <tr>
                <td class="auto-style1">Use the Browse button to locate the Excel File containing your
                    <br />
                    Data on your Computer.
                    <br />
                    This MUST match the format of the Excel Template file provided here.<br />
                    <br />
                    See Sample data entry format for VSM
                    <asp:Image ID="Image2" runat="server" Height="20px" ImageUrl="~/Images/iGreenArrow.png" Width="40px" />
                    <br />
                    Ensure your file for upload, has exact sample data format.</td>
                <td>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkSample" runat="server">Sample VSM As Is</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkFunction" runat="server">Functions</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkProcessLTVATUnit" runat="server">Process LT/VAT Unit</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkWasteCategory" runat="server">Waste Category</asp:HyperLink></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="cTextCenta" colspan="2">
                    <asp:FileUpload ID="FUpBulkExcel" runat="server" TabIndex="3" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FUpBulkExcel" Display="None" ErrorMessage="Browse for Value Stream Data Excel File">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:Button ID="cmdUpload" runat="server" OnClick="cmdUpload_Click" Text="Upload File" />
                    &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" ValidationGroup="close" OnClick="btnClose_Click" />
                    &nbsp;<asp:ValidationSummary ID="VsmCreateUser" runat="server" BackColor="LightSkyBlue" BorderColor="MediumBlue" BorderStyle="Ridge" BorderWidth="3px" Font-Bold="True" Font-Names="Tahoma" HeaderText="!   In-Complete Specification  !" Height="12px" ShowMessageBox="True" ShowSummary="False" Width="159px" />
                </td>
            </tr>
        </table>

    </asp:Panel>
    <asp:LinkButton ID="EditLinkButton" runat="server" OnClick="EditLinkButton_Click">Add Value Stream Data</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="btnVSM" runat="server" OnClick="btnVSM_Click">Upload Value Stream Data</asp:LinkButton>&nbsp;
    <%--</div>--%>

    <hr />
    <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />

    <%--<asp:TextBox ID="txtPLTMin" runat="server" Width="200px"></asp:TextBox>--%>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnLoad="grdGridView_Load" 
               OnPageIndexChanging="grdGridView_PageIndexChanging" OnRowCommand="grdGridView_RowCommand" 
               OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="20" width="99%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                IDVSMASIS='<%# DataBinder.Eval(Container.DataItem, "IDVSMASIS") %>' OnClick="lnkEdit_Click">Update</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Function" SortExpression="FUNCTION">
                        <ItemTemplate>
                            <asp:Label ID="lblFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activity Description" SortExpression="ACTIVITYDESC">
                        <ItemTemplate>
                            <asp:Label ID="labelActivityDesc" runat="server" ForeColor="#003366"
                                Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYDESC") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Process LT" SortExpression="PROCESSLT">
                        <ItemTemplate>
                            <asp:Label ID="labelProcessLT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROCESSLT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LT Unit" SortExpression="PLTUNIT">
                        <ItemTemplate>
                            <asp:Label ID="lblLtUnit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PLTUNIT") %>' 
                                TIMEA='<%# DataBinder.Eval(Container.DataItem, "TIMEA") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LT Min.">
                        <ItemTemplate>
                            <asp:Label ID="lblLtMinute" runat="server" Text='<%# decimal.Parse(Eval("PROCESSLT").ToString()) * decimal.Parse(Eval("TIMEA").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LT Vat" SortExpression="PROCESSVAT">
                        <ItemTemplate>
                            <asp:Label ID="lblLtVat" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROCESSVAT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LT Vat Unit" SortExpression="VLTUNIT">
                        <ItemTemplate>
                            <asp:Label ID="lblVatUnit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VLTUNIT") %>' 
                                TIMEB='<%# DataBinder.Eval(Container.DataItem, "TIMEB") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Vat Min.">
                        <ItemTemplate>
                            <asp:Label ID="lblVatMin" runat="server" Text='<%# decimal.Parse(Eval("PROCESSVAT").ToString()) * decimal.Parse(Eval("TIMEB").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Waste Category" SortExpression="WASTE">
                        <ItemTemplate>
                            <asp:Label ID="lblWasteCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WASTE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Supplier" SortExpression="SUPPLIER">
                        <ItemTemplate>
                            <asp:Label ID="lblSupplier" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUPPLIER") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Input" SortExpression="INPUT">
                        <ItemTemplate>
                            <asp:Label ID="lblnput" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "INPUT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Output" SortExpression="OUTPUT">
                        <ItemTemplate>
                            <asp:Label ID="lblOutPut" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OUTPUT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer" SortExpression="CUSTOMER">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUSTOMER") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Improvement" SortExpression="IMPROVEMENT">
                        <ItemTemplate>
                            <asp:Label ID="lblImprovement" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Waste Code" SortExpression="WASTECODE">
                        <ItemTemplate>
                            <asp:Label ID="lblWasteCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WASTECODE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                IDVSMASIS='<%# DataBinder.Eval(Container.DataItem, "IDVSMASIS") %>' OnClick="lnkDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <%--<asp:TemplateField HeaderText="LT Min." SortExpression="PLTMINUTE">
                        <ItemTemplate>
                            <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PLTMINUTE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Vat Min." SortExpression="PVATMINUTE">
                        <ItemTemplate>
                            <asp:Label ID="lblVatMin" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PVATMINUTE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>


                </Columns>
            </asp:GridView>
    <%--<asp:TextBox ID="txtPVatMin" runat="server" Width="200px"></asp:TextBox>--%>
   <%--<asp:TextBox ID="txtPLTMin" runat="server" Width="200px"></asp:TextBox>--%>
    <%--<asp:TextBox ID="txtPVatMin" runat="server" Width="200px"></asp:TextBox>--%>
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;"
        CssClass="modalPopup" Width="790px">
        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
            +
        </asp:Panel>
        <table class="tMainBorder" style="width: 98%">
            <tr>
                <td class="cHeadTile" colspan="4">ASIS VSM</td>
            </tr>
            <tr>
                <td style="width: 150px">Project Name:</td>
                <td>
                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                </td>
                <td style="width: 150px">Waste Category:</td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlWasteCategory" runat="server" Width="200px">
                        <asp:ListItem Value="-1">Select Waste Category</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Activity Function:</td>
                <td>
                    <asp:DropDownList ID="ddlFunction" runat="server" Width="200px">
                        <asp:ListItem Value="-1">Select Activity Function</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>WasteCode:</td>
                <td>
                    <asp:TextBox ID="txtWasteCode" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Activity Description:</td>
                <td>
                    <asp:TextBox ID="txtActivityDesc" runat="server" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </td>
                <td colspan="2" style="vertical-align: bottom">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" Text="SIPOC"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    Process LT:</td>
                <td>
                    <hr />
                    <asp:TextBox ID="txtProcessLT" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>Supplier:</td>
                <td>
                    <asp:TextBox ID="txtSupplier" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Process LT Unit:</td>
                <td>
                    <asp:DropDownList ID="ddlPLTUnit" runat="server" Width="200px">
                        <asp:ListItem Value="-1">Select Process LT Unit</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Input:</td>
                <td>
                    <asp:TextBox ID="txtInput" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Process LT Minutes:</td>
                <td>
                    <%--<asp:TextBox ID="txtPLTMin" runat="server" Width="200px"></asp:TextBox>--%>
                    <asp:Label ID="lblLtMin" runat="server"></asp:Label>
                </td>
                <td>Output:</td>
                <td>
                    <asp:TextBox ID="txtOutput" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    Process VAT:</td>
                <td>
                    <hr />
                    <asp:TextBox ID="txtProcessVat" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>Customer:</td>
                <td>
                    <asp:TextBox ID="txtCustomer" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Process VAT Unit:</td>
                <td>
                    <asp:DropDownList ID="ddlPVatUnit" runat="server" Width="200px">
                        <asp:ListItem Value="-1">Select Process Vat Unit</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Improvement:</td>
                <td>
                    <asp:TextBox ID="txtImprovement" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Process VAT Minutes:</td>
                <td>
                    <%--<asp:TextBox ID="txtPVatMin" runat="server" Width="200px"></asp:TextBox>--%>
                    <asp:Label ID="lblVatMin" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:HiddenField ID="lVsmAsIsIdHF" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <center>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="100px" />
                    &nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close" ValidationGroup="xxxx" Width="100px" />
                    </center>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

    <%--The Modal Popup codes ends here--%>
    <ajaxToolkit:ModalPopupExtender ID="MPE"
        runat="server"
        TargetControlID="EditLinkButton"
        PopupControlID="pnlModalPanel"
        CancelControlID="closeButton"
        BackgroundCssClass="modalBackground"
        DropShadow="true"
        PopupDragHandleControlID="pnlDragPanel"
        Drag="true" />
</asp:Content>

