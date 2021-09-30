using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um Usuario através de seu ID
        /// </summary>
        /// <param name="id">ID do Usuario buscado</param>
        /// <returns>O Usuario buscado </returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os novos dados</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idUsuario">id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado com os novos dados</param>
        void Atualizar(int idUsuario, UsuarioDomain UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Valida o Usuario
        /// </summary>
        /// <param name="email">Email que será buscado para validar o Usuario</param>
        /// <param name="senha">Senha que será buscada para validar o Usuario</param>
        /// <returns>Um Usuario que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
