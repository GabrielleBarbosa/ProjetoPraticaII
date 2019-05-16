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
                AcontecimentoAleatorio acontecimento = null;
                IList<AcontecimentoAleatorio> lista = repo.AcontecimentoAleatorio.ToList();
                foreach (var con in lista)
                {
                    if (con.Id == id)
                    {
                        acontecimento = con;
                        break;
                    }
                }
                return acontecimento;
            }
        }

    }
}