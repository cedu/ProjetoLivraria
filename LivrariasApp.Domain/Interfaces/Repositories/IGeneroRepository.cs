using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Repositories
{
    public interface IGeneroRepository
    {
        void Add(Genero genero);
        void Update(Genero genero);
        void Delete(Genero genero);
        Genero? GetById(Guid id);
        List<Genero> GetAll();
    }
}
