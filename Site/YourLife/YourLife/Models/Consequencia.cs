using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Consequencia
    {
        public int Id { get ; set; }
        public string Cenario { get; set; }
        public int PontosGanhos { get; set; }
        public string TipoDoPontoGanho { get; set; }
        public string TipoDoPontoPerdido { get; set; }
        public int PontosPerdidos { get; set; }
    }
}