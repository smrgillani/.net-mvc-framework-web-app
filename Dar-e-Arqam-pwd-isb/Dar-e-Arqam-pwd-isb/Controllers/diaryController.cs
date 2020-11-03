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
    public class diaryController : Controller
    {
        //
        // GET: /diary/
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
                    List<Diaries> Searched = new Cateloge().SearchDiaries(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Diary_s = new List<Diary>();
                        foreach (var gdfc in Searched)
                        {
                            Diary dbr = new Diary();
                            dbr.Id = gdfc.db_Id;
                            dbr.Diary_date = gdfc.Diary_date;
                            dbr.Settings = gdfc.Settings;
                            Data.Diary_s.Add(dbr);
                        }
                        Data.Diary_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Diaries> diaries = new Cateloge().Diaries();

                    if (diaries == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Diary_s = new List<Diary>();
                        foreach (var gdfc in diaries)
                        {
                            Diary dbr = new Diary();
                            dbr.Id = gdfc.db_Id;
                            dbr.Diary_date = gdfc.Diary_date;
                            dbr.Settings = gdfc.Settings;
                            Data.Diary_s.Add(dbr);
                        }
                        Data.Diary_s.TrimExcess();
                        return View(Data);
                    }
                }
                return View();
            }
        }

        public ActionResult Active()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<Diaries> diaries = new Cateloge().ActiveDiaries();

                    if (diaries == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Diary_s = new List<Diary>();
                        foreach (var gdfc in diaries)
                        {
                            Diary dbr = new Diary();
                            dbr.Id = gdfc.db_Id;
                            dbr.Diary_date = gdfc.Diary_date;
                            dbr.Settings = gdfc.Settings;
                            Data.Diary_s.Add(dbr);
                        }
                        Data.Diary_s.TrimExcess();
                        return View(Data);
                    }
                return View();
            }
        }

        public ActionResult All()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<Diaries> diaries = new Cateloge().Diaries();

                if (diaries == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Diary_s = new List<Diary>();
                    foreach (var gdfc in diaries)
                    {
                        Diary dbr = new Diary();
                        dbr.Id = gdfc.db_Id;
                        dbr.Diary_date = gdfc.Diary_date;
                        dbr.Settings = gdfc.Settings;
                        Data.Diary_s.Add(dbr);
                    }
                    Data.Diary_s.TrimExcess();
                    return View(Data);
                }
                return View();
            }
        }

        public ActionResult Trash()
        {
            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();
                Diaries diary = new Cateloge().SelectDiary(id);
                AllClasses Data = new AllClasses();
                if (ClassLevels == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    if (diary == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        Data.Diary = new Diary()
                        {
                            Id = diary.db_Id,
                            Diary_date = diary.Diary_date
                        };
                    }
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
        public ActionResult ViewSection(int cid , int did)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<GradesSections> gradesections = new Cateloge().GradeSections(cid);
                Diaries diary = new Cateloge().SelectDiary(did);
                ClassLevels classlevel = new Cateloge().SelectClassLevel(cid);
                AllClasses Data = new AllClasses();
                if (gradesections == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";

                    Data.ClassLevel_ = new ClassLevel()
                    {
                        Name = classlevel.Name
                    };
                    Data.Diary = new Diary(){
                              Id = diary.db_Id,
                              Diary_date = diary.Diary_date
                    };
                    return View(Data);
                }
                else
                {
                    Data.ClassLevel_ = new ClassLevel()
                    {
                        Name = classlevel.Name
                    };
                    Data.Diary = new Diary()
                    {
                        Id = diary.db_Id,
                        Diary_date = diary.Diary_date
                    };
                    Data.GradeSection_s = new List<GradeSection>();
                    foreach (var gdfc in gradesections)
                    {
                        GradeSection dbr = new GradeSection();
                        dbr.Id = gdfc.db_Id;
                        dbr.Name = gdfc.Name;
                        Data.GradeSection_s.Add(dbr);
                    }
                    Data.GradeSection_s.TrimExcess();
                    return View(Data);
                }
            }
        }

        [HttpGet]
        public ActionResult ViewDiary(int sid, int did)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                GradesSections gradesection = new Cateloge().SelectGradeSection(sid);
                Diaries diary = new Cateloge().SelectDiary(did);
                List<Diaries_Contxts> diary_cntxt = new Cateloge().DiariesSubjects(sid, did);
                AllClasses Data = new AllClasses();
                if (gradesection == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                    Data.Diary = new Diary()
                    {
                        Id = diary.db_Id,
                        Diary_date = diary.Diary_date
                    };
                    Data.GradeSection_ = new GradeSection
                    {
                        Id = gradesection.db_Id,
                        Name = gradesection.Name,
                        Class_name = (gradesection.Class_name != null) ? gradesection.Class_name.Name : null
                    };
                    return View(Data);
                }
                else
                {
                    if (diary == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        if (diary_cntxt == null)
                        {
                            ViewBag.StatusMessage = " No Any Data Found ! ";
                        }
                        else
                        {
                            Data.Diary_contxt_s = new List<Diary_Contxt>();
                            foreach (var gdfc in diary_cntxt)
                            {
                                Diary_Contxt dbr = new Diary_Contxt();
                                dbr.Id = gdfc.db_Id;
                                dbr.Subject_name = gdfc.Subject_name;
                                dbr.Contxt = gdfc.Contxt;
                                dbr.Type = gdfc.Type;
                                Data.Diary_contxt_s.Add(dbr);
                            }
                            Data.Diary_contxt_s.TrimExcess();
                        }

                        Data.Diary = new Diary()
                        {
                            Id = diary.db_Id,
                            Diary_date = diary.Diary_date
                        };
                    }
                    Data.GradeSection_ = new GradeSection
                    {
                        Id = gradesection.db_Id,
                        Name = gradesection.Name,
                        Class_name = (gradesection.Class_name != null) ? gradesection.Class_name.Name : null
                    };
                    return View(Data);
                }
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
                    return PartialView("_Create");
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult CreateSubjectDiary(int id, int did, string type)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    Diary_Contxt formelement = new Diary_Contxt
                    {
                        Section_id = Convert.ToString(id),
                        Diary_id = Convert.ToString(did),
                        Type = type
                    };

                    if (type == "eng")
                    {
                        return PartialView("_CreateSubjectDiaryEng", formelement);
                    }
                    else
                    {
                        return PartialView("_CreateSubjectDiaryUrdu", formelement);
                    }
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult CreateSubjectDiary(Diary_Contxt Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Diaries_Contxts AddDiaryContxt = new Diaries_Contxts();
                    AddDiaryContxt.Section_id = Add.Section_id;
                    AddDiaryContxt.Diary_id = Add.Diary_id;
                    AddDiaryContxt.Subject_name = Add.Subject_name;
                    AddDiaryContxt.Contxt = Add.Contxt;
                    AddDiaryContxt.Type = Add.Type;
                    AddDiaryContxt.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddDiaryContxt.Month = DateTime.Today.ToString("MMM");
                    AddDiaryContxt.Year = DateTime.Today.ToString("yyyy");
                    AddDiaryContxt.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddDiarySubjects(AddDiaryContxt);
                    TempData["Msg"] = "New Diary Work For A Subject Have Added Successfully";
                    return RedirectToAction("viewdiary", new { sid = Add.Section_id , did = Add.Diary_id });
                }
                return View(Add);
            }
        }

        public ActionResult EditSubjectDiary(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Diaries_Contxts diary_contaxt = new Cateloge().SelectDiarySubject(id);

                if (diary_contaxt == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Diary_Contxt Formelements = new Diary_Contxt
                    {
                        Subject_name = diary_contaxt.Subject_name,
                        Contxt = diary_contaxt.Contxt,
                        Section_id = diary_contaxt.Section_id,
                        Diary_id = diary_contaxt.Diary_id
                    };

                    if (diary_contaxt.Type == "eng")
                    {
                        return PartialView("_CreateSubjectDiaryEng", Formelements);
                    }
                    else
                    {
                        return PartialView("_CreateSubjectDiaryUrdu", Formelements);
                    }
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult EditSubjectDiary(Diary_Contxt Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Diaries_Contxts UpdateDiaryContxt = new Diaries_Contxts();
                    UpdateDiaryContxt.Subject_name = Update.Subject_name;
                    UpdateDiaryContxt.Contxt = Update.Contxt;
                    new Cateloge().UpdateDiarySubject(UpdateDiaryContxt, id);
                    TempData["Msg"] = "Diary Work Of A Subject Have Updated Successfully";
                    return RedirectToAction("viewdiary", new { sid = Update.Section_id, did = Update.Diary_id });
                }
                return View(Update);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diary Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Diaries AddDiary = new Diaries();
                    AddDiary.Diary_date = Add.Diary_date;
                    AddDiary.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddDiary.Month = DateTime.Today.ToString("MMM");
                    AddDiary.Year = DateTime.Today.ToString("yyyy");
                    AddDiary.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddDiary(AddDiary);
                    TempData["Msg"] = "New Diary Have Added Successfully";
                    return RedirectToAction("Index");
                }
                return View(Add);
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

                Diaries diary = new Cateloge().SelectDiary(id);

                if (diary == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Diary Formelements = new Diary
                    {
                        Diary_date = diary.Diary_date
                    };
                    return PartialView("_Edit", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Diary Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Diaries UpdateDiary = new Diaries();
                    UpdateDiary.Diary_date = Update.Diary_date;
                    new Cateloge().UpdateDiary(UpdateDiary, id);
                    TempData["Msg"] = "Diary Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelSubDiary(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Diaries_Contxts diary_contaxt = new Cateloge().SelectDiarySubject(id);
                string sid = diary_contaxt.Section_id;
                string did = diary_contaxt.Diary_id;
                new Cateloge().DelSubjectDiary(id);
                TempData["Msg"] = "Diary Of A Subject Have Deleted Successfully";
                return RedirectToAction("viewdiary", new { sid = sid, did = did });
            }
        }

        public ActionResult PublishDiary(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_PublishDiary");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishDiary(Diary pd, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Diaries diary = new Diaries();
                    diary.Settings = pd.Settings;
                    //new Cateloge().PublishSubResults(diary, id);
                    if (pd.Settings == "2")
                    {
                        TempData["Msg"] = "Diary Have Published Successfully";
                    }
                    else
                    {
                        TempData["Msg"] = "Diary Have Blocked Successfully";
                    }
                    return RedirectToAction("View", new { id = id });
                }

                return RedirectToAction("Index");
            }
        }

    }
}
