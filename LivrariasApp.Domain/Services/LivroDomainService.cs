using LivrariasApp.Domain.Exceptions;
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

        //método construtor para injeção de dependência da interface ILivroRepository
        public LivroDomainService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public Livro Cadastrar(Livro livro)
        {
            livro.Id = Guid.NewGuid();
            livro.CadastradoEm = DateTime.Now;
            livro.UltimaAtualizacaoEm = DateTime.Now;

            _livroRepository.Add(livro);

            return livro;
        }

        public Livro Atualizar(Livro livro)
        {
            #region Buscar o livro no banco de dados através do ID

            var livroEdicao = _livroRepository.GetById(livro.Id);
            DomainException.When(livroEdicao == null,
                "O livro é inválido para edição. Verifique o ID informado.");

            #endregion

            #region

            livroEdicao.Titulo = livro.Titulo;
            livroEdicao.ISBN = livro.ISBN;
            livroEdicao.Autor = livro.Autor;
            livroEdicao.Sinopse = livro.Sinopse;
            livroEdicao.CaminhoImagem = livro.CaminhoImagem;
            livroEdicao.GeneroId = livro.GeneroId;
            livroEdicao.EditoraId = livro.EditoraId;
            livroEdicao.UsuarioId = livro.UsuarioId;

            // Adicionando a atualização da data de última atualização
            livroEdicao.UltimaAtualizacaoEm = DateTime.Now;

            #endregion

            #region Salvar alterações e retornar livro atualizado

            try
            {
                _livroRepository.Update(livroEdicao); // Usando livroEdicao aqui
            }
            catch (Exception ex)
            {
                // Lidar com a exceção, por exemplo, registrar o erro ou lançar uma exceção personalizada
                throw new Exception("Erro ao atualizar o livro.", ex);
            }

            return livroEdicao;

            #endregion

        }

        public Livro Excluir(Guid id)
        {
            #region Buscar o livro no banco de dados através do ID

            var livroExclusao = _livroRepository.GetById(id);
            DomainException.When(livroExclusao == null,
                "O livro é inválida para exclusão. Verifique o ID informado.");

            #endregion

            #region Excluir o livro

            _livroRepository.Delete(livroExclusao);

            return livroExclusao;

            #endregion
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
