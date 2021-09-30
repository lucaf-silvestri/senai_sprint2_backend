using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de tipos de usuários
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o título do tipo de usuário.")]
        public string titulo { get; set; }
    }
}
