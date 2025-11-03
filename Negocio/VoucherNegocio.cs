using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using Datos;

namespace Negocio
{
    public class VoucherNegocio
    {
        public Voucher ValidarVoucher(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Voucher voucher;

            try
            {
                voucher = datos.BuscarVoucher(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexión o búsqueda del voucher.", ex);
            }

            if (voucher == null)
            {
                throw new Exception("El código de voucher ingresado es incorrecto o no existe.");
            }

            if (voucher.Canjeado)
            {
                throw new Exception("El código ya ha sido utilizado. Cada código solo se puede usar una vez.");
            }

            return voucher;
        }
    }
}