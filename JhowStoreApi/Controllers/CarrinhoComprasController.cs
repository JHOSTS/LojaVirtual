using JhosStoreModels.DTOs;
using JhowStore.Repositories;
using JhowStoreApi.Mappings;
using JhowStoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JhowStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoComprasController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository carrinhoCompraRepo;
        private readonly IProdutoRepository produtoRepo;
        public CarrinhoComprasController(ICarrinhoCompraRepository carrinhoCompraRepository, IProdutoRepository produtoRepository)
        {
            carrinhoCompraRepo = carrinhoCompraRepository;
            produtoRepo = produtoRepository;
        }

        [HttpGet]
        [Route("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens(string usuarioId)
        {
            try
            {
                var carrinhoItens = await carrinhoCompraRepo.GetItens(usuarioId);
                if (carrinhoItens == null)
                    return NoContent();

                var produtos = await this.produtoRepo.GetItens();
                if (produtos == null)
                    throw new Exception("Não há produtos...");

                var carrinhoItensDto = carrinhoItens.ConverteCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{usuarioId:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetItem(int id)
        {
            try
            {
                var carrinhoItem = await carrinhoCompraRepo.GetItem(id);
                if (carrinhoItem == null)
                    return NotFound("Produto não encontrado!");

                var produto = await produtoRepo.GetItem(carrinhoItem.ProdutoId);
                if (produto == null)
                    throw new Exception("Não há produtos...");

                var carrinhoItensDto = carrinhoItem.ConverteCarrinhoItemParaDto(produto);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItem([FromBody]
        CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await carrinhoCompraRepo.AdicionaItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem == null)
                {
                    return NoContent();
                }

                var produto = await produtoRepo.GetItem(novoCarrinhoItem.ProdutoId);

                if (produto == null)
                {
                    throw new Exception($"Produto não localizado (Id:({carrinhoItemAdicionaDto.ProdutoId})");
                }

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverteCarrinhoItemParaDto(produto);

                return Ok(novoCarrinhoItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> DeleteItem(int id)
        {
            try
            {
                var carrinhoItem = await carrinhoCompraRepo.DeletaItem(id);
                if (carrinhoItem == null)
                {
                    return NotFound();
                }

                var produto = await produtoRepo.GetItem(carrinhoItem.ProdutoId);
                if (produto == null)
                {
                    return NotFound();
                }

                var carrinhoItemDto = carrinhoItem.ConverteCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> AtualizaQuantidade(int id,
        CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {

                var carrinhoItem = await carrinhoCompraRepo.AtualizaQuantidade(id,
                                       carrinhoItemAtualizaQuantidadeDto);

                if (carrinhoItem == null)
                {
                    return NotFound();
                }
                var produto = await produtoRepo.GetItem(carrinhoItem.ProdutoId);
                var carrinhoItemDto = carrinhoItem.ConverteCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
