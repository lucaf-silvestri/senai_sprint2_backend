using senai.hroads.webApi.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi.Interfaces
{
    
 /// <summary>
 /// Interface responsável pelo repositório HabilidadeRepository
 /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Lista de Habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma Habilidade através de seu ID
        /// </summary>
        /// <param name="id">ID da Habilidade buscada</param>
        /// <returns>A Habilidade buscada</returns>
        Habilidade ListarId(int id);

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com os novos dados</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma Habilidade existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idHabilidade">id da Habilidade que será atualizada</param>
        /// <param name="HabilidadeAtualizada">Objeto HabilidadeAtualizada com os novos dados</param>
        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada);

        /// <summary>
        /// Deleta um Habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID do Habilidade deletado</param>
        void Deletar(int idHabilidade);
    }
}