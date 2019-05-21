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
    }
}