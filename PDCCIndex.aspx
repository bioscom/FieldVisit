<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="PDCCIndex.aspx.cs" Inherits="PDCCIndex" %>

<%@ Register Src="~/App/PDCC/UserControl/Chartting.ascx" TagName="Chartting" TagPrefix="uc2" %>
<%@ Register Src="~/App/PDCC/UserControl/CharttingData.ascx" TagName="CharttingData" TagPrefix="uc3" %>

<%@ Register Src="~/App/PDCC/UserControl/PartsOpportunities.ascx" TagPrefix="app" TagName="PartsOpportunities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width:98%">
        <div style="margin-left: 10em; margin-right: auto;">
            <app:PartsOpportunities runat="server" ID="PartsOpportunities" />
        </div>
    </div>


    <!-- Main content -->
    <%--    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <h3>FEC T/O</h3>
                        <p>Front End Cost Take/Out</p>
                        <asp:Label ID="lblFecto" Font-Bold="True" Font-Size="Large" runat="server"></asp:Label>
                    </div>
                    <div class="icon">
                        <i class="ion-chevron-right"></i>
                    </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h3>Impr. Oppor.</h3>
                        <p>Improvement Opportunity</p>
                        <asp:Label ID="lblImpOpp" Font-Bold="True" Font-Size="Large" runat="server"></asp:Label>
                    </div>
                    <div class="icon">
                        <i class="ion ion-stats-bars"></i>
                    </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3>Cost Avoidance</h3>
                        <p>Cost Avoidance</p>
                    </div>
                    <div class="icon">
                        
                        <i class="ion-happy"></i>
                    </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-red">
                    <div class="inner">
                        <h3>PD Savings</h3>
                        <p>PD Performance</p>
                        <asp:Label ID="lblPDSavings" Font-Bold="True" Font-Size="Large" runat="server"></asp:Label>
                    </div>
                    <div class="icon">
                        <i class="ion ion-pie-graph"></i>
                    </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
        </div>
        <!-- /.row -->

        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <a href="PdccOnshore.aspx" style="color:white"><h3>Onshore</h3></a>  
                        <asp:Label ID="Label6" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
                        <p>&nbsp;</p>
                    </div>
                    <div class="icon">
                        <i class="ion-chevron-right"></i>
                    </div>
                    <a href="PdccOnshore.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <a href="PdccOffshore.aspx"><h3>Offshore</h3></a>
                        <asp:Label ID="Label7" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                        <p>&nbsp;</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-stats-bars"></i>
                    </div>
                    <a href="PdccOffshore.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        
                        <a href="Dashboard2.aspx"><h3>PD</h3></a>
                        <p>&nbsp;</p>
                    </div>
                    <div class="icon">
                        
                        <i class="ion-happy"></i>
                    </div>
                    <a href="Dashboard2.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->

        </div>
        <!-- /.row -->


        <!-- Main row -->
        <div class="row">
            <!-- Left col -->
            <section class="col-lg-7 connectedSortable">
                <br />

            </section>
            <!-- /.Left col -->
            <!-- right col (We are only adding the ID to make the widgets sortable)-->
            <section class="col-lg-5 connectedSortable">

                <!-- Map box -->
                <div class="box box-solid bg-light-blue-gradient">
                </div>
                <!-- /.box -->

                <!-- solid sales graph -->
                <div class="box box-solid bg-teal-gradient">
                </div>
                <!-- /.box -->

                <!-- Calendar -->
                <div class="box box-solid bg-green-gradient">
                </div>
                <!-- /.box -->

            </section>
            <!-- right col -->
        </div>
        <!-- /.row (main row) -->

    </section>--%>
    <!-- /.content -->
</asp:Content>




