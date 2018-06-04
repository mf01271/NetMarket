using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetMarket.Entidades;

namespace NetMarket.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Carrito()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregaralCarrito(EProducto p)
        {
            var resultado = p;
            ECarrito carrito = new ECarrito();
            List<EProducto> lp = new List<EProducto>();
            if (Session["listaCompra"] != null)
            {
                carrito = (ECarrito)Session["listaCompra"];
                lp = carrito.productos;
                foreach (var pr in lp)
                {
                    if (pr.idProducto != p.idProducto)
                    {
                        lp.Add(p);
                        carrito.mensaje = "Producto agregado al Carrito";
                        Session["listaCompra"] = carrito;
                    }
                    else
                    {
                        carrito.mensaje = "Producto ya agregado al Carrito";
                    }
                }
            }
            else
            {
                lp.Add(p);
                carrito.productos = lp;
                carrito.mensaje = "Producto agregado al Carrito";
                Session["listaCompra"] = carrito;
            }
            //var res = Session["listaCompra"];
            //return Json(res, JsonRequestBehavior.DenyGet);
            return Json(carrito, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult QuitardelCarrito(EProducto p)
        {
            var resultado = p;
            ECarrito carrito = new ECarrito();
            List<EProducto> lp = new List<EProducto>();
            List<EProducto> lpf = new List<EProducto>();
            if (Session["listaCompra"] != null)
            {
                carrito = (ECarrito)Session["listaCompra"];
                lp = carrito.productos;
                foreach (var pro in lp)
                {
                    if (pro.idProducto != p.idProducto)
                    {
                        lpf.Add(pro);
                        carrito.productos = lpf;
                    }
                }
                carrito.mensaje = "Producto Quitado Exitosamente";
                Session["listaCompra"] = carrito;

            }
            //var res = Session["listaCompra"];
            return Json(carrito, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult TraerCarrito()
        {
            ECarrito carrito = new ECarrito();
            carrito = (ECarrito)Session["listaCompra"];
            return Json(carrito, JsonRequestBehavior.DenyGet);
        }

    }
}