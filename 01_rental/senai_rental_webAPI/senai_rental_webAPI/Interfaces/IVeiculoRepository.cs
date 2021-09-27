using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        /// <summary>
        /// Lista todos os veículos
        /// </summary>
        /// <returns>Lista de veículos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um veículo através de seu ID
        /// </summary>
        /// <param name="id">ID do veículo buscado</param>
        /// <returns>O veículo buscado </returns>
        VeiculoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os novos dados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Atualiza um veículo existente
        /// </summary>
        /// <param name="veiculoAtualizado">Objeto veículoAtualizado com os novos dados atualizados</param>
        void Atualizar(VeiculoDomain veículoAtualizado);

        /// <summary>
        /// Deleta um veículo existente
        /// </summary>
        /// <param name="idVeiculo">ID do veículo deletado</param>
        void Deletar(int idVeiculo);
    }
}
