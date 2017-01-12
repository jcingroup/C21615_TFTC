using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class AboutUsController : WebFrontController
    {
        //
        // GET: tfta/AboutUs/
        public AboutUsController()
        {
            ViewBag.BodyClass = "AboutUs";
        }

        public ActionResult Index()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(100, 0).SearchData;

            ViewBag.BodyClass = "AboutUs p1";
            return View(r1);
        }

        public ActionResult p2()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(110, 0).SearchData;

            ViewBag.BodyClass = "AboutUs p2";
            return View(r1);
        }

        public ActionResult p3()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(120, 0).SearchData;

            ViewBag.BodyClass = "AboutUs p3";
            return View(r1);
        }

        public ActionResult p4()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(130, 0).SearchData;

            ViewBag.BodyClass = "AboutUs p4";
            return View(r1);
        }

        public ActionResult p5()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(140, 0).SearchData;

            ViewBag.BodyClass = "AboutUs p5";
            return View(r1);
        }

    }
}
