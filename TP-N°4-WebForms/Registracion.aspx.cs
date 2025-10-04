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
                    txtDireccion.Text = clienteEncontrado.Direccion;
                    txtCiudad.Text = clienteEncontrado.Ciudad;
                    txtCP.Text = clienteEncontrado.CP.ToString();

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
                    txtDireccion.Text = "";
                    txtCiudad.Text = "";
                    txtCP.Text = "";

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
            txtDireccion.Enabled = habilitar;
            txtCiudad.Enabled = habilitar;
            txtCP.Enabled = habilitar;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            lblErrorTerminos.Visible = false;

            if (!chkAceptarTerminos.Checked)
            {
                lblErrorTerminos.Text = "Debe aceptar los Términos y Condiciones.";
                lblErrorTerminos.Visible = true;
                return; 
            }


            if (Session["VoucherActual"] == null)
            {
                lblMensaje.Text = "Error: La sesión de canje ha expirado. Por favor, intente de nuevo.";

                ClientScript.RegisterStartupScript(this.GetType(), "redir", "setTimeout(function(){ window.location.href = 'IngresoVoucher.aspx'; }, 3000);", true);
                return;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtEmail.Text)
            || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCiudad.Text) || string.IsNullOrEmpty(txtCP.Text)) 
            {
                lblMensaje.Text = "Por favor, complete todos los campos obligatorios (incluyendo Dirección, Ciudad y CP).";
                return;
            }

            try
            {
                Voucher voucher = (Voucher)Session["VoucherActual"];

                Cliente cliente = new Cliente();

                if (Session["ClienteActual"] != null)
                {
                    cliente = (Cliente)Session["ClienteActual"];
                }

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Documento = txtDNI.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Ciudad = txtCiudad.Text;
                cliente.CP = int.Parse(txtCP.Text);

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.RegistrarCanje(cliente, voucher);

                Session.Remove("VoucherActual");
                Session.Remove("ClienteActual");
                Response.Redirect("ConfirmacionCanje.aspx", false);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "ERROR GRAVE: No se pudo completar la transacción. " + ex.Message;
            } 
        }
    }
}