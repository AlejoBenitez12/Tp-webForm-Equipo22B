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
    public partial class Registracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VoucherActual"] == null)
            {
                Response.Redirect("IngresoVoucher.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                lblMensaje.Text = "";
                HabilitarControles(false);
                btnConfirmar.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Debe ingresar un DNI para buscar o registrar.";
                return;
            }

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteEncontrado = negocio.BuscarCliente(dni);

                if (clienteEncontrado != null)
                {
                    txtNombre.Text = clienteEncontrado.Nombre;
                    txtApellido.Text = clienteEncontrado.Apellido;
                    txtEmail.Text = clienteEncontrado.Email;

                    Session["ClienteActual"] = clienteEncontrado;
                    lblMensaje.Text = "Cliente encontrado. Confirme el canje.";

                    HabilitarControles(false);
                    btnConfirmar.Enabled = true;
                    btnBuscar.Enabled = false;

                }
                else
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";

                    lblMensaje.Text = "Cliente no encontrado. Ingrese sus datos para registrarse y confirmar.";

                    HabilitarControles(true);
                    btnConfirmar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar cliente: " + ex.Message;
            }
        }

        private void HabilitarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // LÓGICA FINAL PENDIENTE: Registrar cliente (si es nuevo) y realizar el canje.
        }
    }
}