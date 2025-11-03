using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Voucher
    {
        public string CodigoVoucher { get; set; }
        public int? IdCliente { get; set; } 
        public DateTime? FechaCanje { get; set; } 
        public int? IdArticulo { get; set; } 

        
        public bool Canjeado
        {
            get { return FechaCanje != null; }
        }

        public string NombreArticuloPremio { get; set; }
    }
}