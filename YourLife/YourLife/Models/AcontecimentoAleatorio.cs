using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class AcontecimentoAleatorio
    {
        int codAcontecimentoAleatorio;
        string acontecimento;
        int codEscolha;

        public AcontecimentoAleatorio()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodAcontecimentoAleatorio { get => codAcontecimentoAleatorio; set => codAcontecimentoAleatorio = value; }
        public string Acontecimento { get => acontecimento; set => acontecimento = value; }
        public int CodEscolha { get => codEscolha; set => codEscolha = value; }
    }
}