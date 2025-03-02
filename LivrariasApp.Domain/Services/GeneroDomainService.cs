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
    public class GeneroDomainService:IGeneroDomainService
    {
        //atributos
        private readonly IGeneroRepository _generoRepository;


        //método construtor para injeção de dependência da interface IGeneroRepository
        public GeneroDomainService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public Genero Cadastrar(Genero genero)
        {
            genero.Id = Guid.NewGuid();
            genero.CadastradoEm = DateTime.Now;
            genero.UltimaAtualizacaoEm = DateTime.Now;

            _generoRepository.Add(genero);

            return genero;
        }

        public Genero Atualizar(Genero genero)
        {
            #region Buscar o genero no banco de dados através do ID

            //var editoraEdicao = _editoraRepository.GetById(editora.Id);
            //DomainException.When(editoraEdicao == null,
            //    "A editora é inválida para edição. Verifique o ID informado.");

            //#endregion

            //#region Alterar os dados da editora

            //editoraEdicao.Nome = editora.Nome;
            //editoraEdicao.UltimaAtualizacaoEm = DateTime.Now;

            //_editoraRepository.Update(editoraEdicao);

            //return editoraEdicao;

            return genero;

            #endregion
        }

        public Genero Excluir(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero? ConsultarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Genero> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
