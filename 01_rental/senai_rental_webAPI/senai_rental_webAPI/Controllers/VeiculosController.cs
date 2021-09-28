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
/// Controlador responsável pelos end points referentes aos veiculos
/// </summary>
namespace senai_rental_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }
        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _VeiculoRepository.ListarTodos();
            return Ok(listaVeiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nenhum veículo encontrado.");
            }

            return Ok(VeiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, VeiculoDomain VeiculoAtualizado)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Veículo não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _VeiculoRepository.Atualizar(id, VeiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}