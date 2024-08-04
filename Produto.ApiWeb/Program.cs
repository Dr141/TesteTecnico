using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Produto.ApiWeb.Extensoes;
using Produto.Infraestrutura.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Técnico", Version = "v1" });
    c.UseInlineDefinitionsForEnums(); 
});

builder.Services.AddDbContext<ProdutoContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("ProdutosContext")));
builder.Services.RegistrarDependencias();
var app = builder.Build();
app.Services.Migrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
