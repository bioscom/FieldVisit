<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CompetenceAssessment.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_FLBM_Default" %>

<%@ Register src="~/App/FLBM/UserControl/MainHeaderControl.ascx" TagPrefix="app" TagName="MainHeaderControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <app:MainHeaderControl runat="server" ID="MainHeaderControl" />
    
    <table style="width: 70%; margin-left: auto; margin-right: auto; margin-top: 0.7em" class="tMainBorder">
        <tr>
            <td style="font-size: 10pt; color: RED">
                <b>DO NOT </b>distribute or contribute to the distribution of this assessment document. The ongoing integrity of this competence
                assessment relies on the information, <b>specifically the REQUIRED EVIDENCE</b>, contained in this document being kept
                <b>CONFIDENTIAL</b>. Ensure all copies of this document, electronic or printed, in your possession, are stored securely prior to, during,
                and after the assessment
            </td>
        </tr>
    </table>
    <table style="width: 70%; margin-left: auto; margin-right: auto; margin-top: 0.7em" class="tMainBorder">
        <tr>
            <td style="font-size: 10pt">
                <b>Preparation by the Assessor:</b><br />
                <b>Assessment Planning</b><br />
                - Ensure that the assessment room or location in the field is well equipped and all materials are in place that are necessary for<br />
                conducting the Monitor and Control Hydrocarbon Process Activities Assessment.<br />
                - Review the assessee’s previous qualifications and assessments (if available).<br />
                - Plan the most effective and efficient evidence collection methods.<br />
                - Plan the location and condition of the assessment sessions.<br />
                <br />
                <b>Assessee Notification and Assessment Scheduling</b><br />
                - Notify the assessee that the assessment(s) is due<br />
                - Provide the assessee with the relevant competence statement and performance criteria (for example, the competence<br />
                checklist)<br />
                - Contract with the assessee about dates, locations and methods for the assessment sessions<br />
                - Request the assessee to prepare ahead of time and to notify the assessor of any issues (for example, any procedures or<br />
                trainings that cannot be easily located)<br />
            </td>
        </tr>
    </table>

    <table style="width: 70%; margin-left: auto; margin-right: auto; margin-top: 0.7em" class="tMainBorder">
        <tr>
            <td style="font-size: 10pt">Link to Production Academy Sharepoint : <a href="https://eu001-sp.shell.com/sites/AAAAA8320/academy/default.aspx">Click here</a><br />
                Link to restricted/ confidential Production Academy assessor competence assurance area: <a href="https://eu001-sp.shell.com/sites/AAAAA8320/academy/default.aspx">Click here</a> (Go to Competence Assurance – Assessors)<br />
                Link to Production Academy Competence Descriptors: <a href="https://eu001-sp.shell.com/sites/aaaaa8320/academy/Web/Assess.aspx">Click here</a> (Go to Support Materials section)<br />
                Link to Production Academy Assessor Quick Reference Guides : <a href="https://eu001-sp.shell.com/sites/aaaaa8320/academy/Web/Assess.aspx">Click here</a> (Go to Support Materials section)<br />
            </td>
        </tr>
    </table>
    <div style="width: 70%; margin-left: auto; margin-right: auto; horiz-align: center">
        <asp:Button ID="btnKnowledge" runat="server" Text="Knowledge and Skill Assessment" Font-Bold="True" ForeColor="Red" Font-Size="Large" Height="40px" Width="350px" OnClick="btnKnowledge_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="btnAdminSetup" runat="server" Text="Administrative Setup" Font-Bold="True" ForeColor="OrangeRed" Font-Size="Large" Height="40px" Width="320px" OnClick="btnAdminSetup_Click" />
    </div>
    <br />
    <br />
</asp:Content>

