using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class AcontecimentoFixo
    {
        int codAcontecimentoFixo;
        string acontecimento;
        int codEscolha;

        public AcontecimentoFixo()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public int CodAcontecimentoFixo { get => codAcontecimentoFixo; set => codAcontecimentoFixo = value; }
        public string Acontecimento { get => acontecimento; set => acontecimento = value; }
        public int CodEscolha { get => codEscolha; set => codEscolha = value; }
    }
}