
function MENSAJE_PERSONALIZADO(MENSAJE) {
    Swal.fire({
        icon: 'error',
        //title: 'REGISTRO DOCUMENTO',
        text: MENSAJE,
        confirmButtonText: 'Aceptar'
    });
}





function Cargado_Cuestionario_Curso() {

    var Opt = "5";
    var data = JSON.stringify({ "sIdCurso": this.id });
    $.ajax({
        type: "POST",
        url: "Producto.aspx/Procesar_ahora",
        data: data,
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

                        //var data = JSON.stringify({ "sIdCurso": this.id });
                        //$.ajax({
                        //    type: "POST",
                        //    url: "Producto.aspx/Procesar_ahora",
                        //    data: data,
                        //    contentType: 'application/json; charset=utf-8',
                        //    error: function (xhr, ajaxOptions, thrownError) {
                        //        if (xhr.status === 401) {
                        //            location.reload();
                        //        }
                        //        console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                        //    },
                        //    success: function (data) {
                        //        if (data.d == "OPEN") {
                        window.location.replace("/View/Cuestionario.aspx");
                        //}
                        //}
                        //});
                        event.preventDefault();
                        //window.location = ("Cuestionario.aspx?Emi_Categoria_Cod=" + nEmi_Categoria_Cod + "&OPS=" + X_OPS);
                        //event.preventDefault();

                        // OBTENER EL CODIGO CURSO
                        /*MostrarPregunta("0", "0", "1", "");*/




                    } else {

                    }
                })
            } else {
                window.location.replace("/View/Cuestionario.aspx");
                event.preventDefault();
            }

        }
    });
    event.preventDefault();

}