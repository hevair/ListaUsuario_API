using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.API.Models;

namespace eCommerce.API.Interface
{
    public interface IUsuarioRepository
    {
         public Task<List<Usuario>> ObterUsuarios();

         public Task<int> IncluirUsuario(Usuario usuario);

         public Task RemoverUsuario(string id);
    }
}