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

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarJogador(Usuario usu)
        {
            UsuarioDAO dao = new UsuarioDAO();
            if (ModelState.IsValid && dao.BuscaPorNick(usu.nickname) == null)
            {

                Session["Usuario"] = dao.BuscaPorNick(usu.nickname);
                
                return RedirectToAction("Inicio", "Jogo");
            }
            else
            {
                return View("Cadastro");
            }
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult LogarUsuario(Usuario usu)
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usuarioExistente = new Usuario();
            if (ModelState.IsValid && usuarioExistente != null)
            {
                Personagem p = new Personagem();
                PersonagemDAO pg = new PersonagemDAO();
                p = pg.BuscarPorIdUsuario(usu.id);

                Session["Personagem"] = p;
                if (p.Sexo == 'M')
                {
                    if (p.Idade < 14)
                        Session["imagem"] = "menino.png";
                    else if (p.Idade >= 14 && p.Idade <= 20)
                        Session["imagem"] = "menino_adolescente.png";
                    else if (p.Idade >= 21 && p.Idade <= 40)
                        Session["imagem"] = "homem_adulto.png";
                    else if (p.Idade >= 41)
                        Session["imagem"] = "velho.png";
                }
                else
                {
                    if (p.Idade < 14)
                        Session["imagem"] = "menina.png";
                    else if (p.Idade >= 14 && p.Idade <= 20)
                        Session["imagem"] = "menina_adolescente.png";
                    else if (p.Idade >= 21 && p.Idade <= 40)
                        Session["imagem"] = "mulher_adulta.png";
                    else if (p.Idade >= 41)
                        Session["imagem"] = "velha.png";
                }

                return RedirectToAction("Base");
            }
            else
            {
                return View("Login");
            }
            
        }


        public ActionResult Inicio()
        {
            return View();
        }

        [Route("SalvarNome/{nome}")]
        public ActionResult SalvarNome(string nome)
        {
            Usuario usu = (Usuario)Session["Usuario"];
            PersonagemDAO dao = new PersonagemDAO();
            Personagem p = new Personagem();
            p.Dinheiro = 0;
            p.Idade = 5;
            p.Parceiro = 'N';
            p.PontosSaude = 1000;
            Random rm = new Random();
            p.PontosInteligencia = rm.Next(0, 450);
            p.PontosRelacionamento = 0;
            p.PontosFelicidade = 500;
            p.Sexo = 'I';
            p.CodEmprego = 0;
            p.CodUsuario = usu.id;
            p.Nome = "teste";
            dao.Adiciona(p);

            Session["Personagem"] = dao.BuscarPorIdUsuario(usu.id);

            return RedirectToAction("EscolhaPersonagem", "Jogo");
        }


        public ActionResult EscolhaPersonagem()
        {
            return View();
        }

        [Route("SalvarPersonagem/{sexo}")]
        public ActionResult SalvarPersonagem(char sexo)
        {
            ((Personagem)Session["Personagem"]).Sexo = sexo;

            if (sexo == 'M')
                Session["imagem"] = "/Imagens/menino.png";
            else
                Session["imagem"] = "/Imagens/menina.png";


            return RedirectToAction("Base", "po");
        }

        public ActionResult Base()
        {
            ViewBag.Imagem = Session["imagem"];
            return View();
        }

        public ActionResult Mercado()
        {
            //ViewBag.Personagem = Session["Personagem"];
            ViewBag.Personagem = new Personagem();
            ViewBag.Personagem.Dinheiro = 0;

            MercadoDAO dao = new MercadoDAO();
            IList<Mercado> mc = dao.ListarMercado();
            ViewBag.Mercado = mc;
            return View();
        }

        [Route("Comprar/{preco}/{id}")]
        public ActionResult Comprar(decimal preco, int id)
        {
            ViewBag.Personagem = Session["Personagem"];
            if (ViewBag.Personagem.Dinheiro >= preco)
            {
                MercadoJogadorDAO mj = new MercadoJogadorDAO();
                mj.Adiciona(ViewBag.Personagem.Id, id);

                ViewBag.Personagem.Dinheiro -= preco;
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
            Session["Personagem"] = new Personagem();
            Random rd = new Random();
            if (rd.Next(0, 2) == 1)
            {
                EmpregoDAO dao = new EmpregoDAO();

                Session["teste"] = dao.BuscarPorId(id);
                Session["emprego"] = "S";
                ((Personagem)Session["Personagem"]).CodEmprego = id;
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
            Personagem p = (Personagem)Session["Personagem"];

            p.Idade++;
            decimal salario = 0;
            if (p.CodEmprego != 0)
                salario = ((Emprego)Session["emprego"]).salario;
            p.Dinheiro += salario;

            if (p.Sexo == 'M')
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "menino_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "homem_adulto.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "velho.png";
            }
            else
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "menina_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "mulher_adulta.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "velha.png";
            }

            Session["Personagem"] = p;

            return RedirectToAction("Acontecimento", "Jogo");
        }

        public ActionResult Acontecimento()
        {
            Personagem p = (Personagem)Session["Personagem"];

            Random random = new Random();

            if (p.Idade == 16) //idade para dirigir
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
            if (p.Idade == 18) //maioridade 
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
                if (p.Idade <= 14)
                {
                    id = random.Next(1, 20);
                }
                else if (p.Idade <= 30)
                {
                    id = random.Next(21, 40);
                }
                else if(p.Idade <= 60)
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
            ViewBag.Cursando = Session["cursando"];
            Session["paginaAtual"] = 0;
            CursoDAO dao = new CursoDAO();
            IList<Curso> cursos = dao.ListarCursos();
            ViewBag.Cursos = cursos;
            ViewBag.Pagina = Session["paginaAtual"];
            return View();
        }

        [Route("FazerCurso/{id}")]
        public ActionResult FazerCurso(int id)
        {
            CursoDAO dao = new CursoDAO();
            if (Session["cursando"] == null)
                Session["cursando"] = dao.BuscarPorId(id);

            return RedirectToAction("Curso", "Jogo");
        }

        public ActionResult Personagem()
        {
            ViewBag.Personagem = Session["Personagem"];
            return View();
        }
    }
}