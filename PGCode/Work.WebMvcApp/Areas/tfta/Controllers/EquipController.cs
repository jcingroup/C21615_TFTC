using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.LogicL;

namespace DotWeb.WebApp.Areas.tfta.Controllers
{
    public class EquipController : WebFrontController
    {
        //
        // GET: /tfta/Equip/

         public EquipController()
        {
            ViewBag.BodyClass = "Equip";
        }

        public ActionResult Index()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(300, 0).SearchData;

            ViewBag.BodyClass = "Equip p1";
            return View(r1);
        }

    }
}
