using AutoMapper;
using Produto.Contrato.Modelo;
using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;
using Produto.Infraestrutura.Interface;

namespace Produto.Infraestrutura.Negocio
{
    public class ProdutoBll : IProdutoBll
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoBll(IProdutoRepository repository, IMapper mapper) 
        {
            _produtoRepository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> CriarProduto(ProdutoForm produtosForm)
        {
            Produtos pro = _mapper.Map<Produtos>(produtosForm);
            await _produtoRepository.AdcionarProdutos(pro);
            return _mapper.Map<ProdutoDto>(pro);
        }

        public void AtualizarProduto(int id, ProdutoForm produtosForm)
        {
            var produto = _mapper.Map<Produtos>(produtosForm);
            produto.Id = id;
            _produtoRepository.AtualizarProduto(produto);
        }

        public async Task DeletaProduto(int id)
        {
            var produto = await _produtoRepository.ObterProdutos(id);
            _produtoRepository.DeletaProduto(produto);
        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
        {
            var listProduto = await _produtoRepository.ObterProdutos();
            List<ProdutoDto> list = new List<ProdutoDto>();
            foreach (var produto in listProduto)
            {
                list.Add(_mapper.Map<ProdutoDto>(produto));
            }
            return list;
        }

        public async Task<ProdutoDto> ObterProdutos(int id)
        {
            var produto = await _produtoRepository.ObterProdutos(id);
            return _mapper.Map<ProdutoDto>(produto);
        }
    }
}
