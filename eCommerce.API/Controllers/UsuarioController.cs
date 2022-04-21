using System.Threading.Tasks;
using eCommerce.API.Interface;
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
        
    }
}