<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FieldVisitQuestionaire.ascx.cs" Inherits="UserControl_FieldVisitQuestionaire" %>

<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            Manning &amp; Support Arrangements
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s1Label" runat="server"></asp:Label>
            <asp:Image ID="img1" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="s10Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s1HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s10Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s2Label" runat="server"></asp:Label>
            <asp:Image ID="img2" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="s20Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s2HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s20Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s3Label" runat="server"></asp:Label>
            <asp:Image ID="img3" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="s30Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s3HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s30Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s4Label" runat="server"></asp:Label>
            <asp:Image ID="img4" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="s40Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s4HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s40Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s5Label" runat="server"></asp:Label>
            <asp:Image ID="img5" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="s50Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s5HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s50Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s6Label" runat="server"></asp:Label>
            <asp:Image ID="img6" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="s60Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s6HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s60Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s7Label" runat="server"></asp:Label>
            <asp:Image ID="img7" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="s70Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s7HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s70Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            Paperwork &amp; Procedures
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s8Label" runat="server"></asp:Label>
            <asp:Image ID="img8" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="s80Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s8HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s80Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s9Label" runat="server"></asp:Label>
            <asp:Image ID="img9" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="s90Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s9HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s90Chklst" runat="server" RepeatDirection="Horizontal" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            Materials &amp; Equipment
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s10Label" runat="server"></asp:Label>
            <asp:Image ID="img10" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="s100Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s10HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s100Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s11Label" runat="server"></asp:Label>
            <asp:Image ID="img11" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="s110Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s11HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s110Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s12Label" runat="server"></asp:Label>
            <asp:Image ID="img12" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="s120Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s12HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s120Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s13Label" runat="server"></asp:Label>
            <asp:Image ID="img13" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="s130Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s13HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s130Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            Logistics
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s14Label" runat="server"></asp:Label>
            <asp:Image ID="img14" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="s140Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s14HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s140Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s15Label" runat="server"></asp:Label>
            <asp:Image ID="img15" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="s150Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s15HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s150Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            On-Site
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s16Label" runat="server"></asp:Label>
            <asp:Image ID="img16" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="s160Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s16HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s160Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s17Label" runat="server"></asp:Label>
            <asp:Image ID="img17" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="s170Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s17HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s170Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td class="cHeadLeft">
            Personnel Requirements(guidance only)
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
        <td class="cHeadLeft">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 30%">
            Complete?
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s18Label" runat="server"></asp:Label>
            <asp:Image ID="img18" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="s180Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s18HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s180Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s19Label" runat="server"></asp:Label>
            <asp:Image ID="img19" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="s190Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s19HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s190Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s20Label" runat="server"></asp:Label>
            <asp:Image ID="img20" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="s200Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s20HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s200Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s21Label" runat="server"></asp:Label>
            <asp:Image ID="img21" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="s210Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s21HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s210Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s22Label" runat="server"></asp:Label>
            <asp:Image ID="img22" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="s220Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s22HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s220Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="s23Label" runat="server"></asp:Label>
            <asp:Image ID="img23" runat="server" ImageUrl="~/Images/globalheader_help.gif" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="s230Chklst"
                ErrorMessage="option cannot be empty">*</asp:RequiredFieldValidator>
            <asp:HiddenField ID="s23HF" runat="server" />
        </td>
        <td>
            <asp:RadioButtonList ID="s230Chklst" runat="server" RepeatDirection="Horizontal"
                TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="2">Not Applicable</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
