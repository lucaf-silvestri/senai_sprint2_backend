using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AlguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        /// <summary>
        /// Lista todos os aluguéis
        /// </summary>
        /// <returns>Lista de aluguéis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Busca um aluguel através de seu ID
        /// </summary>
        /// <param name="id">ID do aluguel buscado</param>
        /// <returns>O aluguel buscado </returns>
        AluguelDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel com os novos dados</param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um aluguel existente
        /// </summary>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados atualizados</param>
        void Atualizar(AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Deleta um aluguel existente
        /// </summary>
        /// <param name="idAluguel">ID do aluguel deletado</param>
        void Deletar(int idAluguel);
    }
}
