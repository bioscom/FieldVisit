<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="WhatWhyConsequences.aspx.cs" Inherits="App_Contract_WhatWhyConsequences" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<%@ Register Src="UserControls/ActivityChange.ascx" TagName="ActivityChange" TagPrefix="uc3" %>
<%@ Register Src="UserControls/BusinessImprovement.ascx" TagName="BusinessImprovement" TagPrefix="uc4" %>
<%@ Register Src="UserControls/LessonLearnt.ascx" TagName="LessonLearnt" TagPrefix="uc5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tMainBorder" style="width: 98%">
                <tr>
                    <td class="cHeadTile" colspan="3">OPERATIONS SUPERINTENDENT 14 DAY CONTRACT</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Trip Start Date:"></asp:Label>
                    </td>
                    <td>
                        <uc2:dateControl ID="dtTripStart" runat="server" />
                    </td>
                    <td>
                        <%--<asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="300px" AutoPostBack="True">
                            <asp:ListItem Value="-1">Select Asset Area</asp:ListItem>
                        </asp:DropDownList>--%>
                    </td>
                </tr>
            </table>
            <hr />
            <uc3:ActivityChange ID="ActivityChange1" runat="server" />
            <hr />
            <uc4:BusinessImprovement ID="BusinessImprovement1" runat="server" />
            <hr />
            <uc5:LessonLearnt ID="LessonLearnt1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 55%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
