using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório TipoHabilidadeRepository
    /// </summary>
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os TiposHabilidade
        /// </summary>
        /// <returns>Lista de TiposHabilidade</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Busca um TipoHabilidade através de seu ID
        /// </summary>
        /// <param name="id">ID do TipoHabilidade buscado</param>
        /// <returns>O TipoHabilidade buscado</returns>
        TipoHabilidade ListarId(int id);

        /// <summary>
        /// Cadastra um novo TipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade com os novos dados</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza um TipoHabilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoHabilidade">id do TipoHabilidade que será atualizado</param>
        /// <param name="TipoHabilidadeAtualizado">Objeto TipoHabilidadeAtualizado com os novos dados</param>
        void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta um TipoHabilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">ID do TipoHabilidade deletado</param>
        void Deletar(int idTipoHabilidade);

        /// <summary>
        /// Lista todos os TiposHabilidade com suas respectivas listas de habilidades
        /// </summary>
        /// <returns>Uma lista de TiposHabilidade com suas habilidades</returns>
        public List<TipoHabilidade> ListarComHabilidades();
    }
}