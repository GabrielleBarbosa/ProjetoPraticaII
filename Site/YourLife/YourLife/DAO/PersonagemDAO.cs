using System;
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

        public Personagem RetornarPersonagemExistente(Usuario usu)
        {
            Personagem personagemExistente = null;
            using (var contexto = new JogoContext())
            {
                contexto.Personagem.Select(Personagem => usu.nickname);
                return personagemExistente;
            }

        }

        public Personagem BuscarPorIdUsuario(int id)
        {
            using (var contexto = new JogoContext())
            {
                IList<Personagem> lista = contexto.Personagem.ToList();
                foreach (var per in lista)
                    if (per.CodUsuario == id)
                        return per;
            }
            return null;
        }

        public void Alterar(Personagem p)
        {
            using (var contexto = new JogoContext())
            {
                IList<Personagem> lista = contexto.Personagem.ToList();
                foreach (var jog in lista)
                    if (p.Id == jog.Id)
                    {
                        contexto.Personagem.Update(p);
                        contexto.SaveChanges();
                        break;
                    }
            }
        }

        public void Morrer(Personagem p)
        {
            using (var contexto =  new JogoContext())
            {
                contexto.Personagem.Remove(p);
                contexto.SaveChanges();
            }
        }
    }

}