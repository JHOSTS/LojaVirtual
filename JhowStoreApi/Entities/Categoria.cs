using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace JhowStoreApi.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; } = String.Empty;
        [MaxLength(50)]
        public string IconeCategoria { get; set;} = String.Empty;
        
        public Collection<Produto> Produtos { get; set; }
        = new Collection<Produto>();
    }

}
