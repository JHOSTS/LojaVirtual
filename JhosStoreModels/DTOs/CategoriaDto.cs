using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhosStoreModels.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string IconeCategoria { get; set; } = String.Empty;
    }
}
