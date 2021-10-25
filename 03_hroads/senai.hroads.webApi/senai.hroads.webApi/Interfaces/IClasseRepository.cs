using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{/// <summary>
 /// Interface responsável pelo repositório ClasseRepository
 /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as Classes
        /// </summary>
        /// <returns>Lista de Classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Busca uma Classe através de seu ID
        /// </summary>
        /// <param name="id">ID da Classe buscada</param>
        /// <returns>A Classe buscada</returns>
        Classe ListarId(int id);

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com os novos dados</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma Classe existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idClasse">id da Classe que será atualizada</param>
        /// <param name="ClasseAtualizada">Objeto ClasseAtualizada com os novos dados</param>
        void Atualizar(int idClasse, Classe ClasseAtualizada);

        /// <summary>
        /// Deleta um Classe existente
        /// </summary>
        /// <param name="idClasse">ID do Classe deletado</param>
        void Deletar(int idClasse);

        /// <summary>
        /// Lista todas as Classes com suas respectivas listas de personagens
        /// </summary>
        /// <returns>Uma lista de Classes com seus personagens</returns>
        List<Classe> ListarComPersonagens();
    }
}