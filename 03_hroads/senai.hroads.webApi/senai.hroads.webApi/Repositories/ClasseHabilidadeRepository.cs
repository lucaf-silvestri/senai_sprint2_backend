using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasseHabilidade, ClasseHabilidade ClasseHabilidadeAtualizada)
        {
            ClasseHabilidade ClasseHabilidadeBuscada = ListarId(idClasseHabilidade);

            if (ClasseHabilidadeAtualizada.IdClasse != null && ClasseHabilidadeAtualizada.IdHabilidade != null)
            {
                ClasseHabilidadeBuscada.IdClasse = ClasseHabilidadeAtualizada.IdClasse;
                ClasseHabilidadeBuscada.IdHabilidade = ClasseHabilidadeAtualizada.IdHabilidade;
            }

            ctx.ClasseHabilidades.Update(ClasseHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            ctx.ClasseHabilidades.Add(novaClasseHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasseHabilidade)
        {
            ClasseHabilidade ClasseHabilidadeBuscada = ListarId(idClasseHabilidade);

            ctx.ClasseHabilidades.Remove(ClasseHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> Listar()
        {
            return ctx.ClasseHabilidades.ToList();
        }

        public ClasseHabilidade ListarId(int id)
        {
            return ctx.ClasseHabilidades.FirstOrDefault(c => c.IdClasseHabilidade == id);
        }
    }
}