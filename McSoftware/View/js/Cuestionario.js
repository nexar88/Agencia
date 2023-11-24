//const { Callbacks } = require("jquery");

$("#btnBuscarPNP").on("click", function (event) {

});


function MENSAJE_PERSONALIZADO(MENSAJE) {
    Swal.fire({
        icon: 'error',
        //title: 'REGISTRO DOCUMENTO',
        text: MENSAJE,
        confirmButtonText: 'Aceptar'
    });
}


$("#btnAnteriorPregunta").on("click", function (event) {

    //event.preventDefault();
    var seleccionadoANT = "0";
    if (parseInt(document.getElementById("txt_id_Orden").value) != "1") {
        var EVENTO = "ANT";
        //$("#ulCheckbox_Requisitos ul").each(function () {

        var idCuestionario = document.getElementById("txt_id_Cuestionario").value;;
        //var idRespuesta_Contestada = document.getElementById("txt_id_Respuesta").value;

        $('#' + idCuestionario).find('ol div div input').each(function () {
            if (this.checked) {
                //alert(this.value);
                var Cls_Respuesta_BE = {};
                Cls_Respuesta_BE.sIdCuestionario = idCuestionario;
                Cls_Respuesta_BE.sIdRespuesta = this.value;
                Cls_Respuesta_BE.sIdCurso = "1";

                var Opt = "1";
                var data = JSON.stringify({ ObjRespuesta: Cls_Respuesta_BE });
                $.ajax({
                    type: "POST",
                    url: "Cuestionario.aspx/Guardar_Respuesta",
                    data: data,
                    async: true,
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    error: function (xhr, ajaxOptions, thrownError) {
                        if (xhr.status === 401) {
                            location.reload();
                        }
                        console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                    },
                    success: function (data) {
                        if (data.d == "OK") {
                            MostrarPregunta(document.getElementById("txt_id_Orden").value, document.getElementById("txt_total_Preg").value, document.getElementById("txt_id_Curso").value, EVENTO, document.getElementById("txt_id_Pregunta").value);
                        }
                        event.preventDefault();

                    }
                });
                seleccionadoANT = "1";
            }
        });
        if (seleccionadoANT == "0") {
            MostrarPregunta(document.getElementById("txt_id_Orden").value, document.getElementById("txt_total_Preg").value, document.getElementById("txt_id_Curso").value, EVENTO, document.getElementById("txt_id_Pregunta").value);
        }
        //if (document.getElementById("txt_id_Orden").value == "2") {
        //    $("#btnAnteriorPregunta").attr("disabled", true);
        //}

        //if (id == 0) {
        //    MENSAJE_PERSONALIZADO("SELECCIONE UNA ALTERNATIVA");
        //}
        //});
    }

});

$("#btnSiguientePregunta").on("click", function (event) {

    //setTimeout(function () { $(".xxxx").attr("disabled", true); $(".xxxx").css("pointer-events", "none"); }, 1);

    //event.preventDefault();
    var seleccionadoPOS = "0";
    if (parseInt(document.getElementById("txt_id_Orden").value) < parseInt(document.getElementById("txt_total_Preg").value) && parseInt(document.getElementById("txt_id_Orden").value) > 0) {
        var EVENTO = "POS";

        //$("#ulCheckbox_Requisitos ul").each(function () {


        var idCuestionario = document.getElementById("txt_id_Cuestionario").value;;
        //var idRespuesta_Contestada = document.getElementById("txt_id_Respuesta").value;

        $('#' + idCuestionario).find('ol div div input').each(function () {
           // if (this.checked && idRespuesta_Contestada != this.value) {
            if (this.checked ) {
                //alert(this.value);
                var Cls_Respuesta_BE = {};
                Cls_Respuesta_BE.sIdCuestionario = idCuestionario;
                Cls_Respuesta_BE.sIdRespuesta = this.value;
                Cls_Respuesta_BE.sIdCurso = "1";

                var Opt = "1";
                var data = JSON.stringify({ ObjRespuesta: Cls_Respuesta_BE });
                $.ajax({
                    type: "POST",
                    url: "Cuestionario.aspx/Guardar_Respuesta",
                    data: data,
                    async: true,
                    contentType: 'application/json; charset=utf-8',
                    error: function (xhr, ajaxOptions, thrownError) {
                        if (xhr.status === 401) {
                            location.reload();
                        }
                        console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                    },
                    success: function (data) {
                        if (data.d == "OK") {
                            MostrarPregunta(document.getElementById("txt_id_Orden").value, document.getElementById("txt_total_Preg").value, document.getElementById("txt_id_Curso").value, EVENTO, document.getElementById("txt_id_Pregunta").value);
                        }
                        event.preventDefault();

                    }
                });
                seleccionadoPOS = "1";
            }
        });
        if (seleccionadoPOS == "0") {
            MostrarPregunta(document.getElementById("txt_id_Orden").value, document.getElementById("txt_total_Preg").value, document.getElementById("txt_id_Curso").value, EVENTO, document.getElementById("txt_id_Pregunta").value);
        }
        //if (id == 0) {
        //    MENSAJE_PERSONALIZADO("SELECCIONE UNA ALTERNATIVA");

        //});


    }
});

$("#btnCurso1").on("click", function (event) {

    //ListarFamiliar(document.getElementById("txt_CarnetTitular").value);

    //ocultamos el div
    $('#Principal').removeClass("visible").addClass("hidden");
    $('#primera_pagina').removeClass("hidden").addClass("visible");

    event.preventDefault();
});


//async function callEndpoints_delete() {
//    await delete_LLenarRespuestas();
//}

function delete_LLenarRespuestas() {

    //eliminar los checkbox existentes
    document.getElementById('ulCheckbox_Requisitos').innerHTML = '';
    document.getElementById('li_div').innerHTML = '';
    //var lis = document.querySelectorAll('#ulCheckbox_Requisitos ul');
    //for (var i = 0; li = lis[i]; i++) {
    //    li.parentNode.removeChild(li);
    //}

    //var lis = document.querySelectorAll('#li_div label');
    //for (var i = 0; li = lis[i]; i++) {
    //    li.parentNode.removeChild(li);
    //}
    return true;
}

//async function MostrarPregunta(ORDEN, TOTAL_ORDEN, CURSO, EVENTO) {
//    await MostrarPregunta_Final(ORDEN, TOTAL_ORDEN, CURSO, EVENTO);
//}

function MostrarPregunta(ORDEN, TOTAL_ORDEN, CURSO, EVENTO, NIDPREGUNTA) {

    //registra observaciones
    $('#primera_pagina').removeClass("visible").addClass("hidden");
    $('#Detalle_Examen').removeClass("hidden").addClass("visible");


    if (delete_LLenarRespuestas()) {

        $.ajax({
            type: "POST",
            url: "../../Default.aspx/ValidarSession",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                if (xhr.status === 401) {
                    location.reload();
                }
                alert(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                if (data.d == "SESSION") {

                    var Cls_Pregunta_BE = {};
                    Cls_Pregunta_BE.sIdCurso = CURSO;
                    Cls_Pregunta_BE.nIdPregunta = NIDPREGUNTA;
                    Cls_Pregunta_BE.nOrden = ORDEN;
                    Cls_Pregunta_BE.sEvento = EVENTO;
                    Cls_Pregunta_BE.sIdCuestionarioDetalle = document.getElementById("txt_id_Cuestionario_Detalle").value;

                    var data_Pregunta = JSON.stringify({ ObjPregunta: Cls_Pregunta_BE });

                    $.ajax({
                        type: "POST",
                        url: "Cuestionario.aspx/GENERAR_PREGUNTA",
                        data: data_Pregunta,
                        //async: true,
                        contentType: "application/json; charset=utf-8",
                        //dataType: "json",
                        cache: true,
                        //processData: false,  // tell jQuery not to process the data
                        //contentType: false,	 // tell jQuery not to set contentType
                        dataType: "json",
                        headers: {
                            'Access-Control-Allow-Credentials': true,
                            'Access-Control-Allow-Origin': '*',
                            'Access-Control-Allow-Methods': 'POST',
                            'Access-Control-Allow-Headers': 'application/json',
                        },
                        success: function (data) {
                            var datos = data.d;
                            if (datos.length > 0) {

                                //var xListaCheckbox = document.getElementById("MainContent_divDiscapacitado");
                                var ul = document.getElementById('ulCheckbox_Requisitos'); //ul

                                $("#txt_id_Orden").empty();
                                txt_id_Orden.value = datos[0].nOrden;

                                $("#txt_id_Curso").empty();
                                txt_id_Curso.value = CURSO;

                                $("#txt_total_Preg").empty();
                                txt_total_Preg.value = datos[0].sTotalPreg;

                                $("#txt_id_Pregunta").empty();
                                txt_id_Pregunta.value = datos[0].nIdPregunta;

                                $("#txt_id_Respuesta").empty();
                                txt_id_Respuesta.value = datos[0].nidRespuesta;

                                $("#txt_id_Cuestionario").empty();
                                txt_id_Cuestionario.value = datos[0].nidCuestionario;



                                $("#txt_id_Cuestionario_Detalle").empty();
                                txt_id_Cuestionario_Detalle.value = datos[0].sIdCuestionarioDetalle;


                                document.getElementById("MainBody_lblNroPreguntas").innerHTML = String(datos[0].nOrden) + " de " + String(datos[0].sTotalPreg);


                                var li_div_curso = document.createElement('label');//li
                                li_div_curso.setAttribute("style", "color:blue;font-size: 1.875em;");
                                li_div_curso.appendChild(document.createTextNode("MATERIA: " + datos[0].sNombreMateria));
                                li_div.appendChild(li_div_curso);


                                recorreArray(datos);

                                

                                
                                //var xListaCheckbox = document.getElementById("MainContent_divDiscapacitado");
                                event.preventDefault();

                            } else {

                            }


                            if ((parseInt(ORDEN) + 1) == TOTAL_ORDEN && EVENTO == "POS") {
                                $('#btnSiguientePregunta').removeClass("visible").addClass("hidden");
                                $('#btnFinishPregunta').removeClass("hidden").addClass("visible");
                            }
                            if ((parseInt(ORDEN)) == TOTAL_ORDEN && EVENTO == "ANT") {
                                $('#btnSiguientePregunta').removeClass("hidden").addClass("visible");
                                $('#btnFinishPregunta').removeClass("visible").addClass("hidden");
                            }

                        },
                        error: function (result) {
                            alert('ERROR : ' + result.status + ' ' + result.statusText);
                            //location.reload();
                        },
                        complete: function (xhr, status) {
                            console.log('Petición realizada');
                            //setTimeout(function () { $(".xxx").attr("disabled", false); $(".xxx").css("pointer-events", "auto"); }, 1);
                            //setTimeout(function () { $(".xxxx").attr("disabled", false); $(".xxxx").css("pointer-events", "auto"); }, 1);

                            //$(".xxx").attr("disabled", false); $(".xxx").css("pointer-events", "auto");
                            //$(".xxxx").attr("disabled", false); $(".xxxx").css("pointer-events", "auto");
                        }

                    });
                }
            },
            complete: function (xhr, status) {
            }
        });


        event.preventDefault();

    }
}
$("#btnFinishPregunta").on("click", function (event) {
    //$("#myModal2").modal({
    //    "backdrop": "static",
    //    "keyboard": true,
    //    "show": true
    //});
    //$('#myModal2').on('hidden.bs.modal', function () {
    //    //str_foco = '#' + $('#txt_Descripcion').val();
    //    //$(str_foco).focus();
    //});



    $('#myModal2').modal();
    event.preventDefault();

});

$("#btnGuardarConfirmacion").on("click", function (event) {

    event.preventDefault();

    var Cls_Respuesta_BE = {};
    Cls_Respuesta_BE.sIdCuestionario = "";//document.getElementById("txt_id_Cuestionario_Detalle").value
    Cls_Respuesta_BE.sIdRespuesta = this.value;
    Cls_Respuesta_BE.sIdCurso = "1";

    //var Opt = "1";
    //var data = JSON.stringify({ ObjRespuesta: Cls_Respuesta_BE });
    //$.ajax({
    //    type: "POST",
    //    url: "Producto.aspx/Guardar_Respuesta",
    //    data: data,
    //    contentType: 'application/json; charset=utf-8',
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        if (xhr.status === 401) {
    //            location.reload();
    //        }
    //        console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
    //    },
    //    success: function (data) {
    //        if (data.d == "OK") {
    //            MostrarPregunta(document.getElementById("txt_id_Orden").value, document.getElementById("txt_total_Preg").value, document.getElementById("txt_id_Curso").value, EVENTO);
    //        }
    //        event.preventDefault();

    //    }
    //});


    var nEmi_Categoria_Cod = "10";// document.getElementById("Categoria_Personal").value;
    var X_OPS = "REG_FAM";

    window.location = ("Resultado.aspx?Emi_Categoria_Cod=" + nEmi_Categoria_Cod + "&OPS=" + X_OPS);
    event.preventDefault();
});




function Cargado_Cuestionario_Curso() {

    var Opt = "5";
    var data = JSON.stringify({ "sIdCurso": this.id });
    $.ajax({
        type: "POST",
        url: "Cuestionario.aspx/Procesar_ahora",
        data: data,
        async: true,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            if (xhr.status === 401) {
                location.reload();
            }
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == "OPEN") {

                Swal.fire({
                    title: '',
                    text: "¿Cuestionario pendiente por resolver. Desea continuar con el cuestionario?",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // OBTENER EL CODIGO CURSO
                        MostrarPregunta("0", "0", "1", "");
                    } else {

                    }
                })
            }

        }
    });
    event.preventDefault();

}









//async function callEndpoints(CURSO, nIdPregunta, nidCuestionario, sDescripcion) {
//    await LLenarRespuestas(CURSO, nIdPregunta, nidCuestionario, sDescripcion);
//}


const recorreArray = datos => {


    var li_div_Aux = document.createElement('ul');//li
    li_div_Aux.setAttribute("style", "font-family: Homer Simpson UI; font-weight:bold;");
    li_div_Aux.id = datos[0].nidCuestionario;
    li_div_Aux.appendChild(document.createTextNode(datos[0].sDescripcion));

    

    var ol = document.createElement('ol');//li
    ol.type = "A";

    
    

    li_div.appendChild(ol);

    let i_aux = 0;
    while (i_aux <= datos.length - 1) {


        var checkbox = document.createElement('input');
        checkbox.type = "radio";
        checkbox.name = datos[i_aux].nidRespuesta;
        checkbox.value = datos[i_aux].nidRespuesta;
        checkbox.checked = (datos[i_aux].sRptaMarcada == "1") ? true : false;
        checkbox.id = datos[i_aux].nidRespuesta;
        checkbox.setAttribute("style", "");

        var divCheckbox = document.createElement('div');//li
        divCheckbox.setAttribute("style", "width:5%;");
        divCheckbox.setAttribute("class", "col-xs-1 col-sm-1");
        divCheckbox.appendChild(checkbox);


        var li = document.createElement('li');//li
        li.setAttribute("style", "font-family: Homer Simpson UI; font-weight:normal;");
        li.appendChild(document.createTextNode(datos[i_aux].sTituloOpcion));

        var divli_surf = document.createElement('div');//li
        divli_surf.setAttribute("class", "col-xs-11 col-sm-11");
        divli_surf.appendChild(li);


        var div1 = document.createElement('div');//li
        div1.setAttribute("class", "row align-items-start");

        div1.appendChild(divCheckbox);
        div1.appendChild(divli_surf);

        ol.appendChild(div1);

        li_div_Aux.appendChild(ol);

        var ul = document.getElementById('ulCheckbox_Requisitos'); //ul
        ul.appendChild(li_div_Aux);

        i_aux++;
    }

    




}