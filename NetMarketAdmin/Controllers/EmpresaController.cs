using ClientRestNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetMarketAdmin.Controllers
{
    public class EmpresaController : Controller
    {
        protected EmpresaRest empresaRest = new EmpresaRest();
        // GET: Persona
        public ActionResult Empresas()
        {
            return View();
        }
    }
}