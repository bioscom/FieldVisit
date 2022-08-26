<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewStatus.aspx.cs" Inherits="App_Prices_ReviewStatus" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="tMainBorder" style="width: 98%">
                <tr class="cHeadTile">
                    <td colspan="2">Review Status</td>
                </tr>
                <tr>
                    <td style="width: 45%">
                        <asp:DetailsView ID="dtlView" runat="server" AutoGenerateRows="False" Width="100%"
                            DataKeyNames="PRICEID" AllowPaging="True" EnableViewState="False">
                            <Fields>

                                <asp:TemplateField HeaderText="PO Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPONumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PONUMBER") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Material Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MATERIALDESC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<ItemStyle Width="300px" />--%>
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

                                <asp:TemplateField HeaderText="Price Source">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriceSource" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRICESOURCE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Other Information">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOtherInformation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERINFORMATION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<ItemStyle Width="300px" />--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Submitted By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubmittedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Reported">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDateReported" runat="server"
                                            Text='<%# Eval("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Savings Achieved?">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reviewer's Report">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReview" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Fields>

                        </asp:DetailsView>
                    </td>
                    <td style="width: 55%">
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td class="cHeadTile" colspan="2">Uploaded Document</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="OpenPDFHyperLink" runat="server" NavigateUrl="~/App/Prices/Price.pdf" Target="_blank">Open PDF into New Page</asp:HyperLink>
                                </td>
                                <td>Click
                            <asp:ImageButton ID="refreshPageImageButton" runat="server" ImageUrl="~/Images/Refresh.jpg" Width="20px" />
                                    &nbsp;to refresh</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <iframe id="fileLoader" name="fileLoader" style="width: 99%; height: 450px" runat="server" scrolling="auto"></iframe>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
            </table>

        </div>
    </form>
</body>
</html>
