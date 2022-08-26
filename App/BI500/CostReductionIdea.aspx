<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CostReduction.master" AutoEventWireup="true" CodeFile="CostReductionIdea.aspx.cs" Inherits="App_BI500_CostReductionIdea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <script type="text/javascript" src="../../JavaScript/fieldVisit.js"></script>

    <div class="row">
        <div class="col-md-8">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/App/BI500/Resources/Plan and Weekly Commitment.pptx">Download Cadence Review Tool</asp:HyperLink>
<br/>

            <table class="table table-bordered table-hover table-condensed" style="width: 750px; "><%--margin-left:10em--%>
                <thead class="thead-inverse">
                    <tr>
                        <th colspan="4" bgcolor="gold">Cost Reduction Idea Registration Form</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="width: 150px">&nbsp;</td>
                        <td colspan="3">Fill completely this form to submit your Cost Reduction Ideas.<br />
                            Hover your mouse on the blue question mark icons to your left side<br />
                            to see example of what you are expected to do. </td>
                    </tr>

                    <tr>
                        <td>Expected Benefit:
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpBenefit" ErrorMessage="Impacted Area is Required" Operator="NotEqual" Type="Integer" ValidationGroup="xy" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpBenefit" runat="server" Width="200px">
                                <asp:ListItem Value="-1">Select Impacted Area</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Impacted Team:
                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlTeam" ErrorMessage="Please select Your Team" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="xy">*</asp:CompareValidator>
                            <asp:Image ID="img3" runat="server" ImageUrl="~/Images/globalheader_help.gif" ToolTip="This is the team to implement the idea" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTeam" runat="server" Width="200px">
                                <asp:ListItem Value="-1">Select Team</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>Project Title:
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectTitle" ErrorMessage="Enter Project Improvement Title" ValidationGroup="xy">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="vertical-align: middle" colspan="3">
                            <asp:TextBox ID="txtProjectTitle" runat="server" Height="100px" TextMode="MultiLine" Width="590px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Description of cost reduction idea:
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBizCase" ErrorMessage="Business Case is required" ValidationGroup="xy">*</asp:RequiredFieldValidator>
                            <asp:Image ID="img1" runat="server" ToolTip="What is the idea and why do we need to work it. e.g. department should stop printing retractable banners which cost about N45K each and explore
electronic/other cost effective means of information dissemination.
"
                                ImageUrl="~/Images/globalheader_help.gif" />
                        </td>
                        <td style="vertical-align: middle" colspan="3">
                            <asp:TextBox ID="txtBizCase" runat="server" Height="100px" TextMode="MultiLine" Width="590px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Business Value:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOpportunityStmt" ErrorMessage="Opportunity Statement is required" ValidationGroup="xy">*</asp:RequiredFieldValidator>
                            <asp:Image ID="img2" runat="server" ImageUrl="~/Images/globalheader_help.gif" ToolTip="What is in it for the company. e.g. cost saving for the organization will run into millions of Naira bearing in mind the number of such banners in our facilities" />
                            
                        </td>
                        <td style="vertical-align: middle" colspan="3">
                            <asp:TextBox ID="txtOpportunityStmt" runat="server" Height="100px" TextMode="MultiLine" Width="590px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Target Saving:($)<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTargetSavings" ErrorMessage="Invalid entry!!! Decimal number only is allowed" ValidationExpression="[-]?\d{1,18}(?:[,.]\d{1,2})?$" ValidationGroup="xy">*</asp:RegularExpressionValidator>
                        </td>
                        <td style="vertical-align: middle">
                            <asp:TextBox ID="txtTargetSavings" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 180px; vertical-align: middle">
                            Actual Saving:($)<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActualSavings" ErrorMessage="Invalid entry!!! Decimal number only is allowed" ValidationExpression="[-]?\d{1,18}(?:[,.]\d{1,2})?$" ValidationGroup="xy">*</asp:RegularExpressionValidator>
                        </td>
                        <td style="vertical-align: middle">
                            <asp:TextBox ID="txtActualSavings" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <%--<tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align: middle" colspan="3">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align: middle" colspan="3">
                            &nbsp;</td>
                    </tr>--%>

                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Button ID="btnDraft" runat="server" OnClick="btnDraft_Click" Text="Save as Draft" ValidationGroup="xy" />
                            &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure you want to send for approval?')" Text="Submit" Width="100px" ValidationGroup="xy" />
                        </td>
                    </tr>
                </tbody>

            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="xy" />
            <asp:HiddenField ID="HFRequestId" runat="server" />
        </div>
        <div class="col-md-4">
            <asp:Image ID="Image1" ImageUrl="~/Images/CostReductionMajor.png" runat="server" />
        </div>
    </div>
</asp:Content>

