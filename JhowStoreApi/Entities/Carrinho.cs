﻿using System.Collections.ObjectModel;

namespace JhowStoreApi.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; }
        = new List<CarrinhoItem>();
    }
}
