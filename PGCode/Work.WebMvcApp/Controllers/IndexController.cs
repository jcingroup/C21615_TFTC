using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class IndexController :  WebFrontController
    {

        public IndexController()
        {
            ViewBag.BodyClass = "Index";
        }

        public ActionResult Index()
        {
            IndexPage obj = new IndexPage();

            a_Message ac = new a_Message() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            obj.Messages = ac.SearchMaster(new q_Message() { MaxRecord = 5 }, 0).SearchData;

            a_ActivePhoto ac_ActivePhoto = new a_ActivePhoto() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            obj.Albums = ac_ActivePhoto.SearchMaster(new q_ActivePhoto() { MaxRecord = 1, sord = "sort" }, 0).SearchData.FirstOrDefault();

            ViewBag.IsFirstPage = true;
            return View(obj);
        }       
    }
}
