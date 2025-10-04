using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_N_4_WebForms
{
    public partial class ConfirmacionCanje : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Opcional: Si quieres forzar que no se acceda a esta página directamente,
            // puedes chequear si la Sesión sigue estando vacía. Pero generalmente se permite.
        }

        protected void btnVolverInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoVoucher.aspx", false);
        }
    
    }
}