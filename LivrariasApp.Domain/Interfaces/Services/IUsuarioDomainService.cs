using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        Usuario Excluir(Guid id);
        Usuario? ConsultarPorId(Guid id);
        List<Usuario> ConsultarTodos();
    }
}
