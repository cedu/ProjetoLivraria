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
    public class EditoraDomainService:IEditoraDomainService
    {
        //atributos
        private readonly IEditoraRepository _editoraRepository;


        //método construtor para injeção de dependência da interface IEditoraRepository
        public EditoraDomainService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public Editora Cadastrar(Editora editora)
        {
            editora.Id = Guid.NewGuid();
            editora.CadastradoEm = DateTime.Now;
            editora.UltimaAtualizacaoEm = DateTime.Now;

            _editoraRepository.Add(editora);

            return editora;
        }

        public Editora Atualizar(Editora editora)
        {
            #region Buscar a editora no banco de dados através do ID

            var editoraEdicao = _editoraRepository.GetById(editora.Id);
            DomainException.When(editoraEdicao == null,
                "A editora é inválida para edição. Verifique o ID informado.");

            #endregion

            #region Alterar os dados da editora

            editoraEdicao.Nome = editora.Nome;
            editoraEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _editoraRepository.Update(editoraEdicao);

            return editoraEdicao;

            #endregion
        }

        public Editora Excluir(Guid id)
        {
            #region Buscar a editora no banco de dados através do ID

            var editoraExclusao = _editoraRepository.GetById(id);
            DomainException.When(editoraExclusao == null,
                "A editora é inválida para exclusão. Verifique o ID informado.");

            #endregion

            #region Excluir a editora

            _editoraRepository.Delete(editoraExclusao);

            return editoraExclusao;

            #endregion
        }

        public Editora? ConsultarPorId(Guid id)
        {
            return _editoraRepository.GetById(id);
        }

        public List<Editora> ConsultarTodos()
        {
            return _editoraRepository.GetAll();
        }
    }
}
