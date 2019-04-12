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
            using (var context = new RankingContext())
            {
                context.Ranking.Add(rk);
                context.SaveChanges();
            }
        }
        public IList<Ranking> Lista()
        {
            using (var contexto = new RankingContext())
            {
                return contexto.Ranking.ToList();
            }
        }
    }
}