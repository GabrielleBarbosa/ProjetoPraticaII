using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Escolha
    {
        private int codEscolha;
        private string opcao1;
        private string opcao2;
        private int consequencia1;
        private int consequencia2;

        public Escolha ()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodEscolha { get => codEscolha; set => codEscolha = value; }
        public string Opcao1 { get => opcao1; set => opcao1 = value; }
        public string Opcao2 { get => opcao2; set => opcao2 = value; }
        public int Consequencia1 { get => consequencia1; set => consequencia1 = value; }
        public int Consequencia2 { get => consequencia2; set => consequencia2 = value; }
    }
}