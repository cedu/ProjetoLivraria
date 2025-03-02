using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        void Add(Livro livro);
        void Update(Livro livro);
        void Delete(Livro livro);
        List<Livro> GetAll();
        Livro? GetById(Guid id);
    }
}
