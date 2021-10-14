using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{

 /// <summary>
 /// Interface responsável pelo repositório PersonagemRepository
 /// </summary>
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Lista de Personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Busca um Personagem através de seu ID
        /// </summary>
        /// <param name="id">ID do Personagem buscado</param>
        /// <returns>O Personagem buscado</returns>
        Personagem ListarId(int id);

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com os novos dados</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um Personagem existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idPersonagem">id do Personagem que será atualizado</param>
        /// <param name="PersonagemAtualizado">Objeto PersonagemAtualizado com os novos dados</param>
        void Atualizar(int idPersonagem, Personagem PersonagemAtualizado);

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do Personagem deletado</param>
        void Deletar(int idPersonagem);
    }
}