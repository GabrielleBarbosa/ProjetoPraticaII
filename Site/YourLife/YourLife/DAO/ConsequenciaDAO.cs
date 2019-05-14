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
                Consequencia conseq = null;
                IList<Consequencia> lista = repo.Consequencia.ToList();
                foreach (var con in lista)
                {
                    if (con.Id == id)
                    {
                        conseq = con;
                        break;
                    }
                }
                return conseq;
            }
        }
    }
}