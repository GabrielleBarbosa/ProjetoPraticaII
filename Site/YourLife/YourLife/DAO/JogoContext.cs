using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using YourLife.Models;

namespace YourLife.DAO
{
    public class JogoContext:DbContext
    {
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<Mercado> Mercado { get; set; }
        public DbSet<MercadoJogador> MercadoJogador { get; set; }
        public DbSet<Emprego> Emprego { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus;Initial Catalog=PR118200;User ID=PR118200;Password=PR118200");
        }
    }
}