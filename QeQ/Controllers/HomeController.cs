using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QeQ.Models;

namespace QeQ.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Instrucciones()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Ingreso()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session["NomUs"] = null;
            Session["ADM"] = null;
            return View("Index");
        }
        public ActionResult Registrarse()
        {
            

            return View("Registrarse");



        }
        [HttpPost]
        public ActionResult RedirectLogin(Usuario x)
        {
            if (ModelState.IsValid)
            {
                Usuario User = new Usuario();
                User.NomUs = "";
                User = BDD.ExisteUsuario(x.EMail, x.Contraseña);
                ViewBag.NomUs = User.NomUs;
                if (User.EMail != null)
                {
                    Session["NomUs"] = User.NomUs;
                    Session["ADM"] = User.adm;
                    if (User.adm == true)
                    {
                        return View("ADM");
                    }
                    else
                    {
                        ViewBag.ListasCategorias = BDD.ListarCategorias();
                        ViewBag.NombreUsuario = User.NomUs;
                        return View("Juego");
                    }
                }
                else
                {
                    ViewBag.MensajeError = "El usuario no existe en la base de datos";
                    return View("Login",x);
                }
            }
            else
            {
                return View("Login",x);
            }
        }

        [HttpPost]
        public ActionResult Registrar(string Email, string Password, string NombreDeUsuario)
        {
            BDD.CrearUsuario(Email, Password, NombreDeUsuario);
            return View("BienvenidaRegistrarse");
        }
        public ActionResult Juego()
        {
            ViewBag.ListasCategorias = BDD.ListarCategorias();
            return View("Juego");
        }
    }

 
}