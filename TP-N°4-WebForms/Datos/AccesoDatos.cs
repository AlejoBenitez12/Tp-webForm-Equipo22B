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

        public List<Articulo> ListarArticulosBase()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                               "M.Id AS IdMarca, M.Descripcion AS MarcaDesc, " +
                               "C.Id AS IdCategoria, C.Descripcion AS CategoriaDesc " +
                               "FROM ARTICULOS A " +
                               "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                               "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");

                ejecutarLectura(); 

                while (Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)Lector["Id"];
                    aux.Codigo = (string)Lector["Codigo"];
                    aux.Nombre = (string)Lector["Nombre"];
                    aux.Descripcion = (string)Lector["Descripcion"];
                    aux.Precio = (decimal)Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)Lector["MarcaDesc"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)Lector["CategoriaDesc"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos base desde la DB.", ex);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public List<Imagen> ListarImagenesPorArticulo(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();

            try
            {
                setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@id", idArticulo);

                ejecutarLectura();

                while (Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)Lector["Id"];
                    img.IdArticulo = (int)Lector["IdArticulo"];
                    img.ImagenURL = (string)Lector["ImagenUrl"];
                    lista.Add(img);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes desde la DB.", ex);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public Cliente BuscarCliente(string dni)
        {
            Cliente cliente = null;
            try
            {
                setearConsulta("SELECT Id, Nombre, Apellido, Email, Documento FROM CLIENTES WHERE Documento = @Documento");
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@Documento", dni);

                ejecutarLectura();

                if (Lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Id = (int)Lector["Id"];

                    if (Lector["Nombre"] != DBNull.Value)
                        cliente.Nombre = (string)Lector["Nombre"];

                    if (Lector["Apellido"] != DBNull.Value)
                        cliente.Apellido = (string)Lector["Apellido"];

                    if (Lector["Email"] != DBNull.Value)
                        cliente.Email = (string)Lector["Email"];

                    cliente.Documento = (string)Lector["Documento"];
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente por Documento.", ex);
            }
            finally
            {
                cerrarConexion();
            }
        }
    }
}