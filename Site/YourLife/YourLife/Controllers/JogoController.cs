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
                p.CarteiraMotorista = 'N';
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
            IList<MercadoJogador> mj = daoMJ.ListarMercado(ViewBag.Personagem.Id);
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
            IList<CursoJogador> cursosFeitos = daoJC.ListarCursos(((Personagem)Session["Personagem"]).Id);
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

        public JsonResult HaMensagem()
        {
            if (Session["ConseguiuEmprego"] == null && Session["MensagemAcontecimento"] == null)
                return Json(null);
            else if(Session["ConseguiuEmprego"] != null)
            {
                if ((string)Session["ConseguiuEmprego"] == "S")
                {
                    Session["ConseguiuEmprego"] = "j";
                    return Json("Parabéns, você passou na entrevista de emprego!!<br>Entre em empregos novamente após envelhecer!");
                }
                else if ((string)Session["ConseguiuEmprego"] == "N")
                {
                    Session["ConseguiuEmprego"] = "j";
                    return Json("Sinto muito, você não passou na entrevista =(<br>Entre em empregos novamente após envelhecer!");
                }
            }
            else if(Session["MensagemAcontecimento"] != null)
            {
                string msg = (string)Session["MensagemAcontecimento"];
                Session["MensagemAcontecimento"] = null;
                return Json(msg);
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
                if ((int)Session["AnosCursando"] == 5)
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

            //---------------------------------------------------------chances de morrer
            int longevidade = 110 - p.Idade;
            Random rm = new Random();
            int chanceAtual = rm.Next(0, longevidade);
            if (longevidade == chanceAtual)
            {
                PersonagemDAO daoPG = new PersonagemDAO();
                return RedirectToAction("Obituario",new { causaDaMorte = "seu personagem ficou doente e veio a falecer" });
            }
            //--------------------------------------------------------chances de morrer
            return RedirectToAction("Acontecimento", "Jogo");
        }

        public ActionResult Acontecimento()
        {
            if (Session["acontecimento"] == null)
            {
                Personagem p = (Personagem)Session["Personagem"];

                Random random = new Random();

                if (p.Idade == 16) //idade para dirigir
                {
                    AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
                    AcontecimentoFixo af = dao.BuscarPorId(random.Next(1,2));

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
                    AcontecimentoFixo af = dao.BuscarPorId(3);

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
                        id = random.Next(1, 3);
                    }
                    else if (p.Idade <= 30)
                    {
                        id = random.Next(21, 25);
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

        public JsonResult HaAcontecimento()
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

            if (c.assunto == "pontos")
            {
                p = AjustarPontos(p, c);
            }
            else if(c.assunto == "carteira")
            {
                if(c.PontosGanhos == 1)
                {
                    p.CarteiraMotorista = 'S';
                }
            }
            else if(c.assunto == "namoro")
            {
                if(c.PontosGanhos == 1 && !(c.TipoDoPontoGanho.Equals("")))
                {
                    ParceiroDAO daoParceiro = new ParceiroDAO();
                    Random random = new Random();
                    if(c.TipoDoPontoGanho.Equals('M'))
                    {
                        Parceiro par = daoParceiro.BuscarPorId(random.Next(1, 30));
                        Session["Parceiro"] = par;
                        p.Parceiro = par.id;
                    }
                    else
                    {
                        Parceiro par = daoParceiro.BuscarPorId(random.Next(31, 60));
                        Session["Parceiro"] = par;
                        p.Parceiro = par.id;
                    }
                }
                else if(c.PontosGanhos == 0 && c.TipoDoPontoGanho.Equals(""))
                {
                    p.Parceiro = 0;
                    Session["Parceiro"] = 0;
                }
            }
            else if(c.assunto == "carreira")
            {
                Session["MensagemAcontecimento"] = c.resultado;
                RedirectToAction("Curso", "Jogo");
            }

            Session["MensagemAcontecimento"] = c.resultado;

            PersonagemDAO dao = new PersonagemDAO();
            dao.Alterar(p);

            Session["acontecimento"] = null;

            if (p.PontosFelicidade == 0)
            {
                Suicidio();
                return View("Suicidio");
            }

            return RedirectToAction("Base", "Jogo");
        }

        public Personagem AjustarPontos(Personagem p, Consequencia c)
        {
            switch (c.TipoDoPontoGanho)
            {
                case 'I':
                    p.PontosInteligencia += c.PontosGanhos;
                    if (p.PontosInteligencia > 1000)
                        p.PontosInteligencia = 1000;
                    break;

                case 'S':
                    p.PontosSaude += c.PontosGanhos;
                    if (p.PontosSaude > 1000)
                        p.PontosSaude = 1000;
                    break;

                case 'R':
                    p.PontosRelacionamento += c.PontosGanhos;
                    if (p.PontosRelacionamento > 1000)
                        p.PontosRelacionamento = 1000;
                    break;

                case 'F':
                    p.PontosFelicidade += c.PontosGanhos;
                    if (p.PontosFelicidade > 1000)
                        p.PontosFelicidade = 1000;
                    break;
            }
            switch (c.TipoDoPontoPerdido)
            {
                case 'I':
                    p.PontosInteligencia -= c.PontosPerdidos;
                    if (p.PontosInteligencia < 0)
                        p.PontosInteligencia = 0;
                    break;

                case 'S':
                    p.PontosSaude -= c.PontosPerdidos;
                    if (p.PontosSaude < 0)
                        p.PontosSaude = 0;
                    break;

                case 'R':
                    p.PontosRelacionamento -= c.PontosPerdidos;
                    if (p.PontosRelacionamento < 0)
                        p.PontosRelacionamento = 0;
                    break;

                case 'F':
                    p.PontosFelicidade -= c.PontosPerdidos;
                    if (p.PontosFelicidade < 0)
                        p.PontosFelicidade = 0;
                    break;
            }
            return p;
        }

        public ActionResult Curso()
        {
            ViewBag.Cursando = Session["Cursando"];
            CursoDAO dao = new CursoDAO();
            IList<Curso> cursos = dao.ListarCursos();
            ViewBag.Cursos = cursos;
            ViewBag.Pagina = Session["PaginaAtual"];

            CursoJogadorDAO usuDao = new CursoJogadorDAO();
            IList<CursoJogador> cursosFeitos = usuDao.ListarCursos(((Personagem)Session["Personagem"]).Id);
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
            Personagem p = ViewBag.Personagem = Session["Personagem"];

            ParceiroDAO daoP = new ParceiroDAO();
            ViewBag.Parceiro = daoP.SelecionarParceiro(p.Parceiro);

            MercadoJogadorDAO daoMJ = new MercadoJogadorDAO();
            ViewBag.Bens = daoMJ.ListarMercado(p.Id);

            CursoJogadorDAO daoCJ = new CursoJogadorDAO();
            IList<CursoJogador> cursosFeitos = daoCJ.ListarCursos(p.Id);

            foreach (var bem in cursosFeitos)
            {

            }

            return View();
        }


        public ActionResult Obituario(string causaDaMorte)
        {
            ViewBag.FormaDeMorte = causaDaMorte;
             ViewBag.Personagem = Session["Personagem"];
            return View("Obituario");
        }


        //------------------------------------------------------------------------------------------------------------------------------
        //Outros

        public ActionResult Outros()
        {
            ViewBag.Personagem = Session["Personagem"];
            return View();
        }

        public JsonResult Idade()
        {
            return Json(((Personagem)Session["Personagem"]).Idade);
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
            p.Parceiro = 0;
            p.PontosSaude -= 30;
            p.PontosFelicidade -= 50;
            PersonagemDAO pg = new PersonagemDAO();
            pg.Alterar(p);

            Session["Personagem"] = p;
            return View();
        }

        public ActionResult Demissao()
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pg = new PersonagemDAO();
            p.CodEmprego = 0;
            p.PontosFelicidade -= 10;
            pg.Alterar(p);
            Session["Personagem"] = p;
            return View();
        }

        [Route("AlterarAcademia/{d}/{s}")]
        public ActionResult AlterarAcademia(decimal d, int s)
        {
            AlterarDinheiro(d);
            AlterarSaude(s);
            return View("Outros");
        }

        [Route("IrAoCinema/{d}/{s}")]
        public ActionResult IrAoCinema(decimal d, int s)
        {
            AlterarDinheiro(-d);
            AlterarFelicidade(s);
            return View("Outros");
        }

        [Route("IrAoCinema/{f}")]
        public ActionResult IrAoCinema(int f)
        {
            AlterarFelicidade(f);
            return View("Outros");
        }

        [Route("VisitarParentes/{f}/{d}")]
        public ActionResult VisitarParentes(int f, decimal d)
        {
            AlterarFelicidade(f);
            AlterarDinheiro(-d);
            return View("Outros");
        }
        [Route("VisitarParentes/{f}")]
        public ActionResult VisitarParentes(int f)
        {
            AlterarFelicidade(f);
            return View("Outros");
        }

        [Route("Viajar/{d}/{f}/{s}/{i}/{r}")]
        public ActionResult Viajar(decimal d, int f, int s, int i, int r)
        {
            Personagem p = (Personagem)Session["Personagem"];
            AlterarDinheiro(-d);
            AlterarFelicidade(f);
            AlterarInteligencia(-i);
            AlterarSaude(s);
            if (p.Parceiro != 0)
                AlterarRelacionamento(r);
            return View("Outros");
        }

       [Route("Passear`/{f}/{s}/{i}")]
        public ActionResult Passear(int f, int s, int i)
        {
            Personagem p = (Personagem)Session["Personagem"];
            AlterarFelicidade(f);
            AlterarSaude(s);
            AlterarInteligencia(-i);
            return View("Outros");

        }


        //--------------------------------------------------------------------------------------------------------------------
        //ALTERAÇÕES



        [Route("AlterarDinheiro/{d}")]
        public void AlterarDinheiro(decimal d)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.Dinheiro = p.Dinheiro + d;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
        }

        [Route("AlterarFelicidade/{f}")]
        public void AlterarFelicidade(int f)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosFelicidade = p.PontosFelicidade + f;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
        }

        [Route("AlterarInteligencia/{i}")]
        public void AlterarInteligencia(int i)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosInteligencia = p.PontosInteligencia + i;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
        }

        [Route("AlterarSaude/{s}")]
        public void AlterarSaude(int s)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosSaude = p.PontosSaude + s;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
        }

        [Route("AlterarRelacionamento/{r}")]
        public void AlterarRelacionamento(int r)
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO pDAO = new PersonagemDAO();
            p.PontosRelacionamento = p.PontosRelacionamento + r;
            pDAO.Alterar(p);
            Session["Personagem"] = p;
        }


        //-------------------------------------------------------------------------USUARIO

        public ActionResult ExcluirUsuario()
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            PersonagemDAO pg = new PersonagemDAO();
            Personagem personagem = (Personagem)Session["Personagem"];
            pg.Morrer(personagem);
            Usuario usuario = (Usuario)Session["Usuario"];
            usuDAO.Excluir(usuario);
            return View("PaginaInicial");
        }


    }
}