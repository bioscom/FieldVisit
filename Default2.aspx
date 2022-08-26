<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table style="color: black; font:bold">
            <tr>
                <td style="width: 200px">
                    <asp:Label ID="Label2" runat="server" Text="PO Number:"></asp:Label>
                </td>
                <td style="text-align:right">
                    <%# Eval("PONUMBER") %>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Material Description:"></asp:Label>
                </td>
                <td>
                    <%# Eval("MATERIALDESC") %>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Material Code:"></asp:Label>
                </td>
                <td><%# Eval("MATERIALCODE") %></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Price ($):"></asp:Label>
                </td>
                <td>
                    <%# Eval("PRICE") %>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Should be price ($):"></asp:Label>
                </td>
                <td>
                    <%# Eval("SHOULDBEPRICE") %>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Price Variance ($):"></asp:Label>
                </td>
                <td>
                    <%# Eval("XVARIANCE") %>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Price Source:"></asp:Label>
                </td>
                <td>
                    <%# Eval("PRICESOURCE") %>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Other Information:"></asp:Label>
                </td>
                <td>
                    <%# Eval("OTHERINFORMATION") %>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Submitted By:"></asp:Label>
                </td>
                <td>
                    <%# Eval("OTHERINFORMATION") %>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Date Reported:"></asp:Label>
                </td>
                <td>
                    <%# Eval("DATE_SUBMITTED") %>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Saving Achieved?:"></asp:Label>
                </td>
                <td>
                    <%# Eval("CLOSEOUTSTATUS") %>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="Reviewers Report:"></asp:Label>
                </td>
                <td>
                    <%# Eval("COMMENTS") %>

                </td>
            </tr>
        </table>





        <%--<div>
            1) Simple Marquee With Left And Right Direction
   <div style="width: 927px; background-color: #FFFF00;">
       <marquee><strong> Simple Marquee Text</strong></marquee>
       <marquee direction="left"><strong> Simple Marquee Text(Left Direction)</strong></marquee>
   </div>
            <div style="width: 927px; background-color: #CCFFCC;">
                <marquee direction="right"><strong> Simple Marquee Text(Right Direction)</strong></marquee>
            </div>

            <br />

            2)Simple Marquee With Controls(Up And Down Direction)
   <div style="background-color: #FFCCFF">
       <marquee direction="Up"><strong> <a href="#">Simple Marquee With Hyperlink In Up Direction</a></strong></marquee>
   </div>
            <div style="background-color: #CCCCFF">
                <marquee direction="down"><strong> <asp:Image ID="img" runat="server" ImageUrl="~/wait.gif" /></strong></marquee>
            </div>
            <br />
            3) Dynamic Marquee Populated From Database
   <table>
       <tr>
           <td>
               <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFCC" BorderStyle="Inset"
                   BorderWidth="3" Width="454px" GroupingText="Dynamic Marquee From Database(Up Direction)">
                   <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()"
                       scrolldelay="500" style="height: 127px; width: 457px;">
                    <asp:Literal ID="lt1" runat="server"></asp:Literal></marquee>
               </asp:Panel>
           </td>
           <td>
               <asp:Panel ID="Panel2" runat="server" BackColor="#CCFFCC" BorderStyle="Inset"
                   BorderWidth="3" Width="454px"
                   GroupingText="Dynamic Marquee From Database(Down Direction)">
                   <marquee direction="down" onmouseover="this.stop()" onmouseout="this.start()"
                       scrolldelay="500" style="height: 127px; width: 457px;">
                    <asp:Literal ID="lt2" runat="server"></asp:Literal></marquee>
               </asp:Panel>
           </td>
       </tr>
   </table>

        </div>--%>
    </form>
</body>
</html>
