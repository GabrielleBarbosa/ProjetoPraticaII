﻿using System;
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

            UsuarioDAO daoU = new UsuarioDAO();
            Session["Usuario"] = daoU.BuscaPorNick(usu.nickname);

            if (Session["Personagem"] != null)
            {
                if (p.CodCursando != 0)
                {
                    CursoDAO daoC = new CursoDAO();
                    Curso cur = daoC.BuscarPorId(p.CodCursando);
                    Session["Cursando"] = cur;
                    Session["AnosCursando"] = p.AnosCursando;
                }

                EmpregoDAO daoE = new EmpregoDAO();
                Emprego e = daoE.BuscarPorId(p.CodEmprego);
                Session["Emprego"] = e;

                if (p.Sexo == 'M')
                {
                    if (p.Idade < 14)
                        Session["imagem"] = "/Imagens/menino.png";
                    else if (p.Idade >= 14 && p.Idade <= 20)
                        Session["imagem"] = "/Imagens/menino_adolescente.png";
                    else if (p.Idade >= 21 && p.Idade <= 60)
                        Session["imagem"] = "/Imagens/homem_adulto.png";
                    else if (p.Idade >= 61)
                        Session["imagem"] = "/Imagens/velho.png";
                }
                else
                {
                    if (p.Idade < 14)
                        Session["imagem"] = "/Imagens/menina.png";
                    else if (p.Idade >= 14 && p.Idade <= 20)
                        Session["imagem"] = "/Imagens/menina_adolescente.png";
                    else if (p.Idade >= 21 && p.Idade <= 60)
                        Session["imagem"] = "/Imagens/mulher_adulta.png";
                    else if (p.Idade >= 61)
                        Session["imagem"] = "/Imagens/velha.png";
                }
            }
            return RedirectToAction("Inicio", "Jogo");
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult SalvarNome(Personagem p)
        {
            if (ModelState.IsValid)
            {
                PersonagemDAO dao = new PersonagemDAO();
                if (Session["Personagem"] != null)
                {
                    Personagem pExcluir = (Personagem)Session["Personagem"];
                    dao.ExcluirPersonagem(pExcluir);
                }
                Usuario usu = (Usuario)Session["Usuario"];
                p.Dinheiro = 0;
                p.Idade = 7;
                p.Parceiro = 'N';
                p.PontosSaude = 800;
                Random rm = new Random();
                p.PontosInteligencia = rm.Next(100, 450);
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

                if(p.CodCursando != 0)
                {
                    CursoDAO daoC = new CursoDAO();
                    Curso cur = daoC.BuscarPorId(p.CodCursando);
                    Session["Cursando"] = cur;
                    Session["AnosCursando"] = p.AnosCursando;
                }

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
            else if (Session["ConseguiuEmprego"] != null)
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
            else if (Session["MensagemAcontecimento"] != null)
            {
                if (Session["MensagemAcontecimento"].ToString() != "")
                {
                    string msg = (string)Session["MensagemAcontecimento"];
                    Session["MensagemAcontecimento"] = null;
                    return Json(msg);
                }
                return Json(null);
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


        /*********************************************  Envelhecer ****************************************************/
        public ActionResult Envelhecer()
        {
            Session["Cinema"] = null;
            Session["Parentes"] = null;
            Session["Academia"] = null;
            Session["Estudou"] = null;
            Session["Namoro"] = null;

            Personagem p = (Personagem)Session["Personagem"];
            p = AjustarPontosEnvelhecer(p);

            p = AjustarAnosCursando(p);

            Session["ConseguiuEmprego"] = null;

            p.Idade++;

            if (p.CodEmprego != 0)
                p.Dinheiro += ((Emprego)Session["Emprego"]).salario;

            AjustarImagemPersonagem(p);

            Session["Personagem"] = p;

            //-----------------------chances de morrer------------------------------------//
            int longevidade = 110 - p.Idade;
            Random rm = new Random();
            int chanceAtual = rm.Next(0, longevidade);
            if (longevidade == chanceAtual)
            {
                PersonagemDAO daoPG = new PersonagemDAO();
                daoPG.Morrer(p);
                Session["CausaDaMorte"] = "Doença misteriosa";
                return RedirectToAction("Obituario", "Jogo");
            }
            //----------------------------------------------------------------------------//

            return RedirectToAction("Acontecimento", "Jogo");
        }

        public Personagem AjustarPontosEnvelhecer(Personagem p)
        {
            if (p.CodEmprego != 0 && Session["Cursando"] != null)
            {
                if (p.PontosFelicidade >= 20)
                    p.PontosFelicidade -= 20;
                else
                    p.PontosFelicidade = 0;
                if (p.PontosSaude >= 20)
                    p.PontosSaude -= 20;
                else
                    p.PontosSaude = 0;
            }
            if (Session["Cursando"] != null)
            {
                if (p.PontosInteligencia + 25 <= 1000)
                    p.PontosInteligencia += 25;
                else
                    p.PontosInteligencia = 1000;
            }
            if (p.Parceiro != 0)
            {
                Random random = new Random();
                p.PontosRelacionamento += random.Next(-30, 30);
                if (p.PontosRelacionamento < 0)
                    p.PontosRelacionamento = 0;
                else if (p.PontosRelacionamento > 1000)
                    p.PontosRelacionamento = 1000;
            }
            return p;
        }

        public Personagem AjustarAnosCursando(Personagem p)
        {
            if (Session["AnosCursando"] != null)
            {
                PersonagemDAO daoPersonagem = new PersonagemDAO();
                Session["AnosCursando"] = (int)Session["AnosCursando"] + 1;
                if ((int)Session["AnosCursando"] == 5)
                {
                    Curso cur = (Curso)Session["Cursando"];
                    CursoJogadorDAO dao = new CursoJogadorDAO();
                    dao.Adicionar(p.Id, cur.id);

                    Session["AnosCursando"] = null;
                    Session["Cursando"] = null;

                    p.AnosCursando = 0;
                    p.CodCursando = 0;
                    daoPersonagem.Alterar(p);
                }
                else
                {
                    p.AnosCursando = (int)Session["AnosCursando"];
                    p.CodCursando = ((Curso)Session["Cursando"]).id;
                    daoPersonagem.Alterar(p);
                }
            }
            return p;
        }

        public void AjustarImagemPersonagem(Personagem p)
        {
            if (p.Sexo == 'M')
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menino_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 60)
                    Session["imagem"] = "/Imagens/homem_adulto.png";
                else if (p.Idade >= 61)
                    Session["imagem"] = "/Imagens/velho.png";
            }
            else
            {
                if (p.Idade >= 14 && p.Idade <= 20)
                    Session["imagem"] = "/Imagens/menina_adolescente.png";
                else if (p.Idade >= 21 && p.Idade <= 60)
                    Session["imagem"] = "/Imagens/mulher_adulta.png";
                else if (p.Idade >= 61)
                    Session["imagem"] = "/Imagens/velha.png";
            }
        }

        /*************************************************************************************************/

        public ActionResult Acontecimento()
        {
            if (Session["acontecimento"] == null)
            {
                Personagem p = (Personagem)Session["Personagem"];

                Random random = new Random();

                if (p.Idade == 16) //idade para dirigir
                {
                    AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
                    AcontecimentoFixo af = dao.BuscarPorId(random.Next(1, 2));

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
                else if (p.Idade == 18) //maioridade 
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
                else if (p.Idade == 60) //idoso
                {
                    AcontecimentoFixoDAO dao = new AcontecimentoFixoDAO();
                    AcontecimentoFixo af = dao.BuscarPorId(6);

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
                    bool sorteou = SortearAcontecimento(p, random);
                    while (!sorteou)
                    {
                        sorteou = SortearAcontecimento(p, random);
                    }
                }
            }

            return RedirectToAction("Base", "Jogo");
        }

        public bool SortearAcontecimento(Personagem p, Random random)
        {
            AcontecimentoAleatorioDAO daoAcont = new AcontecimentoAleatorioDAO();
            int qtosAcontecimentos;
            bool valido = true;
            int id = 0;
            if (p.Idade <= 18)
            {
                qtosAcontecimentos = daoAcont.ContarAcontecimentos(1, 40);
                id = random.Next(1, qtosAcontecimentos);      
            }
            else if (p.Idade <= 30)
            {
                qtosAcontecimentos = daoAcont.ContarAcontecimentos(41, 80);
                id = random.Next(41, qtosAcontecimentos + 41);
            }
            else if (p.Idade <= 60)
            {
                qtosAcontecimentos = daoAcont.ContarAcontecimentos(81, 120);
                id = random.Next(81, qtosAcontecimentos + 81); 
            }
            else
            {
                qtosAcontecimentos = daoAcont.ContarAcontecimentos(121, 140);
                id = random.Next(121, qtosAcontecimentos + 121);
            }

            AcontecimentoAleatorio aa = daoAcont.BuscarPorId(id);
            EscolhaDAO daoEsc = new EscolhaDAO();
            Escolha esc = daoEsc.BuscarPorId(aa.CodEscolha);
            ConsequenciaDAO daoConseq = new ConsequenciaDAO();
            Consequencia conseq1 = daoConseq.BuscarPorId(esc.Consequencia1);
            Consequencia conseq2 = daoConseq.BuscarPorId(esc.Consequencia2);

            if (conseq1.assunto == "pontos" || conseq2.assunto == "pontos")
            {
                if (p.Parceiro == 0)
                {
                    if (conseq1.TipoDoPontoGanho == 'R' || conseq1.TipoDoPontoPerdido == 'R' || conseq2.TipoDoPontoGanho == 'R' || conseq2.TipoDoPontoPerdido == 'R')
                    {
                        valido = false;
                    }
                }

            }

            if(conseq1.assunto == "namoro" || conseq2.assunto == "namoro")
            {
                if(p.Parceiro == 0)
                {
                    if(conseq1.TipoDoPontoGanho.Equals(' ') || conseq2.TipoDoPontoGanho.Equals(' '))
                    {
                        valido = false;
                    }
                }
            }

            if(conseq1.assunto == "demissao" || conseq2.assunto == "demissao")
            {
                if(p.CodEmprego == 0)
                {
                    valido = false;
                }
            }
            
            
            if (valido)
            {
                ViewBag.Consequencia1 = Session["consequencia1"] = conseq1;
                ViewBag.Consequencia2 = Session["consequencia2"] = conseq2;
                ViewBag.Acontecimento = Session["acontecimento"] = aa;
                ViewBag.Escolha = Session["escolha"] = esc;
            }

            return valido;
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
            else if (c.assunto == "carteira")
            {
                if (c.PontosGanhos == 1)
                {
                    p.CarteiraMotorista = 'S';
                }

                p.Dinheiro -= 1500;
            }
            else if (c.assunto == "namoro")
            {
                if (c.PontosGanhos == 1 && !(c.TipoDoPontoGanho.Equals(' ')))
                {
                    ParceiroDAO daoParceiro = new ParceiroDAO();
                    Random random = new Random();
                    if (c.TipoDoPontoGanho.Equals('M'))
                    {
                        Parceiro par = daoParceiro.BuscarPorId(random.Next(31, 41));
                        Session["Parceiro"] = par;
                        p.Parceiro = par.id;
                    }
                    else
                    {
                        Parceiro par = daoParceiro.BuscarPorId(random.Next(1, 14));
                        Session["Parceiro"] = par;
                        p.Parceiro = par.id;
                    }
                }
                else if (c.PontosGanhos == 0 && c.TipoDoPontoGanho == ' ')
                {
                    p.Parceiro = 0;
                    Session["Parceiro"] = 0;
                }
            }
            else if (c.assunto == "carreira")
            {
                Session["MensagemAcontecimento"] = c.resultado;
                RedirectToAction("Curso", "Jogo");
            }
            else if (c.assunto == "demissao")
            {
                EmpregoDAO daoEmp = new EmpregoDAO();
                p.CodEmprego = 0;
                Session["Emprego"] = daoEmp.BuscarPorId(0);
            }
            else if(c.assunto == "dinheiro")
            {
                p.Dinheiro = p.Dinheiro+ c.PontosGanhos;
            }

            Session["MensagemAcontecimento"] = c.resultado;

            PersonagemDAO dao = new PersonagemDAO();
            dao.Alterar(p);
            Session["Personagem"] = p;
            Session["acontecimento"] = null;

            if (p.PontosFelicidade == 0)
            {
                Suicidio();
                return View("Obituario");
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
            Session["Cursando"] = dao.BuscarPorId(id);

            Personagem p = (Personagem)Session["Personagem"];
            p.CodCursando = id;
            p.AnosCursando = 0;
            PersonagemDAO daoP = new PersonagemDAO();
            daoP.Alterar(p);
            Session["Personagem"] = p;

            return RedirectToAction("Curso", "Jogo");
        }

        public ActionResult Personagem()
        {
            Personagem p = ViewBag.Personagem = Session["Personagem"];

            ParceiroDAO daoP = new ParceiroDAO();
            ViewBag.Parceiro = daoP.SelecionarParceiro(p.Parceiro);

            MercadoJogadorDAO daoMJ = new MercadoJogadorDAO();
            IList<MercadoJogador> bens = daoMJ.ListarMercado(p.Id);
            List<Mercado> listaMercado = new List<Mercado>();

            MercadoDAO daoM = new MercadoDAO();
            foreach (var bem in bens)
            {
                listaMercado.Add(daoM.BuscarPorId(bem.CodMercado));
            }
            ViewBag.Bens = listaMercado;

            CursoJogadorDAO daoCJ = new CursoJogadorDAO();
            IList<CursoJogador> cursosFeitos = daoCJ.ListarCursos(p.Id);
            List<Curso> listaCursos = new List<Curso>();

            CursoDAO daoC = new CursoDAO();
            foreach (var cur in cursosFeitos)
            {
                listaCursos.Add(daoC.BuscarPorId(cur.codCurso));
            }

            ViewBag.CursosFeitos = listaCursos;

            return View();
        }

        public ActionResult Obituario()
        {
            ViewBag.FormaDeMorte = Session["CausaDaMorte"];
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
            Session["CausaDaMorte"] = "Suicídio";
            return RedirectToAction("Obituario", "Jogo");
        }

        public ActionResult TerminarRelacionamento()
        {
            Personagem p = (Personagem)Session["Personagem"];
            p.Parceiro = 0;
            p.PontosSaude -= 30;
            p.PontosFelicidade -= 50;
            p.PontosRelacionamento -= 50;

            if(p.PontosRelacionamento < 0)
            {
                p.PontosRelacionamento = 0;
            }
            if(p.PontosFelicidade < 0)
            {
                p.PontosFelicidade = 0;
            }
            if(p.PontosSaude < 0)
            {
                p.PontosSaude = 0;
            }

            PersonagemDAO pg = new PersonagemDAO();
            pg.Alterar(p);

            Session["Personagem"] = p;
            return RedirectToAction("Outros");
        }

        public ActionResult Demissao()
        {
            Personagem p = (Personagem)Session["Personagem"];
            PersonagemDAO daoPG = new PersonagemDAO();
            p.CodEmprego = 0;
            p.PontosFelicidade -= 10;
            daoPG.Alterar(p);
            Session["Personagem"] = p;

            EmpregoDAO daoE = new EmpregoDAO();
            Session["Emprego"] = daoE.BuscarPorId(0);

            return RedirectToAction("Outros");
        }

        [Route("AlterarAcademia/{d}/{s}")]
        public ActionResult AlterarAcademia(decimal d, int s)
        {
            Session["Academia"] = "S";
            AlterarDinheiro(d);
            AlterarSaude(s);
            return RedirectToAction("Outros");
        }

        [Route("IrAoCinema/{d}/{s}")]
        public ActionResult IrAoCinema(decimal d, int s)
        {
            Session["Cinema"] = "S";
            Personagem p = (Personagem)Session["Personagem"];
            if (p.Dinheiro > 100)
            {
                AlterarDinheiro(-d);
                AlterarFelicidade(s);
            }
            return RedirectToAction("Outros");
        }

        [Route("IrAoCinema/{f}")]
        public ActionResult IrAoCinema(int f)
        {
            Session["Cinema"] = "S";
            AlterarFelicidade(f);
            return RedirectToAction("Outros");
        }

        [Route("VisitarParentes/{f}/{d}")]
        public ActionResult VisitarParentes(int f, decimal d)
        {
            Session["Parentes"] = "S";
            AlterarFelicidade(f);
            AlterarDinheiro(-d);
            return RedirectToAction("Outros");
        }
        [Route("VisitarParentes/{f}")]
        public ActionResult VisitarParentes(int f)
        {
            Session["Parentes"] = "S";
            AlterarFelicidade(f);
            return RedirectToAction("Outros");
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
            return RedirectToAction("Outros");
        }

        [Route("Estudar/{i}")]
        public ActionResult Estudar(int i)
        {
            Session["Estudou"] = "S";
            AlterarInteligencia(i);
            return RedirectToAction("Outros");
        }

        [Route("Carteira/{d}")]
        public ActionResult Carteira(decimal d)
        {
            AlterarDinheiro(-d);
            Random random = new Random();
            if(random.Next(0,1) == 1)
            {
                Session["MensagemAcontecimento"] = "A prova de direção foi um sucesso! Aproveite a carteira de motorista e dirija com cuidado";
                ((Personagem)Session["Personagem"]).CarteiraMotorista = 'S';
            }
            else
            {
                Session["MensagemAcontecimento"] = "Infelismente não foi dessa vez. Você ficou muito nervoso ao fazer a prova...";
            }
            return RedirectToAction("Base", "Jogo");
        }

        [Route("Namoro/{d}/{r}")]
        public ActionResult Namoro(int d, int r)
        {
            Session["Namoro"] = "S";
            AlterarRelacionamento(r);
            AlterarDinheiro(-d);
            return RedirectToAction("Outros");
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
            pg.ExcluirPersonagem(personagem);
            Usuario usuario = (Usuario)Session["Usuario"];
            usuDAO.Excluir(usuario);
            return View("PaginaInicial");
        }

        public ActionResult AlterarNomeUsuario()
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usu = (Usuario)Session["Usuario"];
            usuDAO.Alterar(usu);
            return View();
        }


    }
}