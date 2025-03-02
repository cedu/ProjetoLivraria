using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Services
{
    public interface ILivroDomainService
    {
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        void Excluir(Guid id);
        Livro? ConsultarPorId(Guid id);
        List<Livro> ConsultarTodos();
    }
}
