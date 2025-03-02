using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Interfaces.Services
{
    public interface IGeneroDomainService
    {
        Genero Cadastrar(Genero genero);
        Genero Atualizar(Genero genero);
        Genero Excluir(Genero genero);
        Genero? ConsultarPorId(Guid id);
        List<Genero> ConsultarTodos();
    }
}
