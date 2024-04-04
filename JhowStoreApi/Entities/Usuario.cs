using System.ComponentModel.DataAnnotations;

namespace JhowStoreApi.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? NomeUsuario { get; set; } = String.Empty;

        public Carrinho? Carrinho { get; set; }
    }
}
