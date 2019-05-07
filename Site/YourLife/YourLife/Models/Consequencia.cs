using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Consequencia
    {
        public int CodConsequencia { get ; set; }
        public string Cenario { get; set; }
        public int PontosGanho { get; set; }
        public string TipoDoPontoGanho { get; set; }
        public string TipoDoPontoPerdido { get; set; }
        public int PontosPerdido { get; set; }
    }
}