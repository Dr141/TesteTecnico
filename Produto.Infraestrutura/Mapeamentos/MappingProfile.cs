using AutoMapper;
using Produto.Contrato.Modelo;
using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;

namespace Produto.Infraestrutura.Mapeamentos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produtos, ProdutoDto>();
            CreateMap<ProdutoDto, Produtos>();
            CreateMap<Produtos, ProdutoForm>();
            CreateMap<ProdutoForm, Produtos>();
        }
    }
}
