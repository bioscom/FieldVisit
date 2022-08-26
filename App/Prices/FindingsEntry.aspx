<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindingsEntry.aspx.cs" Inherits="App_Prices_FindingsEntry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <script type="text/javascript">
            function CloseAndRebind() {
                GetRadWindow().BrowserWindow.refreshGrid(); // Call the function in parent page  
                GetRadWindow().close(); // Close the window  
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)  

                return oWindow;
            }

            function CancelEdit() {
                GetRadWindow().close();
            }

        </script>

        <div>
            <ul style="list-style-type: none;">
                <li>
                    <telerik:RadTextBox ID="txtMaterialNum" runat="server" Label="Material Number:" LabelWidth="150px" Width="350px">
                    </telerik:RadTextBox>
                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaterialNum" ErrorMessage="Material Number is required">*</asp:RequiredFieldValidator>

                <br />
                <li>

                    <telerik:RadTextBox ID="txtMaterialDescription" runat="server" Label="Material Description:" LabelWidth="150px" Width="550px">
                    </telerik:RadTextBox>

                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMaterialDescription" ErrorMessage="Material description is required">*</asp:RequiredFieldValidator>

                <br />
                <li>

                    <telerik:RadTextBox ID="txtPONum" runat="server" Label="PO Number:" LabelWidth="150px" Width="350px">
                    </telerik:RadTextBox>

                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPONum" ErrorMessage="PO Number is required">*</asp:RequiredFieldValidator>

                <br />
                <li>
                    <telerik:RadNumericTextBox ID="txtOldPrice" runat="server" Culture="en-US" DbValueFactor="1" Label="Old Price:" Width="300px" LabelWidth="150px" Type="Currency">
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

                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtOldPrice" ErrorMessage="Old price is required">*</asp:RequiredFieldValidator>

                <br />
                <li>
                    <telerik:RadNumericTextBox ID="txtNewPrice" runat="server" Culture="en-US" DbValueFactor="1" Label="New Price:" Width="300px" LabelWidth="150px" Type="Currency">
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

                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNewPrice" ErrorMessage="New price is required">*</asp:RequiredFieldValidator>

                <br />
                <li>
                    <telerik:RadNumericTextBox ID="txtQty" runat="server" Label="Stock Qty:" Width="300px" LabelWidth="150px" Type="Number">
                        <NegativeStyle Resize="None" />
                        <EmptyMessageStyle Resize="None" />
                        <ReadOnlyStyle Resize="None" />
                        <FocusedStyle Resize="None" />
                        <DisabledStyle Resize="None" />
                        <InvalidStyle Resize="None" />
                        <HoveredStyle Resize="None" />
                        <EnabledStyle Resize="None" />
                    </telerik:RadNumericTextBox>

                </li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtOldPrice" ErrorMessage="Stock quantity is required">*</asp:RequiredFieldValidator>

                <br />
                <li>

                    <telerik:RadTextBox ID="txtIssuesDescription" runat="server" Height="100px" Label="Issue Description:" LabelWidth="150px" TextMode="MultiLine" Width="550px">
                    </telerik:RadTextBox>

                </li>
                <br />
                <li>
                    <telerik:RadTextBox ID="txtComments" runat="server" Height="100px" Label="Comments:" LabelWidth="150px" TextMode="MultiLine" Width="550px">
                    </telerik:RadTextBox>
                </li>
                <br />
                <li>
                    <telerik:RadTextBox ID="txtRecommendations" runat="server" Height="100px" Label="Recommendations:" LabelWidth="150px" TextMode="MultiLine" Width="550px">
                    </telerik:RadTextBox>
                </li>
                <br />
                <li style="margin-left: 150px">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
                </li>
            </ul>

        </div>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
