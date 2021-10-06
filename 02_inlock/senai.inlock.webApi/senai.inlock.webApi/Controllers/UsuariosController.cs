using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// Controlador responsável pelos end points referentes aos Estudios
/// </summary>
namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }
        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuarios = _UsuarioRepository.ListarTodos();
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }

            return Ok(UsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain UsuarioAtualizado)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuário não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Luca",
                audience: "Luca",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}