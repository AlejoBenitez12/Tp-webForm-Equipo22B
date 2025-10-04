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


        public void RegistrarCanje(Cliente cliente, Voucher voucher)
        {
            AccesoDatos datos = new AccesoDatos();
            int idClienteFinal = 0;

            try
            {
                if (cliente.Id == 0)
                {
                    idClienteFinal = datos.InsertarNuevoCliente(cliente);
                }
                else
                {
                    idClienteFinal = cliente.Id;
                }

                if (idClienteFinal != 0)
                {
                    datos.FinalizarCanje(voucher, idClienteFinal);
                }
                else
                {
                    throw new Exception("No se pudo obtener un Id de Cliente válido para el canje.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar registrar el canje y el cliente: " + ex.Message);
            }
            finally
            {

                datos.cerrarConexion(); 
            }
        }
    }
}