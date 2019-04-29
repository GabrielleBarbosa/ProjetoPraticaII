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
        public void Adiciona(Ranking rk)
        {
            using (var context = new JogoContext())
            {
                context.Ranking.Add(rk);
                context.SaveChanges();
            }
        }
        public IList<Ranking> ListarRanking()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Ranking.ToList();
            }
        }
    }
}