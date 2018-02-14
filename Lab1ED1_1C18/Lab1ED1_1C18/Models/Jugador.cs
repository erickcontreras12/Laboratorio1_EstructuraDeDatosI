using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1ED1_1C18.Models
{
    public class Jugador
    {
        public int jugadorID { get; set; }

        public string club { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string posicion { get; set; }

        public double salarioBase { get; set; }

        public double compensasion { get; set; }

       
    }
}