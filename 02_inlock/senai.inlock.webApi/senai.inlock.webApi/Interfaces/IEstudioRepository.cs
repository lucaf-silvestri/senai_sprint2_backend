using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os Estudios
        /// </summary>
        /// <returns>Lista de Estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um Estudio através de seu ID
        /// </summary>
        /// <param name="id">ID do Estudio buscado</param>
        /// <returns>O Estudio buscado </returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com os novos dados</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um Estudio existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idEstudio">id do Estudio que será atualizado</param>
        /// <param name="EstudioAtualizado">Objeto EstudioAtualizado com os novos dados</param>
        void Atualizar(int idEstudio, EstudioDomain EstudioAtualizado);

        /// <summary>
        /// Deleta um Estudio existente
        /// </summary>
        /// <param name="idEstudio">ID do Estudio deletado</param>
        void Deletar(int idEstudio);

        /// <summary>
        /// Lista todos os Estudios com suas respectivas listas de jogos
        /// </summary>
        /// <returns>Uma lista de Estudios com seus jogos</returns>
        List<EstudioDomain> ListarComJogos();
    }
}
