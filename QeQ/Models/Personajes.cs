using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public string Nom
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private int Categoria;

        public int Cat
        {
            get { return Categoria; }
            set { Categoria = value; }
        }

        public Personajes(int idPersonaje, string Nombre, int Categoria)
        {
            IdPersonaje = idPerso;
            Nombre = Nom;
            Categoria = Cat;
        }
        public Personajes()
        {
        }



    }
}