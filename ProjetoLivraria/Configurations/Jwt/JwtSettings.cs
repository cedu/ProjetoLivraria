namespace LivrariasApp.API.Configurations.Jwt
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public int? Expiration { get; set; }
    }
}
