using JhosStoreModels.DTOs;

namespace JhowStore.Web.Services
{
    public interface IProdutoService
    {
        public Task<IEnumerable<ProdutoDto>> GetItens();
        public Task<ProdutoDto> GetItem(int id);
    }
}
