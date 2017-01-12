using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcCore.Business.Logic;

namespace DotWeb.WebApp.Controllers
{
    public class ContactUsController : WebFrontController
    {
        //
        // GET: /ContactUs/

        public ContactUsController()
        {
            ViewBag.BodyClass = "ContactUs";
        }

        public ActionResult Index()
        {
            a_PageContext ac_PageContext = new a_PageContext() { Connection = getSQLConnection(), logPlamInfo = this.plamInfo };
            var r1 = ac_PageContext.GetDataMaster(500, 0).SearchData;

            return View(r1);
        }

    }
}
