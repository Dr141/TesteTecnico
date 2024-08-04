using Produto.Contrato.Enum;

namespace Produto.Contrato.Modelo.Dto
{
    public record ProdutoDto(int Id, string Nome, TipoProdutoEnum Tipo, decimal PrecoUnitario);
}
