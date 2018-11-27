using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QeQ.Models
{
    public class Personajes
    {
        private int IdPersonaje;

        public int idPerso
        {
            get { return IdPersonaje; }
            set { IdPersonaje = value; }
        }

        private string Nombre;

        [Required(ErrorMessage = "Es obligatorio escribir el Nombre")]
        [StringLength(maximumLength: 15, MinimumLength = 4, ErrorMessage = "El nombre debe tener entre 4 a 15 letras")]
        public string Nom
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private int Categoria;

        [Required(ErrorMessage = "Es obligatorio escribir una categoria")]
        public int Cat
        {
            get { return Categoria; }
            set { Categoria = value; }
        }

        public Personajes(int idPersonaje, string Nombre, int Categoria)
        {
            idPerso= IdPersonaje;
            Nom = Nombre;
            Cat = Categoria;
        }
        public Personajes()
        {
        }

    }
}