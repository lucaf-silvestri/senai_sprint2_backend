using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controlador responsável pelos end points referentes aos Jogos
/// </summary>
namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }
        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();
            return Ok(listaJogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(id);

            if (JogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado.");
            }

            return Ok(JogoBuscado);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _JogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, JogoDomain JogoAtualizado)
        {
            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(id);

            if (JogoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Jogo não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _JogoRepository.Atualizar(id, JogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}