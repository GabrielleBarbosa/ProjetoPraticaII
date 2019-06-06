using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourLife.DAO;
using YourLife.Models;

namespace YourLife.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult ConfiguracoesUsuario()
        {
            ViewBag.Usuario = Session["Usuario"];
            return View();
        }
    }
}