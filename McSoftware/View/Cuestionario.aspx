<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cuestionario.aspx.cs" Inherits="McSoftware.View.Cuestionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHead" runat="server">
    <style>

    </style>
    <link href="../assets/dist/css/css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">

    <!-- Content Header (Page header) -->
    <%-- <section class="content-header">
        <div class="header-icon">
            <i class="pe-7s-box1"></i>
        </div>
        <div class="header-title">
            <form action="#" method="get" class="sidebar-form search-box pull-right hidden-md hidden-lg hidden-sm">
                <div class="input-group">
                    <input type="text" name="q" class="form-control" placeholder="Search...">
                    <span class="input-group-btn">
                        <button type="submit" name="search" id="search-btn" class="btn"><i class="fa fa-search"></i></button>
                    </span>
                </div>
            </form>
            <h1>Appionment</h1>
            <small>Appionment list</small>
            <ol class="breadcrumb hidden-xs">
                <li><a href="index.html"><i class="pe-7s-home"></i>Home</a></li>
                <li class="active">Appionment</li>
            </ol>
        </div>
    </section>--%>
    <!-- Main content -->
    <%--<section class="content">--%>

    <div id="Principal" class=" hidden">
        <div class="col-sm-12">
            <div class="region region-content">
                <div id="block-block-147" class="block block-block categorias-temas">

                    <center>
                        <h2>SIMULACRO DE PREGUNTAS PARA LA EVALUACIÓN DE CONOCIMIENTOS</h2>
                    </center>

                    <div class="content">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="temas desarrollo-sostenible"><a id="btnCurso1" href="https://www.campusvirtualsp.org/es/cursos/desarrollo-sostenible-equidad-en-salud-genero-y-diversidad-cultural">Especialidad: Desarrollo sostenible, equidad en salud, género y diversidad cultural</a></div>
                                <div class="temas emergencias-salud"><a id="btnCurso2" href="https://www.campusvirtualsp.org/es/cursos/emergencias-de-salud">Especialidad: Emergencias de salud</a></div>
                                <div class="temas enfermedades-no-transmisibles"><a id="btnCurso3" href="https://www.campusvirtualsp.org/es/cursos/enfermedades-no-transmisibles-y-salud-mental">Especialidad: Enfermedades no transmisibles y salud mental</a></div>
                            </div>
                            <div class="col-sm-6">
                                <div class="temas evidencia-inteligencia">
                                    <p><a id="btnCurso4" href="https://www.campusvirtualsp.org/es/cursos/evidencia-e-inteligencia-para-la-accion-de-salud">Especialidad: Evidencia e inteligencia para la acción de salud</a></p>
                                </div>
                                <div class="temas familia-promocion-salud">
                                    <p><a id="btnCurso5" href="https://www.campusvirtualsp.org/es/cursos/familia-promocion-de-la-salud-y-curso-de-vida">Especialidad: Familia, promoción de la salud y curso de vida</a></p>
                                </div>
                                <div class="temas sistemas-servicios-salud">
                                    <p><a id="btnCurso6" href="https://www.campusvirtualsp.org/es/cursos/sistemas-y-servicios-de-salud">Especialidad: Sistemas y servicios de salud</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

    <div id="primera_pagina">
        <%--<div class="row m-t-40">--%>
        <div class="col-md-12">
            <h3 class="font-600" align="center">SIMULACRO DE PREGUNTAS PARA LA EVALUACIÓN DE CONOCIMIENTOS </h3>
            <br>
            <h3 style="text-align: justify">Estimados Usuarios:</h3>
            <br>
            <h3 style="text-align: justify">Ante todo felicitarlos por ingresar a nuestro simulador de entrenamiento. El examen contiene 40 preguntas y tiene una duración de 40 minutos, y para su aprobación, el postulante deberá de acertar por lo menos treinta y cinco (35) respuestas de las cuarenta (40) preguntas. Es importante realizar este examen en completo silencio para evitar distracciones.</h3>

            <h3 style="text-align: justify">Selecciona la categoría a la que postula: </h3>
            <br>
        </div>
        <%--  </div>--%>
        <div id="Botones">
        </div>
        <!-- end row -->
        <%--<div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="text-center">
                    <!-- <h3 class="font-600">...</h3> -->
                    <center>

                        <button type="button" id="btnBuscarPNP" class="btn btn-primary"><i class="glyphicon glyphicon-search"></i>&nbsp; Empezar Simulacro oficiales</button>
                        <button type="button" id="btnEmpezarSimulacroPNP" class="btn btn-primary"><i class="glyphicon glyphicon-search"></i>&nbsp; Empezar Simulacro Sub Oficiales</button>

                    </center>
                </div>
            </div>
            <!-- end col -->
        </div>--%>
        <!-- end row -->
    </div>

    <div id="Detalle_Examen" class=" hidden">

        <div class="navbar-custom">
            <div class="container">
                <center>
                    <%--  <div id="clock" style="display:inline-block">
                        <span class="titleContandorSimulacro">Tiempo Restante :</span>
                        <span class="contadorSimulacro">
                            <h3 id="tmContador"></h3>
                        </span>
                    </div>--%>
                </center>
            </div>
        </div>


        <div id="divTimer" class="col-sm-12 col-sx-12">

            <div class="row">
                <div class="contadorSimulacro col-lg-6 col-md-7 col-sm-7 col-sx-7">
                    <span class="titleContandorSimulacro">Tiempo restante:</span>
                </div>
                <div class="contadorSimulacro  col-lg-6 col-md-2 col-sm-2 col-sx-3">
                    <div id="tmContador"></div>
                </div>
            </div>
            <div class="row">
                <div class="font-controls">
                    <div class="font-control" id="font-up">A<sup>+</sup></div>
                    <div class="font-control" id="font-down">A<sup>-</sup></div>
                </div>
            </div>

        </div>

        <div class="col-sm-12 lobipanel-parent-sortable ui-sortable" data-lobipanel-child-inner-id="9DTzobftjd">

            <div class="panel panel-bd lobidrag lobipanel lobipanel-sortable" data-inner-id="9DTzobftjd" data-index="0">

                <div id="panelRequisitos" class="panel panel-default">

                    <div class="panel-body">
                        <div class="col-sm-12" id="li_div">
                            <%--<label class=" text-left text-primary">
                                 </label>--%>
                        </div>
                        <div class="row">

                            <div class="col-sm-12">
                                <input type="hidden" id="txt_id_Curso" name="txt_id_Curso" />
                                <input type="hidden" id="txt_id_Orden" name="txt_id_Orden" />
                                <input type="hidden" id="txt_total_Preg" name="txt_total_Preg" />

                                <input type="hidden" id="txt_id_Pregunta" name="txt_id_Pregunta" />
                                <input type="hidden" id="txt_id_Respuesta" name="txt_id_Respuesta" />

                                
                                <input type="hidden" id="txt_id_Cuestionario" name="txt_id_Cuestionario" />
                                <input type="hidden" id="txt_id_Cuestionario_Detalle" name="txt_id_Cuestionario_Detalle" />
                                <div class="panel panel-default">

                                    <h4 class=" text-right text-primary">
                                        <asp:Label ID="lblNroPreguntas" runat="server" Text=""></asp:Label></h4>
                                    <div class="form-horizontal">
                                        <ul id="ulCheckbox_Requisitos">
                                        </ul>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <%-- <div class="panel-heading ui-sortable-handle">
                        Tema 1: Reglamento de Tránsito y Manual de Dispositivos de Control de Tránsito
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="panel-header">
                                <div class="col-sm-12">
                                    A) Cuando emita señales visibles.
                                </div>
                                <div class="col-sm-12">
                                    B) Cuando emita señales audibles.
                                </div>
                                <div class="col-sm-12">
                                    C) Cuando emita señales audibles y visibles.
                                </div>
                                <div class="col-sm-12">
                                    D) Ninguna de las alternativas es correcta.
                                </div>
                            </div>

                        </div>

                    </div>--%>
                <div class="row" style="align-content: center">
                    <center>
                        <div class="col-md-12" id="contentBarIdLoading">

                            <div class="progress progress-lg">
                                <div class="progress-bar progress-bar-primary progress-bar-striped active" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100" style="width: 10%;"><span class="sr-only">10% Complete</span></div>
                            </div>
                        </div>
                    </center>
                </div>
                <div class="row">
                    <center>
                        <a id="btnAnteriorPregunta" class="btn btn-primary m-b-5 xxx" href="#">&nbsp;<i class="fa fa-arrow-left"></i>Anterior</a>
                        <a id="btnSiguientePregunta" class="btn btn-primary m-b-5 xxxx" href="#">&nbsp;<i class="fa fa-arrow-right"></i>Siguiente</a>
                        <a id="btnFinishPregunta" class="btn btn-danger waves-effect waves-light m-b-5 hidden" href="#">&nbsp;<i class="fa fa-check m-r-5"></i>Finalizar Simulacro</a>
                    </center>
                </div>
            </div>
        </div>

    </div>

    <%--</section>--%>
    <!-- /.content -->


    <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel">¡  Aviso !</h4>
                </div>
                <div class="modal-body">
                    <div class="icon info" style="display: block;"></div>
                    <h2>¿ Está seguro que desea terminar el simulacro ?</h2>
                    <p class="lead text-muted" style="display: block;">Al enviar sus preguntas no podrá cambiar las alternativas seleccionadas.</p>
                </div>
                <div id="loadingSimulacro" style="display: none">
                    <center>
                        <h3>Procesando...</h3>
                        <img src="/Content/assets/images/loading.gif" width="50%" alt="">
                    </center>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button id="btnGuardarConfirmacion" class="btn btn-primary">
                        <i class="fa fa-pencil" aria-hidden="true"></i>Terminar Simulacro
                    </button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="server">

    <script src='<%= ResolveUrl("~/assets/dist/js/letras-size.js") %>'></script>
    
      <script>


          function CBO_CARGADO_PREGUNTAS() {
              //cargado Button

              var data = JSON.stringify({});
              $.ajax({
                  type: "POST",
                  url: "Cuestionario.aspx/OBTNER_ID_XCURSO",
                  data: data,
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {
                      var datos = data.d;
                      // OBTENER EL CODIGO CURSO
                      MostrarPregunta("0", "0", datos, "","0");
                      
                  },
                  error: function (result) {
                      alert('ERROR : ' + result.status + ' ' + result.statusText);
                      //location.reload();
                  }
              });
          }



          $(document).ready(function () {
              // INICIALIZAR BOTONES--------------------------------
              CBO_CARGADO_PREGUNTAS();

          })
      </script>
    <script src="js/Cuestionario.js"></script>
        <script type="text/javascript">
       <%-- var minutos = localStorage.getItem("minutos") == null ? 0 : localStorage.getItem("minutos");
        var segundos = localStorage.getItem("segundos") == null ? 60 : localStorage.getItem("segundos");
        var minutosBase = parseInt('<%= System.Configuration.ConfigurationManager.AppSettings["ContadorTiempo"] %>');
        var contadorMin = parseInt('<%= System.Configuration.ConfigurationManager.AppSettings["ContadorMin"] %>');
        var timer = setInterval(fnTimer, 1000);--%>

        //function pageLoad() {
        //    $("form").attr('autocomplete', 'off'); // Switching form autocomplete attribute to off

        //}


       <%-- function fnTimer() {
            $("#tmContador").text((100 + (minutosBase - minutos)).toString().substring(1, 3) + ":" + (100 + (60 - segundos)).toString().substring(1, 3));
            if (minutos === minutosBase && segundos === 60) {
                clearInterval(timer);
                localStorage.removeItem("segundos")
                localStorage.removeItem("minutos")
                window.location.href = '<%= ResolveUrl("~/") %>';
            }
            if (60 - segundos === 0) {
                minutos++;
                segundos = 0;
                localStorage.setItem("minutos", minutos)
            }
            if (minutosBase - minutos === contadorMin) {
                $("#divTimer").removeClass("alert-info").addClass('alert-danger');
                $("#divTimer").children('span').text('Finalizado el tiempo el sistema se cerrará.');
            }
            segundos++;
            localStorage.setItem("segundos", segundos)
        }--%>

    </script>

</asp:Content>
