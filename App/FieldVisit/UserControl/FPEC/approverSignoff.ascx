<%@ Control Language="C#" AutoEventWireup="true" CodeFile="approverSignoff.ascx.cs" Inherits="UserControl_approverSignoff" %>
<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>
<style type="text/css">
  


.tMainBorder
{
    border: 1px solid gray;
	padding: 0px;
	background-color :#FFFFFF;
    margin :3px;
	width: 565px;
}

  table  
  {
	border-collapse:collapse;
	font: 85% Verdana, Arial, Helvetica, Georgia, "Times New Roman", Times, serif;
	color: black;
  }

  .tMainBorder td
{
	padding-top:2px;
	padding-bottom:2px;
	padding-left:5px;
	vertical-align:top;
	text-align:left;
}  
		

.cHeadTile{
	vertical-align:middle;
    font-size: 13px;
	font-weight: bold;
	font-family:Arial;
	color:#003366;
	background: url('../../EIP/images/hdrbg_p3.gif') repeat-x;
    }

  table td
        {
			vertical-align:top;
			text-align:left;
			/*margin-left: 80px;	*/
        }  


</style>
<table class="tMainBorder" style="width:550px">
    <tr>
        <td class="cHeadTile" colspan="2">
            <asp:Label ID="SupportLabel" runat="server" Font-Bold="True" 
                ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Stand:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="drpStand" runat="server" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Comments:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="CommentTextBox" runat="server" Height="100px" Text="" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="submitButton" runat="server" onclick="submitButton_Click" 
                Text="Submit" Width="100px" />
            &nbsp;&nbsp;
            <asp:Button ID="closeButton" runat="server" onclick="closeButton_Click" 
                Text="Close" Width="100px" />
        </td>
    </tr>
</table>
