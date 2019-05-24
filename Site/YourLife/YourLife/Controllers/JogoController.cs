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

        public JsonResult ValidarCadastro(string nick)
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usuarioExistente = usuDAO.BuscaPorNick(nick);
            if (usuarioExistente == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public ActionResult AdicionarJogador(Usuario usu)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adiciona(usu);
            Session["Usuario"] = dao.BuscaPorNick(usu.nickname);

            return RedirectToAction("Inicio", "Jogo");
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult ValidarLogin(string senha, string nick)
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usuarioExistente = usuDAO.BuscaPorNick(nick);
            if (usuarioExistente != null && usuarioExistente.senha == senha)
            {
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult LogarUsuario(Usuario usu)
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usuarioExistente = usuDAO.BuscaPorNick(usu.nickname);

            Personagem p = new Personagem();
            PersonagemDAO pg = new PersonagemDAO();
            p = pg.BuscarPorIdUsuario(usuarioExistente.id);

            Session["Personagem"] = p;

            EmpregoDAO daoE = new EmpregoDAO();
            Emprego e = daoE.BuscarPorId(p.CodEmprego);
            Session["Emprego"] = e;

            if (p.Sexo == 'M')
            {
                if (p.Idade < 14)
                    Session["imagem"] = "/Imagens/menino.png";
                else if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menino_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "/Imagens/homem_adulto.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "/Imagens/velho.png";
            }
            else
            {
                if (p.Idade < 14)
                    Session["imagem"] = "/Imagens/menina.png";
                else if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menina_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "/Imagens/mulher_adulta.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "/Imagens/velha.png";
            }


            return RedirectToAction("Base", "Jogo");
        }


        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult SalvarNome(Personagem p)
        {
            if (ModelState.IsValid)
            {
                Usuario usu = (Usuario)Session["Usuario"];
                PersonagemDAO dao = new PersonagemDAO();
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
                p.Parceiro = 0;
                dao.Adiciona(p);

                EmpregoDAO daoE = new EmpregoDAO();
                Session["Emprego"] = daoE.BuscarPorId(0);
                Session["Personagem"] = dao.BuscarPorIdUsuario(usu.id);

                return RedirectToAction("EscolhaPersonagem", "Jogo");
            }
            return RedirectToAction("Inicio", "Jogo");
        }


        public ActionResult EscolhaPersonagem()
        {
            return View();
        }

        [Route("SalvarPersonagem/{sexo}")]
        public ActionResult SalvarPersonagem(char sexo)
        {
            ((Personagem)Session["Personagem"]).Sexo = sexo;
            PersonagemDAO dao = new PersonagemDAO();
            Personagem p = (Personagem)Session["Personagem"];
            dao.Alterar(p);

            if (sexo == 'M')
                Session["imagem"] = "/Imagens/menino.png";
            else
                Session["imagem"] = "/Imagens/menina.png";


            return RedirectToAction("Base", "Jogo");
        }

        public ActionResult Base()
        {
            ViewBag.Acontecimento = Session["acontecimento"];
            ViewBag.Escolha = Session["escolha"];
            ViewBag.Consequencia1 = Session["consequencia1"];
            ViewBag.Consequencia2 = Session["consequencia2"];
            ViewBag.Personagem = Session["Personagem"];
            ViewBag.Imagem = Session["imagem"];
            return View();
        }

        public ActionResult Mercado()
        {
            ViewBag.Personagem = Session["Personagem"];
            ViewBag.Pagina = Session["PaginaAtual"];

            MercadoDAO dao = new MercadoDAO();
            IList<Mercado> mc = dao.ListarMercado();
            ViewBag.Mercado = mc;

            MercadoJogadorDAO daoMJ = new MercadoJogadorDAO();
            IList<MercadoJogador> mj = daoMJ.ListarMercado();
            ViewBag.Bens = mj;

            return View();
        }

        [Route("Comprar/{preco}/{id}")]
        public ActionResult Comprar(decimal preco, int id)
        {
            Personagem p = (Personagem)Session["Personagem"];
            if (p.Dinheiro >= preco)
            {
                MercadoJogadorDAO mj = new MercadoJogadorDAO();
                mj.Adiciona(p.Id, id);
                
                p.Dinheiro = p.Dinheiro - preco;

                PersonagemDAO dao = new PersonagemDAO();
                dao.Alterar(p);
                Session["Personagem"] = p;
                
                return RedirectToAction("Mercado", "Jogo");
            }
            return RedirectToAction("Mercado", "Jogo");
        }

        public ActionResult Emprego()
        {
            ViewBag.EmpregoAtual = Session["Emprego"];
            EmpregoDAO dao = new EmpregoDAO();
            IList<Emprego> emp = dao.ListarEmprego();
            ViewBag.Emprego = emp;

            ViewBag.Pagina = Session["PaginaAtual"];

            CursoJogadorDAO daoJC = new CursoJogadorDAO();
            IList<CursoJogador> cursosFeitos = daoJC.ListarCursos();
            ViewBag.CursosFeitos = cursosFeitos;

            CursoDAO daoC = new CursoDAO();
            IList<Curso> cursos = daoC.ListarCursos();
            ViewBag.Cursos = cursos;

            return View();
        }

        [Route("EntrevistaEmprego/{id}")]
        public ActionResult EntrevistaEmprego(int id)
        {
            Random rd = new Random();
            if (rd.Next(0, 2) == 1)
            {
                EmpregoDAO dao = new EmpregoDAO();

                PersonagemDAO daoP = new PersonagemDAO();
                ((Personagem)Session["Personagem"]).CodEmprego = id;
                daoP.Alterar((Personagem)Session["Personagem"]);

                Session["Emprego"] = dao.BuscarPorId(id);
                Session["ConseguiuEmprego"] = "S";
            }
            else
            {
                Session["ConseguiuEmprego"] = "N";
            }

            return RedirectToAction("Base", "Jogo");
        }
        
        public JsonResult ConseguiuEmprego()
        {
            if (Session["ConseguiuEmprego"] == null)
                return Json(null);
            if ((string)Session["ConseguiuEmprego"] == "S")
            {
                Session["ConseguiuEmprego"] = "j";
                return Json(true);
            }
            else if ((string)Session["ConseguiuEmprego"] == "N")
            {
                Session["ConseguiuEmprego"] = "j";
                return Json(false);
            }
            return Json(null);
        }

        public ActionResult Relatorio()
        {
            return View();
        }

        [Route("MudarPagina/{pagina}/{lugar}")]
        public ActionResult MudarPagina(int pagina, string lugar)
        {
            Session["PaginaAtual"] = pagina;
            return RedirectToAction(lugar, "Jogo");
        }

        public ActionResult Envelhecer()
        {
            Personagem p = (Personagem)Session["Personagem"];  

            if (Session["AnosCursando"] != null)
            {
                Session["AnosCursando"] = (int)Session["AnosCursando"] + 1;
                if((int)Session["AnosCursando"] == 5)
                {
                    Curso cur = (Curso)Session["Cursando"];
                    CursoJogadorDAO dao = new CursoJogadorDAO();
                    dao.Adicionar(p.Id, cur.id);

                    Session["AnosCursando"] = null;
                    Session["Cursando"] = null;
                }
            }

            Session["ConseguiuEmprego"] = null;

            p.Idade++;
            decimal salario = 0;
            if (p.CodEmprego != 0)
                salario = ((Emprego)Session["Emprego"]).salario;
            p.Dinheiro += salario;

            if (p.Sexo == 'M')
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menino_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "/Imagens/homem_adulto.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "/Imagens/velho.png";
            }
            else
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menina_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 40)
                    Session["imagem"] = "/Imagens/mulher_adulta.png";
                else if (p.Idade >= 41)
                    Session["imagem"] = "/Imagens/velha.png";
            }

            Session["Personagem"] = p;

            return RedirectToAction("Acontecimento", "Jogo");
        }

        public ActionResult Acontecimento()
        {
            if (Session["acontecimento"] == null)
            {
                Personagem p = (Personagem)Session["Personagem"];

                Random random = new Random();

                if (p.Idade == 90) //idade para dirigir
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
                if (p.Idade == 90) //maioridade 
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
                        id = random.Next(1, 1); //(1, 20);
                    }
                    else if (p.Idade <= 30)
                    {
                        id = random.Next(1, 1); //(21, 40);
                    }
                    else if (p.Idade <= 60)
                    {
                        id = random.Next(1, 1);      //(41, 60);
                    }
                    else
                    {
                        id = random.Next(1, 1);     //(61, 80);
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
            }

            return RedirectToAction("Base", "Jogo");
        }
        
        public JsonResult HaMensagem()
        {
            if (Session["acontecimento"] == null)
                return Json(false);
            return Json(true);
        }

        [Route("Escolher/{codConsequencia}")]
        public ActionResult Escolha(int codConsequencia)
        {
            Personagem p = (Personagem)Session["Personagem"];
            Consequencia c;

            if (((Consequencia)Session["consequencia1"]).Id == codConsequencia)
            {
                c = (Consequencia)Session["consequencia1"];
            }
            else
            {
                c = (Consequencia)Session["consequencia2"];
            }

            AjustarPontos(p, c);
            p = (Personagem)Session["Personagem"];

            PersonagemDAO dao = new PersonagemDAO();

            dao.Alterar(p);

            Session["acontecimento"] = null;

            return RedirectToAction("Base", "Jogo");
        }

        public void AjustarPontos(Personagem p, Consequencia c)
        {
            switch (c.TipoDoPontoGanho)
            {
                case "Inteligencia":
                    p.PontosInteligencia += c.PontosGanhos;
                    if (p.PontosInteligencia > 1000)
                        p.PontosInteligencia = 1000;
                    break;

                case "Saude":
                    p.PontosSaude += c.PontosGanhos;
                    if (p.PontosSaude > 1000)
                        p.PontosSaude = 1000;
                    break;

                case "Relacionamento":
                    p.PontosRelacionamento += c.PontosGanhos;
                    if (p.PontosRelacionamento > 1000)
                        p.PontosRelacionamento = 1000;
                    break;

                case "Felicidade":
                    p.PontosFelicidade += c.PontosGanhos;
                    if (p.PontosFelicidade > 1000)
                        p.PontosFelicidade = 1000;
                    break;
            }
            switch (c.TipoDoPontoPerdido)
            {
                case "Inteligencia":
                    p.PontosInteligencia -= c.PontosPerdidos;
                    if (p.PontosInteligencia < 0)
                        p.PontosInteligencia = 0;
                    break;

                case "Saude":
                    p.PontosSaude -= c.PontosPerdidos;
                    if (p.PontosSaude < 0)
                        p.PontosSaude = 0;
                    break;

                case "Relacionamento":
                    p.PontosRelacionamento -= c.PontosPerdidos;
                    if (p.PontosRelacionamento < 0)
                        p.PontosRelacionamento = 0;
                    break;

                case "Felicidade":
                    p.PontosFelicidade -= c.PontosPerdidos;
                    if (p.PontosFelicidade < 0)
                        p.PontosFelicidade = 0;
                    break;
            }

            Session["Personagem"] = p;
        }

        public ActionResult Curso()
        {
            ViewBag.Cursando = Session["Cursando"];
            CursoDAO dao = new CursoDAO();
            IList<Curso> cursos = dao.ListarCursos();
            ViewBag.Cursos = cursos;
            ViewBag.Pagina = Session["PaginaAtual"];

            CursoJogadorDAO usuDao = new CursoJogadorDAO();
            IList<CursoJogador> cursosFeitos = usuDao.ListarCursos();
            ViewBag.CursosFeitos = cursosFeitos;
            return View();
        }

        [Route("FazerCurso/{id}")]
        public ActionResult FazerCurso(int id)
        {
            Session["anosCursando"] = 0;
            CursoDAO dao = new CursoDAO();
            if (Session["Cursando"] == null)
                Session["Cursando"] = dao.BuscarPorId(id);

            return RedirectToAction("Curso", "Jogo");
        }

        public ActionResult Personagem()
        {
            ViewBag.Personagem = Session["Personagem"];
            return View();
        }

        
        public ActionResult Obituario(string causaDeMorte)
        {
            ViewBag.FormaDeMorte = 
             ViewBag.Personagem = Session["Personagem"];
            return View("Obituario");
        }
        
        
        //------------------------------------------------------------------------------------------------------------------------------
        //Outros

        public ActionResult Outros()
        {
            return View();
        }
        public ActionResult Suicidio()
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pg = new PersonagemDAO();
            ViewBag.Personagem = p;
            pg.Morrer(p);
            return View("Obituario");
        }
        
        public ActionResult TerminarRelacionamento()
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pg = new PersonagemDAO();
            pg.TerminarRelacionamento(p);
            Session["Personagem"] = p;
            return View();
        }






        //--------------------------------------------------------------------------------------------------------------------
        //ALTERAÇÕES

        [Route("AlterarDinheiro/{d}")]
        public ActionResult AlterarDinheiro(decimal d)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.Dinheiro = p.Dinheiro - d;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }

        [Route("AlterarFelicidade/{f}")]
        public ActionResult AlterarFelicidade(int f)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosFelicidade = p.PontosFelicidade + f;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }

        [Route("AlterarInteligencia/{i}")]
        public ActionResult AlterarInteligencia(int i)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosInteligencia = p.PontosInteligencia + i;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }

        [Route("AlterarSaude/{s}")]
        public ActionResult AlterarSaude(int s)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosSaude = p.PontosSaude + s;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }

        [Route("Alterar/{f}")]
        public ActionResult AlterarFelicidade(int f)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosFelicidade = p.PontosRelacionamento + f;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }
    }
}