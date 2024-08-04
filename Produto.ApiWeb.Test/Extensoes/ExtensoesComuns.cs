using Produto.Contrato.Modelo;
using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;

namespace Produto.ApiWeb.Test.Extensoes
{
    public static class ExtensoesComuns
    {
        public static Produtos ObjetoProduto()
        {
            return new Produtos
            {
                Id = 1,
                Nome = "Avell",
                PrecoUnitario = 10.00m,
                Tipo = Contrato.Enum.TipoProdutoEnum.Produto
            };
        }

        public static ProdutoDto ObjetoProdutoDto()
        {
            return new ProdutoDto(1, "Avell", Contrato.Enum.TipoProdutoEnum.Produto, 10.00m);
        }

        public static ProdutoForm ObjetoProdutoForm()
        {
            return new ProdutoForm
            {
                Nome = "Avell",
                PrecoUnitario = 10.00m,
                Tipo = Contrato.Enum.TipoProdutoEnum.Produto
            };
        }

        public static async Task<IEnumerable<Produtos>> ObjetoListProduto()
        {
            return await Task.FromResult(
                new List<Produtos>
            {
                new Produtos
                {
                    Id = 1,
                    Nome = "Avell",
                    PrecoUnitario = 10.00m,
                    Tipo = Contrato.Enum.TipoProdutoEnum.Produto
                },
                new Produtos
                {
                    Id = 2,
                    Nome = "Aoc",
                    PrecoUnitario = 55.00m,
                    Tipo = Contrato.Enum.TipoProdutoEnum.Produto
                },
            });
        }

        public static List<ProdutoDto> ObjetoListProdutoDto()
        {
            return new List<ProdutoDto>
            {
                new ProdutoDto(1, "Avell", Contrato.Enum.TipoProdutoEnum.Produto, 10.00m),
                new ProdutoDto(2, "Aoc", Contrato.Enum.TipoProdutoEnum.Produto, 55.00m)
            };
        }

    }
}
