using Dar_e_Arqam_pwd_isb.Models;
using Dar_e_Arqam_pwd_isb.APP;
using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dar_e_Arqam_pwd_isb.Controllers
{
    public class messageController : Controller
    {
        //
        // GET: /message/

        public ActionResult Index()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                return View();
            }
        }

    }
}
