<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BenefitPotential.ascx.cs" Inherits="App_Lean_UserControl_BenefitPotential" %>

<style type="text/css">

        .auto-style1 {
            color: red;
        }
    </style>

<table class="tSubGray" style="width: 700px">
    <tr>
        <td class="cHeadTile" colspan="3">Benefit Potential</td>
    </tr>
    <tr style="vertical-align: top">
        <td>Cycle Time Reduction(days):</td>
        <td>
            <asp:TextBox ID="txtCTR" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr style="vertical-align: top">
        <td>Cost Reduction($)&nbsp; (Abs. Value):</td>
        <td>
            <asp:TextBox ID="txtCR" runat="server"></asp:TextBox>
            <span class="auto-style1">**Please, enter absolute values</span></td>
    </tr>
    <tr style="vertical-align: top">
        <td>Production Enhancement (Barrel):</td>
        <td>
            <asp:TextBox ID="txtProdEnhancmt" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr style="vertical-align: top">
        <td>Benefits:</td>
        <td>
            <asp:TextBox ID="txtBenefit" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr style="vertical-align: top">
        <td>Comments:</td>
        <td>
            <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HiddenField ID="PotentialId" runat="server" />
            <asp:HiddenField ID="RecommendationId" runat="server" />
        </td>
        <td colspan="2">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Add Benefit Potential" Width="170px" />
        </td>
    </tr>
</table>
<br />
<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="700px">
    <Columns>

        <asp:TemplateField HeaderText="CT Reduction">
            <ItemTemplate>
                <asp:Label ID="lbCTReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CTREDUCTION") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cost Reduction">
            <ItemTemplate>
                <asp:Label ID="lbCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COSTREDUCTION") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Production Barrels">
            <ItemTemplate>
                <asp:Label ID="lbProductionBarrels" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTIONBARREL") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Other Benefits">
            <ItemTemplate>
                <asp:Label ID="lbOtherBenefitS" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERBENEFITS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Comments">
            <ItemTemplate>
                <asp:Label ID="lbComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

