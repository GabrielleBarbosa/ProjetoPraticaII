using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodCursoNecessario { get; set; }
    }
}