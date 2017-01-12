using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class DownloadController : WebFrontController
    {
        //
        // GET: /Download/

        public DownloadController()
        {
            ViewBag.BodyClass = "Download";
        }

        public ActionResult Index()
        {
            a_Document ac = new a_Document() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.SearchMaster(new q_Document() { s_isopen = true, sidx = "sort" }, 0).SearchData;
            ViewBag.BodyClass = "Download p1";
            return View(r1);
        }

    }
}
