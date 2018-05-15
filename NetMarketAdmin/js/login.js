$("#btnIniciarSesion").on('click', function () {
    var datos3 = {
        correo_persona: $("#txbUsuario").val(),
        contraseña_persona: $("#txbPassword").val()
    };
    var _datosCategoria;
    $.ajax({
        url: "/Persona/Login",
        cache: false,
        data: JSON.stringify(datos3),
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json'
    }).done(function (respuestaMVC) {
        console.log(respuestaMVC.Mensaje);
        if (respuestaMVC.Codigo == 0) {
            _datosCategoria = respuestaMVC.Data;
            console.log(_datosCategoria);
        } else {
        }
    });
});

