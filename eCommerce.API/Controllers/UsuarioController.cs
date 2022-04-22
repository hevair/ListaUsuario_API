using System.Threading.Tasks;
using eCommerce.API.Interface;
using eCommerce.API.Models;
using eCommerce.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
           _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> obterUsuario(){
            
            var result = await _repository.ObterUsuarios();

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult> Insert(Usuario usuario){

            var result = await _repository.IncluirUsuario(usuario);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id){
            
            await _repository.RemoverUsuario(id);

            return Ok();
        }
    }
}