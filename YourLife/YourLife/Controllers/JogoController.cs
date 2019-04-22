using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourLife.Models;
using YourLife.DAO;

namespace YourLife.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        public ActionResult Jogo()
        {
            return View();
        }





        //Métodos da tela início

        public ActionResult Inicio()
        {
            return View();
        }

        public bool ExisteJogador(string nome)
        {
            JogadorDAO jg = new JogadorDAO();
            Jogador jogador = jg.getJogador(nome);
            if(jogador != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdicionarJogador(string nome, string senha, char sexo)
        {
            JogadorDAO jg = new JogadorDAO();
            jg.Adiciona(nome, senha, sexo);
        }
    }
}