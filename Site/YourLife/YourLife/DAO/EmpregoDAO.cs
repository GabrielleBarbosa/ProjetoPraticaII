using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class EmpregoDAO
    {

        public void Adiciona(Emprego emp)
        {
            using (var context = new JogoContext())
            {
                context.Emprego.Add(emp);
                context.SaveChanges();
            }
        }
        public IList<Emprego> ListarEmprego()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Emprego.ToList();
            }
        }
    }
}