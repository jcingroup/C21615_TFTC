using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class NewsController : WebFrontController
    {
        //
        // GET: /News/

        public NewsController()
        {
            ViewBag.BodyClass = "News";
        }

        public ActionResult list()
        {
            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.SearchMaster(new q_Message() { sidx="sort"  }, 0).SearchData;

            ViewBag.BodyClass = "News p1";
            return View(r1);
        }

        public ActionResult content(int id)
        {
            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.GetDataMaster(id, 0).SearchData;

            ViewBag.BodyClass = "News p2";
            return View(r1);
        }

    }
}
