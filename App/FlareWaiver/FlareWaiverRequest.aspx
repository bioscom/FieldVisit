<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="FlareWaiverRequest.aspx.cs" Inherits="FlareWaiverRequest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="WorkOrder.ascx" TagName="WorkOrder" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
    <script language="javascript" type="text/javascript" src="../../JavaScript/MyScript.js"></script>
</head>
<body onload="radalert('If this request is already captured in the current years business plan, kindly select Captured in Business Plan. Otherwise, select Not Captured in Business Plan', 330, 180, 'Client RadAlert', alertCallBackFn, $dialogsDemo.imgUrl);  return false;">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <div style="border-bottom: 2.5em">
            <table>
                <tr>
                    <td>
                        <table class="tMainBorder" style="font-size: 12px">
                            <tr>
                                <td colspan="4" class="cHeadLeft">Flare Waiver
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label2" runat="server" Text="Line Manager:" Style="font-weight: 700"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlManager" ErrorMessage="Select Line Manager" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlManager" runat="server" Width="300px">
                                        <asp:ListItem Value="-1">Select Line Manager</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Category:" Style="font-weight: 700"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Select Category" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px">
                                        <asp:ListItem Value="-1">Select Category</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label109" runat="server" Text="In/Out BP:" Style="font-weight: 700"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlSchedule" ErrorMessage="Select In/Out BP" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlSchedule" runat="server" Width="300px">
                                        <asp:ListItem Value="-1">Select Business Plan</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label108" runat="server" Text="Facilities:" Style="font-weight: 700"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <div style="height: 200px; width: 530px; overflow: auto; border: solid 1px silver">
                                        <asp:CheckBoxList ID="facilitiesCkbLst" runat="server" RepeatColumns="4">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Start Date:" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="dtStartDate" runat="server"></telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Start Time:" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTimePicker RenderMode="Lightweight" ID="startTime" runat="server"></telerik:RadTimePicker>
                                    <%--<app:TimePicker ID="startTime" runat="server" />--%>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="End Date:" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="dtEndDate" runat="server"></telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="End Time:" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTimePicker RenderMode="Lightweight" ID="endTime" runat="server"></telerik:RadTimePicker>
                                    <%--<app:TimePicker ID="endTime" runat="server" />--%>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Flare (or AG):" Style="font-weight: 700"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVolume" ErrorMessage="Flare Volume is required">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtVolume"
                                        ErrorMessage="Invalid value. Please enter Flare (or AG) Volume correctly." ValidationExpression="\d+(\.\d{1,2})?">*</asp:RegularExpressionValidator>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>
                                    <strong>Volume(mmscfd)
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Ass. Oil Production:" Style="font-weight: 700"></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOil"
                                        ErrorMessage="Invalid value. Please enter Associated Oil Production correctly." ValidationExpression="\d+(\.\d{1,2})?">*</asp:RegularExpressionValidator>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOil" ErrorMessage="Associated Oil Production is required">*</asp:RequiredFieldValidator>

                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtOil" runat="server"></asp:TextBox>
                                    <strong>(mbopd)
                                    </strong>
                                </td>
                            </tr>

                            <%--<tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>--%>

                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label8" runat="server" Text="Reason for Flaring:" Style="font-weight: 700"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReason" ErrorMessage="Reason for flaring is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtReason" runat="server" Height="150px" TextMode="MultiLine" Width="530px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label9" runat="server" Text="Justification for Waiver Request:" Style="font-weight: 700"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtJustification" ErrorMessage="Justification for flare request is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtJustification" runat="server" Height="150px" TextMode="MultiLine" Width="530px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label10" runat="server" Text="Post event actions to remain compliant:" Style="font-weight: 700"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPostEvent" ErrorMessage="Post event action is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPostEvent" runat="server" Height="150px" TextMode="MultiLine" Width="530px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <uc1:WorkOrder ID="WorkOrder1" runat="server" />
                        <table class="tMainBorder" style="width: 680px; font-size: 12px">
                            <tr>
                                <td class="cHeadTile" colspan="2">Attach Work Plan here...</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label107" runat="server" Text="Upload Work Plan:"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="UploadFile" runat="server" />
                                    &nbsp;
                                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" Height="22px" ValidationGroup="upload" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; margin-left: 24.0em; margin-top:1.2em";>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px" />
            &nbsp;
            <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="Close" OnClick="btnClose_Click" Width="100px" />
        </div>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <br />
    </form>
</body>
</html>
