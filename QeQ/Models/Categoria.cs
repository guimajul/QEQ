using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QeQ.Models
{
    public class Categoria
    {
        private int _IdCategoria;

        public int IdCategoria
        {
            get { return _IdCategoria; }
            set { _IdCategoria = value; }
        }

        private string _Categoria;

        public string cat
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        public Categoria(int _IdCategoria, string _Categoria)
        {
            IdCategoria = _IdCategoria;
            cat = _Categoria;

        }
        public Categoria() { }








    }
}