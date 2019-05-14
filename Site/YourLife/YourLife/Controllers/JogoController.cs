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
        
        public ActionResult PaginaInicial()
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

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarJogador(Jogador jog)
        {
            JogadorDAO jg = new JogadorDAO();
            if (ModelState.IsValid && jg.BuscaPorNick(jog.Nickname) == null)
            {
                jog.Dinheiro = 0;
                jog.Idade = 5;
                jog.Parceiro = 'N';
                jog.PontosSaude = 1000;
                Random rm = new Random();
                jog.PontosInteligencia = rm.Next(0, 450);
                jog.PontosRelacionamento = 0;
                jog.PontosFelicidade = 500;
                jog.Sexo = 'I';
                jog.CodEmprego = 0;
                jg.Adiciona(jog);

                Session["jogador"] = jg.BuscaPorNick(jog.Nickname);

                return RedirectToAction("EscolhaPersonagem", "Jogo");
            }
            else
            {
                return View("Inicio");
            }
        }

        public ActionResult EscolhaPersonagem()
        {
            return View();
        }

        [Route("SalvarPersonagem/{sexo}")]
        public ActionResult SalvarPersonagem(char sexo)
        {
            ((Jogador)Session["jogador"]).Sexo = sexo;

            if (sexo == 'M')
                Session["personagem"] = "/Imagens/menino.png";
            else
                Session["personagem"] = "/Imagens/menina.png";


            return RedirectToAction("Base", "Jogo");
        }

        public ActionResult Base()
        {
            ViewBag.Personagem = Session["personagem"];
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

        public ActionResult Emprego()
        {
            EmpregoDAO dao = new EmpregoDAO();
            IList<Emprego> emp = dao.ListarEmprego();
            ViewBag.Pagina = Session["paginaAtual"];
            ViewBag.Emprego = emp;

            return View();
        }

        [Route("EntrevistaEmprego/{id}")]
        public ActionResult EntrevistaEmprego(int id)
        {
            Random rd = new Random();
            if (rd.Next(0, 1) == 1)
            {
                Session["emprego"] = "S";
                ((Jogador)Session["jogador"]).CodEmprego = id;
            }
            else
                Session["emprego"] = "N";
            return RedirectToAction("Emprego", "Jogo");
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

        public ActionResult Envelhecer()
        {
            Jogador jog = (Jogador)Session["jogador"];

            jog.Idade++;
            decimal salario = 0;
            if (jog.CodEmprego != 0)
                salario = ((Emprego)Session["emprego"]).salario;
            jog.Dinheiro += salario;

            if (jog.Sexo == 'M')
            {
                if (jog.Idade >= 14 && jog.Idade <= 20)
                    Session["personagem"] = "menino_adolescente.png";
                else if (jog.Idade >= 21 && jog.Idade <= 40)
                    Session["personagem"] = "homem_adulto.png";
                else if (jog.Idade >= 41)
                    Session["personagem"] = "velho.png";
            }
            else
            {
                if (jog.Idade >= 14 && jog.Idade <= 20)
                    Session["personagem"] = "menina_adolescente.png";
                else if (jog.Idade >= 21 && jog.Idade <= 40)
                    Session["personagem"] = "mulher_adulta.png";
                else if (jog.Idade >= 41)
                    Session["personagem"] = "velha.png";
            }

            Session["jogador"] = jog;

            return RedirectToAction("Acontecimento", "Jogo");
        }

        public ActionResult Acontecimento()
        {
            //Jogador jog = (Jogador)Session["jogador"];

            //if(jog.Idade == 16) //idade para dirigir
            //{
            //    
            //}
            //if(jog.Idade == 18) //maioridade 
            //{
            //    AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
            //    AcontecimentoFixo af = dao.Busca();

            //    ViewBag.Acontecimento = af;
            //    ViewBag.Opcao1 = new Escolha();
            //    ViewBag.Opcao2 = new Escolha();
            //}
            //else
            //{
            //    AcontecimentoAleatorioDAO dao = new AcontecimentoAleatorioDAO();
            //    AcontecimentoFixo aa = dao.Busca();

            //    ViewBag.Acontecimento = aa;
            //    ViewBag.Opcao1 = new Escolha();
            //    ViewBag.Opcao2 = new Escolha();
            //}

            return View();
        }

        public ActionResult Curso()
        {
            CursoDAO dao = new CursoDAO();
            IList<Curso> cursos = dao.ListarCursos();
            ViewBag.Cursos = cursos;
            ViewBag.Pagina = Session["paginaAtual"];
            return View();
        }
    }
}