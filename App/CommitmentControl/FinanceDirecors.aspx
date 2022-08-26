<%@ Page Title="" Language="C#" MasterPageFile="~/BongaCCP.master" AutoEventWireup="true" CodeFile="FinanceDirecors.aspx.cs" Inherits="App_CommitmentControl_FinanceDirecors" %>

<%@ Register Src="~/App/CommitmentControl/UserControl/FinanceDirectors.ascx" TagPrefix="app" TagName="FinanceDirectors" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <app:FinanceDirectors runat="server" ID="FinanceDirectors" />
</asp:Content>

