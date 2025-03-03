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
                return dataContext.Set<Livro>()
                    .Include(l => l.Usuario) // Inclui os dados do usuário relacionado
                    .Include(l => l.Genero) // inclui os dados do genero relacionado
                    .Include(l => l.Editora) // inclui os dados da editora relacionado
                    .AsNoTracking() 
                    .FirstOrDefault(l => l.Id == id);
            }
        }
    }
}
