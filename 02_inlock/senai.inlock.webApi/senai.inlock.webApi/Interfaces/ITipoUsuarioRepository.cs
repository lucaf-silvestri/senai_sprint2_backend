using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
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
        List<TipoUsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um TipoUsuario através de seu ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario buscado </returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com os novos dados</param>
        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com os novos dados</param>
        void Atualizar(int idTipoUsuario, TipoUsuarioDomain TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario deletado</param>
        void Deletar(int idTipoUsuario);
    }
}
