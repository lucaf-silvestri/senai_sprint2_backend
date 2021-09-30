using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório JogoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um Jogo através de seu ID
        /// </summary>
        /// <param name="id">ID do Jogo buscado</param>
        /// <returns>O Jogo buscado </returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com os novos dados</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um Jogo existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idJogo">id do Jogo que será atualizado</param>
        /// <param name="JogoAtualizado">Objeto JogoAtualizado com os novos dados</param>
        void Atualizar(int idJogo, JogoDomain JogoAtualizado);

        /// <summary>
        /// Deleta um Jogo existente
        /// </summary>
        /// <param name="idJogo">ID do Jogo deletado</param>
        void Deletar(int idJogo);
    }
}
