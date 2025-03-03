using LivrariasApp.Domain.Exceptions;
using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Domain.Interfaces.Services;
using LivrariasApp.Domain.Models;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Services
{
    public class UsuarioDomainService:IUsuarioDomainService
    {
        //atributos
        private readonly IUsuarioRepository _usuarioRepository;


        //método construtor para injeção de dependência da interface IUsuarioRepository
        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            // Validações
            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new ArgumentException("O email do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new ArgumentException("A senha do usuário não pode ser vazia.");
            }

            usuario.Id = Guid.NewGuid();
            usuario.CadastradoEm = DateTime.Now;
            usuario.UltimaAtualizacaoEm = DateTime.Now;

            // Cadastro do usuário
            try
            {
                _usuarioRepository.Add(usuario);
            }
            catch (Exception ex)
            {
                // Lidar com a exceção, por exemplo, registrar o erro ou lançar uma exceção personalizada
                throw new Exception("Erro ao cadastrar o usuário.", ex);
            }

            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            #region Buscar o usuario no banco de dados através do ID

            var usuarioEdicao = _usuarioRepository.GetById(usuario.Id);
            DomainException.When(usuarioEdicao == null,
                "O usuário é inválido para edição. Verifique o ID informado.");

            #endregion

            #region Alterar os dados do usuario

            usuarioEdicao.Nome = usuario.Nome;
            usuarioEdicao.Email = usuario.Email;
            usuarioEdicao.Senha = usuario.Senha;
            usuarioEdicao.DataNascimento = usuario.DataNascimento;
            usuarioEdicao.IsAdmin = usuario.IsAdmin;
            usuarioEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _usuarioRepository.Update(usuarioEdicao);

            return usuarioEdicao;

            #endregion
        }

        public Usuario Excluir(Guid id)
        {
            #region Buscar o usuario no banco de dados através do ID

            var usuarioExclusao = _usuarioRepository.GetById(id);
            DomainException.When(usuarioExclusao == null,
                "O usuário é inválido para exclusão. Verifique o ID informado.");

            #endregion

            #region Excluir o usuario

            _usuarioRepository.Delete(usuarioExclusao);

            return usuarioExclusao;

            #endregion

        }

        public Usuario? ConsultarPorId(Guid id)
        {
            return _usuarioRepository.GetById(id);
        }

        public List<Usuario> ConsultarTodos()
        {
            return _usuarioRepository.GetAll();
        }
    }
}
