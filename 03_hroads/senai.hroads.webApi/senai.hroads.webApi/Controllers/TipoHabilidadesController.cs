using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _TipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _TipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoHabilidade> listaTipoHabilidades = _TipoHabilidadeRepository.Listar();
            return Ok(listaTipoHabilidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoHabilidade TipoHabilidadeBuscado = _TipoHabilidadeRepository.ListarId(id);

            if (TipoHabilidadeBuscado == null)
            {
                return NotFound("Nenhuma TipoHabilidade encontrada.");
            }

            return Ok(TipoHabilidadeBuscado);
        }

        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            _TipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TipoHabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade TipoHabilidadeAtualizado)
        {
            TipoHabilidade TipoHabilidadeBuscado = _TipoHabilidadeRepository.ListarId(id);

            if (TipoHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "TipoHabilidade não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _TipoHabilidadeRepository.Atualizar(id, TipoHabilidadeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}