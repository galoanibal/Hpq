$(document).ready(function () {
    Listar();
});

function Guardar() {
    try {
        var idCuenta = $('#txtIdCuenta').val();
        var numeroCuenta = $('#txtNumeroCuenta').val();
        var saldo = $('#txtSaldo').val();
        if (numeroCuenta == '') {
            return alert('Por favor llene el Numéro de Cuenta');
        }
       
        $.ajax({
            type: 'Post',
            url: '/Cuentas/Guardar',
            data: {
                idCuenta: idCuenta,
                numeroCuenta: numeroCuenta,
                saldo: saldo,
                estado: true
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.Result.IdCuenta > 0) {
                        Listar();
                        LimpiarText();
                        alert(response.Mensaje + ': ' + response.resp.Result.IdCuenta);
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
        $('#txtIdCuenta').val(obj.idCuenta);
        $('#txtNumeroCuenta').val(obj.numeroCuenta);
        $('#txtSaldo').val(obj.saldo);
    } catch (e) {
    }
}

function Eliminar(e) {
    try {
        var obj = e.row.data;
        if (obj==null) {
            return alert('Error: al editar el registros');
        }
        var idCuenta = obj.idCuenta;
        var estado = false;
        if (idCuenta == 0) {
            return alert('Error al tratar de eliminar el registro');
        }

        $.ajax({
            type: 'Post',
            url: '/Cuentas/Eliminar',
            data: {
                idCuenta: idCuenta,               
                estado: estado
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.Result.IdCuenta > 0) {
                        Listar();
                        alert(response.Mensaje + ': ' + response.resp.Result.IdCuenta);
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
            url: '/Cuentas/Listar',
            data: {
                OffSet: 1,
                Limit: 10
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.length > 0) {
                        $('#gridCuentas').dxDataGrid({ dataSource: response.resp});                       
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
    $('#txtIdCuenta').val(0);
    $('#txtNumeroCuenta').val('');
    $('#txtSaldo').val('');
}