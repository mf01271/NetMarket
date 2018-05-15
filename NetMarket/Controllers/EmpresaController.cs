using ClientRestNet;
using ClientRestNet.RequestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetMarket.Controllers
{
    public class EmpresaController : Controller
    {
        protected EmpresaRest empresaRest = new EmpresaRest();
        // GET: Producto
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ListarEmpresas(EmpresaRequest param)
        {
            try
            {
                var resultado = empresaRest.ListarEmpresas(param);
                //if (resultado.Codigo != 0)
                //{
                //return Json("", JsonRequestBehavior.DenyGet);

                //}
                return Json(resultado, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(RespuestaApi<string>.createRespuestaError(ex.Message.Replace("'", "")), JsonRequestBehavior.DenyGet);
            }
        }
    }
}
