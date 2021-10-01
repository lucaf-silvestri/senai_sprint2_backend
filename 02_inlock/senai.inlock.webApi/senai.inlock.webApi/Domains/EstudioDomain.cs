using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de estúdios
    /// </summary>
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Informe o nome do estúdio.")]
        public string nomeEstudio { get; set; }
        public List<JogoDomain> listaJogos { get; set; }
    }
}
