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
    public class TemaController : ControllerBase
    {
        private ITemaRepository _temaRepository { get; set; }

        public TemaController()
        {
            _temaRepository = new TemaRepository();
        }
        public IActionResult Get()
        {
            return Ok(_temaRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(TemaDomain novoTema)
        {
            if (novoTema.nomeTema == null)
            {
                return BadRequest("O nome do tema é obrigatório!");

            }

            _temaRepository.Cadastrar(novoTema);

            return Created("http://localhost:44696/api/Tema", novoTema);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TemaDomain TemaBuscado = _temaRepository.BuscarPorId(id);

            if (TemaBuscado != null)
            {
                return Ok(TemaBuscado);
            }

            return NotFound("Nenhum tema encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TemaDomain TemaAtualizado)
        {
            TemaDomain TemaBuscado = _temaRepository.BuscarPorId(id);
            if (TemaBuscado != null)
            {
                _temaRepository.Atualizar(id, TemaAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum tema encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TemaDomain TemaBuscado = _temaRepository.BuscarPorId(id);

            if (TemaBuscado != null)
            {
                _temaRepository.Deletar(id);

                return Ok($"O tema {id} foi deletada com sucesso!");
            }

            return NotFound("Nenhum tema encontrado para o identificador informado");
        }
    }
}

