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
            ViewBag.EmpregoAtual = Session["teste"];
            EmpregoDAO dao = new EmpregoDAO();
            IList<Emprego> emp = dao.ListarEmprego();
            ViewBag.Pagina = Session["paginaAtual"];
            ViewBag.Emprego = emp;

            return View();
        }

        [Route("EntrevistaEmprego/{id}")]
        public ActionResult EntrevistaEmprego(int id)
        {
            Session["jogador"] = new Jogador();
            Random rd = new Random();
            if (rd.Next(0, 2) == 1)
            {
                EmpregoDAO dao = new EmpregoDAO();

                Session["teste"] = dao.BuscarPorId(id);
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
            Jogador jog = (Jogador)Session["jogador"];

            Random random = new Random();

            if (jog.Idade == 16) //idade para dirigir
            {
                AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
                AcontecimentoFixo af = dao.BuscarPorId(1);

                ViewBag.Acontecimento = Session["acontecimento"] = af;

                EscolhaDAO daoEsc = new EscolhaDAO();
                Escolha esc = daoEsc.BuscarPorId(af.CodEscolha);
                ViewBag.Escolha = Session["escolha"] = esc;

                ConsequenciaDAO daoConseq = new ConsequenciaDAO();
                Consequencia conseq1 = daoConseq.BuscarPorId(esc.Consequencia1);
                Consequencia conseq2 = daoConseq.BuscarPorId(esc.Consequencia2);
                ViewBag.Consequencia1 = Session["consequencia1"] = conseq1;
                ViewBag.Consequencia2 = Session["consequencia2"] = conseq2;
            }
            if (jog.Idade == 18) //maioridade 
            {
                AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
                AcontecimentoFixo af = dao.BuscarPorId(2);

                ViewBag.Acontecimento = Session["acontecimento"] = af;

                EscolhaDAO daoEsc = new EscolhaDAO();
                Escolha esc = daoEsc.BuscarPorId(af.CodEscolha);
                ViewBag.Escolha = Session["escolha"] = esc;

                ConsequenciaDAO daoConseq = new ConsequenciaDAO();
                Consequencia conseq1 = daoConseq.BuscarPorId(esc.Consequencia1);
                Consequencia conseq2 = daoConseq.BuscarPorId(esc.Consequencia2);
                ViewBag.Consequencia1 = Session["consequencia1"] = conseq1;
                ViewBag.Consequencia2 = Session["consequencia2"] = conseq2;
            }
            else
            {
                int id = 0;
                if (jog.Idade <= 14)
                {
                    id = random.Next(1, 20);
                }
                else if (jog.Idade <= 30)
                {
                    id = random.Next(21, 40);
                }
                else if(jog.Idade <= 60)
                {
                    id = random.Next(41, 60);
                }
                else
                {
                    id = random.Next(61, 80);
                }

                AcontecimentoAleatorioDAO daoAcont = new AcontecimentoAleatorioDAO();
                AcontecimentoAleatorio aa = daoAcont.BuscarPorId(id);

                ViewBag.Acontecimento = Session["acontecimento"] = aa;

                EscolhaDAO daoEsc = new EscolhaDAO();
                Escolha esc = daoEsc.BuscarPorId(aa.CodEscolha);
                ViewBag.Escolha = Session["escolha"] = esc;

                ConsequenciaDAO daoConseq = new ConsequenciaDAO();
                Consequencia conseq1 = daoConseq.BuscarPorId(esc.Consequencia1);
                Consequencia conseq2 = daoConseq.BuscarPorId(esc.Consequencia2);
                ViewBag.Consequencia1 = Session["consequencia1"] = conseq1;
                ViewBag.Consequencia2 = Session["consequencia2"] = conseq2;
            }

            return View();
        }

        public ActionResult Curso()
        {
            Session["paginaAtual"] = 0;
            CursoDAO dao = new CursoDAO();
            IList<Curso> cursos = dao.ListarCursos();
            ViewBag.Cursos = cursos;
            ViewBag.Pagina = Session["paginaAtual"];
            return View();
        }

        public ActionResult Personagem()
        {
            ViewBag.Jogador = Session["jogador"];
            return View();
        }
    }
}