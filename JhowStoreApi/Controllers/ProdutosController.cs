using JhosStoreModels.DTOs;
using JhowStore.Repositories;
using JhowStoreApi.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace JhowStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItems()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos == null)
                {
                    return NotFound("Produtos não localizados!");
                }
                else
                {
                    var produtosDto = produtos.ConverteProdutoParaDto();
                    return Ok(produtosDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados!");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItem(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetItem(id);
                if (produto == null)
                {
                    return NotFound("Produto não localizado!");
                }
                else
                {
                    var produtosDto = produto.ConverteProdutoParaDto();
                    return Ok(produtosDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados!");
            }
        }
        [HttpGet]
        [Route("GetItensPorCategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
                var produtosDto = produtos.ConverteProdutoParaDto();
                return Ok(produtosDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados!");
            }
        }
    }
}
