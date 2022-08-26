<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FusionChartsT.aspx.cs" Inherits="FusionChartsT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="JavaScript" src="FusionCharts/FusionCharts.js"></script>
    <script type="text/javascript" language="JavaScript">

        function myJS(myVar) {
            window.alert(myVar);
        }

    </script>




    <style type="text/css">
        .circleBase {
            border-radius: 50%;
            behavior: url(PIE.htc); /* remove if you don't care about IE8 */
        }

        .type1 {
            width: 150px;
            height: 150px;
            background: red;
            /*border: 3px solid green;*/
            /*background-color: #e7676d;*/
            background-image: -webkit-gradient(linear, left top, left bottom, from(#e7676d), to(#b7070a)); /* Saf4+, Chrome */
            background-image: -webkit-linear-gradient(top, #e7676d, #b7070a); /* Chrome 10+, Saf5.1+, iOS 5+ */
            background-image: -moz-linear-gradient(top, #e7676d, #b7070a); /* FF3.6 */
            background-image: -ms-linear-gradient(top, #e7676d, #b7070a); /* IE10 */
            background-image: -o-linear-gradient(top, #e7676d, #b7070a); /* Opera 11.10+ */
            background-image: linear-gradient(top, #e7676d, #b7070a);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#e7676d', EndColorStr='#b7070a');
            -webkit-box-shadow: 0px 2px 4px #000000; /* Saf3-4 */
            -moz-box-shadow: 0px 2px 4px #000000; /* FF3.5 - 3.6 */
            box-shadow: 0px 2px 4px #000000; /* Opera 10.5, IE9, FF4+, Chrome 10+ */
            display: inline-block;
            /*padding: 2px 2px 2px 2px;
            margin: 3px;*/
            font-family: arial;
            /*font-weight: bold;
            border: 30px solid blue;*/
        }

        .type1b {
            width: 150px;
            height: 150px;
            background: green;
            margin-top: 4em;
            /*border: 3px solid green;*/
        }

        .type2 {
            width: 50px;
            height: 50px;
            background: #ccc;
            border: 3px solid #000;
            /*background-color: #e7676d;*/
            background-image: -webkit-gradient(linear, left top, left bottom, from(#e7676d), to(#b7070a)); /* Saf4+, Chrome */
            background-image: -webkit-linear-gradient(top, #e7676d, #b7070a); /* Chrome 10+, Saf5.1+, iOS 5+ */
            background-image: -moz-linear-gradient(top, #e7676d, #b7070a); /* FF3.6 */
            background-image: -ms-linear-gradient(top, #e7676d, #b7070a); /* IE10 */
            background-image: -o-linear-gradient(top, #e7676d, #b7070a); /* Opera 11.10+ */
            background-image: linear-gradient(top, #e7676d, #b7070a);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#e7676d', EndColorStr='#b7070a');
            -webkit-box-shadow: 0px 2px 4px #000000; /* Saf3-4 */
            -moz-box-shadow: 0px 2px 4px #000000; /* FF3.5 - 3.6 */
            box-shadow: 0px 2px 4px #000000; /* Opera 10.5, IE9, FF4+, Chrome 10+ */
            display: inline-block;
            /*padding: 2px 2px 2px 2px;
            margin: 3px;*/
            font-family: arial;
            /*font-weight: bold;
            border: 30px solid blue;*/
        }

        .type3 {
            width: 320px;
            height: 320px;
            background: navy;
            /*background-color: #e7676d;*/
            background-image: -webkit-gradient(linear, left top, left bottom, from(#e7676d), to(#b7070a)); /* Saf4+, Chrome */
            background-image: -webkit-linear-gradient(top, #e7676d, #b7070a); /* Chrome 10+, Saf5.1+, iOS 5+ */
            background-image: -moz-linear-gradient(top, #e7676d, #b7070a); /* FF3.6 */
            background-image: -ms-linear-gradient(top, #e7676d, #b7070a); /* IE10 */
            background-image: -o-linear-gradient(top, #e7676d, #b7070a); /* Opera 11.10+ */
            background-image: linear-gradient(top, #e7676d, #b7070a);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#e7676d', EndColorStr='#b7070a');
            -webkit-box-shadow: 0px 2px 4px #000000; /* Saf3-4 */
            -moz-box-shadow: 0px 2px 4px #000000; /* FF3.5 - 3.6 */
            box-shadow: 0px 2px 4px #000000; /* Opera 10.5, IE9, FF4+, Chrome 10+ */
            display: inline-block;
            /*padding: 2px 2px 2px 2px;
            margin: 3px;*/
            font-family: arial;
            /*font-weight: bold;
            border: 30px solid blue;*/
        }

        .iphonebadge {
            border-radius: 99px;
            -moz-border-radius: 99px;
            -webkit-border-radius: 99px;
            background: red;
            color: #fff;
            border: 3px #fff solid;
            background-color: #e7676d;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#e7676d), to(#b7070a)); /* Saf4+, Chrome */
            background-image: -webkit-linear-gradient(top, #e7676d, #b7070a); /* Chrome 10+, Saf5.1+, iOS 5+ */
            background-image: -moz-linear-gradient(top, #e7676d, #b7070a); /* FF3.6 */
            background-image: -ms-linear-gradient(top, #e7676d, #b7070a); /* IE10 */
            background-image: -o-linear-gradient(top, #e7676d, #b7070a); /* Opera 11.10+ */
            background-image: linear-gradient(top, #e7676d, #b7070a);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#e7676d', EndColorStr='#b7070a');
            -webkit-box-shadow: 0px 2px 4px #000000; /* Saf3-4 */
            -moz-box-shadow: 0px 2px 4px #000000; /* FF3.5 - 3.6 */
            box-shadow: 0px 2px 4px #000000; /* Opera 10.5, IE9, FF4+, Chrome 10+ */
            display: inline-block;
            padding: 2px 2px 2px 2px;
            margin: 3px;
            font-family: arial;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form id="form2" runat="server">
        <div>
            <table width="800px" border="0" cellspacing="0" cellpadding="3" align="center">
                <tr>
                    <td valign="top" class="text" align="center">
                        <asp:Literal ID="FCLiteral1" runat="server"></asp:Literal>
                    </td>
                    <td valign="top" class="text" align="center">
                        <asp:Literal ID="FCLiteral2" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td valign="top" class="text" align="center">
                        <asp:Literal ID="FCLiteral3" runat="server"></asp:Literal>
                    </td>
                    <td valign="top" class="text" align="center">
                        <asp:Literal ID="FCLiteral4" runat="server"></asp:Literal>
                    </td>

                </tr>
            </table>
        </div>
    </form>


    <div style="border-radius: 80px; background-color: pink; height: 500px; width: 60%; margin-left: auto; margin-right: auto">

        <table style="width:80%; margin-left:5em">
            <tr>
                <td>
                    <table style="margin-top:3em">
                        <tr>
                            <td>
                                <div class="circleBase type1">
                                    <div style="margin-top: 35%; color: white; font-size: 22px; text-align: center">Cost Optimisation</div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <div class="circleBase type1">
                                    <div style="margin-top: 35%; color: white; font-size: 22px; text-align: center">Reliability Improvement</div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <div class="circleBase type3" style="float: right; margin-top: 2.0em">
                        <div style="margin-top: 20%; color: white; font-size: 38pt; text-align: center">Improving Field Performance</div>
                    </div>
                </td>
            </tr>
        </table>



        <%--<div style="margin-left: auto; margin-right: auto; height: 400px; margin-top: 2.5em; width: 70%">
            <div style="float: left">
                <div class="circleBase type1">
                    <div style="margin-top:35%; color:white; font-size:22px; text-align:center">Cost Optimisation</div>
                </div>
                
                <div class="circleBase type1b">
                    <div style="margin-top:35%; color:white; font-size:22px; text-align:center">Reliability Improvement</div>
                </div>
            </div>
            <div class="circleBase type3" style="float: right; margin-top:2.0em">
                <div style="margin-top:25%; color:white; font-size:35pt; text-align:center">Improving field performance</div>
            </div>
        </div>--%>
    </div>
</body>
</html>
