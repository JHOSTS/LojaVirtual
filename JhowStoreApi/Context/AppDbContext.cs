using JhowStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace JhowStoreApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet <Produto> Produtos { get; set; }
        public DbSet <CarrinhoItem> CarrinhoItens{ get; set; }
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet <Carrinho> Carrinhos { get; set; }
        public DbSet <Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
                {
                    Id = 1,
                    Nome = "Camisas",
                    IconeCategoria = "fa-solid fa-shirt"
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Nome = "Camisa X",
                Descricao = "Camisa streetware lançamento JhowStore.",
                Imagem = "/Imagens/Camisas/sem-imagem.png",
                Preco = 69,
                Quantidade = 15,
                CategoriaId = 1
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
                {
                    Id = 2,
                    Nome = "Meias",
                    IconeCategoria = "fa-solid fa-socks"
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 2,
                Nome = "Meias longas",
                Descricao = "Meias cano alto.",
                Imagem = "/Imagens/Camisas/sem-imagem.png",
                Preco = 20,
                Quantidade = 50,
                CategoriaId = 2
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NomeUsuario = "Jhonnatan"
            });
        }
    }
}
