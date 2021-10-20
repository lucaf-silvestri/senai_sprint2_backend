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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _PersonagemRepository { get; set; }

        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<Personagem> listaPersonagens = _PersonagemRepository.Listar();
            return Ok(listaPersonagens);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Personagem PersonagemBuscado = _PersonagemRepository.ListarId(id);

            if (PersonagemBuscado == null)
            {
                return NotFound("Nenhum personagem encontrado.");
            }

            return Ok(PersonagemBuscado);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            _PersonagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _PersonagemRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem PersonagemAtualizado)
        {
            Personagem PersonagemBuscado = _PersonagemRepository.ListarId(id);

            if (PersonagemBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _PersonagemRepository.Atualizar(id, PersonagemAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}