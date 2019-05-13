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
            //ViewBag.Jogador = Session["jogador"];
            ViewBag.Jogador = new Jogador();
            ViewBag.Jogador.Dinheiro = 0;

            MercadoDAO dao = new MercadoDAO();
            IList<Mercado> mc = dao.ListarMercado();
            ViewBag.Mercado = mc;
            return View();
        }

        [Route("Comprar/{preco}/{id}")]
        public ActionResult Comprar(decimal preco, int id)
        {
            ViewBag.Jogador = Session["jogador"];
            if (ViewBag.Jogador.Dinheiro >= preco)
            {
                MercadoJogadorDAO mj = new MercadoJogadorDAO();
                mj.Adiciona(ViewBag.Jogador.Id, id);

                ViewBag.Jogador.Dinheiro -= preco;
                return RedirectToAction("Mercado", "Jogo");
            }
            return RedirectToAction("Mercado", "Jogo");
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
            JogadorDAO jg = new JogadorDAO();
            if (ModelState.IsValid && jg.getJogador(jog.Nickname) == null)
            {
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
                
                Session["jogador"] = jg.getJogador(jog.Nickname);

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
            //ViewBag.Jogador = Session["jogador"];
            //ViewBag.Jogador.Sexo = sexo;
            //Session["usuario"] = ViewBag.Jogador;

            if (sexo == 'M')
                Session["personagem"] = "/Imagens/menino.png";
            else
                Session["personagem"] = "/Imagens/menina.png";


            return RedirectToAction("Base", "Jogo");
        }

        public ActionResult PaginaInicial()
        {
            return View();
        }
    }
}