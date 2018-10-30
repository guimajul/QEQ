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
        public ActionResult Registrarse()
        {
            //Usuario us = new Usuario()

            return View("Registrarse");



        }
        public ActionResult RedirectLogin(string Email, string Password)
        {

            Usuario User = new Usuario();
            User.NomUs = "";
            User = BDD.ExisteUsuario(Email, Password);
            ViewBag.NomUs = User.NomUs;
            if (User.adm == true)
            {
                return View("ADM");
            }
            if (User.NomUs != null)
            {
                ViewBag.NombreUsuario = User.NomUs;
                return View("Ingreso");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult Registrar(string Email, string Password, string NombreDeUsuario)
        {
            BDD.CrearUsuario(Email, Password, NombreDeUsuario);
            return View("BienvenidaRegistrarse");
        }
    }
}