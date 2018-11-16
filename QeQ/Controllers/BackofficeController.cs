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
            if (Session["ADM"] != null && Convert.ToBoolean(Session["ADM"] ))
            {
                ViewBag.ListasCategorias = BDD.ListarCategorias();
                ViewBag.Mensaje = "";
                if (a == false)
                {
                    ViewBag.Mensaje = "";
                }
                return View("ABMLCategorias");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult ABMLCategorias(string accion , int id = -1)
        {
            switch (accion)
            {
                case "modif":

                    Categoria Cat = BDD.TraerCategoria(id);
                    return View("ModificarCat",Cat);

                case "elim":
                    bool afectados = BDD.EliminarCategoria(id);
                    return RedirectToAction("ListaCategorias", "Backoffice", new { a = afectados });
                case "add":
                    return View("CatAdd");

            }
            
            return View();
        }
              
        public ActionResult AgregarCat(string Categoria)
        {
            BDD.CrearCategoria(Categoria);
            return RedirectToAction("ListaCategorias", "Backoffice");
        }

        public ActionResult ModificarCat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditarCat(Categoria x)
        {
            BDD.ModificarCategoria(x.IdCategoria, x.cat);
            return RedirectToAction("ListaCategorias");
        }

        //-------------------------------------------------------------------------------------------------------------

        public ActionResult ListaPersonajes(bool a = true)
        {
            if (Session["ADM"] != null)
            {
                ViewBag.ListasPersonajes = BDD.ListarPersonajes();
            ViewBag.Mensaje = "ABML Perso ";
            if (a == false)
            {
                ViewBag.Mensaje = "";
            }
            return View("ABMLPersonajes");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult ABMLPersonajes(string accion, int id = -1)
        {
            switch (accion)
            {
                case "modif":
                    ViewBag.id = id;
                    return View("ModificarPerso");
                case "elim":
                  bool afectados = BDD.EliminarPersonaje(id);
                    return RedirectToAction("ListaPersonajes", "Backoffice", new { a = afectados });
                case "add":
                    return View("PersoAdd");

            }

            return View();
        }

        public ActionResult AgregarPerso(string Personaje, int Categoria)
        {
            BDD.CrearPersonaje(Personaje,Categoria);
            return RedirectToAction("ListaPersonajes", "Backoffice");
        }

        public ActionResult EditarPerso(int idPerso, string PersoModificado, int CategModificada)
        {
            BDD.ModificarPersonaje(idPerso, PersoModificado,CategModificada);
            return RedirectToAction("ListaPersonajes");
        }




    }
}