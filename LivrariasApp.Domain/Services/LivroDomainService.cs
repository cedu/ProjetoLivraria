using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Domain.Interfaces.Services;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Services
{
    public class LivroDomainService:ILivroDomainService
    {
        //atributos
        private readonly ILivroRepository _livroRepository;

        //método construtor para injeção de dependência da interface ITarefaRepository
        public LivroDomainService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Cadastrar(Livro livro)
        {
            _livroRepository.Add(livro);
        }

        public void Atualizar(Livro livro)
        {
            _livroRepository.Update(livro);
        }

        public void Excluir(Guid id)
        {
            var livro = _livroRepository.GetById(id);
            _livroRepository.Delete(livro);
        }

        public Livro? ConsultarPorId(Guid id)
        {
            return _livroRepository.GetById(id);
        }

        public List<Livro> ConsultarTodos()
        {
            return _livroRepository.GetAll();
        }
    }
}
