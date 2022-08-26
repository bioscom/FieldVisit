<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="VerificationHeatMap.aspx.cs" Inherits="VerificationHeatMap" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="UserControls/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- This goes in the document HEAD so IE7 and IE8 don't cry -->
    <!--[if lt IE 9]>
	<style type="text/css">
		table.gradienttable th {
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d5e3e4', endColorstr='#b3c8cc',GradientType=0 );
			position: relative;
			z-index: -1;
		}
		table.gradienttable td {
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ebecda', endColorstr='#ceceb7',GradientType=0 );
			position: relative;
			z-index: -1;
		}
	</style>
	<![endif]-->

    <!-- CSS goes in the document HEAD or added to your external stylesheet -->
    <style type="text/css">
        table.gradienttable {
            font-family: verdana,arial,sans-serif;
            font-size: 13px;
            color: #333333;
            border-width: 1px;
            border-color: #999999;
            border-collapse: collapse;
        }

            table.gradienttable th {
                padding: 0px;
                background: #d5e3e4;
                background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2Q1ZTNlNCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjQwJSIgc3RvcC1jb2xvcj0iI2NjZGVlMCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNiM2M4Y2MiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
                background: -moz-linear-gradient(top, #d5e3e4 0%, #ccdee0 40%, #b3c8cc 100%);
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#d5e3e4), color-stop(40%,#ccdee0), color-stop(100%,#b3c8cc));
                background: -webkit-linear-gradient(top, #d5e3e4 0%,#ccdee0 40%,#b3c8cc 100%);
                background: -o-linear-gradient(top, #d5e3e4 0%,#ccdee0 40%,#b3c8cc 100%);
                background: -ms-linear-gradient(top, #d5e3e4 0%,#ccdee0 40%,#b3c8cc 100%);
                background: linear-gradient(to bottom, #d5e3e4 0%,#ccdee0 40%,#b3c8cc 100%);
                border: 1px solid #999999;
            }

            table.gradienttable td {
                padding: 0px;
                background: #ebecda;
                background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2ViZWNkYSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjQwJSIgc3RvcC1jb2xvcj0iI2UwZTBjNiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNjZWNlYjciIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
                background: -moz-linear-gradient(top, #ebecda 0%, #e0e0c6 40%, #ceceb7 100%);
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ebecda), color-stop(40%,#e0e0c6), color-stop(100%,#ceceb7));
                background: -webkit-linear-gradient(top, #ebecda 0%,#e0e0c6 40%,#ceceb7 100%);
                background: -o-linear-gradient(top, #ebecda 0%,#e0e0c6 40%,#ceceb7 100%);
                background: -ms-linear-gradient(top, #ebecda 0%,#e0e0c6 40%,#ceceb7 100%);
                background: linear-gradient(to bottom, #ebecda 0%,#e0e0c6 40%,#ceceb7 100%);
                border: 1px solid #999999;
            }

            table.gradienttable th p {
                margin: 0px;
                padding: 8px;
                border-top: 1px solid #eefafc;
                border-bottom: 0px;
                border-left: 1px solid #eefafc;
                border-right: 0px;
            }

            table.gradienttable td p {
                margin: 0px;
                padding: 8px;
                border-top: 1px solid #fcfdec;
                border-bottom: 0px;
                border-left: 1px solid #fcfdec;
                border-right: 0px;
            }
    </style>

    <div style="margin-top:0px; height: 95%; width: 98%">
        <div style="float: left; width: 220px; overflow-x: hidden; height: 100%; overflow: auto; border: solid 1px gray">
            <asp:TreeView ID="mnuTreeView" runat="server" OnSelectedNodeChanged="mnuTreeView_SelectedNodeChanged" ImageSet="Arrows" ExpandDepth="1" ShowCheckBoxes="All" ShowLines="True">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                    HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
        <div style="color: Black; margin-left: 25em; margin-right: 2px; margin-top: 2em">
            <h2>RPI Verification Heat Map</h2>
            <asp:Panel ID="pnlForm" runat="server">
                <table class="gradienttable">
                    <tr>
                        <td class="cHeadTile" colspan="2">
                            <asp:Label ID="lblAssetDistrictFacility" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" ValidationGroup="Filter" Width="150px">
                                <asp:ListItem Value="-1">Select Month...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlMonth" ErrorMessage="Please select Month" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ValidationGroup="Filter" Width="150px">
                                <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlYear" ErrorMessage="Please select Year" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Standadised Work:"></asp:Label>
                        </td>
                        <td>
                            <uc2:statusSelectorControl ID="ddlStandardised" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Go See"></asp:Label>
                        </td>
                        <td>

                            <uc2:statusSelectorControl ID="ddlGoSee" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Structured Day:"></asp:Label>
                        </td>
                        <td>

                            <uc2:statusSelectorControl ID="ddlStructuredDay" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Maintenance Consumables:"></asp:Label>
                        </td>
                        <td>

                            <uc2:statusSelectorControl ID="ddlMtceConsumables" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="iFacilityId" runat="server" />
                        </td>
                        <td>

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />

                            &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" ValidationGroup="xxxx" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDate" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>

</asp:Content>

