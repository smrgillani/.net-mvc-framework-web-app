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
    public class studentController : Controller
    {
         //
        // GET: /student/
        [HttpGet]
        public ActionResult Index(string Search_key)
        {
            //if (Session["Username"] == null && Session["Password"] == null)
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "" });
            //}
            //else
            //{

                if (string.IsNullOrEmpty(Search_key))
                {
                    ViewBag.StatusMessage = " Type In Search , For The Search Of Required Student ! ";
                }
                else
                {
                    List<Students> Searched = new Cateloge().SearchStudent(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Student_s = new List<Student>();
                        List<Student> StudentsList = new List<Student>();
                        foreach (var gdfc in Searched)
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
                        return View(Data);
                    }
                }
                return View();
            //}
        }

        public JsonResult AdvancedSearch(string term)
        {
            List<Students> Students = new Cateloge().Students();
            var result = (from r in Students where r.Aplicnt_name.ToLower().Contains(term.ToLower()) select new { r.Aplicnt_name });
            return Json(result, JsonRequestBehavior.AllowGet);
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
                List<Students> Students = new Cateloge().Students();

                if (Students == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Student_s = new List<Student>();
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
                        if (gdfc.ClassName == null)
                        {
                            dbr.ClassName = "";
                        }
                        else
                        {
                            dbr.ClassName = (gdfc.ClassName != null) ? gdfc.ClassName.Name : null;
                        }
                        dbr.Aplicnt_gender = gdfc.Aplicnt_gender;
                        Data.Student_s.Add(dbr);
                    }
                    Data.Student_s.TrimExcess();
                    return View(Data);
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Alumni(string Search_key)
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

        [HttpGet]
        public ActionResult DelSubResult(int sid , int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                new Cateloge().DelSubjectResult(sid,rid);
                TempData["Msg"] = "All Subjects Result Have Deleted Successfully";
                return RedirectToAction("View", new { id = sid });
            }
        }

        [HttpGet]
        public ActionResult DelResultPosition(int id, int sid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                new Cateloge().DelResultPosition(id);
                TempData["Msg"] = "Result Position Have Deleted Successfully";
                return RedirectToAction("View", new { id = sid });
            }
        }

        public ActionResult ViewResult(int sid, int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                Sub_Results allsubjectsresulttitle = new Cateloge().SelectAllSubjectsResultTitle(rid);
                List<SubjectResults> allsubjectsresult = new Cateloge().SelectAllSubjectsResult(sid, rid);
                ResultsPositions SelectResultPosition = new Cateloge().SelectResultPositionByRidSid(sid, rid);
                AllClasses Data = new AllClasses();
                Data.SubjectResult_s = new List<SubjectResult>();
                if (allsubjectsresulttitle == null && allsubjectsresult == null)
                {
                }
                else
                {
                    foreach (var gdfc in allsubjectsresult)
                    {
                        SubjectResult dbr = new SubjectResult();
                        dbr.Id = gdfc.Id;
                        dbr.Student_id = gdfc.Student_id;
                        dbr.Subject_name = gdfc.Subject_name.Name;
                        dbr.Total_marks = gdfc.Total_marks.Total_marks;
                        dbr.Obtn_marks = gdfc.Obtn_marks;
                        dbr.Status = gdfc.Status;
                        Data.SubjectResult_s.Add(dbr);
                    }

                    Data.Sub_Result = new Sub_Result
                    {
                        name = allsubjectsresulttitle.name
                    };

                    TempData["Fail"] = "Fail";
                    TempData["Pass"] = "Pass";

                    if (SelectResultPosition == null)
                    {
                    }
                    else
                    {
                        Data.Result_Position = new ResultPosition
                        {
                            Id = SelectResultPosition.Id,
                            Student_id = SelectResultPosition.Student_id,
                            Class_Section = SelectResultPosition.Class_Section,
                            Obtn_Pstn = SelectResultPosition.Obtn_Pstn
                        };
                    }

                    return PartialView("_ViewResult", Data);
                }
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

                Students Student_s = new Cateloge().SelectStudent(id);

                List<Sub_Results> subresultstitle = new Cateloge().SelectSubResultsTitles();

                List<SubjectResults> subjectresults = new Cateloge().SelectStudentResultById(id);

                if (Student_s == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {

                    AllClasses Data = new AllClasses();
                    Data.Sub_Result_s = new List<Sub_Result>();
                    Data.SubjectResult_s = new List<SubjectResult>();

                    if (subresultstitle == null)
                    {
                        TempData["NoData"] = " No Any Result Founded ! ";
                    }
                    else
                    {

                        foreach (var gdfc in subresultstitle)
                        {
                            Sub_Result dbr = new Sub_Result();
                            dbr.id =  gdfc.id;
                            dbr.name = gdfc.name;
                            //if (subjectresults.Where(a => a.Sub_r_id.Equals(gdfc.id)).Count() > 0)
                            //    {
                            //        TempData["msg_"] = "Not Null";
                            //    }
                            //    else
                            //    {
                            //        TempData["msg_"] = null;
                            //}
                            Data.Sub_Result_s.Add(dbr);
                        }
                    }

                    if (subjectresults == null)
                    {
                        TempData["NoData"] = " No Any Result Founded ! ";
                    }
                    else
                    {

                        foreach (var gdfc in subjectresults)
                        {
                            SubjectResult dbr = new SubjectResult();
                            dbr.Sub_r_id = gdfc.Sub_r_id;
                            Data.SubjectResult_s.Add(dbr);
                        }
                    }

                    Data.Student = new Student
                    {
                        db_Id = Student_s.db_Id,
                        Aplicnt_Id = Student_s.Aplicnt_Id,
                        Aplicnt_name = Student_s.Aplicnt_name,
                        Aplicnt_nnlty = Student_s.Aplicnt_nnlty,
                        Aplicnt_c_grade = Student_s.Aplicnt_c_grade,
                        Aplicnt_dob = Student_s.Aplicnt_dob,
                        Aplicnt_pob = Student_s.Aplicnt_pob,
                        Aplicnt_gender = Student_s.Aplicnt_gender,
                        Aplicnt_c_addr = Student_s.Aplicnt_c_addr,
                        Aplicnt_p_addr = Student_s.Aplicnt_p_addr,
                        Aplicnt_h_phone = Student_s.Aplicnt_h_phone,
                        Aplicnt_pp_photo = Student_s.Aplicnt_pp_photo,
                        Aplicnt_emrgncy_p_name = Student_s.Aplicnt_emrgncy_p_name,
                        Aplicnt_emrgncy_p_rltn = Student_s.Aplicnt_emrgncy_p_rltn,
                        Aplicnt_emrgncy_p_cell = Student_s.Aplicnt_emrgncy_p_cell,
                        Aplicnt_emrgncy_p_ldln = Student_s.Aplicnt_emrgncy_p_ldln,
                        Aplicnt_emrgncy_p_addr = Student_s.Aplicnt_emrgncy_p_addr,
                        Aplicnt_emrgncy_p_email = Student_s.Aplicnt_emrgncy_p_email,
                        Aplicnt_f_name = Student_s.Aplicnt_f_name,
                        Aplicnt_f_ocptn = Student_s.Aplicnt_f_ocptn,
                        Aplicnt_f_title = Student_s.Aplicnt_f_title,
                        Aplicnt_f_cell = Student_s.Aplicnt_f_cell,
                        Aplicnt_f_bsns_name = Student_s.Aplicnt_f_bsns_name,
                        Aplicnt_f_bsns_addr = Student_s.Aplicnt_f_bsns_addr,
                        Aplicnt_f_email = Student_s.Aplicnt_f_email,
                        Aplicnt_f_phone = Student_s.Aplicnt_f_phone,
                        Aplicnt_m_name = Student_s.Aplicnt_m_name,
                        Aplicnt_m_cell = Student_s.Aplicnt_m_cell,
                        Aplicnt_m_ldln = Student_s.Aplicnt_m_ldln,
                        Aplicnt_b_one_name = Student_s.Aplicnt_b_one_name,
                        Aplicnt_b_one_grade = Student_s.Aplicnt_b_one_grade,
                        Aplicnt_b_two_name = Student_s.Aplicnt_b_two_name,
                        Aplicnt_b_two_grade = Student_s.Aplicnt_b_two_grade,
                        Aplicnt_b_thr_name = Student_s.Aplicnt_b_thr_name,
                        Aplicnt_b_thr_grade = Student_s.Aplicnt_b_thr_grade,
                        Aplicnt_b_fou_name = Student_s.Aplicnt_b_fou_name,
                        Aplicnt_b_fou_grade = Student_s.Aplicnt_b_fou_grade,
                        Aplicnt_b_prsnt_schl = Student_s.Aplicnt_b_prsnt_schl,
                        Aplicnt_b_date_atdnc = Student_s.Aplicnt_b_date_atdnc,
                        Aplicnt_b_lng_ins = Student_s.Aplicnt_b_lng_ins,
                        Aplicnt_p_schl_name_o = Student_s.Aplicnt_p_schl_name_o,
                        Aplicnt_p_schl_strt_date_o = Student_s.Aplicnt_p_schl_strt_date_o,
                        Aplicnt_p_schl_end_date_o = Student_s.Aplicnt_p_schl_end_date_o,
                        Aplicnt_p_schl_name_t = Student_s.Aplicnt_p_schl_name_t,
                        Aplicnt_p_schl_strt_date_t = Student_s.Aplicnt_p_schl_strt_date_t,
                        Aplicnt_p_schl_end_date_t = Student_s.Aplicnt_p_schl_end_date_t,
                        Aplicnt_phycl_emo_cndtn_ackwlg = Student_s.Aplicnt_phycl_emo_cndtn_ackwlg,
                        Aplicnt_spcl_intrst_hobby = Student_s.Aplicnt_spcl_intrst_hobby,
                        Source_of_acknwlge_abt_da = Student_s.Source_of_acknwlge_abt_da,
                        Publish_result = Student_s.Publish_result,
                        ClassName = (Student_s.ClassName != null) ? Student_s.ClassName.Name : null

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
        public ActionResult Publish(Student ps, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Students PublishStudent = new Students();
                    PublishStudent.Publish_result = ps.Publish_result;
                    new Cateloge().PublishStudent(PublishStudent, id);
                    TempData["Msg"] = "This Student's Result Have Published Successfully";
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
                    return View(Data);
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
                    Students AddStudent = new Students();
                    AddStudent.Aplicnt_Id = Add.Student.Aplicnt_Id;
                    AddStudent.Aplicnt_name = Add.Student.Aplicnt_name;
                    AddStudent.Aplicnt_nnlty = Add.Student.Aplicnt_nnlty;
                    AddStudent.Aplicnt_c_grade = Add.Student.Aplicnt_c_grade;
                    AddStudent.Aplicnt_dob = Add.Student.Aplicnt_dob;
                    AddStudent.Aplicnt_pob = Add.Student.Aplicnt_pob;
                    AddStudent.Aplicnt_gender = Add.Student.Aplicnt_gender;
                    AddStudent.Aplicnt_c_addr = Add.Student.Aplicnt_c_addr;
                    AddStudent.Aplicnt_p_addr = Add.Student.Aplicnt_p_addr;
                    AddStudent.Aplicnt_h_phone = Add.Student.Aplicnt_h_phone;
                    AddStudent.Aplicnt_pp_photo = Add.Student.Aplicnt_pp_photo;
                    HttpPostedFileBase imgFile = Request.Files["Student.Aplicnt_pp_photo"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/students/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddStudent.Aplicnt_pp_photo = imgName;
                    }
                    AddStudent.Aplicnt_emrgncy_p_name = Add.Student.Aplicnt_emrgncy_p_name;
                    AddStudent.Aplicnt_emrgncy_p_rltn = Add.Student.Aplicnt_emrgncy_p_rltn;
                    AddStudent.Aplicnt_emrgncy_p_cell = Add.Student.Aplicnt_emrgncy_p_cell;
                    AddStudent.Aplicnt_emrgncy_p_ldln = Add.Student.Aplicnt_emrgncy_p_ldln;
                    AddStudent.Aplicnt_emrgncy_p_addr = Add.Student.Aplicnt_emrgncy_p_addr;
                    AddStudent.Aplicnt_emrgncy_p_email = Add.Student.Aplicnt_emrgncy_p_email;
                    AddStudent.Aplicnt_f_name = Add.Student.Aplicnt_f_name;
                    AddStudent.Aplicnt_f_ocptn = Add.Student.Aplicnt_f_ocptn;
                    AddStudent.Aplicnt_f_title = Add.Student.Aplicnt_f_title;
                    AddStudent.Aplicnt_f_cell = Add.Student.Aplicnt_f_cell;
                    AddStudent.Aplicnt_f_bsns_name = Add.Student.Aplicnt_f_bsns_name;
                    AddStudent.Aplicnt_f_bsns_addr = Add.Student.Aplicnt_f_bsns_addr;
                    AddStudent.Aplicnt_f_email = Add.Student.Aplicnt_f_email;
                    AddStudent.Aplicnt_f_phone = Add.Student.Aplicnt_f_phone;
                    AddStudent.Aplicnt_m_name = Add.Student.Aplicnt_m_name;
                    AddStudent.Aplicnt_m_cell = Add.Student.Aplicnt_m_cell;
                    AddStudent.Aplicnt_m_ldln = Add.Student.Aplicnt_m_ldln;
                    AddStudent.Aplicnt_b_one_name = Add.Student.Aplicnt_b_one_name;
                    AddStudent.Aplicnt_b_one_grade = Add.Student.Aplicnt_b_one_grade;
                    AddStudent.Aplicnt_b_two_name = Add.Student.Aplicnt_b_two_name;
                    AddStudent.Aplicnt_b_two_grade = Add.Student.Aplicnt_b_two_grade;
                    AddStudent.Aplicnt_b_thr_name = Add.Student.Aplicnt_b_thr_name;
                    AddStudent.Aplicnt_b_thr_grade = Add.Student.Aplicnt_b_thr_grade;
                    AddStudent.Aplicnt_b_fou_name = Add.Student.Aplicnt_b_fou_name;
                    AddStudent.Aplicnt_b_fou_grade = Add.Student.Aplicnt_b_fou_grade;
                    AddStudent.Aplicnt_b_prsnt_schl = Add.Student.Aplicnt_b_prsnt_schl;
                    AddStudent.Aplicnt_b_date_atdnc = Add.Student.Aplicnt_b_date_atdnc;
                    AddStudent.Aplicnt_b_lng_ins = Add.Student.Aplicnt_b_lng_ins;
                    AddStudent.Aplicnt_p_schl_name_o = Add.Student.Aplicnt_p_schl_name_o;
                    AddStudent.Aplicnt_p_schl_strt_date_o = Add.Student.Aplicnt_p_schl_strt_date_o;
                    AddStudent.Aplicnt_p_schl_end_date_o = Add.Student.Aplicnt_p_schl_end_date_o;
                    AddStudent.Aplicnt_p_schl_name_t = Add.Student.Aplicnt_p_schl_name_t;
                    AddStudent.Aplicnt_p_schl_strt_date_t = Add.Student.Aplicnt_p_schl_strt_date_t;
                    AddStudent.Aplicnt_p_schl_end_date_t = Add.Student.Aplicnt_p_schl_end_date_t;
                    AddStudent.Aplicnt_phycl_emo_cndtn_ackwlg = Add.Student.Aplicnt_phycl_emo_cndtn_ackwlg;
                    AddStudent.Aplicnt_spcl_intrst_hobby = Add.Student.Aplicnt_spcl_intrst_hobby;
                    AddStudent.Source_of_acknwlge_abt_da = Add.Student.Source_of_acknwlge_abt_da;
                    AddStudent.Aplicnt_admsn_verify = Add.Student.Aplicnt_admsn_verify;
                    AddStudent.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddStudent.Month = DateTime.Today.ToString("MMM");
                    AddStudent.Year = DateTime.Today.ToString("yyyy");
                    AddStudent.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddStudent(AddStudent);
                    TempData["Msg"] = "New Student Have Added Successfully";
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

                List<ClassLevels> classLevels = new Cateloge().ClassLevels();

                Students Student_s = new Cateloge().SelectStudent(id);

                if (Student_s == null && classLevels == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.ClassLevel_s = new List<ClassLevel>();

                    foreach (var gdfc in classLevels)
                    {
                        ClassLevel dbr = new ClassLevel();
                        dbr.Id = gdfc.db_Id;
                        dbr.Name = gdfc.Name;
                        Data.ClassLevel_s.Add(dbr);
                    }
                    Data.Student = new Student
                    {
                        db_Id = Student_s.db_Id,
                        Aplicnt_Id = Student_s.Aplicnt_Id,
                        Aplicnt_name = Student_s.Aplicnt_name,
                        Aplicnt_nnlty = Student_s.Aplicnt_nnlty,
                        Aplicnt_c_grade = Student_s.Aplicnt_c_grade,
                        Aplicnt_dob = Student_s.Aplicnt_dob,
                        Aplicnt_pob = Student_s.Aplicnt_pob,
                        Aplicnt_gender = Student_s.Aplicnt_gender,
                        Aplicnt_c_addr = Student_s.Aplicnt_c_addr,
                        Aplicnt_p_addr = Student_s.Aplicnt_p_addr,
                        Aplicnt_h_phone = Student_s.Aplicnt_h_phone,
                        Aplicnt_pp_photo = Student_s.Aplicnt_pp_photo,
                        Aplicnt_emrgncy_p_name = Student_s.Aplicnt_emrgncy_p_name,
                        Aplicnt_emrgncy_p_rltn = Student_s.Aplicnt_emrgncy_p_rltn,
                        Aplicnt_emrgncy_p_cell = Student_s.Aplicnt_emrgncy_p_cell,
                        Aplicnt_emrgncy_p_ldln = Student_s.Aplicnt_emrgncy_p_ldln,
                        Aplicnt_emrgncy_p_addr = Student_s.Aplicnt_emrgncy_p_addr,
                        Aplicnt_emrgncy_p_email = Student_s.Aplicnt_emrgncy_p_email,
                        Aplicnt_f_name = Student_s.Aplicnt_f_name,
                        Aplicnt_f_ocptn = Student_s.Aplicnt_f_ocptn,
                        Aplicnt_f_title = Student_s.Aplicnt_f_title,
                        Aplicnt_f_cell = Student_s.Aplicnt_f_cell,
                        Aplicnt_f_bsns_name = Student_s.Aplicnt_f_bsns_name,
                        Aplicnt_f_bsns_addr = Student_s.Aplicnt_f_bsns_addr,
                        Aplicnt_f_email = Student_s.Aplicnt_f_email,
                        Aplicnt_f_phone = Student_s.Aplicnt_f_phone,
                        Aplicnt_m_name = Student_s.Aplicnt_m_name,
                        Aplicnt_m_cell = Student_s.Aplicnt_m_cell,
                        Aplicnt_m_ldln = Student_s.Aplicnt_m_ldln,
                        Aplicnt_b_one_name = Student_s.Aplicnt_b_one_name,
                        Aplicnt_b_one_grade = Student_s.Aplicnt_b_one_grade,
                        Aplicnt_b_two_name = Student_s.Aplicnt_b_two_name,
                        Aplicnt_b_two_grade = Student_s.Aplicnt_b_two_grade,
                        Aplicnt_b_thr_name = Student_s.Aplicnt_b_thr_name,
                        Aplicnt_b_thr_grade = Student_s.Aplicnt_b_thr_grade,
                        Aplicnt_b_fou_name = Student_s.Aplicnt_b_fou_name,
                        Aplicnt_b_fou_grade = Student_s.Aplicnt_b_fou_grade,
                        Aplicnt_b_prsnt_schl = Student_s.Aplicnt_b_prsnt_schl,
                        Aplicnt_b_date_atdnc = Student_s.Aplicnt_b_date_atdnc,
                        Aplicnt_b_lng_ins = Student_s.Aplicnt_b_lng_ins,
                        Aplicnt_p_schl_name_o = Student_s.Aplicnt_p_schl_name_o,
                        Aplicnt_p_schl_strt_date_o = Student_s.Aplicnt_p_schl_strt_date_o,
                        Aplicnt_p_schl_end_date_o = Student_s.Aplicnt_p_schl_end_date_o,
                        Aplicnt_p_schl_name_t = Student_s.Aplicnt_p_schl_name_t,
                        Aplicnt_p_schl_strt_date_t = Student_s.Aplicnt_p_schl_strt_date_t,
                        Aplicnt_p_schl_end_date_t = Student_s.Aplicnt_p_schl_end_date_t,
                        Aplicnt_phycl_emo_cndtn_ackwlg = Student_s.Aplicnt_phycl_emo_cndtn_ackwlg,
                        Aplicnt_spcl_intrst_hobby = Student_s.Aplicnt_spcl_intrst_hobby,
                        Source_of_acknwlge_abt_da = Student_s.Source_of_acknwlge_abt_da,
                        Aplicnt_admsn_verify = Student_s.Aplicnt_admsn_verify,
                        ClassName = (Student_s.ClassName != null) ? Student_s.ClassName.Name : null,
                    };
                    return View(Data);
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddSubjectResult(int sid , int cid , int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                //List<Sub_Results> sub_results = new Cateloge().SelectAllSubResults();
                List<SubjectsTotalMarks> subjects = new Cateloge().SelectAllSubjectsTotalMarksWithIds(cid , rid);
                AllClasses Data = new AllClasses();
                Data.SubjectResult_s = new List<SubjectResult>();

                if (subjects == null)
                {
                    ViewBag.StatusMessage = " No Any Subject Founded ! ";
                }
                else
                {
                    Data.SubjectsTotalMark_s = new List<SubjectTotalMark>();
                    foreach (var gdfc in subjects)
                    {
                        SubjectResult dbr = new SubjectResult();
                        dbr.Subject_id = gdfc.Subject_id;
                        dbr.Sub_r_id = Convert.ToString(rid);
                        dbr.Student_id = Convert.ToString(sid);
                        dbr.Subject_name = gdfc.Subject_name.Name;
                        Data.SubjectResult_s.Add(dbr);
                    }
                    Data.SubjectResult_s.TrimExcess();
                }
                return PartialView("_SubjectResultForm", Data);
            }
        }

        [HttpPost]
        public ActionResult AddSubjectResult(List<SubjectResult> Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {

                    List<SubjectResults> subjectsresult = new List<SubjectResults>();
                    foreach (SubjectResult gdfc in Add)
                    {
                        SubjectResults dbr = new SubjectResults();
                        dbr.Obtn_marks = gdfc.Obtn_marks;
                        dbr.Sub_r_id = gdfc.Sub_r_id;
                        dbr.Student_id = gdfc.Student_id;
                        dbr.Status = gdfc.Status;
                        dbr.Subject_id = gdfc.Subject_id;
                        dbr.Date = DateTime.Today.ToString("dd-MM-yyyy");
                        dbr.Month = DateTime.Today.ToString("MMM");
                        dbr.Year = DateTime.Today.ToString("yyyy");
                        dbr.Time = DateTime.Now.ToString("HH:mm:ss");
                        subjectsresult.Add(dbr);
                    }
                    new Cateloge().AddSubjectsObtnMarks(subjectsresult);
                    TempData["Msg"] = "New Subjects Result Have Added Successfully";
                    return RedirectToAction("View", new { id = Add[0].Student_id });
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult UpdtSubjectsResult(int sid , int rid)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                //List<Sub_Results> sub_results = new Cateloge().SelectAllSubResults();
                List<SubjectResults> allsubjectsresult = new Cateloge().SelectAllSubjectsResult(sid, rid);
                AllClasses Data = new AllClasses();
                Data.SubjectResult_s = new List<SubjectResult>();

                if (allsubjectsresult == null)
                {
                    ViewBag.StatusMessage = " No Any Subject Founded ! ";
                }
                else
                {
                    foreach (var gdfc in allsubjectsresult)
                    {
                        SubjectResult dbr = new SubjectResult();
                        dbr.Id = gdfc.Id;
                        dbr.Obtn_marks = gdfc.Obtn_marks;
                        dbr.Sub_r_id = Convert.ToString(rid);
                        dbr.Subject_name = gdfc.Subject_name.Name;
                        dbr.Student_id = Convert.ToString(sid);
                        dbr.Status = gdfc.Status;
                        Data.SubjectResult_s.Add(dbr);
                    }
                    Data.SubjectResult_s.TrimExcess();
                }
                return PartialView("_SubjectResultForm_", Data);
            }
        }

        [HttpPost]
        public ActionResult UpdtSubjectsResult(List<SubjectResult> Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {

                    List<SubjectResults> subjectsresult = new List<SubjectResults>();
                    foreach (SubjectResult gdfc in Add)
                    {
                        SubjectResults dbr = new SubjectResults();
                        dbr.Obtn_marks = gdfc.Obtn_marks;
                        dbr.Id = gdfc.Id;
                        dbr.Status = gdfc.Status;
                        subjectsresult.Add(dbr);
                    }
                    new Cateloge().UpdtSubjectsObtnMarks(subjectsresult);
                    TempData["Msg"] = "Subjects Result Have Updated Successfully";
                    return RedirectToAction("View", new { id = Add[0].Student_id });
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult AddResultPosition(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                List<Sub_Results> sub_results = new Cateloge().SelectAllSubResults();
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
                        Data.Sub_Result_s.Add(dbr);
                    }
                    return PartialView("_ResultPositionForm", Data);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddResultPosition(AllClasses Add, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ResultsPositions AddResultPstn = new ResultsPositions();
                    AddResultPstn.Sub_r_id = Add.Result_Position.Sub_r_id;
                    AddResultPstn.Student_id = Convert.ToString(id);
                    AddResultPstn.Class_Section = Add.Result_Position.Class_Section;
                    AddResultPstn.Obtn_Pstn = Add.Result_Position.Obtn_Pstn;
                    AddResultPstn.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddResultPstn.Month = DateTime.Today.ToString("MMM");
                    AddResultPstn.Year = DateTime.Today.ToString("yyyy");
                    AddResultPstn.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddResultPosition(AddResultPstn);
                    TempData["Msg"] = "Student Position Of Result Have Added Successfully";
                    return RedirectToAction("View", new { id = id });
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(AllClasses Update,int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Students UpdateStudent = new Students();
                    UpdateStudent.Aplicnt_Id = Update.Student.Aplicnt_Id;
                    UpdateStudent.Aplicnt_name = Update.Student.Aplicnt_name;
                    UpdateStudent.Aplicnt_nnlty = Update.Student.Aplicnt_nnlty;
                    UpdateStudent.Aplicnt_c_grade = Update.Student.Aplicnt_c_grade;
                    UpdateStudent.Aplicnt_dob = Update.Student.Aplicnt_dob;
                    UpdateStudent.Aplicnt_pob = Update.Student.Aplicnt_pob;
                    UpdateStudent.Aplicnt_gender = Update.Student.Aplicnt_gender;
                    UpdateStudent.Aplicnt_c_addr = Update.Student.Aplicnt_c_addr;
                    UpdateStudent.Aplicnt_p_addr = Update.Student.Aplicnt_p_addr;
                    UpdateStudent.Aplicnt_h_phone = Update.Student.Aplicnt_h_phone;
                    //HttpPostedFileBase imgFile = Request.Files["Update.Student.Aplicnt_pp_photo"];
                    //if (imgFile.ContentLength > 0)
                    //{
                    //    string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                    //    string imgName = DateTime.Now.Ticks + ext;
                    //    string webpath = "~/students/" + imgName;
                    //    imgFile.SaveAs(Request.MapPath(webpath));
                    //    UpdateStudent.Aplicnt_pp_photo = imgName;
                    //}
                    //else
                    //{
                    //    UpdateStudent.Aplicnt_pp_photo = Update.Student.Aplicnt_pp_photo;
                    //}

                    UpdateStudent.Aplicnt_emrgncy_p_name = Update.Student.Aplicnt_emrgncy_p_name;
                    UpdateStudent.Aplicnt_emrgncy_p_rltn = Update.Student.Aplicnt_emrgncy_p_rltn;
                    UpdateStudent.Aplicnt_emrgncy_p_cell = Update.Student.Aplicnt_emrgncy_p_cell;
                    UpdateStudent.Aplicnt_emrgncy_p_ldln = Update.Student.Aplicnt_emrgncy_p_ldln;
                    UpdateStudent.Aplicnt_emrgncy_p_addr = Update.Student.Aplicnt_emrgncy_p_addr;
                    UpdateStudent.Aplicnt_emrgncy_p_email = Update.Student.Aplicnt_emrgncy_p_email;
                    UpdateStudent.Aplicnt_f_name = Update.Student.Aplicnt_f_name;
                    UpdateStudent.Aplicnt_f_ocptn = Update.Student.Aplicnt_f_ocptn;
                    UpdateStudent.Aplicnt_f_title = Update.Student.Aplicnt_f_title;
                    UpdateStudent.Aplicnt_f_cell = Update.Student.Aplicnt_f_cell;
                    UpdateStudent.Aplicnt_f_bsns_name = Update.Student.Aplicnt_f_bsns_name;
                    UpdateStudent.Aplicnt_f_bsns_addr = Update.Student.Aplicnt_f_bsns_addr;
                    UpdateStudent.Aplicnt_f_email = Update.Student.Aplicnt_f_email;
                    UpdateStudent.Aplicnt_f_phone = Update.Student.Aplicnt_f_phone;
                    UpdateStudent.Aplicnt_m_name = Update.Student.Aplicnt_m_name;
                    UpdateStudent.Aplicnt_m_cell = Update.Student.Aplicnt_m_cell;
                    UpdateStudent.Aplicnt_m_ldln = Update.Student.Aplicnt_m_ldln;
                    UpdateStudent.Aplicnt_b_one_name = Update.Student.Aplicnt_b_one_name;
                    UpdateStudent.Aplicnt_b_one_grade = Update.Student.Aplicnt_b_one_grade;
                    UpdateStudent.Aplicnt_b_two_name = Update.Student.Aplicnt_b_two_name;
                    UpdateStudent.Aplicnt_b_two_grade = Update.Student.Aplicnt_b_two_grade;
                    UpdateStudent.Aplicnt_b_thr_name = Update.Student.Aplicnt_b_thr_name;
                    UpdateStudent.Aplicnt_b_thr_grade = Update.Student.Aplicnt_b_thr_grade;
                    UpdateStudent.Aplicnt_b_fou_name = Update.Student.Aplicnt_b_fou_name;
                    UpdateStudent.Aplicnt_b_fou_grade = Update.Student.Aplicnt_b_fou_grade;
                    UpdateStudent.Aplicnt_b_prsnt_schl = Update.Student.Aplicnt_b_prsnt_schl;
                    UpdateStudent.Aplicnt_b_date_atdnc = Update.Student.Aplicnt_b_date_atdnc;
                    UpdateStudent.Aplicnt_b_lng_ins = Update.Student.Aplicnt_b_lng_ins;
                    UpdateStudent.Aplicnt_p_schl_name_o = Update.Student.Aplicnt_p_schl_name_o;
                    UpdateStudent.Aplicnt_p_schl_strt_date_o = Update.Student.Aplicnt_p_schl_strt_date_o;
                    UpdateStudent.Aplicnt_p_schl_end_date_o = Update.Student.Aplicnt_p_schl_end_date_o;
                    UpdateStudent.Aplicnt_p_schl_name_t = Update.Student.Aplicnt_p_schl_name_t;
                    UpdateStudent.Aplicnt_p_schl_strt_date_t = Update.Student.Aplicnt_p_schl_strt_date_t;
                    UpdateStudent.Aplicnt_p_schl_end_date_t = Update.Student.Aplicnt_p_schl_end_date_t;
                    UpdateStudent.Aplicnt_phycl_emo_cndtn_ackwlg = Update.Student.Aplicnt_phycl_emo_cndtn_ackwlg;
                    UpdateStudent.Aplicnt_spcl_intrst_hobby = Update.Student.Aplicnt_spcl_intrst_hobby;
                    UpdateStudent.Source_of_acknwlge_abt_da = Update.Student.Source_of_acknwlge_abt_da;
                    new Cateloge().UpdateStudent(UpdateStudent, id);
                    TempData["Msg"] = "Student Info Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
