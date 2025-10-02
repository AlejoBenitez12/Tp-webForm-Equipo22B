using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP_N_4_WebForms.Entidades;


namespace TP_N_4_WebForms.Datos
{
    public class AccesoDatos
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {

            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion; 
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion(); 
            }
        }

        public object ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public SqlCommand Comando
        {
            get { return comando; }
        }

        public Voucher BuscarVoucher(string codigo)
        {
            Voucher voucher = null;


            try
            {
                setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@codigo", codigo);

                ejecutarLectura();

                if (Lector.Read())
                {
                    voucher = new Voucher();
                    voucher.CodigoVoucher = (string)Lector["CodigoVoucher"];

                    if (Lector["IdCliente"] != DBNull.Value)
                        voucher.IdCliente = (int)Lector["IdCliente"];

                    if (Lector["FechaCanje"] != DBNull.Value)
                        voucher.FechaCanje = (DateTime)Lector["FechaCanje"];

                    if (Lector["IdArticulo"] != DBNull.Value)
                        voucher.IdArticulo = (int)Lector["IdArticulo"];
                }

                return voucher; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Voucher en la base de datos.", ex);
            }
            finally
            {
                cerrarConexion(); 
            }
        }
    }
}