using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Mercado
    {
        private int codProduto;
        private string compra;
        private double preco;

        public Mercado()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodProduto { get => codProduto; set => codProduto = value; }
        public string Compra { get => compra; set => compra = value; }
        public double Preco { get => preco; set => preco = value; }
    }
}