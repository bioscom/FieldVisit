<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDocumentLoader.ascx.cs" Inherits="App_IDD_UserControl_oDocumentLoader" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<fieldset>
        <legend>
            <b style="color: green">Upload Documents</b>
        </legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2" style="height: 35px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="background-color: silver; border: solid 1px silver">
                                            <asp:Label ID="Label13" runat="server" Text="Upload Documents:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="height: 150px; overflow: auto; border: solid 1px silver">
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
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>