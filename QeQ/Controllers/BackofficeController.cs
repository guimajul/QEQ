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

        public ActionResult ListaCategorias(bool a = true)
        {
            ViewBag.ListasCategorias = BDD.ListarCategorias();
            ViewBag.Mensaje = "";
            if (a == false)
            {
                ViewBag.Mensaje = "No se puede borrar ya que hay datos asociados, primero debes borrarlos, Je!";
            }
            return View("ABMLCategorias");
        }

        public ActionResult ABMLCategorias(string accion , int id = -1)
        {
            switch (accion)
            {
                case "modif":
                    return View("CatModif");
                case "elim":
                    bool afectados = BDD.EliminarCategoria(id);
                    return RedirectToAction("ListaCategorias", "Backoffice", new { a = afectados });
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
            return RedirectToAction("ListaCategorias", "Backoffice");
        }
   
    }
}