<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oReviewerReport.ascx.cs" Inherits="App_Prices_UserControl_oReviewerReport" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
    </Scripts>
</telerik:RadScriptManager>



<div>
    <table>
        <tr>
            <td>Savings Achieved?:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlSavingsAchieved" ErrorMessage="Please Select Savings Status" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="waho">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlSavingsAchieved" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Amount Saved:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount Saved is required. Put 0 if no amount saved" ValidationGroup="waho">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <%--<asp:TextBox ID="txtAmount" runat="server" Width="200px"></asp:TextBox>--%>
                <telerik:RadNumericTextBox ID="txtAmount" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="205px">
                    <NegativeStyle Resize="None" />
                    <NumberFormat ZeroPattern="$n" />
                    <EmptyMessageStyle Resize="None" />
                    <ReadOnlyStyle Resize="None" />
                    <FocusedStyle Resize="None" />
                    <DisabledStyle Resize="None" />
                    <InvalidStyle Resize="None" />
                    <HoveredStyle Resize="None" />
                    <EnabledStyle Resize="None" />
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td>Closed Out?:<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlClosedOut" ErrorMessage="Please Select Close Out Status" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="waho">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlClosedOut" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Comments:</td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" Height="138px" TextMode="MultiLine" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" ValidationGroup="waho" />
                &nbsp;<%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" OnClick="btnClose_Click" ValidationGroup="xxxx" />--%>
                <asp:HiddenField ID="sRequestHF" runat="server" />
            </td>
        </tr>
    </table>
</div>

<%--<table style="width: 98%">
    <tr class="cHeadTile">
        <td>Details</td>
    </tr>
    <tr>
        <td>
            <asp:DetailsView ID="dtlView" runat="server" AutoGenerateRows="False" Width="100%"
                DataKeyNames="PRICEID" AllowPaging="True" EnableViewState="False">
                <Fields>

                    <asp:TemplateField HeaderText="PO Number">
                        <ItemTemplate>
                            <asp:Label ID="lbPONumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PONUMBER") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Material Description">
                        <ItemTemplate>
                            <asp:Label ID="lbMaterialDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALDESC") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Material Code">
                        <ItemTemplate>
                            <asp:Label ID="lbMaterialCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALCODE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price ($)">
                        <ItemTemplate>
                            <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Should be price ($)">
                        <ItemTemplate>
                            <asp:Label ID="lbShouldBePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SHOULDBEPRICE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price Variance ($)">
                        <ItemTemplate>
                            <asp:Label ID="lbPriceVariance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XVARIANCE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price Source">
                        <ItemTemplate>
                            <asp:Label ID="lbPriceSource" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICESOURCE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Other Information">
                        <ItemTemplate>
                            <asp:Label ID="lbOtherInformation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERINFORMATION") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Submitted By">
                        <ItemTemplate>
                            <asp:Label ID="lbSubmittedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Reported">
                        <ItemTemplate>
                            <asp:Label ID="lbDateReported" runat="server"
                                Text='<%# Eval("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Savings Achieved?">
                        <ItemTemplate>
                            <asp:Label ID="lbStatus" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reviewer's Report">
                        <ItemTemplate>
                            <asp:Label ID="lbReview" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Fields>

            </asp:DetailsView>
        </td>
    </tr>

</table>
<br />
<table class="tMainBorder" style="width: 98%">
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
</table>--%>
