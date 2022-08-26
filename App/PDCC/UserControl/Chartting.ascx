<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chartting.ascx.cs" Inherits="App_PDCC_UserControl_Chartting" %>

<script type="text/javascript" src="fusioncharts/fusioncharts.js"></script>
<script type="text/javascript" src="fusioncharts/themes/fusioncharts.theme.fint.js"></script>

<div>
        <table style="width:98%; border:none" align="center" cellspacing="0" cellpadding="3">
          <tr> 
            <td style="border:none" valign="top" class="text" align="center" >
                <asp:Literal ID="FCLiteral1" runat="server"></asp:Literal>
	        </td>
            <td style="border:none" valign="top" class="text" align="center">
                <asp:Literal ID="FCLiteral2" runat="server"></asp:Literal>
	        </td>
	        
            <td style="border:none" valign="top" class="text" align="center">
                <asp:Literal ID="FCLiteral3" runat="server"></asp:Literal>
	        </td>
          </tr>     
        </table>    
    </div>