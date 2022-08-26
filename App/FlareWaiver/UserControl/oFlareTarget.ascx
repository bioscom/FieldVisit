<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oFlareTarget.ascx.cs" Inherits="App_FlareWaiver_UserControl_oFlareTarget" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<script language="javascript" type="text/javascript">

        function showRadWin() {
            //Call existing global function to obtain a reference to the window manager
            var oManager = GetRadWindowManager();
            //Show a particular existing window
            
            oManager.open(null, "RadWindow1");
            oManager.set_visibleStatusbar(false);
        }

    </script>


    <table class="tMainBorder" style="width: 99%">
        <tr class="cHeadTile">
            <td>Current Flare Target (mscfd)
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadButton RenderMode="Lightweight" runat="server" AutoPostBack="false" OnClientClicked="showRadWin" Text="Add Flare Target" />

                <br />
                <br />
                <div style="margin-left: 0.5em">
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                        OnRowDataBound="grdView_RowDataBound" OnRowEditing="grdView_RowEditing" OnRowCancelingEdit="grdView_RowCancelingEdit" OnRowUpdating="grdView_RowUpdating"
                        DataKeyNames="TARGETID" Width="100%">
                        <Columns>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="">

                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="iPersonnel"></asp:LinkButton>
                                    <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="iPersonnel" Enabled="true" HeaderText="Validation Summary..." />
                                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" ValidationGroup="iPersonnel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument="<%# Container.DisplayIndex %>"
                                        TARGETID='<%# DataBinder.Eval(Container.DataItem, "TARGETID") %>' ValidationGroup="iPersonnel">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Facilities" SortExpression="FACILITY">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="drpFacilities" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="labelFacilities" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Codes" SortExpression="CODE">
                                <ItemTemplate>
                                    <asp:Label ID="labelCodes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Jan" SortExpression="JAN">

                                <EditItemTemplate>
                                    <asp:TextBox ID="txtJan" Width="60px" runat="server" Text='<%# Eval("JAN") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelJan" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JAN") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Feb" SortExpression="FEB">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFeb" Width="60px" runat="server" Text='<%# Eval("FEB") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelFeb" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FEB") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mar" SortExpression="MAR">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMar" Width="60px" runat="server" Text='<%# Eval("MAR") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelMar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MAR") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Apr" SortExpression="APR">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtApr" Width="60px" runat="server" Text='<%# Eval("APR") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelApr" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "APR") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="May" SortExpression="MAY">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMay" Width="60px" runat="server" Text='<%# Eval("MAY") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelMay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MAY") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Jun" SortExpression="JUN">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtJun" Width="60px" runat="server" Text='<%# Eval("JUN") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelJun" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JUN") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Jul" SortExpression="JUL">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtJul" Width="60px" runat="server" Text='<%# Eval("JUL") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelJul" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JUL") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Aug" SortExpression="AUG">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAug" Width="60px" runat="server" Text='<%# Eval("AUG") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelAug" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AUG") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sep" SortExpression="SEP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSep" Width="60px" runat="server" Text='<%# Eval("SEP") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelSep" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SEP") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Oct" SortExpression="OCT">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOct" Width="60px" runat="server" Text='<%# Eval("OCT") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelOct" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OCT") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nov" SortExpression="NOV">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNov" Width="60px" runat="server" Text='<%# Eval("NOV") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelNov" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NOV") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Dec" SortExpression="DECB">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDec" Width="60px" runat="server" Text='<%# Eval("DECB") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelDec" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DECB") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="YTD" SortExpression="YTD">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtYTD" Width="60px" runat="server" Text='<%# Eval("YTD") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div style="text-align: right">
                                        <asp:Label ID="labelYTD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YTD") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

            </td>
        </tr>
    </table>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" Title="Add Flare Target" NavigateUrl="~/App/FlareWaiver/FlareTargetFrm.aspx"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>