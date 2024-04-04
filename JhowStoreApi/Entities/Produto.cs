using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhowStoreApi.Entities
{
    public class Produto
    {
        public int Id{ get; set; }
        [MaxLength(50)]
        public string? Nome { get; set; }
        [MaxLength(200)]
        public string? Descricao { get; set;} = String.Empty;
        [MaxLength(200)]
        public string? Imagem { get; set;} = String.Empty;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco{ get; set;}
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; }
        = new List<CarrinhoItem>();
    }
}
