using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// Busca um cliente através de seu ID
        /// </summary>
        /// <param name="id">ID do cliente buscado</param>
        /// <returns>O cliente buscado </returns>
        ClienteDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os novos dados</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Atualiza um cliente existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idCliente">id do cliente que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto ClienteAtualizado com os novos dados</param>
        void Atualizar(int idCliente, ClienteDomain ClienteAtualizado);

        /// <summary>
        /// Deleta um cliente existente
        /// </summary>
        /// <param name="idCliente">ID do cliente deletado</param>
        void Deletar(int idCliente);
    }
}
