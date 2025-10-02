using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_N_4_WebForms.Entidades
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }

        public string ImagenURL { get; set; }

        public override string ToString()
        {
            return ImagenURL;
        }
    }
}