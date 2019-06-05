using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class AcontecimentoFixoDAO
    {
        public AcontecimentoFixo BuscarPorId(int id)
        {
            using (var repo = new JogoContext())
            {
                return repo.AcontecimentoFixo.Where(af => af.Id == id).FirstOrDefault();
            }
        }
    }
}