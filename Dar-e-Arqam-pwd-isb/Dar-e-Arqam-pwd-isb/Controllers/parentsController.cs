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
    public class parentsController : Controller
    {
        [HttpGet]
        public ActionResult Index(string Search_key)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (!string.IsNullOrEmpty(Search_key))
                {
                    List<Students> Searched = new Cateloge().SearchParent(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Student_s = new List<Student>();
                        List<Student> ParentsList = new List<Student>();
                        foreach (var gdfc in Searched)
                        {
                            Student dbr = new Student();
                            dbr.db_Id = gdfc.db_Id;
                            dbr.Aplicnt_f_name = gdfc.Aplicnt_f_name;
                            dbr.Aplicnt_f_email = gdfc.Aplicnt_f_email;
                            dbr.Aplicnt_f_cell = gdfc.Aplicnt_f_cell;
                            dbr.Aplicnt_f_phone = gdfc.Aplicnt_f_phone;
                            dbr.Aplicnt_f_bsns_addr = gdfc.Aplicnt_f_bsns_addr;
                            Data.Student_s.Add(dbr);
                        }
                        Data.Student_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Students> Parents = new Cateloge().Parents();

                    if (Parents == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Student_s = new List<Student>();
                        List<Student> StudentsList = new List<Student>();
                        foreach (var gdfc in Parents)
                        {
                            Student dbr = new Student();
                            dbr.db_Id = gdfc.db_Id;
                            dbr.Aplicnt_f_name = gdfc.Aplicnt_f_name;
                            dbr.Aplicnt_f_email = gdfc.Aplicnt_f_email;
                            dbr.Aplicnt_f_cell = gdfc.Aplicnt_f_cell;
                            dbr.Aplicnt_f_phone = gdfc.Aplicnt_f_phone;
                            dbr.Aplicnt_f_bsns_addr = gdfc.Aplicnt_f_bsns_addr;
                            Data.Student_s.Add(dbr);
                        }
                        Data.Student_s.TrimExcess();
                        return View(Data);
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Active(string Search_key)
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

        [HttpGet]
        public ActionResult Old(string Search_key)
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

        [HttpGet]
        public ActionResult Trash(string Search_key)
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

        public ActionResult View(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Students Parents = new Cateloge().SelectParent(id);
                if (Parents == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Student = new Student
                    {
                        db_Id = Parents.db_Id,
                        Aplicnt_Id = Parents.Aplicnt_Id,
                        Aplicnt_f_name = Parents.Aplicnt_f_name,
                        Aplicnt_f_ocptn = Parents.Aplicnt_f_ocptn,
                        Aplicnt_f_title = Parents.Aplicnt_f_title,
                        Aplicnt_f_cell = Parents.Aplicnt_f_cell,
                        Aplicnt_f_bsns_name = Parents.Aplicnt_f_bsns_name,
                        Aplicnt_f_bsns_addr = Parents.Aplicnt_f_bsns_addr,
                        Aplicnt_f_email = Parents.Aplicnt_f_email,
                        Aplicnt_f_phone = Parents.Aplicnt_f_phone,
                        Aplicnt_m_name = Parents.Aplicnt_m_name,
                        Aplicnt_m_cell = Parents.Aplicnt_m_cell,
                        Aplicnt_m_ldln = Parents.Aplicnt_m_ldln
                    };
                    return View(Data);
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Students Parents = new Cateloge().SelectParent(id);
                if (Parents == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Student Data = new Student()
                    {
                        db_Id = Parents.db_Id,
                        Aplicnt_f_name = Parents.Aplicnt_f_name,
                        Aplicnt_f_ocptn = Parents.Aplicnt_f_ocptn,
                        Aplicnt_f_title = Parents.Aplicnt_f_title,
                        Aplicnt_f_cell = Parents.Aplicnt_f_cell,
                        Aplicnt_f_bsns_name = Parents.Aplicnt_f_bsns_name,
                        Aplicnt_f_bsns_addr = Parents.Aplicnt_f_bsns_addr,
                        Aplicnt_f_email = Parents.Aplicnt_f_email,
                        Aplicnt_f_phone = Parents.Aplicnt_f_phone,
                        Aplicnt_m_name = Parents.Aplicnt_m_name,
                        Aplicnt_m_cell = Parents.Aplicnt_m_cell,
                        Aplicnt_m_ldln = Parents.Aplicnt_m_ldln,
                    };
                    return PartialView("_EditParent", Data);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Student Update , int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Students UpdateParent = new Students();
                    UpdateParent.Aplicnt_f_name = Update.Aplicnt_f_name;
                    UpdateParent.Aplicnt_f_ocptn = Update.Aplicnt_f_ocptn;
                    UpdateParent.Aplicnt_f_title = Update.Aplicnt_f_title;
                    UpdateParent.Aplicnt_f_cell = Update.Aplicnt_f_cell;
                    UpdateParent.Aplicnt_f_bsns_name = Update.Aplicnt_f_bsns_name;
                    UpdateParent.Aplicnt_f_bsns_addr = Update.Aplicnt_f_bsns_addr;
                    UpdateParent.Aplicnt_f_email = Update.Aplicnt_f_email;
                    UpdateParent.Aplicnt_f_phone = Update.Aplicnt_f_phone;
                    UpdateParent.Aplicnt_m_name = Update.Aplicnt_m_name;
                    UpdateParent.Aplicnt_m_cell = Update.Aplicnt_m_cell;
                    UpdateParent.Aplicnt_m_ldln = Update.Aplicnt_m_ldln;
                    new Cateloge().UpdateParent(UpdateParent, id);
                    TempData["Msg"] = "Parent Info Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}