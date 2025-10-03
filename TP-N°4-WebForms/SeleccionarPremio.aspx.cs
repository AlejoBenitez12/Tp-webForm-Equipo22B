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
    public partial class SeleccionarPremio : System.Web.UI.Page
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
                CargarPremios();
            }
        }

        private void CargarPremios()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.ListarArticulos();

                rptPremios.DataSource = lista;
                rptPremios.DataBind();
            }
            catch (Exception ex)
            {                
            }
        }

        protected void rptPremios_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Elegir")
            {
                int idArticuloElegido = int.Parse(e.CommandArgument.ToString());

                Voucher voucher = (Voucher)Session["VoucherActual"];

                voucher.IdArticulo = idArticuloElegido;
                Session["VoucherActual"] = voucher; 

                Response.Redirect("Registracion.aspx", false);
            }
        }
    }
}