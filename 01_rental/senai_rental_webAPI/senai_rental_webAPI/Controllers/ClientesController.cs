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

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }
    }
}
