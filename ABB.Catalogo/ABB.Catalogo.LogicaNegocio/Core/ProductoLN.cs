using ABB.Catalogo.Entidades.Core;
using ABB.Catalogo.AccesoDatos.Core;
using ABB.Catalogo.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Catalogo.LogicaNegocio.Core
{
    public class ProductoLN : BaseLN
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                ProductoDA productos = new ProductoDA();
                return productos.ListarProductos();
            }
            catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                return lista;
            }
        }
        /*public int GetProductoId(string pProducto, string pPassword)
        {
            try
            {
                ProductoDA producto = new ProductoDA();
                return producto.GetProductoId(pUsuario, pPassword);
            }
            catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                return -1;
            }
        }*/
        /*
        public Producto BuscaProductoId(int pProductoId)
        {
            try
            {
                ProductoDA producto = new ProductoDA();
                return producto.BuscaProductoId(pProductoId);
            }
            catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                throw;
            }
        }
        */

        public Producto InsertarProducto(Producto producto)
        {
            try
            {
                return new ProductoDA().InsertarProducto(producto);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        /*
        public Usuario ModificarUsuario(Usuario usuario)
        {
            try
            {
                return new UsuarioDA().ModificarUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                new UsuarioDA().EliminarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        */
    }
}
