using Produto.Contrato.Enum;
using System.ComponentModel.DataAnnotations;

namespace Produto.Contrato.Modelo.Formulario
{
    public class ProdutoForm
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public TipoProdutoEnum Tipo { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }
    }
}
