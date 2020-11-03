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
    public class webController : Controller
    {
        //
        // GET: /web/

        public ActionResult Index()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            WebAllClass Data = new WebAllClass();

            if (SelectAllNews == null)
            {
                TempData["Message_Null_News"] = "No Any News Posted Yet !";
            }
            else
            {
                
                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews.Take(1))
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }
                
            }

            List<Stars> SelectAllStars = new Cateloge().StarsForWeb();

            if (SelectAllStars == null)
            {
                TempData["Message_Null_Star"] = "No Any Star Posted Yet !";
            }
            else
            {
                Data.Star_s = new List<Star>();
                foreach (var gdfc in SelectAllStars)
                {
                    Star dbr = new Star();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Star_type = gdfc.Star_type;
                    dbr.Achievement = gdfc.Achievement;
                    Data.Star_s.Add(dbr);
                }
            }

            return View(Data);
        }

        public ActionResult AboutUs()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            WebAllClass Data = new WebAllClass();

            if (SelectAllNews == null)
            {
                TempData["Message_Null_News"] = "No Any News Posted Yet !";
            }
            else
            {

                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews.Take(6))
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }

            }

            List<Events> SelectAllEvents = new Cateloge().EventsForWeb();

            if (SelectAllEvents == null)
            {
                TempData["Message_Null_Event"] = "No Any Event Posted Yet !";
            }
            else
            {
                Data.Event_s = new List<Event>();
                foreach (var gdfc in SelectAllEvents.Take(6))
                {
                    Event dbr = new Event();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Event_s.Add(dbr);
                }
            }

            return View(Data);
        }

        public ActionResult Admission()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            WebAllClass Data = new WebAllClass();

            if (SelectAllNews == null)
            {
                TempData["Message_Null_News"] = "No Any News Posted Yet !";
            }
            else
            {

                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews.Take(12))
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }

            }

            List<Events> SelectAllEvents = new Cateloge().EventsForWeb();

            if (SelectAllEvents == null)
            {
                TempData["Message_Null_Event"] = "No Any Event Posted Yet !";
            }
            else
            {
                Data.Event_s = new List<Event>();
                foreach (var gdfc in SelectAllEvents.Take(12))
                {
                    Event dbr = new Event();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Event_s.Add(dbr);
                }
            }

            return View(Data);
        }

        public ActionResult Overview()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            WebAllClass Data = new WebAllClass();

            if (SelectAllNews == null)
            {
                TempData["Message_Null_News"] = "No Any News Posted Yet !";
            }
            else
            {

                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews.Take(6))
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }

            }

            List<Events> SelectAllEvents = new Cateloge().EventsForWeb();

            if (SelectAllEvents == null)
            {
                TempData["Message_Null_Event"] = "No Any Event Posted Yet !";
            }
            else
            {
                Data.Event_s = new List<Event>();
                foreach (var gdfc in SelectAllEvents.Take(6))
                {
                    Event dbr = new Event();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Event_s.Add(dbr);
                }
            }

            return View(Data);
        }

        public ActionResult Management()
        {
            return View();
        }

        public ActionResult Faqs()
        {
            return View();
        }

        public ActionResult Messages()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            WebAllClass Data = new WebAllClass();

            if (SelectAllNews == null)
            {
                TempData["Message_Null_News"] = "No Any News Posted Yet !";
            }
            else
            {

                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews.Take(6))
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }

            }

            List<Events> SelectAllEvents = new Cateloge().EventsForWeb();

            if (SelectAllEvents == null)
            {
                TempData["Message_Null_Event"] = "No Any Event Posted Yet !";
            }
            else
            {
                Data.Event_s = new List<Event>();
                foreach (var gdfc in SelectAllEvents.Take(6))
                {
                    Event dbr = new Event();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Event_s.Add(dbr);
                }
            }

            return View(Data);
        }

        public ActionResult Academic()
        {
            return View();
        }

        public ActionResult Exploreus()
        {
            return View();
        }

        public ActionResult Achievements()
        {
            List<Achvmnts> achvmnts = new Cateloge().AchvmntsForWeb();

            if (achvmnts == null)
            {
                TempData["Message"] = "No Any Ahcievement Posted Yet !";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.Achievements = new List<Achvmnt>();
                foreach (var gdfc in achvmnts)
                {
                    Achvmnt dbr = new Achvmnt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Achievements.Add(dbr);
                }
                return View(Data);
            }
            return View();
        }

        public ActionResult ViewAchvmnt(int? id)
        {
            if (id.HasValue)
            {
                Achvmnts selectachvmntforweb = new Cateloge().SelectAchvmntForWeb(id);
                if (selectachvmntforweb == null)
                {
                    TempData["Message"] = "Unknown Request !";
                    return RedirectToAction("Index");
                }
                else
                {
                    WebAllClass Data = new WebAllClass();
                    Data.Achievement = new Achvmnt
                    {
                        Id = selectachvmntforweb.db_Id,
                        Name = selectachvmntforweb.Name,
                        Picture = selectachvmntforweb.Picture,
                        Detail = selectachvmntforweb.Detail,
                        Date = selectachvmntforweb.Date,
                        Month = selectachvmntforweb.Month,
                        Year = selectachvmntforweb.Year,
                        Time = selectachvmntforweb.Time
                    };
                    return View(Data);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Results()
        {
            List<Sub_Results> ResultsForWeb = new Cateloge().SelectAllSubResultsForWeb();

            if (ResultsForWeb == null)
            {
                TempData["Message"] = "No Any Result Published !";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.Sub_Result_s = new List<Sub_Result>();
                foreach (var gdfc in ResultsForWeb)
                {
                    Sub_Result dbr = new Sub_Result();
                    dbr.id = gdfc.id;
                    dbr.name = gdfc.name;
                    Data.Sub_Result_s.Add(dbr);
                }
                return View(Data);
            }

            return View();
        }

        public ActionResult ViewResult(int? id, int? zid)
        {
            WebAllClass Data = new WebAllClass();

            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                Sub_Results ResultForWeb = new Cateloge().SelectAllSubResultForWeb(id);

                if (ResultForWeb == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    Data.Sub_Result = new Sub_Result
                    {
                        id = ResultForWeb.id,
                        name = ResultForWeb.name
                    };

                    if (!zid.HasValue)
                    {
                        TempData["Message"] = "Please Enter A Valid Registration Number Of Student !";
                    }
                    else
                    {
                        Students SelectforWeb = new Cateloge().SelectAllStudentForWeb(Convert.ToInt32(zid));

                        if (SelectforWeb == null)
                        {
                            TempData["Message"] = "No Any Student Founded Against This Regsitration Number !";
                        }
                        else
                        {
                            List<SubjectResults> SelectSubjectsResultForWeb = new Cateloge().SelectAllSubjectsResultForWeb(Convert.ToInt32(SelectforWeb.db_Id), id);
                            Data.Student = new Student
                            {
                                Aplicnt_Id = SelectforWeb.Aplicnt_Id,
                                Aplicnt_name = SelectforWeb.Aplicnt_name,
                                Aplicnt_f_name = SelectforWeb.Aplicnt_f_name,
                                ClassName = SelectforWeb.ClassName.Name
                            };

                            if (SelectSubjectsResultForWeb == null)
                            {
                                TempData["Message"] = "No Any Result Founded Against This Regsitration Number !";
                            }
                            else
                            {
                                Data.SubjectResult_s = new List<SubjectResult>();

                                foreach (var gdfc in SelectSubjectsResultForWeb)
                                {
                                    SubjectResult dbr = new SubjectResult();
                                    dbr.Subject_name = gdfc.Subject_name.Name;
                                    dbr.Total_marks = gdfc.Total_marks.Total_marks;
                                    dbr.Obtn_marks = gdfc.Obtn_marks;
                                    dbr.Status = gdfc.Status;
                                    Data.SubjectResult_s.Add(dbr);
                                }

                                List<Sub_Results> SelectAllSubResultsForWeb = new Cateloge().SelectSubResultsWithDetailForWeb(Convert.ToInt32(ResultForWeb.S_id.db_Id), Convert.ToInt32(SelectforWeb.db_Id));

                                if (SelectAllSubResultsForWeb == null)
                                {
                                    TempData["Message"] = " Overall Report Is Empty !";
                                }
                                else
                                {
                                    Data.Sub_Result_s = new List<Sub_Result>();
                                    Data.SubjectResult_s_ = new List<SubjectResult>();
                                    foreach (var gdfc in SelectAllSubResultsForWeb)
                                    {
                                        Sub_Result dbr = new Sub_Result();
                                        dbr.id = gdfc.id;
                                        dbr.name = gdfc.name;
                                        dbr.Percentage = gdfc.Percentage;
                                        if (gdfc.S_r == null)
                                        {
                                        }
                                        else
                                        {
                                            foreach (var lgdfc in gdfc.S_r)
                                            {
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

        public ActionResult News()
        {
            List<NewsUpdts> SelectAllNews = new Cateloge().SelectAllNewsForWeb();

            if (SelectAllNews == null)
            {
                TempData["Message"] = "No Any News Posted Yet !";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.NewsAndUpdts_s = new List<NewsUpdt>();
                foreach (var gdfc in SelectAllNews)
                {
                    NewsUpdt dbr = new NewsUpdt();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.NewsAndUpdts_s.Add(dbr);
                }
                return View(Data);
            }
            return View();
        }

        public ActionResult ViewNews(int? id)
        {
            if (id.HasValue)
            {
                NewsUpdts selectnewsforweb = new Cateloge().SelectNewsForWeb(id);
                if (selectnewsforweb == null)
                {
                    TempData["Message"] = "Unknown Request !";
                    return RedirectToAction("Index");
                }
                else
                {
                    WebAllClass Data = new WebAllClass();
                    Data.NewsAndUpdts = new NewsUpdt
                    {
                        Id = selectnewsforweb.db_Id,
                        Name = selectnewsforweb.Name,
                        Picture = selectnewsforweb.Picture,
                        Detail = selectnewsforweb.Detail,
                        Date = selectnewsforweb.Date,
                        Month = selectnewsforweb.Month,
                        Year = selectnewsforweb.Year,
                        Time = selectnewsforweb.Time
                    };
                    return View(Data);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Events()
        {
            List<Events> SelectAllEvents = new Cateloge().EventsForWeb();

            if (SelectAllEvents == null)
            {
                TempData["Message"] = "No Any Event Posted Yet !";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.Event_s = new List<Event>();
                foreach (var gdfc in SelectAllEvents)
                {
                    Event dbr = new Event();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Detail = gdfc.Detail;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Event_s.Add(dbr);
                }
                return View(Data);
            }
            return View();
        }

        public ActionResult ViewEvent(int? id)
        {
            if (id.HasValue)
            {
                Events selecteventforweb = new Cateloge().EventForWeb(id);
                if (selecteventforweb == null)
                {
                    TempData["Message"] = "Unknown Request !";
                    return RedirectToAction("Index");
                }
                else
                {
                    WebAllClass Data = new WebAllClass();
                    Data.Event_ = new Event
                    {
                        Id = selecteventforweb.db_Id,
                        Name = selecteventforweb.Name,
                        Picture = selecteventforweb.Picture,
                        Detail = selecteventforweb.Detail,
                        Date = selecteventforweb.Date,
                        Month = selecteventforweb.Month,
                        Year = selecteventforweb.Year,
                        Time = selecteventforweb.Time
                    };
                    return View(Data);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ShiningStars()
        {
            List<Stars> SelectAllStars = new Cateloge().StarsForWeb();

            if (SelectAllStars == null)
            {
                TempData["Message"] = "No Any Shining Star Posted Yet !";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.Star_s = new List<Star>();
                foreach (var gdfc in SelectAllStars)
                {
                    Star dbr = new Star();
                    dbr.Id = gdfc.db_Id;
                    dbr.Name = gdfc.Name;
                    dbr.Picture = gdfc.Picture;
                    dbr.Date = gdfc.Date;
                    dbr.Month = gdfc.Month;
                    dbr.Year = gdfc.Year;
                    dbr.Time = gdfc.Time;
                    Data.Star_s.Add(dbr);
                }
                return View(Data);
            }
            return View();
        }

        public ActionResult ContactUs()
        {
            ContactsInfo SelectContactInfo = new Cateloge().ContactInfoForWeb();
            
            WebAllClass Data = new WebAllClass();

            if (SelectContactInfo == null)
            {
                ViewBag.Msg = "No Content Founded";
               return View();
            }
            else
            {
                Data.ContactInfo = new ContactInfo
                {
                    Title = SelectContactInfo.Title,
                    Contact_Cell = SelectContactInfo.Contact_Cell,
                    Contact_Phone = SelectContactInfo.Contact_Phone,
                    Contact_Email = SelectContactInfo.Contact_Email,
                    Contact_Website = SelectContactInfo.Contact_Website,
                    Contact_Location = SelectContactInfo.Contact_Location,
                    Contact_Address = SelectContactInfo.Contact_Address,
                };
                return View(Data);
            }
        }

        public ActionResult Uniforms()
        {
            return View();
        }

        public ActionResult Uniformb()
        {
            return View();
        }

        public ActionResult Uniformg()
        {
            return View();
        }

        public ActionResult Redirect()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Diary()
        {
            List<Diaries> diaries = new Cateloge().ActiveDiaries();

            if (diaries == null)
            {
                ViewBag.StatusMessage = " No Any Diary Founded  ! ";
            }
            else
            {
                WebAllClass Data = new WebAllClass();
                Data.Diary_s = new List<Diary>();
                foreach (var gdfc in diaries)
                {
                    Diary dbr = new Diary();
                    dbr.Id = gdfc.db_Id;
                    dbr.Diary_date = gdfc.Diary_date;
                    Data.Diary_s.Add(dbr);
                }
                Data.Diary_s.TrimExcess();
                return View(Data);
            }
            return View();
        }

        public ActionResult GetClass(int id)
        {
            List<ClassLevels> ClassLevels = new Cateloge().ClassLevels();
            Diaries diary = new Cateloge().SelectActiveDiary(id);
            WebAllClass Data = new WebAllClass();
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
                    Data.Diary_ = new Diary()
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

        public ActionResult GetSections(int cid, int did)
        {
            List<GradesSections> gradesections = new Cateloge().GradeSections(cid);
            Diaries diary = new Cateloge().SelectActiveDiary(did);
            ClassLevels classlevel = new Cateloge().SelectClassLevel(cid);
            WebAllClass Data = new WebAllClass();
            if (gradesections == null)
            {
                ViewBag.StatusMessage = " No Any Data Found ! ";
                Data.ClassLevel_ = new ClassLevel
                {
                    Name = classlevel.Name
                };
                Data.Diary_ = new Diary()
                {
                    Id = diary.db_Id,
                    Diary_date = diary.Diary_date
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
                    if (classlevel == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        Data.ClassLevel_ = new ClassLevel
                        {
                            Name = classlevel.Name
                        };
                    }

                    Data.Diary_ = new Diary()
                    {
                        Id = diary.db_Id,
                        Diary_date = diary.Diary_date
                    };
                }
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

        [HttpGet]
        public ActionResult ViewDiaryCntxt(int sid, int did)
        {
                GradesSections gradesection = new Cateloge().SelectGradeSection(sid);
                Diaries diary = new Cateloge().SelectActiveDiary(did);
                List<Diaries_Contxts> diary_cntxt = new Cateloge().DiariesSubjects(sid, did);
                WebAllClass Data = new WebAllClass();
                if (gradesection == null)
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

                        Data.Diary_ = new Diary()
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
                return View();
        }
    }
}
