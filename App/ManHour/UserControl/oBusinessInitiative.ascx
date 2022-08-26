<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oBusinessInitiative.ascx.cs" Inherits="UserControl_oBusinessInitiative" %>

<%--<script type="text/javascript">
    function uploadStarted() {
        $get("imgDisplay").style.display = "none";
    }
    function uploadComplete(sender, args) {
        var imgDisplay = $get("imgDisplay");
        var filename = $get("filenameHF");
        imgDisplay.src = "";
        imgDisplay.style.cssText = "";
        var img = new Image();
        img.onload = function () {
            imgDisplay.style.cssText = "height:125px; width:250px; border:1px solid black; margin-top:2px";
            imgDisplay.src = img.src;
        };
        img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
        filename.value = args.get_fileName();
    }
</script>--%>

<%--<asp:ScriptManagerProxy ID="smtAjaxManagerBI" runat="Server"> </asp:ScriptManagerProxy>--%>

<table style="width: 100%; margin-bottom: 0.5em">
    <tr>
        <td style="width: 150px">
            <asp:Label runat="server" Text="Organisation Unit:" ID="Label1"></asp:Label>

            <asp:CompareValidator runat="server" Operator="NotEqual" ValueToCompare="-1" Type="Integer" ControlToValidate="drpOUs" ErrorMessage="Please Select District" ValidationGroup="BI" ID="CompareValidator4">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList runat="server" Width="300px" ID="drpOUs">
                <asp:ListItem Value="-1">Select Organisation Unit...</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" Text="Function:" ID="Label2"></asp:Label>

            <asp:CompareValidator runat="server" Operator="NotEqual" ValueToCompare="-1" Type="Integer" ControlToValidate="drpFunction" ErrorMessage="Please select your Function" ValidationGroup="BI" ID="CompareValidator1">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList runat="server" Width="300px" ID="drpFunction">
                <asp:ListItem Value="-1">Select Function...</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" Text="Title:" ID="Label3"></asp:Label>

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" ErrorMessage="Please enter title/description" ValidationGroup="BI" ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox runat="server" Width="500px" ID="txtTitle"></asp:TextBox>
        </td>
    </tr>
</table>


<ajaxToolkit:TabContainer runat="server" ID="BIPnlTabs" ActiveTabIndex="0" Width="100%">
    <ajaxToolkit:TabPanel runat="server" ID="PnlBusinessCase" HeaderText="Business Case" Width="100%">
        <HeaderTemplate>
            Business Case
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtBusinessCase" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlScope" HeaderText="Scope" Width="100%">
        <HeaderTemplate>
            Scope
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtScope" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlSuccess" HeaderText="Critical Success Factors" Width="100%">
        <HeaderTemplate>
            Critical Success Factors
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtSuccessFactors" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlObjectives" HeaderText="Objectives" Width="100%">
        <HeaderTemplate>
            Objectives
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtObjectives" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlDeliverables" HeaderText="Deliverables" Width="100%">
        <HeaderTemplate>
            Deliverables
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtDeliverables" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlActivities" HeaderText="Key Activities" Width="100%">
        <HeaderTemplate>
            Key Activities
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtKeyActivities" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlMembers" HeaderText="Team Members" Width="100%">
        <HeaderTemplate>
            Team Members
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtTeamMember" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlBenefit" HeaderText="Benefit" Width="100%">
        <HeaderTemplate>
            Benefit
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtBenefit" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="PnlMeasures" HeaderText="Measures" Width="100%">
        <HeaderTemplate>
            Measures
        </HeaderTemplate>
        <ContentTemplate>
            <asp:TextBox ID="txtMeasures" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <%--<ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Scope" Width="100%">
        <HeaderTemplate>
            Upload Image
        </HeaderTemplate>
        <ContentTemplate>
            <ajaxToolkit:AsyncFileUpload OnClientUploadComplete="uploadComplete" runat="server" ID="AsyncFileUpload1"
                Width="250px" UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
                ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted="uploadStarted" FailedValidation="False" />
            <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" />
            <img id="imgDisplay" alt="" src="" style="display: none" />
            <asp:Image ID="imgLoaderAlt" runat="server" Style="display: none" />
            <asp:HiddenField ID="filenameHF" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>--%>
</ajaxToolkit:TabContainer>


<div style="float: right; margin-top: 0.5em">
    <asp:Button runat="server" Text="Submit" ValidationGroup="BI" Width="100px" ID="btnSubmit" OnClick="btnSubmit_Click"></asp:Button>

    <asp:Button runat="server" Text="Submit" ValidationGroup="BI" Width="100px" ID="btnUpdate" OnClick="btnUpdate_Click"></asp:Button>

    <asp:ValidationSummary runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="BI" ID="ValidationSummary1"></asp:ValidationSummary>

</div>
<asp:HiddenField ID="lInitiativeMainPgHF" runat="server" />


