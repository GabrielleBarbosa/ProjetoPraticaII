using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using YourLife.DAO;
namespace YourLife.Models
{
    public class Ranking
    {
        public string Nickname { get; set; }
        public int Pontos { get; set; }
        public int Id { get; set; }
        
    }
}