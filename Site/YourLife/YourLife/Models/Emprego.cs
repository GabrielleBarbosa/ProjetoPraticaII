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

        public int codEmprego { get => codEmprego; set => codEmprego = value; }
        public int pontosNecessarios { get => pontosNecessarios; set => pontosNecessarios = value; }
        public string trabalho { get => trabalho; set => trabalho = value; }
        public double salario { get => salario; set => salario = value; }
        public int restricao { get => restricao; set => restricao = value; }
        public int anosExperiencia { get => anosExperiencia; set => anosExperiencia = value; }
    }
}