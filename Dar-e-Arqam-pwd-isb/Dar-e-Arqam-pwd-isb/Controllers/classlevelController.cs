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
    public class classlevelController : Controller
    {
        //
        // GET: /classlevel/
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
                    List<ClassLevels> Searched = new Cateloge().SearchClassLevel(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.ClassLevel_s = new List<ClassLevel>();
                        foreach (var gdfc in Searched)
                        {
                            ClassLevel dbr = new ClassLevel();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Range = gdfc.Range;
                            Data.ClassLevel_s.Add(dbr);
                        }
                        Data.ClassLevel_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();

                    if (ClassLevels == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
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
                            dbr.Range = gdfc.Range;
                            Data.ClassLevel_s.Add(dbr);
                        }
                        Data.ClassLevel_s.TrimExcess();
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
                List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();

                if (ClassLevels == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
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
                        dbr.Range = gdfc.Range;
                        Data.ClassLevel_s.Add(dbr);
                    }
                    Data.ClassLevel_s.TrimExcess();
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
                    return PartialView("_CreateClassLevel");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassLevel Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ClassLevels AddClassLevel = new ClassLevels();
                    AddClassLevel.Name = Add.Name;
                    AddClassLevel.Range = Add.Range;
                    AddClassLevel.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddClassLevel.Month = DateTime.Today.ToString("MMM");
                    AddClassLevel.Year = DateTime.Today.ToString("yyyy");
                    AddClassLevel.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddClassLevel(AddClassLevel);
                    TempData["Msg"] = "New Class Level Have Added Successfully";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult CreateSection(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CreateSection");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSection(GradeSection Add, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    GradesSections AddGradeSection = new GradesSections();
                    AddGradeSection.Class_Level_id = Convert.ToString(id);
                    AddGradeSection.Name = Add.Name;
                    AddGradeSection.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddGradeSection.Month = DateTime.Today.ToString("MMM");
                    AddGradeSection.Year = DateTime.Today.ToString("yyyy");
                    AddGradeSection.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddGradeSection(AddGradeSection);
                    TempData["Msg"] = "New Section Have Added Successfully";
                    return RedirectToAction("View", new { id = id });
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

                ClassLevels ClassLevel = new Cateloge().SelectClassLevel(id);

                if (ClassLevel == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    ClassLevel Formelements = new ClassLevel
                    {
                        Name = ClassLevel.Name,
                        Range = ClassLevel.Range
                    };
                    return PartialView("_CreateClassLevel", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewSection(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                AllClasses Data = new AllClasses();
                GradesSections gradesections = new Cateloge().SelectGradeSection(id);

                if (gradesections == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    List<Students> Students = new Cateloge().SelectStudentsForClassLevels(id);

                    if (Students == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        Data.Student_s = new List<Student>();
                        List<Student> StudentsList = new List<Student>();
                        foreach (var gdfc in Students)
                        {
                            Student dbr = new Student();
                            dbr.db_Id = gdfc.db_Id;
                            dbr.Aplicnt_Id = gdfc.Aplicnt_Id;
                            dbr.Aplicnt_name = gdfc.Aplicnt_name;
                            dbr.Aplicnt_dob = gdfc.Aplicnt_dob;
                            dbr.Aplicnt_c_grade = gdfc.Aplicnt_c_grade;
                            dbr.Aplicnt_f_cell = gdfc.Aplicnt_f_cell;
                            dbr.Aplicnt_pp_photo = gdfc.Aplicnt_pp_photo;
                            dbr.ClassName = (gdfc.ClassName != null) ? gdfc.ClassName.Name : null;
                            dbr.Aplicnt_gender = gdfc.Aplicnt_gender;
                            Data.Student_s.Add(dbr);
                        }
                        Data.Student_s.TrimExcess();
                    }

                    Data.GradeSection_ = new GradeSection
                    {
                        Name = gradesections.Name,
                        Class_name = (gradesections.Class_name != null) ? gradesections.Class_name.Name : null
                    };

                }

                return View(Data);
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
                AllClasses Data = new AllClasses();
                ClassLevels ClassLevel = new Cateloge().SelectClassLevel(id);
                List<GradesSections> gradesections = new Cateloge().GradeSections(id);

                if (ClassLevel == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Data.ClassLevel_ = new ClassLevel
                    {
                        Id = ClassLevel.db_Id,
                        Name = ClassLevel.Name
                    };    
                        

                        if (gradesections == null)
                        {
                            ViewBag.StatusMessage = " No Any Result Founded ! ";
                        }
                        else
                        {

                            Data.GradeSection_s = new List<GradeSection>();
                            foreach (var gdfc in gradesections)
                            {
                                GradeSection dbr = new GradeSection();
                                dbr.Id = gdfc.db_Id;
                                dbr.Class_Level_id = gdfc.Class_Level_id;
                                dbr.Name = gdfc.Name;
                                Data.GradeSection_s.Add(dbr);
                            }
                            Data.GradeSection_s.TrimExcess();

                        }   
                }
                return View(Data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassLevel Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ClassLevels UpdateClassLevel = new ClassLevels();
                    UpdateClassLevel.Name = Update.Name;
                    UpdateClassLevel.Range = Update.Range;
                    new Cateloge().UpdateClassLevel(UpdateClassLevel, id);
                    TempData["Msg"] = "Class Level Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        public ActionResult EditSection(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                GradesSections gradesection = new Cateloge().SelectGradeSection(id);

                if (gradesection == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    GradeSection Formelements = new GradeSection
                    {
                        Name = gradesection.Name,
                    };
                    return PartialView("_CreateSection", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSection(GradeSection Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    GradesSections UpdateGradeSection = new GradesSections();
                    UpdateGradeSection.Name = Update.Name;
                    new Cateloge().UpdateGradeSection(UpdateGradeSection, id);
                    TempData["Msg"] = "Section Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelClassLvl(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                new Cateloge().DelClassLvl(id);
                TempData["Msg"] = "Selected Class Level Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
