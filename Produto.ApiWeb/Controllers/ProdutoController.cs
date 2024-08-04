using Microsoft.AspNetCore.Mvc;
using Produto.Contrato.Modelo.Dto;
using Produto.Contrato.Modelo.Formulario;
using Produto.Infraestrutura.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Produto.ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoBll _produtoBll;
        public ProdutoController(IProdutoBll produtoBll)
        {
            _produtoBll = produtoBll;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IEnumerable<ProdutoDto>> Get()
        {
            return await _produtoBll.ObterProdutos();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ProdutoDto> Get(int id)
        {
            return await _produtoBll.ObterProdutos(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] ProdutoForm produto)
        {
            try
            {
                ProdutoDto resultado = await _produtoBll.CriarProduto(produto);
                return Ok($"Produto criado com sucesso. Id = {resultado.Id}");
            }
            catch (Exception ex) { return BadRequest($"Ocorreu um erro: {ex.Message}"); }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromForm] ProdutoForm produto)
        {
            try
            {
                _produtoBll.AtualizarProduto(id, produto);
                return Ok("Produto atualizado com sucesso.");
            }
            catch (Exception ex) { return BadRequest($"Ocorreu um erro: {ex.Message}"); }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                await _produtoBll.DeletaProduto(id);
                return Ok("Produto deletado com sucesso.");
            }
            catch (Exception ex) { return BadRequest($"Ocorreu um erro: {ex.Message}"); }
        }
    }
}
