﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class PersonagemDAO
    {

        public void Adiciona(Personagem pers)
        {
            using (var context = new JogoContext())
            {
                context.Personagem.Add(pers);
                context.SaveChanges();
            }
        }
        public IList<Personagem> ListarJogador()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Personagem.ToList();
            }
        }

    }

}