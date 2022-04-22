using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using eCommerce.API.Interface;
using Dapper;
using eCommerce.API.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;

namespace eCommerce.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;
        public UsuarioRepository(IConfiguration configuration)
        {
             _connection = new SqlConnection(configuration.GetValue<string>("connectionString:SqlServer"));
           
            // _connection = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));

        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            string sql = @"select * from usuarios u 
			                        join Contatos c on u.id = c.UsuarioId
			                        join EnderecosEntrega e on u.id = e.UsuarioId";


            List<Usuario> usuarios = new List<Usuario>();

            var result = await _connection.QueryAsync<Usuario,Contato, EnderecoEntrega, Usuario>
                (sql,(usuario,contato, enderecoEntrega) => 
                { 

                    usuario.Contato = contato;
                    
                    if(usuarios.SingleOrDefault(s => s.Id == usuario.Id) == null){
                        usuario.EnderecosEntrega = new List<EnderecoEntrega>();
                        usuarios.Add(usuario);
                    }else{
                        usuario = usuarios.SingleOrDefault(s => s.Id == usuario.Id);
                    }

                    usuario.EnderecosEntrega.Add(enderecoEntrega); 
                    
                    return usuario;
                }
            );

            return result.ToList();
            
        }

        public async Task<int> IncluirUsuario(Usuario usuario){

            string sqlUsuario = "Insert into Usuarios (Nome, Email, Sexo, RG, CPF, NomeMae, SituacaoCadastro, DataCadastro) VALUES (@Nome, @Email, @Sexo, @RG, @CPF, @NomeMae, @SituacaoCadastro, @DataCadastro); select SCOPE_IDENTITY()";

            var id = await _connection.QueryAsync<int>(sqlUsuario,usuario);

            string sqlcontato = "Insert into Contatos (UsuarioId, Telefone, Celular) VALUES (@UsuarioId, @Telefone, @Celular)";

            await _connection.QueryAsync(sqlcontato, new {
                UsuarioId = id,
                Telefone = usuario.Contato.Telefone,
                Celular =  usuario.Contato.Celular
            });
            
            return id.Single();
        }

        
        public async Task RemoverUsuario(string id){

            string sql = "Delete From Usuarios where id = @id";

            await _connection.ExecuteAsync(sql,new {id = id});

        }

    }
}