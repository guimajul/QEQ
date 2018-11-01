using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QeQ.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ABMLPreguntas()
        {
            return View();
        }
        public ActionResult ABMLCategorias(string accion)
        {
            switch(accion)
            {
                case "modif":
                    return View("CatModif");
                    
                case "elim":
                    return View("CatElim");
                    
                case "ver":
                    return View("CatVer");
                    
                case "add":
                    return View("CatAdd");
                    

            }

            return View();
        }
        public ActionResult ABMLPersonajes()
        {
            return View();
        }
        public ActionResult Ver(string Tabla)
        {
            return View();
        }
    }
}