$(document).ready(function () {
    Listar();
});

function Guardar() {
    try {
        var idCliente = $('#txtIdCliente').val();
        var nombre = $('#txtNombre').val();
        var direccion = $('#txtDireccion').val();
        var telefono = $('#txtTelefono').val();
        if (nombre == '') {
            return alert('Por favor llene el Nombre');
        }       
        $.ajax({
            type: 'Post',
            url: '/ClientesFront/Guardar',
            data: {
                idCliente: idCliente,
                nombre: nombre,
                direccion: direccion,
                telefono: telefono,
                estado: true
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.Result.IdCliente > 0) {
                        Listar();
                        LimpiarText();
                        alert(response.Mensaje + ': ' + response.resp.Result.IdCliente);
                    } else {
                        alert(response.Mensaje);
                    }
                } else if (response != null && !response.ProcesoExitoso) {
                    alert(response.Mensaje);
                }
            },
            error: function (response) {
            },
            failure: function (response) {
            }
        });
    } catch (e) {
    }
}

function Editar(e) {
    try {
        var obj = e.row.data;
        if (obj == null) {
            return alert('Error: al editar el registros');
        }
        $('#txtIdCliente').val(obj.idCliente);
        $('#txtNombre').val(obj.nombre);
         $('#txtDireccion').val(obj.direccion);
         $('#txtTelefono').val(obj.telefono);
    } catch (e) {
    }
}

function Eliminar(e) {
    try {
        var obj = e.row.data;
        if (obj == null) {
            return alert('Error: al editar el registros');
        }
        var idCliente = obj.idCliente;
        var estado = false;
        if (idCliente == 0) {
            return alert('Error al tratar de eliminar el registro');
        }

        $.ajax({
            type: 'Post',
            url: '/ClientesFront/Eliminar',
            data: {
                idCliente: idCliente,
                estado: estado
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.Result.IdCliente > 0) {
                        Listar();
                        alert(response.Mensaje + ': ' + response.resp.Result.IdCliente);
                    } else {
                        alert(response.Mensaje);
                    }
                } else if (response != null && !response.ProcesoExitoso) {
                    alert(response.Mensaje);
                }
            },
            error: function (response) {
            },
            failure: function (response) {
            }
        });
    } catch (e) {
    }
}

function Listar() {
    try {
        $.ajax({
            type: 'Get',
            url: '/ClientesFront/Listar',
            data: {
                OffSet: 1,
                Limit: 10
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.length > 0) {
                        $('#gridClientes').dxDataGrid({ dataSource: response.resp });
                    } else {
                        alert(response.Mensaje);
                    }
                } else if (response != null && !response.ProcesoExitoso) {
                    alert(response.Mensaje);
                }
            },
            error: function (response) {
            },
            failure: function (response) {
            }
        });
    } catch (e) {
    }
}

function LimpiarText() {
    $('#txtIdCliente').val(0);
    $('#txtNombre').val('');
    $('#txtDireccion').val('');
    $('#txtTelefono').val('');
}