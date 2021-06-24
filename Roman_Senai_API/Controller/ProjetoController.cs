using Microsoft.AspNetCore.Mvc;
using Roman_Senai.Domains;
using Roman_Senai.Interface;
using Roman_Senai.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }

        public ProjetoController()
        {
            _projetoRepository = new ProjetoRepository();
        }
        public IActionResult Get()
        {
            return Ok(_projetoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(ProjetoDomain novoProjeto)
        {
            if (novoProjeto.nomeProjeto == null)
            {
                return BadRequest("O nome do projeto é obrigatório!");

            }
            if (novoProjeto.nomeProjeto == null)
            {
                return BadRequest("O nome do professor é obrigatório!");

            }

            _projetoRepository.Cadastrar(novoProjeto);

            return Created("http://localhost:44696/api/Projeto", novoProjeto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProjetoDomain ProjetoBuscado = _projetoRepository.BuscarPorId(id);

            if (ProjetoBuscado != null)
            {
                return Ok(ProjetoBuscado);
            }

            return NotFound("Nenhum projeto encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProjetoDomain ProjetoAtualizado)
        {
            ProjetoDomain ProjetoBuscado = _projetoRepository.BuscarPorId(id);
            if (ProjetoBuscado != null)
            {
                _projetoRepository.Atualizar(id, ProjetoAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum projeto encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProjetoDomain ProjetoBuscado = _projetoRepository.BuscarPorId(id);

            if (ProjetoBuscado != null)
            {
                _projetoRepository.Deletar(id);

                return Ok($"O projeto {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhum projeto encontrado para o identificador informado");
        }
    }
}
