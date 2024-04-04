using System.ComponentModel.DataAnnotations;

namespace JhosStoreModels.DTOs
{
    public class CarrinhoItemAdicionaDto
    {
        [Required]
        public int CarrinhoId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
