using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using YourLife.Models;

namespace YourLife.DAO
{
    public class RankingDAO
    {
        public void Adiciona(int pontos, string nickname)
        {
            Ranking rk = new Ranking();
            rk.Nickname = nickname;
            rk.Pontos = pontos;
            using (var contexto = new JogoContext())
            {
                contexto.Ranking.Add(rk);
                contexto.SaveChanges();
            }
        }
        public IEnumerable<Ranking> ListarRanking()
        {
            using (var contexto = new JogoContext())
            {
                var vet = contexto.Ranking.ToList();
                
                return vet.OrderByDescending(Ranking => Ranking.Pontos);
            }
        }

        public Ranking BuscarPorNick(string nickname)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Ranking.Where(r => r.Nickname == nickname).FirstOrDefault();
            }
        }

        internal void Altera(Ranking rk)
        {
            using (var contexto = new JogoContext())
            {
                contexto.Ranking.Update(rk);
            }
        }
    }
}