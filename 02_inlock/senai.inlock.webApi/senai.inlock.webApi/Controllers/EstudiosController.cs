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
/// Controlador responsável pelos end points referentes aos Estudios
/// </summary>
namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }
        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _EstudioRepository.ListarTodos();
            return Ok(listaEstudios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(id);

            if (EstudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado.");
            }

            return Ok(EstudioBuscado);
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _EstudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _EstudioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudioDomain EstudioAtualizado)
        {
            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(id);

            if (EstudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Estúdio não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _EstudioRepository.Atualizar(id, EstudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("jogos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_EstudioRepository.ListarComJogos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}