<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadCostSavingStories.ascx.cs" Inherits="App_PDCC_UserControl_UploadCostSavingStories" %>

<div style="text-align: center; margin-bottom: 0.5em; margin-top: 0em">
    <asp:Panel runat="server" ID="adminFileUpload">
        <table style="width: 420px; border: none">
            <tr>
                <td colspan="2">Upload Cost Saving Stories
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="xyFileUpload" runat="server" Height="26px" Width="300px" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="uploadButton" runat="server" OnClick="uploadButton_Click" Text="Upload" ValidationGroup="upload" Width="120px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
