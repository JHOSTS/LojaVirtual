using JhowStoreApi.Entities;

namespace JhowStore.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetItem(int id);
        Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
    }
}
