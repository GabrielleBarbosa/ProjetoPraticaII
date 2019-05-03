using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Mercado
    {
        
        public string produto { get; set; }
        public string descricao { get; set; }
        public int id { get; set; }
        public float preco { get; set; }
        public string tipoProduto { get; set; }
    }
}