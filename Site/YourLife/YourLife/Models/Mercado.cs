using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Mercado
    {
        public int Id { get; set; }
        public string TipoProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Produto { get; set; }
    }
}