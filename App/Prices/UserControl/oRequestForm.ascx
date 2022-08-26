<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequestForm.ascx.cs" Inherits="App_Prices_UserControl_oRequestForm" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


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


<%--<div style="float: left">--%>
<table style="width: 600px">
    <tr>
        <td style="width:200px">
            <asp:Label ID="Label1" runat="server" Text="PO/PR/SE/Agreement No:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPO" ErrorMessage="PO/PR/SE/Agreement Number is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="txtPO" runat="server" Width="200px"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Material Code:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode" ErrorMessage="Material Code is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="txtCode" runat="server" Width="200px"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Item/Material Description:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaterialDesc" ErrorMessage="Item/Material Description is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="txtMaterialDesc" runat="server" Height="70px" TextMode="MultiLine" Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Asset/Hub:"></asp:Label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAssetHub" ErrorMessage="Select Asset Hub" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList ID="ddlAssetHub" runat="server" Width="200px">
                <asp:ListItem Value="-1">Select Asset Hub...</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Price $:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <telerik:RadNumericTextBox ID="txtPrice" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="200px" Height="22px">
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
        <td>
            <asp:Label ID="Label5" runat="server" Text="Should be price($):"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtShouldBePrice" ErrorMessage="Should be price is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <telerik:RadNumericTextBox ID="txtShouldBePrice" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="200px" Height="22px">
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
        <td>
            <asp:Label ID="Label6" runat="server" Text="Your Price Source:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPriceSource" ErrorMessage="Your Price Source is required">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="txtPriceSource" runat="server" Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Any other Information:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtOtherInformation" runat="server" Height="70px" TextMode="MultiLine" Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Upload Document:</strong></td>
        <td>
            <asp:FileUpload ID="xyFileUpload" runat="server" />
            <div id="DemoContainer1" runat="server" class="demo-container size-narrow">
                <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server" ChunkSize="1048576" RenderMode="Lightweight" />
                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" RenderMode="Lightweight" />
            </div>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="DemoContainer1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:HiddenField ID="HFPriceId" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
        </td>
    </tr>
</table>
<br />
<table style="width: 600px">
    <tr>
        <td colspan="4">Uploaded Document</td>
    </tr>
    <tr>
        <td colspan="4">
            <iframe id="fileLoader" name="fileLoader" style="width: 99%; height: 450px" runat="server" scrolling="auto"></iframe>
        </td>
    </tr>
</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
<asp:HiddenField ID="sFileNameHF" runat="server" />

