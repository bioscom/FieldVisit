<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DistrictSuperintendents.ascx.cs" Inherits="App_PDR_UserControl_DistrictSuperintendents" %>

<table class="tSubGray">
    <tr>
        <td class="cHeadTile">Map District to Superintendents</td>
    </tr>
    <tr>
        <td>
            <div style="margin-left: 0.5em">
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSuperintendents" runat="server">
                                <asp:ListItem Value="-1">--Select Superintendent--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlAssets" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssets_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
                            </asp:DropDownList>
                        &nbsp;</td>
                    </tr>
                </table>
            </div>

            <div style="border: solid 1px gray; margin-left: 0.5em;">
                <asp:CheckBoxList ID="ckbDistrict" runat="server" RepeatColumns="8">
                </asp:CheckBoxList>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div style="margin-left: 0.5em">
                <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click"
                    Text="Submit" Width="100px" />
            </div>
        </td>
    </tr>
</table>

