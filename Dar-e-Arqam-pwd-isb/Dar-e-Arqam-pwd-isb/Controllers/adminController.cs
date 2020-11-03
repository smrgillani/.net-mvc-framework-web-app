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
    public class adminController : Controller
    {
        //
        // GET: /admin/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["Username"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "admin");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login li)
        {
            List<Logins> selectuser = new Cateloge().SelectAllLoginUsers();
            Logins temp = (from u in selectuser where u.Username.Equals(li.Username.ToLower()) && u.Password.Equals(li.Password) select u).FirstOrDefault();
            if (temp != null)
            {
                // Authenticating user, only with email, you can also inlude password, here is not any method getting user name + password
                //FormsAuthentication.SetAuthCookie(li.Username, true);
                Session["Username"] = li.Username;
                Session["Password"] = li.Password;
                return RedirectToAction("Home" , "admin");
            }
            else
            {
                TempData["Msg"] = "Username Or Password Invalid !";
                return View(li);
            }
        }

        public ActionResult Home()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<Students> Students = new Cateloge().Students();
                AllClasses Data = new AllClasses();

                if (Students == null)
                {
                    ViewBag.StatusMessage = " Null ";
                }
                else
                {
                    Data.Student_s = new List<Student>();
                    foreach (var gdfc in Students)
                    {
                        Student dbr = new Student();
                        Data.Student_s.Add(dbr);
                    }
                    Data.Student_s.TrimExcess();
                    return View(Data);
                }
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["Password"] = null;
            return RedirectToAction("Index", "Admin", new { area = "" });
            
        }
    }
}
