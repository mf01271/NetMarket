var ide = getParameterByName('ide');
var datos3 = { idSucursal: ide };
var _datosProductoCategoria;
$.ajax({
    url: "http://localhost/ApiNet/api/productosucursal/verproductosbysucursal",
    cache: false,
    data: JSON.stringify(datos3),
    type: "POST",
    contentType: 'application/json; charset=utf-8',
    dataType: 'json'
}).done(function (respuestaMVC) {
    console.log(respuestaMVC.Mensaje);
    if (respuestaMVC.Codigo == 0) {
        _datosProductoCategoria = respuestaMVC.Data;
        console.log(_datosProductoCategoria);
        mostrarDatosCategorias();
    } else {
        cosole.log(respuestaMVC.Mensaje);
    }
});
function mostrarDatosCategorias() {
    $.each(_datosProductoCategoria, function (index, elemento) {
        var imgprincipal = "thumb-item-01.jpg";
        var imgsecundaria = "thumb-item-01.jpg";
        var imgterciaria = "thumb-item-01.jpg";
        if (elemento.rutaimagen1 != "") {
            imgprincipal = elemento.rutaimagen1;
        } else {
            imgprincipal = "thumb-item-01.jpg";
        }
        if (elemento.rutaimagen2 != "") {
            imgsecundaria = elemento.rutaimagen2;
        } else {
            imgsecundaria = "thumb-item-01.jpg";
        }
        if (elemento.rutaimagen3 != "") {
            imgterciaria = elemento.rutaimagen2;
        } else {
            imgterciaria = "thumb-item-01.jpg";
        }
        var columna = $("#prods").prepend(" <div class='col-sm-12 col-md-6 col-lg-4 p-b-50'>" +
                        "<div class='block2'>" +
                            "<div class='block2-img wrap-pic-w of-hidden pos-relative block2-labelnew'>" +
                                "<img src='http://localhost/NetMarket/images/" + imgprincipal + "' alt='IMG-PRODUCT'>" +
                                "<div class='block2-overlay trans-0-4'>" +
                                    "<a href='" + "#" + "' class='block2-btn-addwishlist hov-pointer trans-0-4'>" +
                                        "<i class='icon-wishlist icon_heart_alt' aria-hidden='true'></i>" +
                                        "<i class='icon-wishlist icon_heart dis-none' aria-hidden='true'></i>" +
                                    "</a>" +
                                    "<div class='block2-btn-addcart w-size1 trans-0-4'>" +
                                        "<button class='flex-c-m size1 bg4 bo-rad-23 hov1 s-text1 trans-0-4 btnaddlist'  data-toggle='modal' data-target='#ModalDetalle' data-idproducto='" + elemento.idProducto + "'>" +
                                            "Añadir a la Lista" +
                                        "</button>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                            "<div class='block2-txt p-t-20'>" +
                                "<a href='product-detail.html' class='block2-name dis-block s-text3 p-b-5'>" +
                                    "" + elemento.nombre + " " + elemento.descripcionCorta +
                                "</a>" +
                                "<span class='block2-price m-text6 p-r-5'>" +
                                    "Bs. " + elemento.precio +
                                "</span>" +
                            "</div>" +
                        "</div>" +
                    "</div>");
    });
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}