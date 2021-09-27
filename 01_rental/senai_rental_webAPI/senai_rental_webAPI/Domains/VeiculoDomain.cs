using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) VEICULO
    /// </summary>
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int anoVeiculo { get; set; }
        public string placaVeiculo { get; set; }
    }
}
