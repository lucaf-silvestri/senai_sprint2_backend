using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TipoUsuarios
        /// </summary>
        /// <returns>Lista de TipoUsuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um TipoUsuario através de seu ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario buscado</returns>
        TipoUsuario ListarId(int id);

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com os novos dados</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com os novos dados</param>
        void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario deletado</param>
        void Deletar(int idTipoUsuario);

        /// <summary>
        /// Lista todos os TiposUsuario com suas respectivas listas de usuarios
        /// </summary>
        /// <returns>Uma lista de TiposUsuario com seus usuarios</returns>
        public List<TipoUsuario> ListarComUsuarios();
    }
}