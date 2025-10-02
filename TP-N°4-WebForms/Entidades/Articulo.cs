using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_N_4_WebForms.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }

        public List<Imagen> ListaImagenes { get; set; }

        public string NombreMarca
        {
            get { return Marca != null ? Marca.Descripcion : "N/A"; }
        }

        public string NombreCategoria
        {
            get { return Categoria != null ? Categoria.Descripcion : "N/A"; }
        }
    }
}