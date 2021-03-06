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

        public Personagem RetornarPersonagemExistente(Usuario usu)
        {
            Personagem personagemExistente = null;
            using (var contexto = new JogoContext())
            {
                contexto.Personagem.Select(Personagem => usu.nickname);
                return personagemExistente;
            }

        }

        public Personagem BuscarPorIdUsuario(int codUsuario)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Personagem.Where(p => p.CodUsuario == codUsuario).FirstOrDefault();
            }
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
                MercadoJogadorDAO daoMG = new MercadoJogadorDAO();
                RankingDAO daoRK = new RankingDAO();
                int pontos = p.PontosFelicidade + p.PontosInteligencia + p.PontosRelacionamento + p.PontosSaude + p.Idade + decimal.ToInt32(p.Dinheiro) + daoMG.PontosBens(p);
                UsuarioDAO daoUsu = new UsuarioDAO();
                Usuario usu = daoUsu.BuscarPorId(p.CodUsuario);

                Ranking rk = daoRK.BuscarPorNick(usu.nickname);
                
                if(rk != null)
                {
                    if (rk.Pontos < pontos)
                    {
                        rk.Pontos = pontos;
                        daoRK.Altera(rk);
                    }
                }
                else
                    daoRK.Adiciona(pontos,usu.nickname);

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

        public void ExcluirPersonagem(Personagem p)
        {
            using (var contexto = new JogoContext())
            {
                IList<CursoJogador> cj = contexto.CursoJogador.Where(c => c.codJogador == p.Id).ToList();
                IList<MercadoJogador> mj = contexto.MercadoJogador.Where(m => m.CodJogador == p.Id).ToList();
                foreach (CursoJogador cj1 in cj)
                    contexto.CursoJogador.Remove(cj1);
                foreach (MercadoJogador mj1 in mj)
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