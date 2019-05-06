using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Emprego
    {
        

        public Emprego()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int codEmprego { get; set; }
        public int pontosNecessarios { get; set; }
        public string trabalho { get; set; }
        public decimal salario { get; set; }
        public int restricao { get; set; }
        public int anosExperiencia { get; set; }
    }
}