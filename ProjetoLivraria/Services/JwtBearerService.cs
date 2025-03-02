using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivrariasApp.API.Services
{
    /// <summary>
    /// Classe de serviço para gerarmos tokens JWT
    /// </summary>
    public class JwtBearerService
    {
        #region Propriedades

        public static string SecretKey => "9E9A1D53-A504-47B4-ADAA-2E585B067C5B";
        public static int ExpirationInHours => 1;

        #endregion

        /// <summary>
        /// Método para fazer a geração do TOKEN JWT
        /// </summary>
        public static string GenerateToken(Guid usuarioId)
        {
            //criando os parametros para geração do TOKEN
            var jwtSecurityToken = new JwtSecurityToken(
                    claims: CreateClaims(usuarioId), //dados do usuário que será gravado no token
                    signingCredentials: CreateCredentials(), //assinatura do token (chave criptografada)
                    expires: CreateExpiration() //tempo de expiração do token
                );

            //gerar e retornando o TOKEN JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }

        /// <summary>
        /// método para gerar a data e hora de expiração do TOKEN
        /// </summary>
        private static DateTime? CreateExpiration()
        {
            return DateTime.Now.AddHours(Convert.ToDouble(ExpirationInHours));
        }

        /// <summary>
        /// Método para gerar a chave secreta do token (chave criptografada)
        /// </summary>
        private static SigningCredentials? CreateCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Método para gravar a identificação do usuário no TOKEN
        /// </summary>
        private static Claim[] CreateClaims(Guid usuarioId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuarioId.ToString())
            };

            return claims;
        }

    }
}
