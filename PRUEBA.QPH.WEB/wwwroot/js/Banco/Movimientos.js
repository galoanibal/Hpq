$(document).ready(function () {
    ConsultarCuenta();
});

function Guardar() {
    try {
        var idMovimiento = $('#txtIdMovimiento').val();
        var idCuenta=$('#selectCuenta').val();
        var fecha=$('#txtFecha').val();
        var tipo=$('#selectTipo').val();
        var valor = $('#txtValor').val();
        valor = valor.replace('.',',');
       
        if (idCuenta == 0) {
            return alert('Por favor seleccione una Cuenta');
        }

        if (tipo == 0) {
            return alert('Por favor seleccione un tipo de movimiento');
        }

        if (fecha == '') {
            return alert('Por favor ingrese la Fecha');
        }
        $.ajax({
            type: 'Post',
            url: '/Movimientos/Guardar',
            data: {
                idMovimiento: idMovimiento,
                idCuenta: idCuenta,
                fecha: fecha,
                tipo: tipo,
                valor: valor
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.Result.IdMovimiento > 0) {
                        Listar();
                        LimpiarText();
                        alert(response.Mensaje + ': ' + response.resp.Result.IdMovimiento);
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
        var fechaDesde = $('#txtFechaDesde').val();
        var fechaHasta = $('#txtFechaHasta').val();
        if (fechaDesde == '' || fechaHasta=='') {
            return alert('Por favor llene las fechas');
        }
        $.ajax({
            type: 'Get',
            url: '/Movimientos/Listar',
            data: {
                fecha: fechaDesde,
                fechaFin: fechaHasta,
                OffSet: 1,
                Limit: 10
            },
            dataType: "json",
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.length > 0) {
                        $('#gridMovimientos').dxDataGrid({ dataSource: response.resp });
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

function ConsultarCuenta() {
    try {
        $.ajax({
            type: 'Get',
            url: '/Cuentas/ConsultarCuenta',
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.resp.length > 0) {
                        var selectCuenta = $('#selectCuenta');
                        var option = new Option('Seleccione...',0 , true, true);
                        selectCuenta.append(option).trigger('change');
                        for (var row of response.resp) {
                            option = new Option(row.numeroCuenta, row.idCuenta);
                            selectCuenta.append(option);
                        }                        
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
    $('#txtIdMovimiento').val(0);
    $('#selectCuenta').val(0);
    $('#txtFecha').val('');
    $('#selectTipo').val(0);
    $('#txtValor').val('');
}