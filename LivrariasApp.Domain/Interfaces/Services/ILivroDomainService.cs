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
        Livro Cadastrar(Livro livro);
        Livro Atualizar(Livro livro);
        Livro Excluir(Guid id);
        Livro? ConsultarPorId(Guid id);
        List<Livro> ConsultarTodos();
    }
}
