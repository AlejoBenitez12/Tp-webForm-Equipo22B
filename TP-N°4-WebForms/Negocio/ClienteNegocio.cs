using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_N_4_WebForms.Entidades;
using TP_N_4_WebForms.Datos;

namespace TP_N_4_WebForms.Negocio
{
    public class ClienteNegocio
    {
        public Cliente BuscarCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                return datos.BuscarCliente(dni);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al buscar cliente: " + ex.Message);
            }
        }
    }
}