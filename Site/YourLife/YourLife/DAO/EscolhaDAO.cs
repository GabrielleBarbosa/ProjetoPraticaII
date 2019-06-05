using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class EscolhaDAO
    {
        public Escolha BuscarPorId(int id)
        {
            using (var repo = new JogoContext())
            {
                return repo.Escolha.Where(e => e.Id == id).FirstOrDefault();
            }
        }
    }
}