using System.Collections;
using System.Threading.Tasks;

namespace eCommerce.API.Interface
{
    public interface IUsuarioRepository
    {
         public Task<IEnumerable> ObterUsuarios();
    }
}