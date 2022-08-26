<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="ReviewerReport.aspx.cs" Inherits="App_Prices_ReviewerReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <div>
        <div style="float: left">
            <table class="tMainBorder" style="width: 600px">
                <tr class="cHeadTile">
                    <td>Details</td>
                </tr>
                <tr>
                    <td>
                        <asp:DetailsView ID="dtlView" runat="server" AutoGenerateRows="False" Width="600px"
                            DataKeyNames="PRICEID" AllowPaging="True" EnableViewState="False">
                            <Fields>

                                <asp:TemplateField HeaderText="PO Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPONumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PONUMBER") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Material Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALDESC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Material Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALCODE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price ($)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Should be price ($)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShouldBePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SHOULDBEPRICE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price Variance ($)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriceVariance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XVARIANCE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price Source">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriceSource" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICESOURCE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Other Information">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOtherInformation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERINFORMATION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Submitted By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubmittedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Reported">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDateReported" runat="server"
                                            Text='<%# Eval("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Savings Achieved?">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reviewer's Report">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReview" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Fields>

                        </asp:DetailsView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="tMainBorder" style="width:600px">
                            <tr>
                                <td class="cHeadTile" colspan="2">Uploaded Document</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="OpenPDFHyperLink" runat="server" NavigateUrl="~/App/Prices/Price.pdf" Target="_blank">Open PDF into New Page</asp:HyperLink>
                                </td>
                                <td>Click
                            <asp:ImageButton ID="refreshPageImageButton" runat="server" ImageUrl="~/Images/Refresh.jpg" Width="20px" />
                                    &nbsp;to refresh</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <iframe id="fileLoader" name="fileLoader" style="width: 99%; height: 450px" runat="server" scrolling="auto"></iframe>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left">
            <table style="border: solid 1px silver">
                <tr class="cHeadTile">
                    <td colspan="2">Reviewers Comment</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>Savings Achieved?:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlSavingsAchieved" ErrorMessage="Please Select Savings Status" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSavingsAchieved" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>

                <tr>
                    <td>Amount Saved:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount Saved is required. Put 0 if no amount saved">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>Comments:</td>
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>Closed Out?:<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlClosedOut" ErrorMessage="Please Select Close Out Status" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClosedOut" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="150px" OnClick="btnSubmit_Click" />
                        &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="150px" OnClick="btnClose_Click" ValidationGroup="xxxx" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="headId">
</asp:Content>



