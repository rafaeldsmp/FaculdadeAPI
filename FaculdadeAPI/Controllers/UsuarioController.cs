using FaculdadeUD.Domain.Model;
using FaculdadeUD.InfraStructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaculdadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repositorio;
        
        public UsuarioController(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuario = _repositorio.GetAllUsuarios();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _repositorio.GetById(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _repositorio.Add(usuario);
            if(_repositorio.SaveChanges())
            {
                return Ok(usuario);
            }
            return BadRequest("Usuário não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var usuario = _repositorio.GetById(id);
            if (usuario == null) return BadRequest("Usuario não encontrado");
            _repositorio.Update(usuario);
            if (_repositorio.SaveChanges())
            {
                return Ok(usuario);
            }
            return BadRequest("Usuário não foi atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _repositorio.GetById(id);
            if (usuario == null) return BadRequest("usuario não encontrado");
            _repositorio.Delelte(usuario);
            if (_repositorio.SaveChanges())
            {
                return Ok(usuario);
            }
            return BadRequest("Usuario não foi deletado");
        }
    }
}
