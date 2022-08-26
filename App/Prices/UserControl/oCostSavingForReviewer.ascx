<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCostSavingForReviewer.ascx.cs" Inherits="App_Prices_UserControl_oCostSavingForReviewer" %>

<asp:GridView ID="grdView" runat="server"
                    AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand"
                    AllowPaging="True" PageSize="30"
                    OnPageIndexChanging="grdView_PageIndexChanging" Width="100%">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server"
                                    PRICEID='<%# DataBinder.Eval(Container.DataItem, "PRICEID") %>'
                                    CommandName="EditThis" CommandArgument='<%# Container.DisplayIndex %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="ActionLinkButton" runat="server"
                                    PRICEID='<%# DataBinder.Eval(Container.DataItem, "PRICEID") %>'
                                    CommandName="Action" CommandArgument='<%# Container.DisplayIndex %>'>Action...</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PO Number">
                            <ItemTemplate>
                                <asp:Label ID="lblPONumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PONUMBER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Material Description">
                            <ItemTemplate>
                                <asp:Label ID="lblMaterialDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALDESC") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Material Code">
                            <ItemTemplate>
                                <asp:Label ID="lblMaterialCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALCODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price ($)">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Should be price ($)">
                            <ItemTemplate>
                                <asp:Label ID="lblShouldBePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SHOULDBEPRICE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price Variance ($)">
                            <ItemTemplate>
                                <asp:Label ID="lblPriceVariance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XVARIANCE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Price Source">
                            <ItemTemplate>
                                <asp:Label ID="lblPriceSource" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICESOURCE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Other Information">
                            <ItemTemplate>
                                <asp:Label ID="lblOtherInformation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERINFORMATION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Hub">
                            <ItemTemplate>
                                <asp:Label ID="lblHub" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HUB") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Submitted By">
                            <ItemTemplate>
                                <asp:Label ID="lblSubmittedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Reported">
                            <ItemTemplate>
                                <asp:Label ID="labelDateReported" runat="server"
                                    Text='<%# Eval("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewStatusLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="ViewStatus"
                                    STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                                    PRICEID='<%# DataBinder.Eval(Container.DataItem, "PRICEID") %>'>View Review Status</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>