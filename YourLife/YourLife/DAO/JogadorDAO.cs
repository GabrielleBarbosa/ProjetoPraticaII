using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class JogadorDAO
    {

        /*public void Adiciona(string nome, string senha, char sexo)
        {
            Jogador jg = new Jogador(nome, senha, sexo);

            using (var context = new JogadorContext())
            {
                context.Jogador.Add(jg);
                context.SaveChanges();
            }
        }*/
        public IList<Jogador> ListarJogador()
        {
            using (var contexto = new JogadorContext())
            {
                return contexto.Jogador.ToList();
            }
        }

        public Jogador getJogador(string nome)
        {
            Jogador jogadorExistente = null;
            using (var repo = new JogadorContext())
            {
                IList<Jogador> jg = repo.Jogador.ToList();
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