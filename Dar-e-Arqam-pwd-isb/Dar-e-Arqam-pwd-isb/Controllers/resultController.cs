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
    public class resultController : Controller
    {
        //
        // GET: /result/

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
                    List<Results> Searched = new Cateloge().SearchResults(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Result_s = new List<Result>();
                        foreach (var gdfc in Searched)
                        {
                            Result dbr = new Result();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Session_year;
                            Data.Result_s.Add(dbr);
                        }
                        Data.Result_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Results> results = new Cateloge().Results();

                    if (results == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Result_s = new List<Result>();
                        foreach (var gdfc in results)
                        {
                            Result dbr = new Result();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Session_year;
                            Data.Result_s.Add(dbr);
                        }
                        Data.Result_s.TrimExcess();
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

                List<Sub_Results> sub_results = new Cateloge().SelectSubResults(id);

                Results result = new Cateloge().SelectResults(id);


                if (result == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Sub_Result_s = new List<Sub_Result>();
                    if (sub_results == null)
                    {
                        ViewBag.StatusMessage = " No Any Result Founded ! ";

                    }
                    else
                    {
                        foreach (var gdfc in sub_results)
                        {
                            Sub_Result dbr = new Sub_Result();
                            dbr.id = gdfc.id;
                            dbr.name = gdfc.name;
                            dbr.Publish = gdfc.Publish;
                            Data.Sub_Result_s.Add(dbr);
                        }
                    }
                    Data.Result = new Result
                    {
                        Id = result.db_Id,
                        Name = result.Session_year
                    };

                    TempData["p"] = "Published On Web";
                    TempData["b"] = "Blocked On Web";
                    return View(Data);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewSub(int? id , int? zid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                AllClasses Data = new AllClasses();

                if (!id.HasValue)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Sub_Results ResultForPanel = new Cateloge().SelectSubResult(id);

                    if (ResultForPanel == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        Data.Sub_Result = new Sub_Result
                        {
                            id = ResultForPanel.id,
                            name = ResultForPanel.name
                        };

                        if (!zid.HasValue)
                        {
                            TempData["Message"] = "Please Enter A Valid Registration Number Of Student !";
                        }
                        else
                        {
                            Students SelectforPanel = new Cateloge().SelectStudentForPanel(Convert.ToInt32(zid));

                            if (SelectforPanel == null)
                            {
                                TempData["Message"] = "No Any Student Founded Against This Regsitration Number !";
                            }
                            else
                            {
                                List<SubjectResults> SelectSubjectsResultForWeb = new Cateloge().SelectAllSubjectsResultForWeb(Convert.ToInt32(SelectforPanel.db_Id), id);
                                
                                ResultsPositions SelectResultPosition = new Cateloge().SelectResultPositionByRidSid(Convert.ToInt32(SelectforPanel.db_Id), id);
                                
                                Data.Student = new Student
                                {
                                    Aplicnt_Id = SelectforPanel.Aplicnt_Id,
                                    Aplicnt_name = SelectforPanel.Aplicnt_name,
                                    Aplicnt_f_name = SelectforPanel.Aplicnt_f_name,
                                    ClassName = SelectforPanel.ClassName.Name
                                };

                                if (SelectSubjectsResultForWeb == null)
                                {
                                    TempData["Message"] = "No Any Result Founded Against This Regsitration Number !";
                                }
                                else
                                {
                                    Data.SubjectResult_s = new List<SubjectResult>();
                                    Data.SubjectResult_s_ = new List<SubjectResult>();

                                    foreach (var gdfc in SelectSubjectsResultForWeb)
                                    {
                                        SubjectResult dbr = new SubjectResult();
                                        dbr.Subject_name = gdfc.Subject_name.Name;
                                        dbr.Total_marks = gdfc.Total_marks.Total_marks;
                                        dbr.Obtn_marks = gdfc.Obtn_marks;
                                        dbr.Status = gdfc.Status;
                                        Data.SubjectResult_s.Add(dbr);
                                    }

                                    if (SelectResultPosition == null)
                                    {
                                        //TempData["Message"] = "The Student Position By Section Of This Result Not Posted Yet !";
                                    }
                                    else
                                    {
                                        Data.Result_Position = new ResultPosition
                                        {
                                            Id = SelectResultPosition.Id,
                                            Class_Section = SelectResultPosition.Class_Section,
                                            Obtn_Pstn = SelectResultPosition.Obtn_Pstn
                                        };
                                    }

                                    List<Sub_Results> SelectAllSubResults = new Cateloge().SelectSubResultsWithDetail(Convert.ToInt32(ResultForPanel.S_id.db_Id) , Convert.ToInt32(SelectforPanel.db_Id));

                                    //List<Sub_Results> SelectAllSubResults = new Cateloge().SelectSubResultsWithDetail(Convert.ToInt32(1), Convert.ToInt32(1));

                                    if (SelectAllSubResults == null)
                                    {
                                        TempData["Message"] = " Overall Report Is Empty !";
                                    }
                                    else
                                    {
                                        Data.Sub_Result_s = new List<Sub_Result>();
                                        Data.SubjectResult_s_ = new List<SubjectResult>();
                                        //Data.Sub_Result_s = new List<Sub_Result>();
                                        foreach (var gdfc in SelectAllSubResults)
                                        {
                                            Sub_Result dbr = new Sub_Result();
                                            dbr.id = gdfc.id;
                                            dbr.name = gdfc.name;
                                            dbr.Percentage = gdfc.Percentage;
                                            if (gdfc.S_r == null)
                                            {
                                                ViewBag.StatusMessage = " No Any Result Founded ! ";
                                            }
                                            else
                                            {
                                                foreach (var llgdfc in gdfc.S_r.Where(a=>a.Sub_r_id.Equals(dbr.id)))
                                                {
                                                }

                                                foreach (var lgdfc in gdfc.S_r)
                                                {


                                                    //SubjectResult ldbr = new SubjectResult();
                                                    //ldbr.Id = lgdfc.Id;
                                                    //ldbr.Obtn_marks = lgdfc.Obtn_marks;
                                                    //ldbr.Total_marks = lgdfc.Total_marks;
                                                    //ldbr.Status = lgdfc.Status;
                                                    //Data.SubjectResult_s_.Add(ldbr);
                                                    //dbr.S_r.Add(ldbr);
                                                    SubjectResult ldbr = new SubjectResult();
                                                    ldbr.Sub_r_id = lgdfc.Sub_r_id;
                                                    ldbr.Obtn_marks = lgdfc.Obtn_marks;
                                                    //ldbr.Total_marks = lgdfc.Total_marks;
                                                    Data.SubjectResult_s_.Add(ldbr);
                                                }
                                            }
                                            Data.Sub_Result_s.Add(dbr);
                                          }
                                    }
                                }
                            }
                        }
                    }

                    return View(Data);
                } 
            }
        }

        public ActionResult SelectViewType(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Sub_Results sub_result = new Cateloge().SelectSubResult(id);

                if (sub_result == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Sub_Result = new Sub_Result()
                    {
                        id = sub_result.id,
                        name = sub_result.name
                    };
                    return View(Data);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult SubResults(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_SubResultsForm");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubResults(Sub_Result Add,int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Sub_Results AddSubResult = new Sub_Results();
                    AddSubResult.name = Add.name;
                    AddSubResult.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddSubResult.Month = DateTime.Today.ToString("MMM");
                    AddSubResult.Year = DateTime.Today.ToString("yyyy");
                    AddSubResult.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddSubResult(AddSubResult, id);
                    TempData["Msg"] = "New Sub Result Have Added Successfully";
                    return RedirectToAction("View", new { id = id });
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult PublishSubResult(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_PublishSubResult");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishSubResult(Sub_Result Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Sub_Results SubResult = new Sub_Results();
                    SubResult.Publish = Update.Publish;
                    new Cateloge().PublishSubResults(SubResult, id);
                    if (Update.Publish == "2")
                    {
                        TempData["Msg"] = "Sub Result Have Published Successfully";
                    }
                    else
                    {
                        TempData["Msg"] = "Sub Result Have Blocked Successfully";
                    }
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
                    return PartialView("_CreateNewResult");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Result Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Results AddResult = new Results();
                    AddResult.Session_year = Add.Name;
                    AddResult.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddResult.Month = DateTime.Today.ToString("MMM");
                    AddResult.Year = DateTime.Today.ToString("yyyy");
                    AddResult.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddResult(AddResult);
                    TempData["Msg"] = "New Result Have Added Successfully";
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

                Results result = new Cateloge().SelectResults(id);

                if (result == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Result Formelements = new Result
                    {
                        Name = result.Session_year
                    };
                    return PartialView("_CreateNewResult", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Result Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Results UpdateResult = new Results();
                    UpdateResult.Session_year = Update.Name;
                    new Cateloge().UpdateResult(UpdateResult, id);
                    TempData["Msg"] = "Result Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        public ActionResult ResultOfClasses(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Sub_Results sub_result = new Cateloge().SelectSubResult(id);
                List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();
                AllClasses Data = new AllClasses();

                Data.Sub_Result = new Sub_Result()
                {
                    id = sub_result.id,
                    name = sub_result.name
                };

                if (ClassLevels == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    Data.ClassLevel_s = new List<ClassLevel>();
                    foreach (var gdfc in ClassLevels)
                    {
                        ClassLevel dbr = new ClassLevel();
                        dbr.Id = gdfc.db_Id;
                        dbr.Name = gdfc.Name;
                        Data.ClassLevel_s.Add(dbr);
                    }
                    Data.ClassLevel_s.TrimExcess();
                    return View(Data);
                }
                return View();
            }
        }

        public ActionResult ClsStdntsRslt(int id,int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Sub_Results sub_result = new Cateloge().SelectSubResult(rid);
                ClassLevels classLevel = new Cateloge().SelectClassLevel(id);
                List<Students> students = new Cateloge().SelectStudentsForClassLevels(id);
                List<SubjectsTotalMarks> subjectsttlmrks = new Cateloge().SelectAllSubjectsTotalMarksWithIds(id, rid);
                AllClasses Data = new AllClasses();

                Data.Sub_Result = new Sub_Result()
                {
                    id = sub_result.id,
                    name = sub_result.name
                };

                Data.ClassLevel_ = new ClassLevel()
                {
                    Name = classLevel.Name
                };

                if (students == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    Data.Student_s = new List<Student>();
                    List<Student> StudentsList = new List<Student>();
                    foreach (var gdfc in students)
                    {
                        Student dbr = new Student();
                        dbr.db_Id = gdfc.db_Id;
                        dbr.Aplicnt_Id = gdfc.Aplicnt_Id;
                        dbr.Aplicnt_name = gdfc.Aplicnt_name;
                        dbr.ClassName = (gdfc.ClassName != null) ? gdfc.ClassName.Name : null;
                        Data.Student_s.Add(dbr);
                    }
                    Data.Student_s.TrimExcess();
                }

                if (subjectsttlmrks == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    Data.SubjectsTotalMark_s = new List<SubjectTotalMark>();
                    foreach (var gdfc in subjectsttlmrks)
                    {
                        SubjectTotalMark dbr = new SubjectTotalMark();
                        dbr.Subject_Name = gdfc.Subject_name.Name;
                        dbr.Total_marks = gdfc.Total_marks;
                        Data.SubjectsTotalMark_s.Add(dbr);
                    }
                    Data.SubjectsTotalMark_s.TrimExcess();
                }
                return View(Data);
            }
        }

        public ActionResult AllSbjctsTtlMrks(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

            Sub_Results sub_result = new Cateloge().SelectSubResult(id);
            List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();
            List<SubjectsTotalMarks> subjectstotalmarks = new Cateloge().SelectAllSubjectsTotalMarks();
            AllClasses Data = new AllClasses();
                    
            Data.Sub_Result = new Sub_Result()
                    {
                        id = sub_result.id,
                        name = sub_result.name
                    };

            if (ClassLevels == null)
            {
                ViewBag.StatusMessage = " No Any Data Found ! ";
            }
            else
            {
                Data.ClassLevel_s = new List<ClassLevel>();
                foreach (var gdfc in ClassLevels)
                {
                    ClassLevel dbr = new ClassLevel();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    Data.ClassLevel_s.Add(dbr);
                }
                Data.ClassLevel_s.TrimExcess();
                if (subjectstotalmarks == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    Data.SubjectsTotalMark_s = new List<SubjectTotalMark>();
                    foreach (var gdfc in subjectstotalmarks)
                    {
                        SubjectTotalMark dbr = new SubjectTotalMark();
                        dbr.Class_id = gdfc.Class_id;
                        dbr.R_id = gdfc.R_id;
                        dbr.Subject_Name = gdfc.Subject_name.Name;
                        dbr.Total_marks = gdfc.Total_marks;
                        Data.SubjectsTotalMark_s.Add(dbr);
                    }
                    Data.SubjectsTotalMark_s.TrimExcess();
                }
                return View(Data);
            }
            return View();
           }
        }

        public ActionResult AddSbjctsTtlMrks(int id, int rid)
        {
            List<Subjects> subjects = new Cateloge().SelectSubjectsOfClassById(id);
            AllClasses Data = new AllClasses();
            
            if (subjects == null)
            {
                ViewBag.StatusMessage = " No Any Subject Founded ! ";
            }
            else
            {
                Data.SubjectsTotalMark_s = new List<SubjectTotalMark>();
                foreach (var gdfc in subjects)
                {
                    SubjectTotalMark dbr = new SubjectTotalMark();
                    dbr.Id = gdfc.db_Id;
                    dbr.Subject_Name = gdfc.Name;
                    dbr.Subject_id = gdfc.db_Id;
                    Data.SubjectsTotalMark_s.Add(dbr);
                }
                Data.SubjectsTotalMark_s.TrimExcess();

                Data.SubjectsTotalMarks_ = new SubjectTotalMark()
                {
                    R_id = Convert.ToString(rid),
                    Class_id = Convert.ToString(id)
                };
            }
            return PartialView("_AddSbjctsTtlMrks", Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSbjctsTtlMrks(AllClasses Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    SubjectsTotalMarks addsubjectsmarks = new SubjectsTotalMarks();
                    addsubjectsmarks.Subject_id = Add.SubjectsTotalMarks_.Subject_id;
                    addsubjectsmarks.Total_marks = Add.SubjectsTotalMarks_.Total_marks;
                    addsubjectsmarks.R_id = Add.SubjectsTotalMarks_.R_id;
                    addsubjectsmarks.Class_id = Add.SubjectsTotalMarks_.Class_id;
                    addsubjectsmarks.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    addsubjectsmarks.Month = DateTime.Today.ToString("MMM");
                    addsubjectsmarks.Year = DateTime.Today.ToString("yyyy");
                    addsubjectsmarks.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddSubjectsTotalMarks(addsubjectsmarks);
                    TempData["Msg"] = "New Subject Total Marks Have Added Successfully";
                }
                return RedirectToAction("allsbjctsttlmrks", new { id = Add.SubjectsTotalMarks_.R_id });
            }
        }

        public ActionResult EditSbjctsTtlMrks(int id, int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<SubjectsTotalMarks> subjectsttlmrks = new Cateloge().SelectAllSubjectsTotalMarksWithIds(id, rid);
                AllClasses Data = new AllClasses();

                if (subjectsttlmrks == null)
                {
                    ViewBag.StatusMessage = " No Any Subject Founded ! ";
                }
                else
                {
                    Data.SubjectsTotalMark_s = new List<SubjectTotalMark>();
                    foreach (var gdfc in subjectsttlmrks)
                    {
                        SubjectTotalMark dbr = new SubjectTotalMark();
                        dbr.Id = gdfc.Id;
                        dbr.R_id = Convert.ToString(rid);
                        dbr.Subject_Name = gdfc.Subject_name.Name;
                        dbr.Total_marks = gdfc.Total_marks;
                        Data.SubjectsTotalMark_s.Add(dbr);
                    }
                    Data.SubjectsTotalMark_s.TrimExcess();
                }
                return PartialView("_EditSbjctsTtlMrks", Data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSbjctsTtlMrks(List<SubjectTotalMark> p)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    List<SubjectsTotalMarks> updatesubjectsmarks = new List<SubjectsTotalMarks>();
                    foreach (SubjectTotalMark pdr in p)
                    {
                        SubjectsTotalMarks dbr = new SubjectsTotalMarks();
                        dbr.Id = pdr.Id;
                        dbr.Total_marks = pdr.Total_marks;
                        updatesubjectsmarks.Add(dbr);
                    }
                    new Cateloge().UpdateSubjectsTotalMarks(updatesubjectsmarks);
                    TempData["Msg"] = "Subjects Total Marks Have Updated Successfully";
                }
                return RedirectToAction("allsbjctsttlmrks", new { id = p[0].R_id });
            }
        }

        public ActionResult delsbjctsttlmrks(int id, int rid)
        {
            new Cateloge().DelSbjctsTtlMrks(id, rid);
            TempData["Msg"] = "Subjects Total Marks Have Deleted Successfully";
            return RedirectToAction("allsbjctsttlmrks", new { id = rid });
        }
    }
}
