using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class MercadoDAO
    {
        public void Adiciona(Mercado mc)
        {
            using (var context = new MercadoContext())
            {
                context.Mercado.Add(mc);
                context.SaveChanges();
            }
        }
        public IList<Mercado> ListarMercado()
        {
            using (var contexto = new MercadoContext())
            {
                return contexto.Mercado.ToList();
            }
        }
    }
}