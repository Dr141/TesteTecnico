using Produto.Contrato.Modelo;

namespace Produto.Infraestrutura.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> ObterProdutos();
        Task<Produtos> ObterProdutos(int id);
        void DeletaProduto(Produtos produto);
        void AtualizarProduto(Produtos produto);
        Task AdcionarProdutos(Produtos produto);
    }
}
