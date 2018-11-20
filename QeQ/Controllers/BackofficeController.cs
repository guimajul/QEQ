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
              
        public ActionResult AgregarCat(Categoria x)
        {
            if (ModelState.IsValid)
            {
                BDD.CrearCategoria(x.cat);
            return RedirectToAction("ListaCategorias", "Backoffice");
            }
            else
            {
                return View("CatAdd");
            }
        }

        public ActionResult ModificarCat()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditarCat(Categoria x)
        {
            if (ModelState.IsValid)
            {
                BDD.ModificarCategoria(x.IdCategoria, x.cat);
                return RedirectToAction("ListaCategorias");
            }
            else
            {
                return View("ModificarCat");
            }

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

                    Personajes Perso = BDD.TraerPersonajes(id);
                    ViewBag.ListaCategorias = BDD.ListarCategorias();
                    return View("ModificarPerso", Perso);                  
                   
                case "elim":
                  bool afectados = BDD.EliminarPersonaje(id);
                    return RedirectToAction("ListaPersonajes", "Backoffice", new { a = afectados });
                case "add":
                    ViewBag.ListaCategorias = BDD.ListarCategorias();
                    return View("PersoAdd");

            }

            return View();
        }

        public ActionResult AgregarPerso(Personajes x)
        {
            if (ModelState.IsValid)
            {
                BDD.CrearPersonaje(x.Nom,x.Cat);
            return RedirectToAction("ListaPersonajes", "Backoffice");
            }
            else
            {
                return View("PersoAdd");
            }
        }

        /*public ActionResult EditarPerso(int idPerso, string PersoModificado, int CategModificada)
        {
            BDD.ModificarPersonaje(idPerso, PersoModificado,CategModificada);
            return RedirectToAction("ListaPersonajes");
        }
        */

        public ActionResult EditarPerso(Personajes x)
        {
            if (ModelState.IsValid)
            {
                BDD.ModificarPersonaje(x.idPerso,x.Nom,x.Cat);
            return RedirectToAction("ListaPersonajes");
            }
            else
            {
                return View("ModificarPerso");
            }
        }




    }
}