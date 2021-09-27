using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) ALUGUEL
    /// </summary>
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idCliente { get; set; }
        public int idVeiculo { get; set; }
        public Decimal valorAluguel { get; set; }
        public DateTime dataRetirada { get; set; }
        public DateTime dataDevolucao { get; set; }
        public ClienteDomain cliente { get; set; }
        public VeiculoDomain veiculo { get; set; }
    }
}
