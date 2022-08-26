<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tester.aspx.cs" Inherits="Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 

     <script>
         $(document).ready(function () {
             var k = $("#Wizard1 tr:first-child td:last-child table tr:first-child");
             var n = k.clone();
             k.remove();
             $("#Wizard1 tr:first-child td:last-child table").append(n);
         });

    </script>

    <style>
        body {
            background-color: white;
        }

        .leftColumn {
            width: 125px;
            background-image: url(Images/LeftColorRow.png);
            background-repeat: repeat-y;
        }

        .rightColumn {
            background-color: white;
            background-image: url(Images/RightColorRow.png);
            background-repeat: repeat-y;
        }

        .black {
            background-color: black;
        }

        .tableHeader {
            width: 100%;
            height: 50px;
            background-image: url(Images/HeaderColorRow.png);
            background-repeat: repeat-y;
            text-align: center;
            font-family: Verdana;
            color: white;
        }

        .titleLogo {
            width: 106px;
            height: 42px;
            background-image: url(Images/Mylogo.png);
        }

        .wizardTemplate {
            display: block;
            width: 500px;
        }

        .floatRight {
            float: right;
        }

        .floatLeft {
            float: left;
        }

        .title {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="wizardTemplate">
            <div class="tableHeader">
                <div class="floatLeft"><span class="title">My Mail Wizard</span></div>
                <div class="titleLogo floatRight">
                </div>

            </div>
            <asp:Wizard ID="Wizard1" runat="server" Width="500" Height="300"
                BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
                <NavigationButtonStyle CssClass="rightColumn" />
                <SideBarButtonStyle Font-Names="Verdana"
                    ForeColor="#EFEFEF" />
                <SideBarStyle CssClass="leftColumn" Font-Size="0.9em" VerticalAlign="Top" />
                <StartNavigationTemplate>
                    <div id="navigationTemplate" style="width: 100%; height: 100%;" class="rightColumn">
                        <asp:Button ID="StartNextButton" runat="server" BackColor="White"
                            BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                            CommandName="MoveNext" Font-Names="Verdana" Font-Size="0.8em"
                            ForeColor="#284E98" Text="Next" />

                    </div>
                </StartNavigationTemplate>
                <StepNavigationTemplate>
                    <asp:Button ID="Button1" runat="server" BackColor="White"
                        BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        CommandName="MoveNext" Font-Names="Verdana" Font-Size="0.8em"
                        ForeColor="#284E98" Text="Next" />

                    </div>
                </StepNavigationTemplate>
                <StartNextButtonStyle CssClass="rightColumn"></StartNextButtonStyle>
                <StepStyle CssClass="rightColumn"></StepStyle>
                <StepStyle CssClass="rightColumn" Font-Size="0.8em" ForeColor="#333333" />
                <WizardSteps>
                    <asp:WizardStep ID="Start" runat="server" Title="Start">
                        <div class="innerTableHeader"></div>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                        <div class="innerTableHeader"></div>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Step 3">
                        <div class="innerTableHeader"></div>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Step 4">
                        <div class="innerTableHeader"></div>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Finish">
                        <div class="innerTableHeader"></div>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </div>
    </form>

   
</body>
</html>
