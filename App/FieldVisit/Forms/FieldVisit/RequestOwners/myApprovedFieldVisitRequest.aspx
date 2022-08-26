<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="myApprovedFieldVisitRequest.aspx.cs" Inherits="myApprovedFieldVisitRequest" %>

<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/approvedFieldVisitRequests.ascx" TagName="approvedFieldVisitRequests" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:approvedFieldVisitRequests ID="approvedFieldVisitRequests1" runat="server" />
</asp:Content>