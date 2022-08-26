<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PDCostPerformance.ascx.cs" Inherits="UserControl_PDCostPerformance" %>

<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>

    <ItemTemplate>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/i_MI.JPG" />
        <asp:Label runat="server" ID="Label2" Text='<%# Eval("DEPARTMENT") %>' />
        <%--<div>
            <div>
                
            </div>
            <div>
                
            </div>
        </div>--%>
    </ItemTemplate>

    <%-- <AlternatingItemTemplate>
                <asp:Label runat="server" ID="Label3" text='<%# Eval("CategoryName") %>' /> 
                   
                 <asp:Label runat="server" ID="Label4"  text='<%# Eval("Description") %>' />
                    
          </AlternatingItemTemplate>--%>

    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>

<asp:DataList ID="list" runat="server" RepeatColumns="3" CssClass="ProductList"  onitemdatabound="list_ItemDataBound">
  <ItemTemplate>
    <h3 class="ProductTitle">
      <a href="<%# Eval("IDDEPARTMENT").ToString() %>">
        <%# HttpUtility.HtmlEncode(Eval("DEPARTMENT").ToString()) %>
      </a>
    </h3>
    <a href="<%# Eval("IDDEPARTMENT").ToString() %>">
      <img width="100" src="~/Images/i_MI.JPG" border="0" alt='<%# HttpUtility.HtmlEncode(Eval("DEPARTMENT").ToString())%>' />
    </a>
    <%# HttpUtility.HtmlEncode(Eval("DEPARTMENT").ToString()) %>
    <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
  </ItemTemplate>
</asp:DataList>

<%--<asp:ListView ID="ListView1" runat="server"></asp:ListView>--%>
