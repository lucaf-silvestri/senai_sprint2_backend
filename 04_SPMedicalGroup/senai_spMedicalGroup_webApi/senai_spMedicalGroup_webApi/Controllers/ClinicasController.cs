using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using senai_spMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_spMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicasController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Clinica> listaClinicas = _ClinicaRepository.Listar();
            return Ok(listaClinicas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Clinica ClinicaBuscado = _ClinicaRepository.ListarId(id);

            if (ClinicaBuscado == null)
            {
                return NotFound("Nenhuma Clinica encontrada.");
            }

            return Ok(ClinicaBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novoClinica)
        {
            _ClinicaRepository.Cadastrar(novoClinica);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClinicaRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscado = _ClinicaRepository.ListarId(id);

            if (ClinicaBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Clinica não encontrada.",
                        erro = true
                    });
            }

            try
            {
                _ClinicaRepository.Atualizar(id, ClinicaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("medicos")]
        public IActionResult ListarComMedicos()
        {
            try
            {
                return Ok(_ClinicaRepository.ListarComMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}