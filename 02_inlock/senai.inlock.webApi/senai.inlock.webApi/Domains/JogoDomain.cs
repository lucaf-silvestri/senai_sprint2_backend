using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de jogos
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "Informe o nome do jogo.")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do jogo.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo senha deve conter, no mínimo, 10 e, no máximo, 200 caracteres.")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento do jogo.")]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "Informe o valor do jogo.")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "Informe o id do estúdio do jogo.")]
        public int idEstudio { get; set; }

        public EstudioDomain estudio { get; set; }
    }
}
