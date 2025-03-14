using LivrariasApp.API.Configurations.Jwt;
using LivrariasApp.API.Extensions;
using LivrariasApp.API.Mappings;
using LivrariasApp.Domain.Interfaces.Services;
using LivrariasApp.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddCorsConfig();

// Adicionando a configura��o do JWT
JwtConfiguration.Configure(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(cfg => cfg.AddPolicy("defaultPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
    //servidor que poder� acessar a API

    .AllowAnyMethod()

    //permiss�o para acessar os m�todos POST, PUT, DELETE e GET

    .AllowAnyHeader();

    //permiss�o para enviar parametros no cabe�alho

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultPolicy");

app.UseCorsConfig();

app.UseAuthorization();

app.MapControllers();

app.Run();

//tornando a classe Program p�blica
public partial class Program { }
