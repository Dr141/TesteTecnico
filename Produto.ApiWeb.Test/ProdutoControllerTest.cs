using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Produto.ApiWeb.Controllers;
using Produto.ApiWeb.Test.Extensoes;
using Produto.Contrato.Modelo;
using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;
using Produto.Infraestrutura.Interface;
using Produto.Infraestrutura.Negocio;

namespace Produto.ApiWeb.Test
{
    public class ProdutoControllerTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly ProdutoBll _produtoBll;
        private readonly ProdutoController _controller;

        public ProdutoControllerTest()
        {
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _produtoBll = new ProdutoBll(_mockProdutoRepository.Object, _mockMapper.Object);
            _controller = new ProdutoController(_produtoBll);
        }

        [Fact]
        public async void GetTest()
        {
            _mockProdutoRepository.Setup(rep => rep.ObterProdutos()).Returns(ExtensoesComuns.ObjetoListProduto());
            var produtoDto = ExtensoesComuns.ObjetoListProdutoDto();

            _mockMapper.Setup(m => m.Map<ProdutoDto>(It.IsAny<Produtos>())).Returns(((Produtos pro) => produtoDto.Find(vm => vm.Id == pro.Id)));

            var retorno = await _controller.Get();
            var resutlValue = Assert.IsAssignableFrom<IEnumerable<ProdutoDto>>(retorno);
            Assert.Equal(produtoDto, resutlValue);            
        }

        [Fact]
        public async void GetIdTest()
        {
            int id = 1;
            _mockProdutoRepository.Setup(rep => rep.ObterProdutos(id)).Returns(Task.FromResult(ExtensoesComuns.ObjetoProduto()));
            var produtoDto = ExtensoesComuns.ObjetoListProdutoDto();

            _mockMapper.Setup(m => m.Map<ProdutoDto>(It.IsAny<Produtos>())).Returns(((Produtos pro) => produtoDto.Find(vm => vm.Id == pro.Id)));

            var retorno = await _controller.Get(id);
            var resutlValue = Assert.IsAssignableFrom<ProdutoDto>(retorno);
            Assert.Equal(produtoDto.First(px => px.Id.Equals(id)), resutlValue);
        }

        [Fact]
        public async void PostTest()
        {
            var expectedId = 1;
            var produto = ExtensoesComuns.ObjetoProduto();
            var produtoDto = ExtensoesComuns.ObjetoProdutoDto();
            var produtoForm = ExtensoesComuns.ObjetoProdutoForm();
            _mockProdutoRepository.Setup(rep => rep.AdcionarProdutos(produto));
            _mockMapper.Setup(m => m.Map<Produtos>(It.IsAny<ProdutoForm>())).Returns(produto);
            _mockMapper.Setup(m => m.Map<ProdutoDto>(It.IsAny<Produtos>())).Returns(produtoDto);
            var retorno = await _controller.Post(produtoForm);
            var okResult = Assert.IsType<OkObjectResult>(retorno.Result);
            var value = Assert.IsType<string>(okResult.Value);
            Assert.StartsWith("Produto criado com sucesso. Id =", value);
            Assert.Contains(expectedId.ToString(), value);
        }

        [Fact]
        public void PutTest()
        {
            var id = 1;
            var produto = ExtensoesComuns.ObjetoProduto();
            var produtoDto = ExtensoesComuns.ObjetoProdutoDto();
            var produtoForm = ExtensoesComuns.ObjetoProdutoForm();
            _mockProdutoRepository.Setup(rep => rep.AtualizarProduto(produto));
            _mockMapper.Setup(m => m.Map<Produtos>(It.IsAny<ProdutoForm>())).Returns(produto);
            var retorno = _controller.Put(id, produtoForm);
            var okResult = Assert.IsType<OkObjectResult>(retorno.Result);
            var value = Assert.IsType<string>(okResult.Value);
            Assert.StartsWith("Produto atualizado com sucesso.", value);
        }

        [Fact]
        public async void DeleteTest()
        {
            var produto = ExtensoesComuns.ObjetoProduto();
            var id = 1;
            _mockProdutoRepository.Setup(rep => rep.ObterProdutos(id)).Returns(Task.FromResult(produto));
            _mockProdutoRepository.Setup(rep => rep.DeletaProduto(produto));
            
            var retorno = await _controller.Delete(id);
            var okResult = Assert.IsType<OkObjectResult>(retorno.Result);
            var value = Assert.IsType<string>(okResult.Value);
            Assert.StartsWith("Produto deletado com sucesso.", value);
        }
    }
}
