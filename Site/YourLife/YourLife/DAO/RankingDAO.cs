﻿using System;
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
    }
}