using Microsoft.EntityFrameworkCore;
using Produto.Infraestrutura.Context;
using Produto.Infraestrutura.Interface;
using Produto.Infraestrutura.Mapeamentos;
using Produto.Infraestrutura.Negocio;
using Produto.Infraestrutura.Repository;

namespace Produto.ApiWeb.Extensoes
{
    public static class CollectionExtensions
    {
        public static void RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoBll, ProdutoBll>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        public static void Migrations(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
