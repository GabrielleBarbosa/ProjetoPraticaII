using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class MercadoJogadorDAO
    {
        public void Adiciona(int idJogador, int idMercado)
        {
            MercadoJogador mc = new MercadoJogador();
            mc.CodJogador = idJogador;
            mc.CodMercado = idMercado;
            using (var context = new JogoContext())
            {
                context.MercadoJogador.Add(mc);
                context.SaveChanges();
            }
        }
    }
}