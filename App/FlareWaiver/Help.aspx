<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin:auto auto auto auto">
        <iframe id="fileLoader" name="fileLoader" src="../FlareWaiver/Help.pdf" style="width: 98%; height: 600px" runat="server" scrolling="auto"></iframe>
    </div>
</asp:Content>

