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
/// Controlador responsável pelos end points referentes aos clientes
/// </summary>
namespace senai_rental_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }
        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _ClienteRepository.ListarTodos();
            return Ok(listaClientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado.");
            }

            return Ok(ClienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClienteDomain ClienteAtualizado)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _ClienteRepository.Atualizar(id, ClienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
