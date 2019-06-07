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

        public IList<MercadoJogador> ListarMercado(int idPersonagem)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.MercadoJogador.Where(p => p.CodJogador == idPersonagem).ToList();
            }
        }

        public int PontosBens(Personagem p)
        {
            int pontos = 0;
            using (var contexto = new JogoContext())
            {
                IList<MercadoJogador> mg = contexto.MercadoJogador.Where(Mg => Mg.CodJogador == p.Id).ToList(); // pega uma lista de todos os itens do jogador
                if (mg.First() != null) //significa que tem itens na lista
                {
                    foreach (var m in mg) //para cada item do jogador, procuramos correspondente em Mercado e adicionamos no int retornável "pontos"
                    {
                        Mercado item = (Mercado)contexto.Mercado.Select(Mercado => Mercado.Id == m.CodMercado);
                        pontos = decimal.ToInt32(item.Preco)/100;  //divisão por 100 para os valores não ficarem extensos

                    }
                }
            }
            return pontos; //retorna os pontos que serão utilizados em PersonagemDAO para salvar no Ranking
        }
    }
}