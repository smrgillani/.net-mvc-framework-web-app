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
    public class syllabusController : Controller
    {
        //
        // GET: /syllabus/

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
                    List<Syllabuses> Searched = new Cateloge().SearchSyllabuses(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Syllabus_s = new List<Syllabus>();
                        foreach (var gdfc in Searched)
                        {
                            Syllabus dbr = new Syllabus();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name_of_lvl = gdfc.Name_of_lvl;
                            dbr.Detail_of_syllabus = gdfc.Detail_of_syllabus;
                            Data.Syllabus_s.Add(dbr);
                        }
                        Data.Syllabus_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Syllabuses> syllabuses = new Cateloge().Syllabuses();

                    if (syllabuses == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Syllabus_s = new List<Syllabus>();
                        foreach (var gdfc in syllabuses)
                        {
                            Syllabus dbr = new Syllabus();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name_of_lvl = gdfc.Name_of_lvl;
                            dbr.Detail_of_syllabus = gdfc.Detail_of_syllabus;
                            Data.Syllabus_s.Add(dbr);
                        }
                        Data.Syllabus_s.TrimExcess();
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

                Syllabuses syllabus = new Cateloge().SelectSyllabus(id);

                if (syllabus == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Syllabus = new Syllabus
                    {
                        Id = syllabus.db_Id,
                        Name_of_lvl = syllabus.Name_of_lvl,
                        Detail_of_syllabus = syllabus.Detail_of_syllabus,
                        Publish = syllabus.Publish
                    };
                    return View(Data);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult Publish(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Publish");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Publish(Syllabus ps, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Syllabuses PublishSyllabus = new Syllabuses();
                    PublishSyllabus.Publish = ps.Publish;
                    new Cateloge().PublishSyllabus(PublishSyllabus, id);
                    TempData["Msg"] = " This Syllabus Have Published Successfully";
                    return RedirectToAction("View", new { id = id });
                }

                return RedirectToAction("Index");
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
                        return PartialView("_CreateNewSyllabus", Data);
                    }

                }

                return RedirectToAction("Index");
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
                    Syllabuses AddSyllabus = new Syllabuses();
                    AddSyllabus.Name_of_lvl = Add.Syllabus.Name_of_lvl;
                    AddSyllabus.Detail_of_syllabus = Add.Syllabus.Detail_of_syllabus;
                    AddSyllabus.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddSyllabus.Month = DateTime.Today.ToString("MMM");
                    AddSyllabus.Year = DateTime.Today.ToString("yyyy");
                    AddSyllabus.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddSyllabus(AddSyllabus);
                    TempData["Msg"] = "New Syllabus Have Added Successfully";
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

                Syllabuses syllabus = new Cateloge().SelectSyllabus(id);

                if (syllabus == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Syllabus Formelements = new Syllabus
                    {
                        Name_of_lvl = syllabus.Name_of_lvl,
                        Detail_of_syllabus = syllabus.Detail_of_syllabus
                    };
                    return PartialView("_CreateNewSyllabus", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Syllabus Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Syllabuses UpdateSyllabus = new Syllabuses();
                    UpdateSyllabus.Name_of_lvl = Update.Name_of_lvl;
                    UpdateSyllabus.Detail_of_syllabus = Update.Detail_of_syllabus;
                    new Cateloge().UpdateSyllabus(UpdateSyllabus, id);
                    TempData["Msg"] = "Syllabus Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
