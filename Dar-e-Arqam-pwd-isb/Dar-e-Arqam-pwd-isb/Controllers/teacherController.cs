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
    public class teacherController : Controller
    {
        //
        // GET: /teacher/
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
                    List<Teachers> Searched = new Cateloge().SearchTeacher(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        foreach (var gdfc in Searched)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Teachers> Teachers = new Cateloge().Teachers();

                    if (Teachers == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        List<Teacher> TeachersList = new List<Teacher>();
                        foreach (var gdfc in Teachers)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }
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

                Teachers view = new Cateloge().SelectTeacher(id);

                if (view == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Teacher_s = new Teacher
                    {
                        Id = view.db_Id,
                        T_Id = view.T_Id,
                        T_name = view.T_name,
                        T_dob = view.T_dob,
                        T_cnic = view.T_cnic,
                        T_gen = view.T_gen,
                        T_email = view.T_email,
                        T_c_num = view.T_c_num,
                        T_a_c_num = view.T_a_c_num,
                        T_type = view.T_type,
                        T_desig = view.T_desig,
                        T_jd = view.T_jd,
                        T_spcl_in_sbjct = view.T_spcl_in_sbjct,
                        T_g_name = view.T_g_name,
                        T_g_cnic = view.T_g_cnic,
                        T_res_addr = view.T_res_addr
                    };
                    return View(Data);
                }

                return RedirectToAction("Index");
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

                if (!string.IsNullOrEmpty(Search_key))
                {
                    List<Teachers> Searched = new Cateloge().SearchActiveTeacher(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        foreach (var gdfc in Searched)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Teachers> Teachers = new Cateloge().ActiveTeachers();

                    if (Teachers == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        List<Teacher> TeachersList = new List<Teacher>();
                        foreach (var gdfc in Teachers)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }
                }
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

                if (!string.IsNullOrEmpty(Search_key))
                {
                    List<Teachers> Searched = new Cateloge().SearchOldTeacher(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        foreach (var gdfc in Searched)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Teachers> Teachers = new Cateloge().OldTeachers();

                    if (Teachers == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        List<Teacher> TeachersList = new List<Teacher>();
                        foreach (var gdfc in Teachers)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }
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
                if (!string.IsNullOrEmpty(Search_key))
                {
                    List<Teachers> Searched = new Cateloge().SearchTrashTeacher(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        foreach (var gdfc in Searched)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Teachers> Teachers = new Cateloge().TrashTeachers();

                    if (Teachers == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Teacher = new List<Teacher>();
                        List<Teacher> TeachersList = new List<Teacher>();
                        foreach (var gdfc in Teachers)
                        {
                            Teacher dbr = new Teacher();
                            dbr.Id = gdfc.db_Id;
                            dbr.T_name = gdfc.T_name;
                            dbr.T_jd = gdfc.T_jd;
                            dbr.T_spcl_in_sbjct = gdfc.T_spcl_in_sbjct;
                            dbr.T_email = gdfc.T_email;
                            dbr.T_c_num = gdfc.T_c_num;
                            Data.Teacher.Add(dbr);
                        }
                        Data.Teacher.TrimExcess();
                        return View(Data);
                    }
                }
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

                Teacher createteacher = new Teacher();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_TeacherForm", createteacher);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult AsignClsSub(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_AsgnClsSubForm");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsignClsSub( ClassOrSubjectToTeacher Add, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ClassesOrSubjectsToTeacher AsgnClsSub = new ClassesOrSubjectsToTeacher();
                    AsgnClsSub.Class_subject_id = Add.Class_subject_id;
                    AsgnClsSub.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AsgnClsSub.Month = DateTime.Today.ToString("MMM");
                    AsgnClsSub.Year = DateTime.Today.ToString("yyyy");
                    AsgnClsSub.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddAsgndClsSub(AsgnClsSub, id);
                    TempData["Msg"] = "New Subject Have Asigned Successfully";
                    return RedirectToAction("View", new { id = id });
                }
                return View(Add);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Teachers AddTeacher = new Teachers();
                    AddTeacher.T_Id = Add.T_Id;
                    AddTeacher.T_name = Add.T_name;
                    AddTeacher.T_dob = Add.T_dob;
                    AddTeacher.T_cnic = Add.T_cnic;
                    AddTeacher.T_gen = Add.T_gen;
                    AddTeacher.T_email = Add.T_email;
                    AddTeacher.T_c_num = Add.T_c_num;
                    AddTeacher.T_a_c_num = Add.T_a_c_num;
                    AddTeacher.T_type = Add.T_type;
                    AddTeacher.T_desig = Add.T_desig;
                    AddTeacher.T_jd = Add.T_jd;
                    AddTeacher.T_spcl_in_sbjct = Add.T_spcl_in_sbjct;
                    AddTeacher.T_g_name = Add.T_g_name;
                    AddTeacher.T_g_cnic = Add.T_g_cnic;
                    AddTeacher.T_res_addr = Add.T_res_addr;
                    AddTeacher.Active_id = "0";
                    AddTeacher.Del_id = "0";
                    AddTeacher.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddTeacher.Month = DateTime.Today.ToString("MMM");
                    AddTeacher.Year = DateTime.Today.ToString("yyyy");
                    AddTeacher.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddTeacher(AddTeacher);
                    TempData["Msg"] = "New Teacher Have Added Successfully";
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

                Teachers Update = new Cateloge().SelectTeacher(id);

                if (Update == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Teacher Formelements = new Teacher
                    {
                        T_Id = Update.T_Id,
                        T_name = Update.T_name,
                        T_dob = Update.T_dob,
                        T_cnic = Update.T_cnic,
                        T_gen = Update.T_gen,
                        T_email = Update.T_email,
                        T_c_num = Update.T_c_num,
                        T_a_c_num = Update.T_a_c_num,
                        T_type = Update.T_type,
                        T_desig = Update.T_desig,
                        T_jd = Update.T_jd,
                        T_spcl_in_sbjct = Update.T_spcl_in_sbjct,
                        T_g_name = Update.T_g_name,
                        T_g_cnic = Update.T_g_cnic,
                        T_res_addr = Update.T_res_addr
                    };
                    return PartialView("_TeacherForm", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Teacher Update , int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Teachers UpdateTeacher = new Teachers();
                    UpdateTeacher.T_Id = Update.T_Id;
                    UpdateTeacher.T_name = Update.T_name;
                    UpdateTeacher.T_dob = Update.T_dob;
                    UpdateTeacher.T_cnic = Update.T_cnic;
                    UpdateTeacher.T_gen = Update.T_gen;
                    UpdateTeacher.T_email = Update.T_email;
                    UpdateTeacher.T_c_num = Update.T_c_num;
                    UpdateTeacher.T_a_c_num = Update.T_a_c_num;
                    UpdateTeacher.T_type = Update.T_type;
                    UpdateTeacher.T_desig = Update.T_desig;
                    UpdateTeacher.T_jd = Update.T_jd;
                    UpdateTeacher.T_spcl_in_sbjct = Update.T_spcl_in_sbjct;
                    UpdateTeacher.T_g_name = Update.T_g_name;
                    UpdateTeacher.T_g_cnic = Update.T_g_cnic;
                    UpdateTeacher.T_res_addr = Update.T_res_addr;
                    new Cateloge().UpdateTeacher(UpdateTeacher, id);
                    TempData["Msg"] = "Teacher Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
