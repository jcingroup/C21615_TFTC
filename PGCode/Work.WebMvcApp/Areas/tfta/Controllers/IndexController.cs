using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class IndexController : WebFrontController
    {
        //
        // GET: /tfta/Index/

        public IndexController()
        {
            ViewBag.BodyClass = "Index";
        }

        public ActionResult Index()
        {
            IndexPageL obj = new IndexPageL();

            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            obj.Messages = ac.SearchMaster(new q_Message() { MaxRecord = 3 , s_kind = CodeSheet.消息分類L.Active.Code}, 0).SearchData;

            a_ActivePhoto aca = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            obj.ActivePhoto = aca.SearchMaster(new q_ActivePhoto() { MaxRecord=1, sidx="sort" }, 0).SearchData.FirstOrDefault();

            ViewBag.IsFirstPage = true;
            return View(obj);
        }

    }
}
