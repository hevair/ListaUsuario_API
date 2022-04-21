using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using eCommerce.API.Interface;
using Dapper;
using eCommerce.API.Models;

namespace eCommerce.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection(@"Server=Server;Database=eCommerce;User Id=sa;Password=Senha;");

        }
        public async Task<IEnumerable> ObterUsuarios()
        {
            var result = await _connection.QueryAsync<Usuario>("select * from usuarios");

            return result;
        }
    }
}