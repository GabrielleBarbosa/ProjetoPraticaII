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
            Usuario jogadorExistente = null;
            using (var contexto = new JogoContext())
            {
                IList<Usuario> usu = contexto.Usuario.ToList();
                foreach (var player in usu)
                {
                    if (nome == player.nickname)
                    {
                        return jogadorExistente = player;
                    }
                }
            }
            return jogadorExistente;
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
    }
}