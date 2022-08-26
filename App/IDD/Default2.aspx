<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="App_IDD_Default2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="HistoryContentPlaceHolder" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <%--    <table style="color: black; width:80%">
        <tr>
            <td>
                <table style="color: black">
                    <tr>
                        <td style="width: 200px">
                            <asp:Label ID="Label8" runat="server" Text="IDD Number:"></asp:Label>
                        </td>
                        <td>
                            <b><%# Eval("IDDNO") %></b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <asp:Label ID="Label2" runat="server" Text="Vendor's Code:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("VENDOURCODE") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Location:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("LOCATION") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Service:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("CATEGORY") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Request initiator:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("CONTRACTHOLDERFULLNAME") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="CP IDD Focal Point:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("FOCALPOINTFULLNAME") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="IDD Analyst:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("ANALYSTFULLNAME") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Nature of Request:"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Priority:"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Vendor's Full Registered Name:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("REGISTEREDNAME") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Vendor's Address:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("ADDRESS") %>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Company Representative:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("REPRESENTATIVE") %>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="E-mail address:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("EMAILADDRESS") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Telephone(GSM NO):"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("TELEPHONENO") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="Nature of Contract:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("REPRESENTATIVE") %>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                <table style="color: black">
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Value of Contract (if any) in US$:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("AMOUNT") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Nature of Request:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("NOR") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="Nature of Contract:"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("NOC") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Does Business Ownership have Government Ownership (GO) Element?:" Width="200px"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("GO") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Is vendor a Government Intermediary (GI)?:" Width="200px"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("GI") %>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>--%>

    <%--<table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Assign IDD Analyst:"></asp:Label>
            </td>
            <td>

                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlAnalyst" runat="server" Height="200" Width="430px" Font-Size="10pt"
                    DropDownWidth="500" EmptyMessage="Search for IDD Analyst..." HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlAnalyst_ItemsRequested"
                    Skin="Office2010Silver">

                    <HeaderTemplate>
                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 165px;">Name</td>
                                <td style="width: 220px;">Email Address</td>
                                <td style="width: 90px;">Ref. Ind.</td>
                            </tr>
                        </table>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 165px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAIL']")%></td>
                                <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['REFIND']")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>--%>

        <p>
            Reason for Rejection:
        </p>
        <p>
            <telerik:RadTextBox ID="txtRejectionComment" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></telerik:RadTextBox>
        </p>
        <p>
            <%--<asp:Button ID="btnRejected" runat="server" Text="Request Rejected" OnClick="btnRejected_Click" />--%>
        </p>
    <asp:LinkButton ID="lnkRejectRequest" runat="server" OnClick="lnkRejectRequest_Click"></asp:LinkButton>
    <table cellpadding="0" cellspacing="0" width="100%" border="2" bordercolor="#003366">
        <tr>
            <td valign="top" align="center" bgcolor="#003366">
                <font size="2" color="#FFFFFF" face="tahoma">
                    <b>Integrity Due Diligence</b>
                </font>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" cellpadding="2" cellspacing="0">
                    <tr>
                        <td bgcolor="#FFFFFF">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <img alt="" src="cid:Logo" />
                                    </td>
                                    <td>
                                        <font size="2" face="tahoma" color="black">
                                            This Mail was automatically generated to notify you that @=CONTRACTHOLDER has raised an Integrity Due Diligence Request.
                                        </font>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>
                                        <font size="2" face="tahoma" color="black">

                                            <strong>Vendor:</strong> @=VENDOR<br />
                                            <strong>Value of Contract:</strong> @=VALUE<br />
                                            <strong>Nature of Request:</strong> @=NATURE<br />
                                            <strong>Nature of Contract:</strong> @=CONTRACT<br />
                                            <br />
                                            <br />
                                            Login to your account <a href="@=EEEE"></a>
                                            <a href="@=EEEE">here</a>. Please, contact the Administrator for any support.
                                                
                                        </font>
                                    </td>
                                </tr>
                            </table>

                            <table width="100%" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>
                                        <font size="2" face="tahoma" color="black">
                                            <strong>Request initiator:</strong> @=CONTRACTHOLDER<br />
                                            <strong>CP IDD Focal Point:</strong> @=IDDFOCALPOINT<br />
                                            <strong>IDD Analyst:</strong> @=ANALYST</font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" bgcolor="#003366">
                <font size="2" color="#FFFFFF" face="tahoma">
                    <b>@=TTTT</b>
                </font>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td valign="top" align="right" bgcolor="#FFFFFF">
                <table>
                    <tr>
                        <td align="right" bgcolor="#FFFFFF" valign="top">
                            <font color="#000000" face="tahoma" size="2">
                                <b>
                                    Support Contacts &gt;<font face="tahoma" size="2">Business Improvement: @=L1SUPPORT,&nbsp; System Support: @=L2SUPPORT</font>
                                    &nbsp;
                                </b>
                            </font>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
