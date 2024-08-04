using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Contrato.Extensoes
{
    public static class CollectionExtensions
    {
        public static void RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<PedidoBll>();
            services.AddScoped<ProtudoBll>();
            return services;
        }
    }
}
