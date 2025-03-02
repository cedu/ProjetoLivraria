namespace LivrariasApp.API.Models
{
    /// <summary>
    /// Modelo de dados para usuário
    /// </summary>
    public class Usuarios
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        #endregion

        #region Mock dos dados do usuário

        public static Usuarios MockUsuario()
        {
            return new Usuarios
            {
                Id = Guid.NewGuid(),
                Nome = "Usuário Teste",
                Email = "usuario@teste.com.br",
                Senha = "@Teste123"
            };
        }

        #endregion
    }
}
