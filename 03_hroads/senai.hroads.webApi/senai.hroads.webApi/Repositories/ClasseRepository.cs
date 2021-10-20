using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasse, Classe ClasseAtualizada)
        {
            Classe ClasseBuscada = ListarId(idClasse);

            if (ClasseAtualizada.NomeClasse != null)
            {
                ClasseBuscada.NomeClasse = ClasseAtualizada.NomeClasse;
            }

            ctx.Classes.Update(ClasseBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            Classe classeBuscada = ListarId(idClasse);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }

        public Classe ListarId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public List<Classe> ListarComPersonagens()
        {
            return ctx.Classes.Include(c => c.Personagems).ToList();
        }

        public List<Classe> ListarComClasseHabilidades()
        {
            return ctx.Classes.Include(c => c.ClasseHabilidades).ToList();
        }
    }
}