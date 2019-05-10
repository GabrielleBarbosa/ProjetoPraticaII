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
                jog.Idade = 5;
                jog.Parceiro = 'N';
                jog.PontosSaude = 1000;
                Random rm = new Random();
                jog.PontosInteligencia = rm.Next(0,450);
                jog.PontosRelacionamento = 0;
                jog.PontosFelicidade = 500;
                jog.Sexo = 'I';
                jog.CodEmprego = 0;
                jg.Adiciona(jog);
                
                Session["usuario"] = jog;

                return RedirectToAction("EscolhaPersonagem", "Jogo");
            }
            else
            {
                return View("Inicio");
            }
        }

        public ActionResult Base()
        {
            ViewBag.Personagem = Session["personagem"];
            return View();
        }

        public ActionResult Relatorio()
        {
            return View();
        }

        [Route("MudarPagina/{pagina}/{lugar}")]
        public ActionResult MudarPagina(int pagina, string lugar)
        {
            Session["paginaAtual"] = pagina;
            return RedirectToAction(lugar, "Jogo");
        }

        public ActionResult Emprego()
        {
            EmpregoDAO dao = new EmpregoDAO();
            IList<Emprego> emp = dao.ListarEmprego();
            ViewBag.Pagina = Session["paginaAtual"];
            ViewBag.Emprego = emp;

            return View();
        }

        public ActionResult EscolhaPersonagem()
        {
            return View();
        }

        public ActionResult Ranking()
        {
            RankingDAO dao = new RankingDAO();
            IEnumerable<Ranking> rk = dao.ListarRanking();
            ViewBag.Ranking = rk;
            return View();
        }

        [Route("SalvarPersonagem/{sexo}")]
        public ActionResult SalvarPersonagem(char sexo)
        {
            //ViewBag.Jogador = Session["usuario"];
            //ViewBag.Jogador.Sexo = sexo;
            //Session["usuario"] = ViewBag.Jogador;

            if (sexo == 'M')
                Session["personagem"] = "/Imagens/menino.png";
            else
                Session["personagem"] = "/Imagens/menina.png";


            return RedirectToAction("Base", "Jogo");
        }
    }
}