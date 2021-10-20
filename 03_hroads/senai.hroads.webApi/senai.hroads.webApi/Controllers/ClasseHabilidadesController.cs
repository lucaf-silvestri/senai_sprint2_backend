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
    public class ClasseHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _ClasseHabilidadeRepository { get; set; }

        public ClasseHabilidadesController()
        {
            _ClasseHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClasseHabilidade> listaClasseHabilidades = _ClasseHabilidadeRepository.Listar();
            return Ok(listaClasseHabilidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClasseHabilidade ClasseHabilidadeBuscado = _ClasseHabilidadeRepository.ListarId(id);

            if (ClasseHabilidadeBuscado == null)
            {
                return NotFound("Nenhuma ClasseHabilidade encontrada.");
            }

            return Ok(ClasseHabilidadeBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ClasseHabilidade novoClasseHabilidade)
        {
            _ClasseHabilidadeRepository.Cadastrar(novoClasseHabilidade);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClasseHabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClasseHabilidade ClasseHabilidadeAtualizado)
        {
            ClasseHabilidade ClasseHabilidadeBuscado = _ClasseHabilidadeRepository.ListarId(id);

            if (ClasseHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "ClasseHabilidade não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _ClasseHabilidadeRepository.Atualizar(id, ClasseHabilidadeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}