using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Escolha
    {
        public int Id { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }
        public int Consequencia1 { get; set; }
        public int Consequencia2 { get; set; }
    }
}