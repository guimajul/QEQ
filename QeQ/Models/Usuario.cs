using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QeQ.Models
{
    public class Usuario
    {
        private string mail;

        public string EMail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string contra;

        public string Contraseña
        {
            get { return contra; }
            set { contra = value; }
        }
        private bool Administrador;

        public bool adm
        {
            get { return Administrador; }
            set { Administrador = value; }
        }
        private string NombreUsuario;

        public string NomUs
        {
            get { return NombreUsuario; }
            set { NombreUsuario = value; }
        }



        public Usuario(string EMail, string Contraseña, bool adm, string NomUs)
        {
            mail = EMail;
            contra = Contraseña;
            Administrador = adm;
            NombreUsuario = NomUs;
        }
        public Usuario()
        {

        }
    }
    


}