using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace QeQ.Models
{
    public class Usuario
    {
        private string mail;

        [Required(ErrorMessage = "Es obligatorio escribir el  mail")]
        public string EMail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string contra;

        [Required(ErrorMessage = "Es obligatorio escribir la contraseña")]
        [StringLength(maximumLength:15,MinimumLength =3,ErrorMessage ="La contraseña debe tener entre 3 y 15")]
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