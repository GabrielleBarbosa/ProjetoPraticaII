using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class JogadorDAO
    {

        public void Adiciona(Personagem jog)
        {
            using (var context = new JogoContext())
            {
                context.Jogador.Add(jog);
                context.SaveChanges();
            }
        }
        public IList<Personagem> ListarJogador()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Jogador.ToList();
            }
        }

        public Personagem BuscaPorNick(string nome)
        {
            Personagem jogadorExistente = null;
            using (var repo = new JogoContext())
            {
                IList<Personagem> jg = repo.Jogador.ToList();
                foreach(var player in jg)
                {
                    if(nome == player.Nickname)
                    {
                        return jogadorExistente = player;
                    }
                }
            }
            return jogadorExistente;
        }

    }

}