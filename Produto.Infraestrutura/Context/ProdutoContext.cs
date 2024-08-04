using Microsoft.EntityFrameworkCore;
using Produto.Contrato.Modelo;

namespace Produto.Infraestrutura.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }
        public DbSet<Produtos> Produtos {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql()
                         .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.UseIdentityByDefaultColumns();
    }
}
