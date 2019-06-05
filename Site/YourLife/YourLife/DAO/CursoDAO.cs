using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class CursoDAO
    {
        public IList<Curso> ListarCursos()
        {
            using (var repo = new JogoContext())
            {
                return repo.Curso.ToList();
            }
        }

        public Curso BuscarPorId(int id)
        {
            using (var repo = new JogoContext())
            {
                return repo.Curso.Where(c => c.id == id).FirstOrDefault();
            }
        }
    }
}