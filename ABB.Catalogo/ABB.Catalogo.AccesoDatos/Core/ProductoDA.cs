using ABB.Catalogo.Entidades.Core;
using ABB.Catalogo.Utiles.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Catalogo.AccesoDatos.Core
{
    public class ProductoDA
    {
        public Producto LlenarEntidad(IDataReader reader)
        {
            Producto producto = new Producto();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'IdProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdProducto"]))
                    producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'NomProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NomProducto"]))
                    producto.NomProducto = Convert.ToString(reader["NomProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'MarcaProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["MarcaProducto"]))
                    producto.MarcaProducto = Convert.ToString(reader["MarcaProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'ModeloProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["ModeloProducto"]))
                    producto.ModeloProducto = Convert.ToString(reader["ModeloProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'LineaProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["LineaProducto"]))
                    producto.LineaProducto = Convert.ToString(reader["LineaProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'GarantiaProducto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["GarantiaProducto"]))
                    producto.GarantiaProducto = Convert.ToString(reader["GarantiaProducto"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'DescripcionTecnica'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["DescripcionTecnica"]))
                    producto.DescripcionTecnica = Convert.ToString(reader["DescripcionTecnica"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'IdCategoria'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdCategoria"]))
                    producto.IdCategoria = Convert.ToInt32(reader["IdCategoria"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName = 'Precio'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Precio"]))
                    producto.Precio = Convert.ToSingle(reader["Precio"]);
            }
            return producto;
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> ListaEntidad = new List<Producto>();
            Producto entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListarProductos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        ListaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return ListaEntidad;
        }

        public Producto InsertarProducto(Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paProducto_insertar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    //comando.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    comando.Parameters.AddWithValue("@IdCategoria", Convert.ToInt32(producto.IdCategoria));
                    comando.Parameters.AddWithValue("@Nomproducto", producto.NomProducto);
                    comando.Parameters.AddWithValue("@MarcaProducto", producto.MarcaProducto);
                    comando.Parameters.AddWithValue("@ModeloProducto", producto.ModeloProducto);
                    comando.Parameters.AddWithValue("@Lineaproducto", producto.LineaProducto);
                    comando.Parameters.AddWithValue("@GarantiaProducto", producto.GarantiaProducto);
                    comando.Parameters.AddWithValue("@DescripcionTecnica", producto.DescripcionTecnica);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    //comando.Parameters.AddWithValue("@DescripcionTecnica", producto.DescripcionTecnica);
                    //comando.Parameters.AddWithValue("@Imagen", producto.Imagen);
                    conexion.Open();
                    producto.IdProducto = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return producto;
        }
    }
}
