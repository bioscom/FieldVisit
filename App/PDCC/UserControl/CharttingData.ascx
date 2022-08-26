<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CharttingData.ascx.cs" Inherits="App_PDCC_UserControl_CharttingData" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%--<style type="text/css">
*{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}*,:after,:before{color:#000!important;text-shadow:none!important;background:0 0!important;-webkit-box-shadow:none!important;box-shadow:none!important}</style>--%>

<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release" />
<div style="background-color: white">          
    <asp:LinkButton ID="EditLinkButton" ForeColor="Transparent" runat="server"></asp:LinkButton>
    <asp:GridView ID="grdView" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" OnLoad="grdView_Load"
        OnPageIndexChanging="grdView_PageIndexChanging"
        OnRowCommand="grdView_RowCommand" PageSize="20" AlternatingRowStyle-BackColor="#46b5b5"
        OnSelectedIndexChanged="grdView_SelectedIndexChanged" ShowFooter="true">
        <Columns>

            <asp:TemplateField HeaderText="...">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Asset">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRecommendation" CommandArgument="<%# Container.DisplayIndex %>" Font-Bold="true"
                        ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>' OnClick="lnkEdit_Click"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="OP ($mln)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Banked ($mln)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblActualSaving" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="%age Banked">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblPercentageBanked" ForeColor="Black" runat="server" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Opportunities ($mln)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblImprovement" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="B&O ($mln)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblBO" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="25% Target Reduction($mln)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblReduction" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Current Gap($mln) excl. Oppor.">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblCurrentGap" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</div>

<asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;" CssClass="modalPopup" Width="826px">
    <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        <asp:Button ID="closeButton" runat="server" Text="Close" ValidationGroup="xxxx" Width="100px" />
        <center><asp:Label ID="lblAsset" runat="server" Font-Size="18pt" ForeColor="#336699"></asp:Label></center>
    </asp:Panel>
    <div style="overflow: scroll; height: 550px; background-color: white">
        <asp:GridView ID="grdViewDetails" runat="server" AutoGenerateColumns="False" AllowPaging="false" ShowHeader="true"
            OnPageIndexChanging="grdViewDetails_PageIndexChanging" BackColor="White" Width="100%"  AlternatingRowStyle-BackColor="#46b5b5" ShowFooter="true">
            <Columns>

                <asp:TemplateField HeaderText="...">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Opportunity">
                    <ItemTemplate>
                        <asp:Label ID="lbAsset" runat="server" ForeColor="Black"
                            Text='<%# DataBinder.Eval(Container.DataItem, "OPPORTUNITY") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Wrap="true" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="OP ($mln)">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Banked ($mln)">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblActualSaving" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="%age Banked">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblPercentageBanked" ForeColor="Black" runat="server" Text=''></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Opportunities ($mln)">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblImprovement" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="B&O ($mln)">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblBO" runat="server" ForeColor="Black" Text=''></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="25% Target Reduction($mln)">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblReduction" runat="server" ForeColor="Black" Text=''></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Current Gap($mln) excl. Oppor.">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="lblCurrentGap" runat="server" ForeColor="Black" Text=''></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="MPE"
    runat="server"
    TargetControlID="EditLinkButton"
    PopupControlID="pnlModalPanel"
    CancelControlID="closeButton"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    PopupDragHandleControlID="pnlDragPanel"
    Drag="true" />

<asp:HiddenField ID="AssetIdHF" runat="server" />
    

