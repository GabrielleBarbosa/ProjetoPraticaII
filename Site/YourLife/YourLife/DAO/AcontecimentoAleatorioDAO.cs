using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class AcontecimentoAleatorioDAO
    {
        public AcontecimentoAleatorio BuscarPorId(int id)
        {
            using (var repo = new JogoContext())
            {
                return repo.AcontecimentoAleatorio.Where(aa => aa.Id == id).FirstOrDefault();
            }
        }

    }
}