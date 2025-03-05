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
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(usuario);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(usuario);
                dataContext.SaveChanges();
            }
        }

        public Usuario? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>().FirstOrDefault();
            }
        }

        public List<Usuario> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>().ToList();
            }
        }

        public Usuario? GetByEmail(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Usuario>().Where(u => u.Email == email).FirstOrDefault();
            }
        }
    }
}
