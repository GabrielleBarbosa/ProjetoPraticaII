using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;
using Microsoft.EntityFrameworkCore;
namespace YourLife.DAO
{
    public class MercadoDAO
    {
        public void Adiciona(Mercado mc)
        {
            using (var context = new JogoContext())
            {
                context.Mercado.Add(mc);
                context.SaveChanges();
            }
        }
        public IList<Mercado> ListarMercado()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Mercado.ToList();
            }
        }

        internal Mercado BuscarPorId(int id)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Mercado.Where(m => m.Id == id).FirstOrDefault();
            }
        }
    }
}