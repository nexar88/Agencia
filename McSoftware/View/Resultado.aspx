<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="McSoftware.View.Resultado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHead" runat="server">
    <link href="../assets/dist/css/css.css" rel="stylesheet" />
    <link href="../Content/core.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">

    <div class="wrapper">
        <div class="container">

            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <h4 class="page-title">Resultados</h4>
                </div>
            </div>

            <!-- End row -->
            <div class="row">

                <div class="col-lg-3 col-md-6">
                    <div class="card-box DetalleTotal">
                        <h4 class="header-title m-t-0 m-b-30">Tema : <asp:Label ID="lblNombreTema" runat="server" Text=""></asp:Label></h4>
                        <div class="widget-chart-1">
                            <div class="widget-chart-box-1">
                                <div style="display: inline; width: 80px; height: 80px;">
                                    <canvas width="100" height="100" style="width: 80px; height: 80px;"></canvas>
                                    <input data-plugin="knob" data-width="80" data-height="80" data-fgcolor="#f05050 " data-bgcolor="#F9B9B9" value="25" data-skin="tron" data-angleoffset="180" data-readonly="true" data-thickness=".15" readonly="readonly" style="width: 44px; height: 26px; position: absolute; vertical-align: middle; margin-top: 26px; margin-left: -62px; border: 0px; background: none; font: bold 16px Arial; text-align: center; color: rgb(240, 80, 80); padding: 0px; appearance: none;">
                                </div>
                            </div>
                            <div class="widget-detail-1">
                                <h3 class="p-t-10 m-b-0">Correctas : <asp:Label ID="lblCorrecto" runat="server" Text=""></asp:Label> </h3>
                                <h3 class="p-t-10 m-b-0">Incorrectas : <asp:Label ID="lblIncorrecto" runat="server" Text=""></asp:Label> </h3>
                                <h3 class="p-t-10 m-b-0">Sin Contestar : <asp:Label ID="lblSinCostestar" runat="server" Text=""></asp:Label> </h3>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end col -->

            </div>
            <!-- end row -->

        </div>
        <!-- end container -->

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="server">

    <script src="js/Producto.js"></script>
</asp:Content>
