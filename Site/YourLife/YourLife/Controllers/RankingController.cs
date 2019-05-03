using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourLife.DAO;
using YourLife.Models;

namespace YourLife.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Ranking()
        {
            RankingDAO dao = new RankingDAO();
            IList<Ranking> rk = dao.ListarRanking();
            ViewBag.Ranking = rk;
            return View();
        }
    }
}