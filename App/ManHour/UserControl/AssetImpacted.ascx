<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssetImpacted.ascx.cs" Inherits="App_ManHour_UserControl_AssetImpacted" %>

<table class="tMainBorder">
    <tr class="cHeadTile">
        <td>
            
            SPDC Assets</td>
    </tr>
    <tr>
        <td>
            <asp:CheckBoxList ID="SPDCCheckBoxList" runat="server"></asp:CheckBoxList>
        </td>
    </tr>
</table>
<br/>
<table class="tMainBorder">
    <tr class="cHeadTile">
        <td>
            
            SNEPCO Assets</td>
    </tr>
    <tr>
        <td>
            <asp:CheckBoxList ID="SNEPCOCheckBoxList" runat="server"></asp:CheckBoxList> 
        </td>
    </tr>
</table>