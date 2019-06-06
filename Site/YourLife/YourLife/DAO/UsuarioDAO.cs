using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourLife.Models;

namespace YourLife.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usu)
        {
            using (var context = new JogoContext())
            {
                context.Usuario.Add(usu);
                context.SaveChanges();
            }
        }
        public IList<Usuario> ListarUsuario()
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Usuario.ToList();
            }
        }

        public Usuario BuscaPorNick(string nome)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Usuario.Where(u => u.nickname == nome).FirstOrDefault();
            }
        }

        public void Excluir(Usuario usu)
        {
            using (var contexto = new JogoContext())
            {
                Usuario usuASerExcluido = (Usuario)contexto.Usuario.Where(u => u == usu);
                contexto.Usuario.Remove(usuASerExcluido);
                contexto.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (var contexto = new JogoContext())
            {
                return contexto.Usuario.Where(u => u.id == id).FirstOrDefault();
            }
        }

        public void Alterar(Usuario usu)
        {
            using (var contexto = new JogoContext())
            {
                contexto.Usuario.Update(usu);
                contexto.SaveChanges();
            }
        }

        internal void Deletar(Usuario usu)
        {
            PersonagemDAO daoP = new PersonagemDAO();
            Personagem p = daoP.BuscarPorIdUsuario(usu.id);

            if(p!=null)
                daoP.ExcluirPersonagem(p);

            RankingDAO daoR = new RankingDAO();
            Ranking r = daoR.BuscarPorNick(usu.nickname);

            using (var repo = new JogoContext())
            {
                if(r != null)
                    repo.Ranking.Remove(r);

                repo.Usuario.Remove(usu);
                repo.SaveChanges();
            }
        }
    }
}