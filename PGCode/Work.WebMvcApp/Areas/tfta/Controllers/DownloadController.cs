using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class DownloadController : WebFrontController
    {
        //
        // GET: tfta/Download/
        public DownloadController()
        {
            ViewBag.BodyClass = "Download";
        }

        public ActionResult Index()
        {
            a_Document ac = new a_Document() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1  = ac.SearchMaster(new q_Document() { s_isopen=true, sidx="sort" }, 0).SearchData;
            return View(r1);
        }

    }
}
