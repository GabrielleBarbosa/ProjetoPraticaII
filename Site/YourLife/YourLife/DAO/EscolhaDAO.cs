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
                Escolha escolha = null;
                IList<Escolha> lista = repo.Escolha.ToList();
                foreach(var esc in lista)
                {
                    if (esc.Id == id)
                    {
                        escolha = esc;
                        break;
                    }
                }
                return escolha;
            }
        }
    }
}