
function alertErrorLogin() {
    Swal.fire({
        type: 'error',
        title: 'Usuario inválido. ',
        text: 'El usuario o la contraseña son incorrectas'
    })
}



function alertDatosInvalidos() {
    Swal.fire({
        type: 'error',
        title: 'Datos inválido. ',
        text: 'Los datos que desea ingresar no son válidos.'
    })
}


function alertDatosValidos() {
    Swal.fire({
        position: 'top-end',
        type: 'success',
        title: 'Datos ingresados correctamente.',
        showConfirmButton: false,
        timer: 3500
    })
}



function alertAdvertenciaEliminar() {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: '¿Seguro?',
        text: "¿Desea eliminar los datos permanentemente?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si',
        cancelButtonText: 'No',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            swalWithBootstrapButtons.fire(
                'Eliminados',
                'Los datos se eliminaron correctamente',
                'success'
            )
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelado',
                'Ocurrió un error en la eliminación de los datos',
                'error'
            )
        }
    })
}



function alertAdvertenciaEliminarTiempos(button) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: '¿Seguro?',
        text: "¿Desea eliminar los datos permanentemente?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si',
        cancelButtonText: 'No',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            //acá debo llamar al método para borrar los datos

            parametros = { "horario": button.id };
            $.ajax(
                {
                    data: parametros,
                    url: '/Catalogo_Tiempos_Laborales/Eliminar',
                    type: 'post',
                    beforeSend: function () {
                        var div = document.createElement('div');
                        div.setAttribute('class', 'd-flex align-items-center justify-content-center');

                        var divSpin = document.createElement('div');
                        divSpin.setAttribute('class', 'spinner-grow text-primary');
                        divSpin.setAttribute('style', 'width: 2em; height: 2em;');
                        divSpin.setAttribute('role', 'status');

                        var newSpan = document.createElement('strong');
                        //newSpan.setAttribute('class', 'sr-only');
                        newSpan.innerHTML = 'Eliminando los datos. Espere por favor';

                        div.appendChild(divSpin);
                        div.appendChild(newSpan);

                        document.getElementById('respuesta').appendChild(div);
                    }, //antes de enviar

                    success: function (response) {
                        document.getElementById('respuesta').innerHTML = "";
                        if (response == 1) {
                            swalWithBootstrapButtons.fire(
                                'Eliminados',
                                'Los datos se eliminaron correctamente. Recargando la página',
                                'success'
                            )
                            window.location.href = "/"
                        } else {
                            if (response == 0) {
                                swalWithBootstrapButtons.fire(
                                    'Cancelado',
                                    'El registro que desea eliminar no existe',
                                    'error'
                                )
                            } else {
                                swalWithBootstrapButtons.fire(
                                    'Cancelado',
                                    'Ocurrió un error en la eliminación de los datos. Inténtelo dentro de unos minutos',
                                    'error'
                                )
                            }
                        }
                    } //se ha enviado
                }
            );

            //acá debo llamar al método para borrar los datos
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelado',
                'Ocurrió un error en la eliminación de los datos. Inténtelo dentro de unos minutos',
                'error'
            )
        }
    })
}

