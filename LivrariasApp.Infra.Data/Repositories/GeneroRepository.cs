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
    public class GeneroRepository:IGeneroRepository
    {
        public void Add(Genero genero)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(genero);
                dataContext.SaveChanges();
            }
        }

        public void Update(Genero genero)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(genero);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Genero genero)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(genero);
                dataContext.SaveChanges();
            }
        }

        public Genero? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Genero>().FirstOrDefault();
            }
        }

        public List<Genero> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Genero>().ToList();
            }
        }
    }
}
