using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Roman_Senai.Domains;
using Roman_Senai.Interface;
using Roman_Senai.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Roman_Senai.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.Email == null)
            {
                return BadRequest("O email é obrigatório!");

            }
            if (novoUsuario.Senha == null)
            {
                return BadRequest("A senha é obrigatória!");

            }
            return Created("http://localhost:44696/api/Usuario", novoUsuario);
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmdegroup-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(
                issuer: "Roman_Senai.webApi",
                audience: "Roman_Senai.webApi",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                return Ok(UsuarioBuscado);
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain UsuarioAtualizado)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (UsuarioBuscado != null)
            {
                _usuarioRepository.Atualizar(id, UsuarioAtualizado);

                return StatusCode(204);
            }
            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum usuario encontrado para o identificador informado");
        }


    }
}

