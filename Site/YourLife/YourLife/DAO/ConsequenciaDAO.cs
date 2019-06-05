using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class ConsequenciaDAO
    {
        public Consequencia BuscarPorId(int id)
        {
            using (var repo = new JogoContext())
            {
                return repo.Consequencia.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}