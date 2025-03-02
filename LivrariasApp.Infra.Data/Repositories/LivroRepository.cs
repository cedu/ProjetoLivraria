using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Infra.Data.Contexts;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Infra.Data.Repositories
{
    public class LivroRepository:ILivroRepository
    {
        public void Add(Livro livro)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(livro);
                dataContext.SaveChanges();
            }
        }

        public void Update(Livro livro)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(livro);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Livro livro)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(livro);
                dataContext.SaveChanges();
            }
        }

        public List<Livro> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Livro>().ToList();
            }
        }

        public Livro? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Livro>().FirstOrDefault();
            }
        }
    }
}
