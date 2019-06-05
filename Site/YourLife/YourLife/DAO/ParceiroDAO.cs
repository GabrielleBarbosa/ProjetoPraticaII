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
                return contexto.Parceiro.Where(p => p.id == id).FirstOrDefault();
            }
        }

        public Parceiro SelecionarParceiro(int id)
        {
            IList<Parceiro> p = null;
            using (var contexto = new JogoContext())
            {
                p = (contexto.Parceiro.Where(Parceiro => Parceiro.id == id).ToList());
            }
            return p.First() ;

        }
    }
}