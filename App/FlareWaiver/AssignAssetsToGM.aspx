<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="AssignAssetsToGM.aspx.cs" Inherits="App_FlareWaiver_AssignAssetsToGM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tMainBorder" style="width:750px; font-size: 12px">
        <tr>
            <td class="cHeadTile">Assign Asset to GM Offshore/GM Onshore</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="drpGMOnOffShore" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpGMOnOffShore_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Select GM Offshore/GM Onshore--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="facilitiesCheckBoxList" runat="server" RepeatColumns="5">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td>
                <div style="margin-left: 0.5em">
                    <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" Width="100px" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
