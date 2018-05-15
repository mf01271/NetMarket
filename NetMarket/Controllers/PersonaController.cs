using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
//using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using ClientRestNet;
using ClientRestNet.RequestEntity;
using ClientRestNet.ResponseEntity;

namespace NetMarket.Controllers
{
    public class PersonaController : Controller
    {
        protected PersonaRest PersonaRest = new PersonaRest();
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(PersonaRequest param)
        {
            try
            {
                var resultado = PersonaRest.Login(param);
                Session.Add("persona", resultado);
                return Json(resultado, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(RespuestaApi<string>.createRespuestaError(ex.Message.Replace("'", "")), JsonRequestBehavior.DenyGet);
            }
        }
    }
}