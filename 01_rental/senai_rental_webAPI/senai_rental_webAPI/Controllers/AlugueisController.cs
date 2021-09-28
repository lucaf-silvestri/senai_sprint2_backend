using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using senai_rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controlador responsável pelos end points referentes aos alugueis
/// </summary>
namespace senai_rental_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }
        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.ListarTodos();
            return Ok(listaAlugueis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado.");
            }

            return Ok(AluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AluguelDomain AluguelAtualizado)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Aluguel não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _AluguelRepository.Atualizar(id, AluguelAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}