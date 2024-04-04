using JhosStoreModels.DTOs;
using JhowStoreApi.Entities;

namespace JhowStoreApi.Mappings
{
    public static class MappingDto
    {
        public static IEnumerable<CategoriaDto> ConverterCategoriaParaDto(
            this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        IconeCategoria = categoria.IconeCategoria,
                    }).ToList();
        }

        public static IEnumerable<ProdutoDto> ConverteProdutoParaDto(
            this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDto
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        Imagem = produto.Imagem,
                        CategoriaId = produto.CategoriaId,
                        Preco = produto.Preco,
                        Quantidade = produto.Quantidade,
                        CategoriaNome = produto.Categoria?.Nome
                    }).ToList();
        }
        public static ProdutoDto ConverteProdutoParaDto (this Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Imagem = produto.Imagem,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria?.Nome
            };
        }
        public static IEnumerable<CarrinhoItemDto> ConverteCarrinhoItensParaDto(
        this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDto
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoImagemUrl = produto.Imagem,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                    }).ToList();
        }
        public static CarrinhoItemDto ConverteCarrinhoItemParaDto(this CarrinhoItem carrinhoItem, Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoImagemUrl = produto.Imagem,
                Preco = produto.Preco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade,
                PrecoTotal = produto.Preco * carrinhoItem.Quantidade
            };
        }
    }
}
