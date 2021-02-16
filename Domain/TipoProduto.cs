using System.Collections.Generic;

namespace Domain
{
    public class TipoProduto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public List<Produto> Produtos { get; set; }

    }
}