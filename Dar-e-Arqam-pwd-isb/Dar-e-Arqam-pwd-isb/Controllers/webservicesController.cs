using Dar_e_Arqam_pwd_isb.Models;
using Dar_e_Arqam_pwd_isb.ENT;
using Dar_e_Arqam_pwd_isb.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dar_e_Arqam_pwd_isb.Controllers
{
    public class webservicesController : Controller
    {
        //
        // GET: /webservices/

        public ActionResult Index()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                List<Students> allstudentsresultstatus = new Cateloge().AllStudentsResultStatus();
                if (allstudentsresultstatus == null)
                {
                    TempData["StatusMsg"] = "Not Fully Blocked Or Allowed To Some Of The Students";
                }
                else
                {
                    TempData["StatusMsg"] = "Blocked";
                }
                return View();
            }
        }

        public ActionResult PublishAllStudentsResult()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_PublishAllStudentsResult");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult PublishAllStudentsResult(Students pas)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Students PublishAllStudentsResult = new Students();
                PublishAllStudentsResult.Publish_result = pas.Publish_result;
                new Cateloge().PublishAllStudentsResult(PublishAllStudentsResult);
                if (pas.Publish_result == "2")
                {
                    TempData["Msg"] = "All Students Result Have Published Successfully";
                }
                else
                {
                    TempData["Msg"] = "All Students Result Have Blocked Successfully";
                }
                return RedirectToAction("Index");
            }
        }

    }
}
