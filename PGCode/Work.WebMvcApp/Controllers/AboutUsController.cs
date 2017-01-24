using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class AboutUsController : WebFrontController
    {
        //
        // GET: /AboutUs/
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

        public ActionResult tfta()
        {
            C21A0_TFTCEntities db = new C21A0_TFTCEntities();
            var md = db.網頁L.Where(x => x.id == 100).FirstOrDefault();

            return View(md);
        }
        public ActionResult tfta2()
        {
            C21A0_TFTCEntities db = new C21A0_TFTCEntities();
            var md = db.網頁L.Where(x => x.id == 110).FirstOrDefault();
            return View(md);
        }
        public ActionResult tfta3()
        {
            C21A0_TFTCEntities db = new C21A0_TFTCEntities();
            var md = db.網頁L.Where(x => x.id == 120).FirstOrDefault();
            return View(md);
        }
        public ActionResult tfta4()
        {
            C21A0_TFTCEntities db = new C21A0_TFTCEntities();
            var md = db.網頁L.Where(x => x.id == 130).FirstOrDefault();
            return View(md);
        }
        public ActionResult tfta5()
        {
            C21A0_TFTCEntities db = new C21A0_TFTCEntities();
            var md = db.網頁L.Where(x => x.id == 140).FirstOrDefault();
            return View(md);
        }
    }
}
