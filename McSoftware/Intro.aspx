<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Intro.aspx.cs" Inherits="McSoftware.Intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHead" runat="server">
    <style>
        .categorias-temas .temas {
            height: 80px;
            vertical-align: middle;
            padding: 18px 0 0 50px;
            font-size: 17px;
        }

        .categorias-temas .desarrollo-sostenible {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-desarrollo-sostenible.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .evidencia-inteligencia {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-evidencia-inteligencia.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .emergencias-salud {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-emergencias-salud.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .familia-promocion-salud {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-familia-promocion-salud.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .enfermedades-no-transmisibles {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-enfermedades-no-transmisibles.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .sistemas-servicios-salud {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-sistemas-servicios-salud.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }

        .categorias-temas .enfermedades-transmisibles {
            background-image: url(https://www.campusvirtualsp.org/sites/default/files/category-ico-enfermedades-transmisibles.png);
            background-repeat: no-repeat;
            background-size: 40px 40px;
            background-position: 0 20px;
        }
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




  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="server">

   
</asp:Content>
