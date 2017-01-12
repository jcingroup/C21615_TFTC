using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class AlbumsController : WebFrontController
    {
        //
        // GET: tfta/Albums/
        public AlbumsController()
        {
            ViewBag.BodyClass = "Albums";
        }

        public ActionResult list()
        {
            a_ActivePhoto ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.SearchMaster(new q_ActivePhoto() { sidx = "sort", s_isopen = true }, 0).SearchData;

            ViewBag.BodyClass = "Albums p1";
            return View(r1);
        }

        public ActionResult content(int id)
        {
            a_ActivePhoto ac = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.GetDataMaster(id, 0).SearchData;

            ViewBag.BodyClass = "Albums p2";
            return View(r1);
        }

    }
}
