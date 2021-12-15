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
    public class UsuariosLN : BaseLN
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                UsuarioDA usuarios = new UsuarioDA();
                return usuarios.ListarUsuarios();
            } catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                return lista;
            }
        }
        public int GetUsuarioId(string pUsuario, string pPassword)
        {
            try
            {
                UsuarioDA usuario = new UsuarioDA();
                return usuario.GetUsuarioId(pUsuario, pPassword);
            } catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                return -1;
            }
        }

        public Usuario InsertarUsuario(Usuario usuario)
        {
            try
            {
                return new UsuarioDA().InsertarUsuario(usuario);
            } catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Usuario ModificarUsuario(Usuario usuario)
        {
            try
            {
                return new UsuarioDA().ModificarUsuario(usuario.IdUsuario,usuario);
            } catch(Exception ex)
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
    }
}
