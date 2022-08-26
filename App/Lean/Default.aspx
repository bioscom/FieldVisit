<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_Lean_Default" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>

<%--<%@ Register Src="~/UserControls/supportContact.ascx" TagPrefix="bi500" TagName="supportContact" %>--%>
<%@ Register Src="~/UserControls/supportContactExt.ascx" TagPrefix="bi500" TagName="supportContactExt" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<script  lang="java" type="text/javascript">
        var iFrame = document.getElementById('fileLoader');
        var iFrameBody = iFrame.contentDocument.getElementsByTagName('body')[0];
        var iFrameBodyLinks = iFrameBody.getElementsByTagName('a');
        for (var i = 0, len = iFrameBodyLinks.length; i < len; i += 1) {
            iFrameBodyLinks[i].setAttribute('target', '_blank');
        }
    </script>--%>
    <style type="text/css">
        p {
            margin-right: 0in;
            margin-left: 0in;
            font-size: 12.0pt;
            font-family: "Times New Roman","serif";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="body" style="margin-left: 5em">
        <table style="width: 95%">
            <tr>
                <td style="width: 400px">
                    <%--<fieldset>
                    <legend style="font-weight: 700">Projects Ownership Management</legend>
                    <br />
                    <asp:LinkButton ID="lnkProjGovernance" runat="server" PostBackUrl="~/App/Lean/ProjectGovernance.aspx">Project Governance</asp:LinkButton>
                    <br />
                </fieldset><br />--%>
                    <fieldset>
                        <legend style="font-weight: 700">CI Projects</legend>
                        <ComponentArt:Menu ID="MnuMainPageMenu" runat="server" CssClass="TopGroup" DefaultGroupCssClass="MenuGroup"
                            DefaultGroupItemSpacing="2px" DefaultItemLookId="DefaultItemLook" EnableViewState="False"
                            ExpandDelay="50" ImagesBaseUrl="~/Images/comArt/baseMenu/" Orientation="Vertical"
                            TopGroupItemSpacing="1px" Width="100%" ScrollDownLookId="DefaultItemLook" ScrollUpLookId="DefaultItemLook">
                            <items>
                                <ComponentArt:MenuItem runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="~/App/Lean/ProjectDashBoard.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="View Projects - Read only view all projects (All Users)">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="~/App/Lean/LeanProjects.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="My Projects - Edit &amp; Update details (PMs &amp; Project Coach only)">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="~/App/Lean/NewLeanProject.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Add New Project - Create new project + details (PMs &amp; Project Coach only)">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="~/App/Lean/Training.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Capability – Training & Certifications">
                                </ComponentArt:MenuItem>

                            </items>
                            <itemlooks>
                                <ComponentArt:ItemLook CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingBottom="4px"
                                    LabelPaddingLeft="15px" LabelPaddingRight="15px" LabelPaddingTop="4px" LookId="TopItemLook"
                                    LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuItem" ExpandedCssClass="MenuItemHover" HoverCssClass="MenuItemHover"
                                    LabelPaddingBottom="4px" LabelPaddingLeft="18px" LabelPaddingRight="12px" LabelPaddingTop="3px"
                                    LookId="DefaultItemLook" LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuBreak" ImageHeight="2px" ImageUrl="break.gif"
                                    ImageWidth="100%" LookId="BreakItem" LeftIconVisibility="Always" RightIconVisibility="Always" />
                            </itemlooks>
                        </ComponentArt:Menu>
                    </fieldset>
                    <br />
                    <br />
                    <fieldset>
                        <legend style="font-weight: 700">Dashboard/Reports</legend>
                        <ComponentArt:Menu ID="Menu1" runat="server" CssClass="TopGroup" DefaultGroupCssClass="MenuGroup"
                            DefaultGroupItemSpacing="2px" DefaultItemLookId="DefaultItemLook" EnableViewState="False"
                            ExpandDelay="50" ImagesBaseUrl="~/Images/comArt/baseMenu/" Orientation="Vertical"
                            TopGroupItemSpacing="1px" Width="100%" ScrollDownLookId="DefaultItemLook" ScrollUpLookId="DefaultItemLook">
                            <items>
                                <ComponentArt:MenuItem ID="MenuItem1" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="~/App/Lean/CIDashBoard.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Management Dashboard">
                                </ComponentArt:MenuItem>


                            </items>
                            <itemlooks>
                                <ComponentArt:ItemLook CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingBottom="4px"
                                    LabelPaddingLeft="15px" LabelPaddingRight="15px" LabelPaddingTop="4px" LookId="TopItemLook"
                                    LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuItem" ExpandedCssClass="MenuItemHover" HoverCssClass="MenuItemHover"
                                    LabelPaddingBottom="4px" LabelPaddingLeft="18px" LabelPaddingRight="12px" LabelPaddingTop="3px"
                                    LookId="DefaultItemLook" LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuBreak" ImageHeight="2px" ImageUrl="break.gif"
                                    ImageWidth="100%" LookId="BreakItem" LeftIconVisibility="Always" RightIconVisibility="Always" />
                            </itemlooks>
                        </ComponentArt:Menu>
                        <%--<asp:LinkButton ID="LinkButton10" runat="server" Enabled="False">Kaizen Outcome Impl Summary</asp:LinkButton>--%>
                    </fieldset>
                    <br />
                    <br />
                    <asp:Panel ID="pnlUserMgt" runat="server">
                        <fieldset>
                            <legend style="font-weight: 700">Users Management</legend>
                            <ComponentArt:Menu ID="Menu3" runat="server" CssClass="TopGroup" DefaultGroupCssClass="MenuGroup"
                                DefaultGroupItemSpacing="2px" DefaultItemLookId="DefaultItemLook" EnableViewState="False"
                                ExpandDelay="50" ImagesBaseUrl="~/Images/comArt/baseMenu/" Orientation="Vertical"
                                TopGroupItemSpacing="1px" Width="100%" ScrollDownLookId="DefaultItemLook" ScrollUpLookId="DefaultItemLook">
                                <items>
                                <ComponentArt:MenuItem ID="MenuItem5" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" 
                                    NavigateUrl="~/App/Lean/UserMgt.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="View Users">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem ID="MenuItem6" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" 
                                    NavigateUrl="~/App/Lean/AddUser.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Add New User">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem ID="MenuItem7" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" 
                                    NavigateUrl="~/App/Lean/AddUser.aspx" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Add C4C User">
                                </ComponentArt:MenuItem>
                            </items>
                                <itemlooks>
                                <ComponentArt:ItemLook CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingBottom="4px"
                                    LabelPaddingLeft="15px" LabelPaddingRight="15px" LabelPaddingTop="4px" LookId="TopItemLook"
                                    LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuItem" ExpandedCssClass="MenuItemHover" HoverCssClass="MenuItemHover"
                                    LabelPaddingBottom="4px" LabelPaddingLeft="18px" LabelPaddingRight="12px" LabelPaddingTop="3px"
                                    LookId="DefaultItemLook" LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuBreak" ImageHeight="2px" ImageUrl="break.gif"
                                    ImageWidth="100%" LookId="BreakItem" LeftIconVisibility="Always" RightIconVisibility="Always" />
                            </itemlooks>
                            </ComponentArt:Menu>
                        </fieldset>
                    </asp:Panel>
                    <br />

                    <fieldset>
                        <legend style="font-weight: 700">Links to additional information</legend>
                        <ComponentArt:Menu ID="Menu2" runat="server" CssClass="TopGroup" DefaultGroupCssClass="MenuGroup"
                            DefaultGroupItemSpacing="2px" DefaultItemLookId="DefaultItemLook" EnableViewState="False"
                            ExpandDelay="50" ImagesBaseUrl="~/Images/comArt/baseMenu/" Orientation="Vertical"
                            TopGroupItemSpacing="1px" Width="100%" ScrollDownLookId="DefaultItemLook" ScrollUpLookId="DefaultItemLook">
                            <items>
                                <ComponentArt:MenuItem ID="MenuItem2" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="https://eu001-sp.shell.com/sites/aaaaa7807/UIGRLIT/SitePages/SISHome.aspx" Target="_blank" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="UIOG CI/Lean website – additional information">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem ID="MenuItem3" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="https://eu001-sp.shell.com/sites/AAAAA7807/UIOGCINews/default.aspx" Target="_blank" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="CI Newsletters">
                                </ComponentArt:MenuItem>
                                <ComponentArt:MenuItem ID="MenuItem4" runat="server" DefaultSubGroupCssClass="MenuGroup" DefaultSubGroupItemSpacing="2px" NavigateUrl="https://eu001-sp.shell.com/sites/AAAAA7807/BI_UIG/SitePages/SISHome.aspx" Target="_blank" SubGroupCssClass="MenuGroup" SubGroupItemSpacing="2px" Text="Bright Ideas – Register an improvement idea">
                                </ComponentArt:MenuItem>
                            </items>
                            <itemlooks>
                                <ComponentArt:ItemLook CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingBottom="4px"
                                    LabelPaddingLeft="15px" LabelPaddingRight="15px" LabelPaddingTop="4px" LookId="TopItemLook"
                                    LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuItem" ExpandedCssClass="MenuItemHover" HoverCssClass="MenuItemHover"
                                    LabelPaddingBottom="4px" LabelPaddingLeft="18px" LabelPaddingRight="12px" LabelPaddingTop="3px"
                                    LookId="DefaultItemLook" LeftIconVisibility="Always" RightIconVisibility="Always" />
                                <ComponentArt:ItemLook CssClass="MenuBreak" ImageHeight="2px" ImageUrl="break.gif"
                                    ImageWidth="100%" LookId="BreakItem" LeftIconVisibility="Always" RightIconVisibility="Always" />
                            </itemlooks>
                        </ComponentArt:Menu>
                    </fieldset>
                    <br /><br />
                    <%--<bi500:supportContact runat="server" ID="supportContact" />--%>
                    <bi500:supportContactExt runat="server" ID="supportContactExt" />
                </td>
                <td>
                    <table style="width: 98%">
                        <tr>
                            <td>
                                <iframe id="fileLoader" name="fileLoader" src="../../Images/CIWoW.pdf" style="width: 99%; height: 600px" runat="server" scrolling="auto"></iframe>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

