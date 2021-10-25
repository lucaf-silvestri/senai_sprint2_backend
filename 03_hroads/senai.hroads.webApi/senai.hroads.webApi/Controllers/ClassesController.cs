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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _ClasseRepository { get; set; }

        public ClassesController()
        {
            _ClasseRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Classe> listaClasses = _ClasseRepository.Listar();
            return Ok(listaClasses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Classe ClasseBuscado = _ClasseRepository.ListarId(id);

            if (ClasseBuscado == null)
            {
                return NotFound("Nenhuma Classe encontrada.");
            }

            return Ok(ClasseBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novoClasse)
        {
            _ClasseRepository.Cadastrar(novoClasse);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClasseRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe ClasseAtualizado)
        {
            Classe ClasseBuscado = _ClasseRepository.ListarId(id);

            if (ClasseBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Classe não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _ClasseRepository.Atualizar(id, ClasseAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("personagens")]
        public IActionResult ListarComPersonagens()
        {
            try
            {
                return Ok(_ClasseRepository.ListarComPersonagens());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}