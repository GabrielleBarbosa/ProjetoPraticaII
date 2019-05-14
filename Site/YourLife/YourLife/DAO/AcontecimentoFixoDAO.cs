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
                AcontecimentoFixo acontfixo = null;
                IList<AcontecimentoFixo> lista = repo.AcontecimentoFixo.ToList();
                foreach (var a in lista)
                {
                    if (a.Id == id)
                    {
                        acontfixo = a;
                        break;
                    }
                }
                return acontfixo;
            }
        }
    }
}