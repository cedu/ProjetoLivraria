using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Services
{
    public interface IEditoraDomainService
    {
        Editora Cadastrar(Editora editora);
        Editora Atualizar(Editora editora);
        Editora Excluir(Guid id);
        Editora? ConsultarPorId(Guid id);
        List<Editora> ConsultarTodos();
    }
}
