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

            var generoEdicao = _generoRepository.GetById(genero.Id);
            DomainException.When(generoEdicao == null,
                "O gênero é inválido para edição. Verifique o ID informado.");

            #endregion

            #region Alterar os dados do genero

            generoEdicao.Nome = genero.Nome;
            generoEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _generoRepository.Update(generoEdicao);

            return generoEdicao;

            #endregion
        }

        public Genero Excluir(Guid id)
        {
            #region Buscar o genero no banco de dados através do ID

            var generoExclusao = _generoRepository.GetById(id);
            DomainException.When(generoExclusao == null,
                "O gênero é inválido para exclusão. Verifique o ID informado.");

            #endregion

            #region Excluir o gênero

            _generoRepository.Delete(generoExclusao);

            return generoExclusao;

            #endregion
        }

        public Genero? ConsultarPorId(Guid id)
        {
            return _generoRepository.GetById(id);
        }

        public List<Genero> ConsultarTodos()
        {
            return _generoRepository.GetAll();
        }
    }
}
