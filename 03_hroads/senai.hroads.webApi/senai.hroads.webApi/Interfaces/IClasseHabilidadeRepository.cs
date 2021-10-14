using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório ClasseHabilidadeRepository
    /// </summary>
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as ClasseHabilidades
        /// </summary>
        /// <returns>Lista de ClasseHabilidades</returns>
        List<ClasseHabilidade> Listar();

        /// <summary>
        /// Busca uma ClasseHabilidade através de seu ID
        /// </summary>
        /// <param name="id">ID da ClasseHabilidade buscada</param>
        /// <returns>A ClasseHabilidade buscada</returns>
        ClasseHabilidade ListarId(int id);

        /// <summary>
        /// Cadastra uma nova ClasseHabilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto novaClasseHabilidade com os novos dados</param>
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Atualiza uma ClasseHabilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idClasseHabilidade">id da ClasseHabilidade que será atualizada</param>
        /// <param name="ClasseHabilidadeAtualizada">Objeto ClasseHabilidadeAtualizada com os novos dados</param>
        void Atualizar(int idClasseHabilidade, ClasseHabilidade ClasseHabilidadeAtualizada);

        /// <summary>
        /// Deleta um ClasseHabilidade existente
        /// </summary>
        /// <param name="idClasseHabilidade">ID do ClasseHabilidade deletado</param>
        void Deletar(int idClasseHabilidade);
    }
}