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
                contexto.Personagem.Update(p);
                contexto.SaveChanges();
            }
        }

        public void Morrer(Personagem p)
        {
            using (var contexto =  new JogoContext())
            {
                RankingDAO daoRK = new RankingDAO();
                int pontos = p.PontosFelicidade + p.PontosInteligencia + p.PontosRelacionamento + p.PontosSaude + p.Idade + decimal.ToInt32(p.Dinheiro);
                daoRK.Adiciona(pontos);
                IList<CursoJogador> cj = contexto.CursoJogador.Where(c => c.codJogador == p.Id).ToList();
                IList<MercadoJogador> mj = contexto.MercadoJogador.Where(m => m.CodJogador == p.Id).ToList();
                foreach (CursoJogador cj1 in cj)
                contexto.CursoJogador.Remove(cj1);
                foreach(MercadoJogador mj1 in mj)
                contexto.MercadoJogador.Remove(mj1);
                contexto.Personagem.Remove(p);
                contexto.SaveChanges();
            }

        }

        public bool TerminarRelacionamento(Personagem p)     //método que termina relacionamento
        {
            if (p.Parceiro > 0)                             // verificando com antecedência se a pessoa está em um relacionamento
                using (var contexto = new JogoContext())
                {
                    p.Parceiro = 0;
                    p.PontosFelicidade = p.PontosFelicidade - 50;
                    p.PontosSaude = p.PontosSaude - 30;
                    contexto.Personagem.Update(p);
                    contexto.SaveChanges();
                    return true;
                }
            else
                return false;

        }

        public bool Demissao(Personagem p) // método que demite a pessoa de seu emprego
        {
            if (p.CodEmprego > 0)         // verificando com antecedência se a pessoa está em um emprego
                using (var contexto = new JogoContext())
                {
                    p.CodEmprego = 0;
                    p.PontosFelicidade = p.PontosFelicidade - 10;
                    contexto.Personagem.Update(p);
                    contexto.SaveChanges();
                    return true;
                }
            else
                return false;
        }


    }

}