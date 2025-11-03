using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio; 
using Datos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                lista = datos.ListarArticulosBase();

                foreach (Articulo item in lista)
                {
                    item.ListaImagenes = datos.ListarImagenesPorArticulo(item.Id);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de premios: " + ex.Message);
            }
        }
    }
}