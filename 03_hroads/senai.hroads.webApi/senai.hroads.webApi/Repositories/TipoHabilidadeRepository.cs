using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizado)
        {
            TipoHabilidade TipoHabilidadeBuscado = ListarId(idTipoHabilidade);

            if (TipoHabilidadeAtualizado.NomeTipoHab != null)
            {
                TipoHabilidadeBuscado.NomeTipoHab = TipoHabilidadeAtualizado.NomeTipoHab;
            }

            ctx.TipoHabilidades.Update(TipoHabilidadeBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidade)
        {
            TipoHabilidade TipoHabilidadeBuscado = ListarId(idTipoHabilidade);

            ctx.TipoHabilidades.Remove(TipoHabilidadeBuscado);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }

        public TipoHabilidade ListarId(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(c => c.IdTipoHab == id);
        }

        List<TipoHabilidade> ITipoHabilidadeRepository.ListarComHabilidades()
        {
            return ctx.TipoHabilidades.Include(Th => Th.Habilidades).OrderBy(Th => Th.IdTipoHab).ToList();
        }
    }
}