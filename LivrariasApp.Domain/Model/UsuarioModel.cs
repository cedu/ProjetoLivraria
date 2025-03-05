using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Model
{
    public class UsuarioModel
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public DateTime? DataNascimento { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime? DataHoraCriacao { get; set; }
    }
}
