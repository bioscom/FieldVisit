<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dateControl.ascx.cs" Inherits="UserControl_dateControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div style="width: 130px">
    <div style="float: left">
        <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox>
    </div>
    <div style="float: left">
        <asp:ImageButton ID="imgBtnStartDate" runat="server" Height="22px" ImageUrl="~/Images/Calendar_scheduleHS.png" ValidationGroup="yyyy" />
    </div>
</div>
<ajaxToolkit:CalendarExtender ID="txtDateExt"
    runat="server" Enabled="True" EnableViewState="true"
    PopupButtonID="imgBtnStartDate" TargetControlID="txtDate" Format="dd-MM-yyyy">
</ajaxToolkit:CalendarExtender>


