<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="UserControls/LoggedOnStat.ascx" TagName="LoggedOnStat" TagPrefix="uc2" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Theme Made By www.w3schools.com - No Copyright -->
    <title>Business Improvement and Production Excellence</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery.min.js"></script>
    <script src="../bootstrap/js/bootstrap.js"></script>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            font: Garamond;
            /*font: 400 15px Lato, sans-serif;*/
            line-height: 1.8;
            color: #818181;
        }

        h2 {
            font-size: 24px;
            text-transform: uppercase;
            color: #303030;
            font-weight: 600;
            margin-bottom: 30px;
        }

        h4 {
            font-size: 19px;
            line-height: 1.375em;
            color: #303030;
            font-weight: 400;
            margin-bottom: 30px;
        }

        .jumbotron {
            background-color: #D42E12;
            color: #fff;
            padding: 50px 25px;
        }

        .container-fluid {
            padding: 60px 50px;
        }

        .bg-grey {
            background-color: #f6f6f6;
        }

        .logo-small {
            color: #f4511e;
            font-size: 50px;
        }

        .logo {
            color: #f4511e;
            font-size: 200px;
        }

        .thumbnail {
            padding: 0 0 15px 0;
            border: none;
            border-radius: 0;
        }

            .thumbnail img {
                width: 100%;
                height: 100%;
                margin-bottom: 10px;
            }

        .carousel-control.right, .carousel-control.left {
            background-image: none;
            color: #f4511e;
        }

        .carousel-indicators li {
            border-color: #f4511e;
        }

            .carousel-indicators li.active {
                background-color: #f4511e;
            }

        .item h4 {
            font-size: 19px;
            line-height: 1.375em;
            font-weight: 400;
            font-style: italic;
            margin: 70px 0;
        }

        .item span {
            font-style: normal;
        }

        .panel {
            border: 1px solid #f4511e;
            border-radius: 0 !important;
            transition: box-shadow 0.5s;
        }

            .panel:hover {
                box-shadow: 5px 0px 40px rgba(0,0,0, .2);
            }

        .panel-footer .btn:hover {
            border: 1px solid #f4511e;
            background-color: #fff !important;
            color: #f4511e;
        }

        .panel-heading {
            color: #fff !important;
            background-color: #f4511e !important;
            padding: 25px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 0px;
            border-top-right-radius: 0px;
            border-bottom-left-radius: 0px;
            border-bottom-right-radius: 0px;
        }

        .panel-footer {
            background-color: white !important;
        }

            .panel-footer h3 {
                font-size: 32px;
            }

            .panel-footer h4 {
                color: #aaa;
                font-size: 14px;
            }

            .panel-footer .btn {
                margin: 15px 0;
                background-color: #f4511e;
                color: #fff;
            }

        .navbar {
            margin-bottom: 0;
            background-color: gold;
            z-index: 9999;
            border: 0;
            font-size: 12px !important;
            line-height: 1.42857143 !important;
            /*letter-spacing: 4px;*/
            border-radius: 0;
            /*border-bottom: 1px silver solid;
            font-family: Montserrat, sans-serif;*/
        }

            .navbar li a, .navbar .navbar-brand {
                color: #000 !important;
                float: left;
                margin-top: 0;
            }

        .navbar-nav li a:hover, .navbar-nav li.active a {
            color: #fff !important;
            background-color: silver !important;
        }

        .navbar-default .navbar-toggle {
            border-color: transparent;
            color: #fff !important;
        }

        footer .glyphicon {
            font-size: 20px;
            margin-bottom: 20px;
            color: #f4511e;
        }

        .slideanim {
            visibility: hidden;
        }

        .slide {
            animation-name: slide;
            -webkit-animation-name: slide;
            animation-duration: 1s;
            -webkit-animation-duration: 1s;
            visibility: visible;
        }

        @keyframes slide {
            0% {
                opacity: 0;
                transform: translateY(70%);
            }

            100% {
                opacity: 1;
                transform: translateY(0%);
            }
        }

        @-webkit-keyframes slide {
            0% {
                opacity: 0;
                -webkit-transform: translateY(70%);
            }

            100% {
                opacity: 1;
                -webkit-transform: translateY(0%);
            }
        }

        @media screen and (max-width: 768px) {
            .col-sm-4 {
                text-align: center;
                margin: 25px 0;
            }

            .btn-lg {
                width: 100%;
                margin-bottom: 35px;
            }
        }

        @media screen and (max-width: 480px) {
            .logo {
                font-size: 150px;
            }
        }
    </style>
</head>
<body id="myPage" data-spy="scroll" data-target=".navbar" data-offset="60">

    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>

            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="http://sww.scin.cpdms.shell.com/PEC">Home</a></li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Tools<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="AppGatePass.aspx?sAppToken=BI">Bright Ideas</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=pr">Service/Material Cost Red Flag</a></li>
                            <li><a href="Dashboard2.aspx">Cost Saving Performance Dashboard</a></li>
                            <li><a href="VerificationHeatMapReport.aspx">RPI Verification Heat Map</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=ftnDay">14 Days Contract</a></li>
                            <li><a href="App/PPMS/Default.aspx">Project Registration System</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=pdcc">Production Cost Challenge</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=pec">Field Visit / PEC</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=IMF">Initiative Management</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=flr">Flare Waiver</a></li>
                            <li><a href="AppGatePass.aspx?sAppToken=Lean">CI Projects Dashboard</a></li>
                            <li><a href="http://sww.scin.cpdms.shell.com/iap/Default.aspx">IAP Change Control Form</a></li>
                            <li><a href="App/FLBM/Default.aspx">Front Line Barrier Management</a></li>
                        </ul>
                    </li>
                    <li><a href="App/FLBM/Default.aspx">Front Line Barrier Management</a></li>
                    <li><a href="AppGatePass.aspx?sAppToken=pr">Cost Red Flag</a></li>
                    <li><a href="AppGatePass.aspx?sAppToken=flr">Weekly Highlights</a></li>
                    <li><a href="https://nga001-sp.shell.com/sites/AFFAA0125/default.aspx">Our Sharepoint Site</a></li>
                    <li><a href="http://sww.scin.shell.com/ep/epg/sepcin/production/OperationalExcellenceIntegrity.html"><b style="color: red">Operations Integrity/ESP</b></a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="jumbotron">
        <a class="navbar-brand" href="#myPage">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/p_ShellLogo64.gif" Style="float: left" />
        </a>
        <div style="margin-left: 3em; font-size: 20pt; font: bold">
            Business Improvement and Production Excellence
        </div>
        <div style="float: right; margin-right: 3.5em; top: 0.2em">
            <asp:Label ID="mssgLbl" runat="server" Text=""></asp:Label>
        </div>

        <div style="float: left; margin-left: 8.5em; margin-top: 0.8em">
            <uc2:LoggedOnStat ID="LoggedOnStat1" runat="server" />
        </div>
    </div>

    <!-- Container (Services Section) -->
    <div id="services" class="container-fluid text-center">
        <div class="row">

            <div class="col-sm-3">
                <a href="Default.aspx?BI=3" class="image">
                    <img src="images/i_OnLamp.png" alt="" />
                    <h4>Bright Idea</h4>
                    <p>submit a bright idea</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="taskPage.aspx" class="image">
                    <img src="images/Savings1.png" alt="" />
                    <h4>Cost Saving Agenda</h4>
                    <p>view cost saving Agenda</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="Default.aspx?pr=9" class="image">
                    <img src="images/redflag.jpg" alt="" />
                    <h4>Service/Material</h4>
                    <p>service/material cost red flag</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="Default.aspx?CR=3" class="image">
                    <img src="images/iCostreduction3.png" alt="" />
                    <h4>Cost Reduction Portal</h4>
                    <p>Submit Improvement Ideas</p>
                </a>
            </div>
        </div>
        <br>
        <br>
        <div class="row">

            <div class="col-sm-3">
                <a href="AppGatePass.aspx?sAppToken=pec" class="image">
                    <img src="images/oilandGasField.jpg" alt="" />
                    <h4>Field Visit
                        <br />
                        Plan Execution Criteria</h4>
                    <p>Raise PEC Form</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="AppGatePass.aspx?sAppToken=flr" class="image">
                    <img src="Images/i_GasFlaring.jpg" alt="" />
                    <h4>Flare Waiver</h4>
                    <p>Apply for Gas Flare Waiver</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="AppGatePass.aspx?sAppToken=flr" class="image">
                    <img src="Images/i_WeeklyHighLights1.jpg" alt="" />
                    <h4>Weekly Highlights</h4>
                    <p>&nbsp;</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="App/CommitmentControl/Default.aspx" class="image">
                    <img src="Images/i_CommitmentControl.jpg" alt="" />
                    <h4>Commitment Control</h4>
                    <p>SCiN Budget Control</p>
                </a>
            </div>
        </div>

        <br>
        <br>
        <div class="row">
            <div class="col-sm-3">
                <a href="App/IDD/Default.aspx" class="image">
                    <img src="Images/IntegrityDueDiligence.jpg" alt="" />
                    <h4>Integrity Due Diligence</h4>
                    <p>Electronic Integrity Due Diligence</p>
                </a>
            </div>
        
            <div class="col-sm-3">
                <a href="http://sww.scin.cpdms.shell.com/iap" class="image">
                    <img src="Images/iChangeControl2.jpg" alt="" />
                    <h4>Integrated Activity Planning</h4>
                    <p>Change Request Electronic Tool (IAP CRET)</p>
                </a>
            </div>

            <div class="col-sm-3">
                <a href="http://161.158.8.7:8080/" class="image">
                    <img src="Images/BONGAMR.jpeg" alt="" />
                    <h4>Bonga Morning Report</h4>
                    <p>Bonga Morning Report (BMR)</p>
                </a>
            </div>

        </div>

    </div>


    <footer class="container-fluid text-center">
        <a href="#myPage" title="To Top">
            <span class="glyphicon glyphicon-chevron-up"></span>
        </a>
        <div class="row">
            <div class="12u">
                <div id="copyright">
                    <ul style="list-style-type: none;" class="menu">
                        <li>&copy; Production Directorate. All rights reserved</li>
                        <li>Design: <a href="">Business Improvement and Production Excellence</a></li>
                        <li>Support Contact +234 807 022 4772</li>
                        <li><a href="UserManagement.aspx">Portal Manager</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>

    <%--<script>
        $(document).ready(function () {
            // Add smooth scrolling to all links in navbar + footer link
            $(".navbar a, footer a[href='#myPage']").on('click', function (event) {
                // Make sure this.hash has a value before overriding default behavior
                if (this.hash !== "") {
                    // Prevent default anchor click behavior
                    event.preventDefault();

                    // Store hash
                    var hash = this.hash;

                    // Using jQuery's animate() method to add smooth page scroll
                    // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
                    $('html, body').animate({
                        scrollTop: $(hash).offset().top
                    }, 900, function () {

                        // Add hash (#) to URL when done scrolling (default click behavior)
                        window.location.hash = hash;
                    });
                } // End if
            });

            $(window).scroll(function () {
                $(".slideanim").each(function () {
                    var pos = $(this).offset().top;

                    var winTop = $(window).scrollTop();
                    if (pos < winTop + 600) {
                        $(this).addClass("slide");
                    }
                });
            });
        })
    </script>--%>
    
</body>
</html>