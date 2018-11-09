using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QeQ.Models;


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


        public ActionResult ABMLCategorias(string accion, int id = -1)

        {
            ViewBag.ListasCategorias = BDD.ListarCategorias();
            switch (accion)
            {
                case "modif":
                    return View("CatModif");

                case "elim":
                    break;

                case "add":

                    return View("CatAdd");

            }
            
            return View();
        }
        public ActionResult ABMLPersonajes()
        {
            return View();
        }
        
        public ActionResult AgregarCat(string Categoria)
        {
            BDD.CrearCategoria(Categoria);
            ViewBag.ListasCategorias = BDD.ListarCategorias();
            return View("ABMLCategorias");
        }
   
    }
}