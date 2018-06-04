var datos3 = {};
var _datosEmpresa;
$.ajax({
    url: "http://localhost/ApiNet/api/empresa/verempresas",
    cache: false,
    data: JSON.stringify(datos3),
    type: "POST",
    contentType: 'application/json; charset=utf-8',
    dataType: 'json'
}).done(function (respuestaMVC) {
    console.log(respuestaMVC.Mensaje);
    if (respuestaMVC.Codigo == 0) {
        _datosEmpresa = respuestaMVC.Data;
        console.log(_datosEmpresa);
        mostrarDatosEmpresas();
    } else {
        console.log(respuestaMVC.Mensaje);
    }
});
function mostrarDatosEmpresas() {
    var contador = 0;
    $.each(_datosEmpresa, function (index, elemento) {
        contador = contador + 1;

        var columna = $("#colm" + contador).prepend("<div class='block1 hov-img-zoom pos-relative m-b-30'>" +
            "<img src='http://localhost/NetMarket/images/" + elemento.rutaimagen + "' alt='IMG-BENNER'>" +
            "<div class='block1-wrapbtn w-size2'>" +
            "<a data-idEmpresa='" + elemento.idEmpresa + "' class='flex-c-m size2 m-text2 bg3 hov1 trans-0-4 linkcate' data-toggle='modal' data-target='#ModalSucursales'>" + elemento.nombrempresa + "</a>" +
            "</div>" +
            "</div>");
        if (contador == 3) {
            contador = 0;
        }
    });
}
$(document).ready(function () {
    
    $(".linkcate").click(function () {
        var idem = $(this).attr("data-idEmpresa");
        var datos3 = { idEmpresa: idem };
        var _datosSucursal;
        var _datosEmpresa;
        $.ajax({
            url: "http://localhost/ApiNet/api/empresa/verempresa",
            cache: false,
            data: JSON.stringify(datos3),
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).done(function (respuestaMVC) {
            console.log(respuestaMVC.Mensaje);
            if (respuestaMVC.Codigo == 0) {
                _datosEmpresa = respuestaMVC.Data;
                console.log(_datosEmpresa);
                mostrarDatosEmpresa();
            } else {
                console.log(respuestaMVC.Mensaje);
            }
        });
        $.ajax({
            url: "http://localhost/ApiNet/api/sucursal/versucursales",
            cache: false,
            data: JSON.stringify(datos3),
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).done(function (respuestaMVC) {
            console.log(respuestaMVC.Mensaje);
            if (respuestaMVC.Codigo == 0) {
                _datosSucursal = respuestaMVC.Data;
                console.log(_datosSucursal);
                mostrarDatosSucursalesEmpresa();
            } else {
                console.log(respuestaMVC.Mensaje);
            }
        });
        function mostrarDatosEmpresa() {
            $("#Empresaname").text(_datosEmpresa.nombrempresa);
            $("#Empresarazon").text(_datosEmpresa.razon);
            $("#Empresadir").text(_datosEmpresa.direccion);
            $("#Empresanit").text(_datosEmpresa.nit);
        }
        function mostrarDatosSucursalesEmpresa() {
            Limpiarmodal();
            var contador = 0;
            $.each(_datosSucursal, function (index, elemento) {
                contador = contador + 1;

                var columna = $("#colms" + contador).prepend("<div class='block1 hov-img-zoom pos-relative m-b-30'>" +
                    "<img src='http://localhost/NetMarket/images/" + elemento.rutaimagen + "' alt='IMG-BENNER'>" +
                    "<div class='block1-wrapbtn w-size2'>" +
                    "<a href='http://localhost/NetMarket/Producto/ProductoSucursal?ide=" + elemento.idSucursal + "' class='flex-c-m size2 m-text2 bg3 hov1 trans-0-4 linkcate'>" + elemento.nombre + "</a>" +
                    "</div>" +
                    "</div>");
                if (contador == 2) {
                    contador = 0;
                }
            });
        }
        function Limpiarmodal() {
            var col = $("div [id*='colms']");
            col[0].innerHTML = "";
            col[1].innerHTML = "";
        }
    });
    
});