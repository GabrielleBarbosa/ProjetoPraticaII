using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Consequencia
    {
        private int codConsequencia;
        private string cenario;
        private int pontosGanho;
        private string tipoDoPontoGanho;
        private string tipoDoPontoPerdido;
        private int pontosPerdido;

        public Consequencia()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodConsequencia { get => codConsequencia; set => codConsequencia = value; }
        public string Cenario { get => cenario; set => cenario = value; }
        public int PontosGanho { get => pontosGanho; set => pontosGanho = value; }
        public string TipoDoPontoGanho { get => tipoDoPontoGanho; set => tipoDoPontoGanho = value; }
        public string TipoDoPontoPerdido { get => tipoDoPontoPerdido; set => tipoDoPontoPerdido = value; }
        public int PontosPerdido { get => pontosPerdido; set => pontosPerdido = value; }
    }
}