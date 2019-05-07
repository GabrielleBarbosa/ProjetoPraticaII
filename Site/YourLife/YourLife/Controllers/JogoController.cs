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

        public ActionResult Mercado()
        {
            MercadoDAO dao = new MercadoDAO();
            IList<Mercado> mc = dao.ListarMercado();
            ViewBag.Mercado = mc;
            return View();
        }

        //Métodos da tela início

        public ActionResult Inicio()
        {
            return View();
        }

        public JsonResult ExisteJogador(string nome)
        {
            JogadorDAO jg = new JogadorDAO();
            Jogador jogador = jg.getJogador(nome);
            if(jogador != null)
                return Json(true);
            
            return Json(false);
        }

        [HttpPost]
        public ActionResult AdicionarJogador(Jogador jog)
        {
            if (ModelState.IsValid)
            {
                JogadorDAO jg = new JogadorDAO();

                jog.Dinheiro = 0;
                jog.Idade = 0;
                jog.Parceiro = 'N';
                jog.PontosSaude = 1000;
                jog.PontosInteligencia = 450;
                jog.PontosRelacionamento = 0;
                jog.PontosFelicidade = 500;
                jog.Sexo = 'I';
                jog.CodEmprego = 0;
                jg.Adiciona(jog);

                return RedirectToAction("Base", "Jogo");
            }
            else
            {
                return View("Inicio");
            }
        }

        public ActionResult Base()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            return View();
        }
        public ActionResult Emprego()
        {
            EmpregoDAO dao = new EmpregoDAO();
            IList<Emprego> emp = dao.ListarEmprego();
            ViewBag.Emprego = emp;
            return View();
        }
    }
}