using Microsoft.AspNetCore.Authorization;
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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Habilidade> listaHabilidades = _HabilidadeRepository.Listar();
            return Ok(listaHabilidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Habilidade HabilidadeBuscado = _HabilidadeRepository.ListarId(id);

            if (HabilidadeBuscado == null)
            {
                return NotFound("Nenhuma habilidade encontrada.");
            }

            return Ok(HabilidadeBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novoHabilidade)
        {
            _HabilidadeRepository.Cadastrar(novoHabilidade);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _HabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade HabilidadeAtualizado)
        {
            Habilidade HabilidadeBuscado = _HabilidadeRepository.ListarId(id);

            if (HabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Habilidade não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _HabilidadeRepository.Atualizar(id, HabilidadeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}