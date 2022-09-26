using Microsoft.AspNetCore.Mvc;
using FaculdadeUD.InfraStructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FaculdadeUD.Domain.Model;

namespace FaculdadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _repositorio;
        public DepartamentoController(IDepartamentoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departamento = _repositorio.GetAllDepartamentos();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(departamento);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var departamento = _repositorio.GetDepartamentoById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(departamento);
        }

        [HttpPost]
        public IActionResult Post(Departamento departamento)
        {
            _repositorio.Add(departamento);
            if (_repositorio.SaveChanges())
            {
                return Ok(departamento);
            }
            return BadRequest("Departamento não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var departamento = _repositorio.GetDepartamentoById(id);
            if (departamento == null) return BadRequest("Departamento não encontrado");
            _repositorio.Update(departamento);
            if (_repositorio.SaveChanges())
            {
                return Ok(departamento);
            }
            return BadRequest("Departamento não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var departamento = _repositorio.GetDepartamentoById(id);
            if (departamento == null) return BadRequest("Departamento não encontrado");
            _repositorio.Delete(departamento);
            if (_repositorio.SaveChanges())
            {
                return Ok(departamento);
            }
            return BadRequest("Departamento não deletado");
        }
    }
}
