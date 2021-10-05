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
/// Controlador responsável pelos end points referentes aos TiposUsuario
/// </summary>
namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }
        public TiposUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipoUsuarios = _TipoUsuarioRepository.ListarTodos();
            return Ok(listaTipoUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum tipo de usuário encontrado.");
            }

            return Ok(TipoUsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            TipoUsuarioDomain TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de usuário não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}