using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class CursoJogadorDAO
    {
        public IList<CursoJogador> ListarCursos()
        {
            using (var repo = new JogoContext())
            {
                IList<CursoJogador> lista = repo.CursoJogador.ToList();
                return lista;
            }
        }

        public void Adicionar(int idPersonagem, int idCurso)
        {
            using (var contexto = new JogoContext())
            {
                CursoJogador cur = new CursoJogador();
                cur.codCurso = idCurso;
                cur.codJogador = idPersonagem;

                contexto.CursoJogador.Add(cur);
                contexto.SaveChanges();
            }
        }
    }
}