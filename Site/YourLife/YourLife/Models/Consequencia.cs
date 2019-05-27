using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Consequencia
    {
        public int Id { get ; set; }
        public string assunto { get; set; }
        public int PontosGanhos { get; set; }
        public char TipoDoPontoGanho { get; set; }
        public char TipoDoPontoPerdido { get; set; }
        public int PontosPerdidos { get; set; }
    }
}