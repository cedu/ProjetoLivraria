using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Infra.Data.Repositories
{
    public class EditoraRepository: IEditoraRepository
    {
        public void Add(Editora editora)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Add(editora);
                dataContext.SaveChanges();
            }
        }

        public void Update(Editora editora)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(editora);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Editora editora)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(editora);
                dataContext.SaveChanges();
            }
        }

        public Editora? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Editora>().FirstOrDefault();
            }
        }

        public List<Editora> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Editora>().ToList();
            }
        }
    }
}
