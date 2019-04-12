using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Emprego
    {
        int codEmprego;
        int pontosNecessarios;
        string trabalho;
        double salario;

        public Emprego()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodEmprego { get => codEmprego; set => codEmprego = value; }
        public int PontosNecessarios { get => pontosNecessarios; set => pontosNecessarios = value; }
        public string Trabalho { get => trabalho; set => trabalho = value; }
        public double Salario { get => salario; set => salario = value; }
    }
}