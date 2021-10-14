using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idPersonagem, Personagem PersonagemAtualizado)
        {
            Personagem PersonagemBuscado = ListarId(idPersonagem);

            if (PersonagemBuscado != null)
            {
                PersonagemBuscado.IdClasse = PersonagemAtualizado.IdClasse;
                PersonagemBuscado.Nome = PersonagemAtualizado.Nome;
                PersonagemBuscado.MaxVida = PersonagemAtualizado.MaxVida;
                PersonagemBuscado.MaxMana = PersonagemAtualizado.MaxMana;
                PersonagemBuscado.DataAtualizacao = PersonagemAtualizado.DataAtualizacao;
                PersonagemBuscado.DataCriacao = PersonagemAtualizado.DataCriacao;
            }

            ctx.Personagems.Update(PersonagemBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            Personagem PersonagemBuscado = ListarId(idPersonagem);

            ctx.Personagems.Remove(PersonagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.ToList();
        }

        public Personagem ListarId(int id)
        {
            return ctx.Personagems.FirstOrDefault(c => c.IdPersonagem == id);
        }
    }
}