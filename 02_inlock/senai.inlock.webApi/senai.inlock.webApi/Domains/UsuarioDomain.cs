using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de usuários
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O campo senha deve conter, no mínimo, 5 e, no máximo, 30 caracteres.")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}