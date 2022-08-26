<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vendorCallOutInfo.ascx.cs" Inherits="UserControl_vendorCallOutInfo" %>
<%@ Reference VirtualPath="~/App/FieldVisit/UserControl/SEPCiN/activityHeader.ascx" %>

<style type="text/css">
    .style1
    {
        width: 140px;
    }
</style>

<table>
    <tr>
        <td>(Complete if applicable)</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMssg" runat="server" CssClass="Warning"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td class="style1">Vendor Name:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVendorName" ErrorMessage="Vendor Name is required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVendorName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Contact Person:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Contact Person is required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactPerson" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Telephone:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTelephone" ErrorMessage="Telephone Number is required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelephone" ErrorMessage="Invalid Telephone Number" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\-\(\)]*$" ValidationGroup="Vendor">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelephone" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Email Address:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email Address is required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Vendor">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailAddress" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Trade Types:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpTradeTypes" ErrorMessage="Select Trade Type" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="Vendor">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpTradeTypes" runat="server">
                            <asp:ListItem Value="-1">--Select Trade Type--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Vendor Address:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVendorAddress" ErrorMessage="Vendor Address is required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVendorAddress" runat="server" TextMode="MultiLine" Width="400px"
                            Height="48px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">Special Tools &amp; Materials:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToolsMaterials" ErrorMessage="Special Tools and Materials required" ValidationGroup="Vendor">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToolsMaterials" runat="server" TextMode="MultiLine" Width="400px"
                            Height="100px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <hr />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                Width="100px" ValidationGroup="Vendor" />
            <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click"
                Text="Update" Width="100px" ValidationGroup="Vendor" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Vendor" />
        </td>
    </tr>
</table>
<asp:HiddenField ID="VendorIDHF" runat="server" />
                <asp:HiddenField ID="ActivityIDHF" runat="server" />
        