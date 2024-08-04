using Produto.Contrato.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produto.Contrato.Modelo
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }

        [Length(1, 100)]
        public string Nome { get; set; }
        public TipoProdutoEnum Tipo { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal PrecoUnitario { get; set; }
    }
}
