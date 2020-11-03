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
    public class subjectsController : Controller
    {
        //
        // GET: /subjects/

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
                    List<Subjects> Searched = new Cateloge().SearchSubjects(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Subject_s = new List<Subject>();
                        foreach (var gdfc in Searched)
                        {
                            Subject dbr = new Subject();
                            dbr.Id = gdfc.db_Id;
                            dbr.ClassLevel = gdfc.ClassLevel;
                            dbr.Name = gdfc.Name;
                            Data.Subject_s.Add(dbr);
                        }
                        Data.Subject_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Subjects> Subjects = new Cateloge().Subjects();

                    if (Subjects == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Subject_s = new List<Subject>();
                        foreach (var gdfc in Subjects)
                        {
                            Subject dbr = new Subject();
                            dbr.Id = gdfc.db_Id;
                            dbr.ClassLevel = gdfc.ClassLevel;
                            dbr.ClassName = (gdfc.ClassName != null) ? gdfc.ClassName.Name : null;
                            dbr.Name = gdfc.Name;
                            Data.Subject_s.Add(dbr);
                        }
                        Data.Subject_s.TrimExcess();
                        return View(Data);
                    }
                }
                return View();

            }
        }

        [HttpGet]
        public ActionResult All(string Search_key)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<Subjects> Subjects = new Cateloge().Subjects();
                AllClasses Data = new AllClasses();
                if (Subjects == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    Data.Subject_s = new List<Subject>();
                    foreach (var gdfc in Subjects)
                    {
                        Subject dbr = new Subject();
                        dbr.Id = gdfc.db_Id;
                        dbr.ClassLevel = gdfc.ClassLevel;
                        dbr.ClassName = (gdfc.ClassName != null) ? gdfc.ClassName.Name : null;
                        dbr.Name = gdfc.Name;
                        Data.Subject_s.Add(dbr);
                    }
                    Data.Subject_s.TrimExcess();
                    return View(Data);
                }
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

        public ActionResult Create()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {


                if (Request.IsAjaxRequest())
                {
                    List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();

                    if (ClassLevels == null)
                    {
                        return View();
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.ClassLevel_s = new List<ClassLevel>();
                        foreach (var gdfc in ClassLevels)
                        {
                            ClassLevel dbr = new ClassLevel();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            Data.ClassLevel_s.Add(dbr);
                        }
                        Data.ClassLevel_s.TrimExcess();
                        return PartialView("_CreateNewSubject", Data);
                    }
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AllClasses Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Subjects AddSubject = new Subjects();
                    AddSubject.ClassLevel = Add.Subject.ClassLevel;
                    AddSubject.Name = Add.Subject.Name;
                    AddSubject.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddSubject.Month = DateTime.Today.ToString("MMM");
                    AddSubject.Year = DateTime.Today.ToString("yyyy");
                    AddSubject.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddSubject(AddSubject);
                    TempData["msg"] = "New Subject Have Added Successfully";
                    return RedirectToAction("Index");
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

                //if (Request.IsAjaxRequest())
                //{
                    List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();
                    Subjects subject = new Cateloge().SelectSubject(id);

                    if (ClassLevels == null)
                    {
                        return View();
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.ClassLevel_s = new List<ClassLevel>();
                        foreach (var gdfc in ClassLevels)
                        {
                            ClassLevel dbr = new ClassLevel();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            Data.ClassLevel_s.Add(dbr);
                        }
                        Data.ClassLevel_s.TrimExcess();

                    if (subject == null)
                    {
                        return View();
                    }
                    else
                    {
                            Data.Subject = new Subject
                            {
                                ClassLevel = subject.ClassLevel,
                                ClassName = (subject.ClassName != null) ? subject.ClassName.Name : null,
                                Name = subject.Name
                            };
                    }

                        return PartialView("_EditSubject", Data);
                    }
                //}
                //else
                //{

                //    return RedirectToAction("Index");
                //}
            }
        }

        [HttpPost]
        public ActionResult Edit(AllClasses Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {


                if (ModelState.IsValid)
                {
                    Subjects UpdateSubject = new Subjects();
                    UpdateSubject.ClassLevel = Update.Subject.ClassLevel;
                    UpdateSubject.Name = Update.Subject.Name;
                    new Cateloge().UpdateSubject(UpdateSubject, id);
                    TempData["msg"] = "Subject Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
