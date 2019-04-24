using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Mercado
    {
        private string produto;
        private string descricao;
        private float preco;

        public Mercado()
        {
        }

        public float Preco { get => preco; set => preco = value; }
        public string Produto { get => produto; set => produto = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}