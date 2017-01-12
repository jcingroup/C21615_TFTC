using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class MemberController : WebFrontController
    {
        //
        // GET: /Member/

        public MemberController()
        {
            ViewBag.BodyClass = "Member";
        }

        public ActionResult Index()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(200, 0).SearchData;

            ViewBag.BodyClass = "Member p1";
            return View(r1);
        }

        public ActionResult p2()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(210, 0).SearchData;

            ViewBag.BodyClass = "Member p2";
            return View(r1);
        }

        public ActionResult p3()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(220, 0).SearchData;

            ViewBag.BodyClass = "Member p3";
            return View(r1);
        }

    }
}
