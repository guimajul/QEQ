using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Es obligatorio escribir la caracteristica")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "La caracteristica debe tener entre 4 y 20 letras")]
        public string Caracteristica
        {
            get => _Caracteristica;
            set => _Caracteristica = value;
        }


        [Required(ErrorMessage = "Es obligatorio escribir la pregunta")]
        [StringLength(maximumLength: 30, MinimumLength = 10, ErrorMessage = "La pregunta debe tener entre 10 y 30 letras")]
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