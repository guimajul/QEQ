using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QeQ.Models
{
    public class Caracteristicas
    {
        private int _IdCaracteristica;
        private string _Caracteristica;
        private string _Pregunta;

        public int IdCaracteristica
        {
            get => _IdCaracteristica;
            set => _IdCaracteristica = value;
        }
        public string Caracteristica
        {
            get => _Caracteristica;
            set => _Caracteristica = value;
        }
        public string Pregunta
        {
            get => _Pregunta;
            set => _Pregunta = value;
        }

        public Caracteristicas (int _IdCaracteristica, string _Caracteristica, string _Pregunta)
        {
            IdCaracteristica = _IdCaracteristica;
            Caracteristica = _Caracteristica;
            Pregunta = _Pregunta;
        }
        public Caracteristicas()
        {

        }

    }
}