﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetMarket.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Empresas()
        {
            return View();
        }
    }
}