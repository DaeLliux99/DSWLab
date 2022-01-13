using ABB.Catalogo.Entidades.Core;
using ABB.Catalogo.LogicaNegocio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;

namespace WebServicesAbb.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = new UsuariosLN().ListarUsuarios();
            return usuarios;
        }

        // GET: api/Usuarios/5
        public int Get([FromUri] string pUsuario, [FromUri] string pPassword)
        {
            try
            {
                UsuariosLN usuario = new UsuariosLN();
                return usuario.GetUsuarioId(pUsuario, pPassword);
            }
            catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                return -1;
            }
        }

        public Usuario GetUserId([FromUri] int idUsuario)
        {
            try
            {
                UsuariosLN usuario = new UsuariosLN();
                return usuario.BuscaUsuarioId(idUsuario);
            }
            catch (Exception ex)
            {
                string innerException = (ex.InnerException == null) ? "" : ex.InnerException.ToString();
                throw;
            }
        }

        // POST: api/Usuarios
        public void Post([FromBody]Usuario value)
        {
            Usuario usuario = new UsuariosLN().InsertarUsuario(value);
        }

        // PUT: api/Usuarios/5
        public void Put([FromBody]Usuario value)
        {
            Usuario usuario = new Usuario();
            usuario = new UsuariosLN().ModificarUsuario(value);
        }

        // DELETE: api/Usuarios/5
        public void Delete([FromUri] int idUsuario)
        {
            new UsuariosLN().EliminarUsuario(idUsuario);
        }
    }
}
