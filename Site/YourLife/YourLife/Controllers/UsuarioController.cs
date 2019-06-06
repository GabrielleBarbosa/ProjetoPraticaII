using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourLife.DAO;
using YourLife.Models;
using YourLife.Filtro;

namespace YourLife.Controllers
{
    public class UsuarioController : Controller
    {
        [AutorizacaoFilterAttribute]
        public ActionResult ConfiguracoesUsuario()
        {
            ViewBag.Usuario = Session["Usuario"];
            return View();
        }

        public JsonResult ValidarLogin(string senha, string nick)
        {
            UsuarioDAO usuDAO = new UsuarioDAO();
            Usuario usuarioExistente = usuDAO.BuscaPorNick(nick);
            if (usuarioExistente != null && usuarioExistente.senha == senha)
            {
                Session["Usuario"] = usuarioExistente;
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult Alterar(Usuario usu)
        {
            UsuarioDAO daoU = new UsuarioDAO();
            Usuario usuAntes = (Usuario)Session["Usuario"];

            usuAntes.senha = usu.senha;
            
            daoU.Alterar(usuAntes);

            Session["Usuario"] = usuAntes;

            return RedirectToAction("PaginaInicial", "Jogo");
        }

        public ActionResult Deslogar()
        {
            Session["Usuario"] = null;
            return RedirectToAction("PaginaInicial", "Jogo");
        }

        public ActionResult DeletarUsuario()
        {
            UsuarioDAO daoU = new UsuarioDAO();
            daoU.Deletar((Usuario)Session["Usuario"]);

            Session["Usuario"] = null;
            return RedirectToAction("PaginaInicial", "Jogo");
        }
    }
}