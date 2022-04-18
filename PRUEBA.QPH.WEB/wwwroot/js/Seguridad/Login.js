function Login() {
    try {
        var nombreUsuario = $('#txtNombreUsuario').val();
        var contrasena = $('#txtContrasena').val();
        if (nombreUsuario=='' && contrasena=='') {
            return alert('Llene todos los datos');
        }
        $.ajax({
            type: 'GET',
            url: 'Login/ValidarUsuario',
            data: {
                nombreUsuario: nombreUsuario,
                contrasena: contrasena
                },
            success: function (response) {
                if (response != null && response.ProcesoExitoso) {
                    if (response.respFormularios.Result.length > 0) {
                        window.location.replace("../Home/");                        
                    } else {
                        alert('No tiene asignado ningun Rol/Formulario');
                    }
                   
                } else if (response != null && !response.ProcesoExitoso) {
                    alert(response.resp.Mensaje);
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