using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class NewsController : WebFrontController
    {
        //
        // GET: tfta/News/
        public NewsController()
        {
            ViewBag.BodyClass = "News";
        }

        public ActionResult list(String kind)
        {
            if (kind == null)
                kind = "Active";

            ViewBag.KindName = CodeSheet.消息分類L.MakeCodes().Where(x => x.Code == kind).FirstOrDefault().Value;
            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.SearchMaster(new q_Message() { sidx = "sort", s_kind=kind }, 0).SearchData;
            return View(r1);
        }

        public ActionResult content(int id)
        {
            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac.GetDataMaster(id, 0).SearchData;
            ViewBag.KindName = CodeSheet.消息分類L.MakeCodes().Where(x => x.Code == r1.kind).FirstOrDefault().Value;
            return View(r1);
        }
    }
}
