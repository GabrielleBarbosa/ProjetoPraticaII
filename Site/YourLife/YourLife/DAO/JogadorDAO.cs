﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class JogadorDAO
    {

        public void Adiciona(Jogador jog)
        {
            using (var context = new JogoContext())
            {
                context.Jogador.Add(jog);
                context.SaveChanges();
            }
        }
        public IList<Jogador> ListarJogador()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Jogador.ToList();
            }
        }

        public Jogador getJogador(string nome)
        {
            Jogador jogadorExistente = null;
            using (var repo = new JogoContext())
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