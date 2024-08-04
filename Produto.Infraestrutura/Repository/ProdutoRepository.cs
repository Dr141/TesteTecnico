using Produto.Contrato.Modelo;
using Produto.Infraestrutura.Context;
using Produto.Infraestrutura.Interface;

namespace Produto.Infraestrutura.Repository
{
    public class ProdutoRepository : Repository<Produtos>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoContext pContext) : base(pContext)
        {
        }

        public async Task AdcionarProdutos(Produtos produto)
        {
            await AddAsync(produto);
        }

        public void AtualizarProduto(Produtos produto)
        {
            Update(produto);
        }

        public void DeletaProduto(Produtos produto)
        {
            Remove(produto);
        }

        public async Task<IEnumerable<Produtos>> ObterProdutos()
        {
            return await GetAllAsync();
        }

        public async Task<Produtos> ObterProdutos(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
