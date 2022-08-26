<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="FlareWaiverRequestEdt.aspx.cs" Inherits="FlareWaiverRequestEdt" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="WorkOrder.ascx" TagName="WorkOrder" TagPrefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
            <table style="width: 98%">
                <tr>
                    <td style="width: 40%">
                        <table class="tMainBorder" style="width: 98%">
                            <tr>
                                <td colspan="2" class="cHeadLeft">Flare Waiver
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Line Manager:"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlManager" ErrorMessage="Select Line Manager" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                </td>
                                <td>
                                    <%--<app:Search ID="LineManager" runat="server" />--%>
                                    <asp:DropDownList ID="ddlManager" runat="server" Width="300px">
                                        <asp:ListItem Value="-1">Select Line Manager</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Category:"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Select Category" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px">
                                        <asp:ListItem Value="-1">Select Category</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--<tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Facility:"></asp:Label>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlFacilities" ErrorMessage="Select Facility" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>

                            <asp:DropDownList ID="ddlFacilities" runat="server" Width="300px">
                                <asp:ListItem Value="-1">Select Facility</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>--%>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label108" runat="server" Font-Bold="true" Text="Facilities:"></asp:Label>
                                    <div style="height: 150px; width: 99%; overflow: auto; border: solid 1px silver">
                                        <asp:CheckBoxList ID="facilitiesCkbLst" runat="server" RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Waiver Start Date:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Waiver Start Time:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="dtStartDate" runat="server" DateInput-DisplayDateFormat="dd-MMM-yyyy" DateInput-Label="Start Date:" DateInput-LabelWidth="100px" RenderMode="Lightweight" Width="250px">
                                                </telerik:RadDatePicker>
                                                <%--<app:dateControl ID="dtStartDate" runat="server" />--%>
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker RenderMode="Lightweight" ID="startTime" runat="server"></telerik:RadTimePicker>
                                                <%--<app:TimePicker ID="startTime" runat="server" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Waiver End Date:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="true" Text="Waiver End Time:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="dtEndDate" runat="server" DateInput-DisplayDateFormat="dd-MMM-yyyy" DateInput-Label="Start Date:" DateInput-LabelWidth="100px" RenderMode="Lightweight" Width="250px">
                                                </telerik:RadDatePicker>
                                                <%--<app:dateControl ID="dtEndDate" runat="server" />--%>
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker RenderMode="Lightweight" ID="endTime" runat="server"></telerik:RadTimePicker>
                                                <%--<app:TimePicker ID="endTime" runat="server" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Font-Bold="true" Text="Flare (or AG) Volume(mmscfd):"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVolume" ErrorMessage="Flare Volume is required">*</asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtVolume"
                                                    ErrorMessage="Invalid value. Please enter Flare (or AG) Volume correctly." ValidationExpression="\d+(\.\d{1,2})?">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="Associated Oil Production(mbopd):"></asp:Label>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOil"
                                                    ErrorMessage="Invalid value. Please enter Associated Oil Production correctly." ValidationExpression="\d+(\.\d{1,2})?">*</asp:RegularExpressionValidator>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOil" ErrorMessage="Associated Oil Production is required">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOil" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Reason for Flaring:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReason" ErrorMessage="Reason for flaring is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">

                                    <asp:TextBox ID="txtReason" runat="server" Height="100px" TextMode="MultiLine" Width="560px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Justification for Waiver Request:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtJustification" ErrorMessage="Justification for flare request is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtJustification" runat="server" Height="100px" TextMode="MultiLine" Width="560px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Post event actions to remain compliant:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPostEvent" ErrorMessage="Post event action is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">

                                    <asp:TextBox ID="txtPostEvent" runat="server" Height="100px" TextMode="MultiLine" Width="560px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div class="main">

                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px" />
                                        &nbsp;
            <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="Close" OnClick="btnClose_Click" Width="100px" />
                                    </div>
                                </td>
                                <%--</tr>--%>
                        </table>
                    </td>
                    <td>
                        <uc1:WorkOrder ID="WorkOrder1" runat="server" />
                        <table class="tMainBorder" style="width: 98%">
                            <tr>
                                <td class="cHeadTile" colspan="2">Attach Work Plan here...</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label107" runat="server" Text="Upload Work Plan:"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="UploadFile" runat="server" Width="187px" />
                                    &nbsp;
                            <asp:Button ID="btnUpload" runat="server" Height="22px" OnClick="btnUpload_Click" Text="Upload Work Plan" Width="128px" ValidationGroup="upload" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />


        </div>
    </form>
</body>
</html>
