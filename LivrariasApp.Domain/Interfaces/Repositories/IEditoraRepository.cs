using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Repositories
{
    public interface IEditoraRepository
    {
        void Add(Editora editora);
        void Update(Editora editora);
        void Delete(Editora editora);
        Editora? GetById(Guid id);
        List<Editora> GetAll();
    }
}
