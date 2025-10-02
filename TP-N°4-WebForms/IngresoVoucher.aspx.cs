using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_N_4_WebForms.Entidades;
using TP_N_4_WebForms.Negocio;

namespace TP_N_4_WebForms
{
    public partial class IngresoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensajeError.Text = "";
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";

            try
            {
                string codigoIngresado = txtCodigoVoucher.Text.Trim();

                if (string.IsNullOrEmpty(codigoIngresado))
                {
                    lblMensajeError.Text = "Por favor, ingrese el código del voucher.";
                    return;
                }

                VoucherNegocio negocio = new VoucherNegocio();
                Voucher voucherValido = negocio.ValidarVoucher(codigoIngresado);

                Session["VoucherActual"] = voucherValido;

                Response.Redirect("SeleccionarPremio.aspx", false);
            }
            catch (Exception ex)
            {

                lblMensajeError.Text = ex.Message;
            }
        }
    }
}