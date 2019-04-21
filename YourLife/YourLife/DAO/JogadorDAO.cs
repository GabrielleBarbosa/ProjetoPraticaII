using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class JogadorDAO
    {

            public void Adiciona(Jogador jg)
            {
                using (var context = new JogadorContext())
                {
                    context.Jogador.Add(jg);
                    context.SaveChanges();
                }
            }
            public IList<Jogador> ListarJogador()
            {
                using (var contexto = new JogadorContext())
                {
                    return contexto.Jogador.ToList();
                }
            }
        }
    
}