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
        protected PersonaRest PersonaRest = new PersonaRest();
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }     
    }
}