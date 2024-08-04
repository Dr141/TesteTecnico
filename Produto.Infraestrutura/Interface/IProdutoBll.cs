using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;

namespace Produto.Infraestrutura.Interface
{
    public interface IProdutoBll
    {
        Task<ProdutoDto> CriarProduto(ProdutoForm produtos);
        void AtualizarProduto(int id, ProdutoForm produtos);
        Task DeletaProduto(int id);
        Task<IEnumerable<ProdutoDto>> ObterProdutos();
        Task<ProdutoDto> ObterProdutos(int id);
    }
}
