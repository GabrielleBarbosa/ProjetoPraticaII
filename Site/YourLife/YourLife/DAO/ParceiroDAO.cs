using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class ParceiroDAO
    {
        public Parceiro BuscarPorId(int id)
        {
            using (var contexto = new JogoContext())
            {
                Parceiro parceiro = null;
                IList<Parceiro> lista = contexto.Parceiro.ToList();
                foreach (var p in lista)
                {
                    if(p.id == id)
                    {
                        parceiro = p;
                        break;
                    }
                }
                return parceiro;
        }
    }
}