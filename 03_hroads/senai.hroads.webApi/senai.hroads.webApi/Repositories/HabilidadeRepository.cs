using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada)
        {
            Habilidade HabilidadeBuscada = ListarId(idHabilidade);

            if (HabilidadeAtualizada.IdTipoHab != null && HabilidadeAtualizada.NomeHabilidade != null)
            {
                HabilidadeBuscada.IdTipoHab = HabilidadeAtualizada.IdTipoHab;
                HabilidadeBuscada.NomeHabilidade = HabilidadeAtualizada.NomeHabilidade;
            }

            ctx.Habilidades.Update(HabilidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            Habilidade HabilidadeBuscada = ListarId(idHabilidade);

            ctx.Habilidades.Remove(HabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        public Habilidade ListarId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidade == id);
        }

        public List<Habilidade> ListarComClasseHabilidades()
        {
            return ctx.Habilidades.Include(c => c.ClasseHabilidades).ToList();
        }
    }
}