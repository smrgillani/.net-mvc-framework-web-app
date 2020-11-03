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
    public class managementController : Controller
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
                    List<Employees> Searched = new Cateloge().SearchEmployees(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Employee_s = new List<Employee>();
                        foreach (var gdfc in Searched)
                        {
                            Employee dbr = new Employee();
                            dbr.Id = gdfc.db_Id;
                            dbr.E_name = gdfc.E_name;
                            dbr.E_email = gdfc.E_email;
                            dbr.E_c_num = gdfc.E_c_num;
                            dbr.E_desig = gdfc.E_desig;
                            Data.Employee_s.Add(dbr);
                        }
                        Data.Employee_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Employees> employees = new Cateloge().Employees();

                    if (employees == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Employee_s = new List<Employee>();
                        foreach (var gdfc in employees)
                        {
                            Employee dbr = new Employee();
                            dbr.Id = gdfc.db_Id;
                            dbr.E_name = gdfc.E_name;
                            dbr.E_email = gdfc.E_email;
                            dbr.E_c_num = gdfc.E_c_num;
                            dbr.E_desig = gdfc.E_desig;
                            Data.Employee_s.Add(dbr);
                        }
                        Data.Employee_s.TrimExcess();
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
                    return PartialView("_EmployeeForm");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Employees AddEmployee = new Employees();
                    AddEmployee.E_Id = Add.E_Id;
                    AddEmployee.E_name = Add.E_name;
                    AddEmployee.E_dob = Add.E_dob;
                    AddEmployee.E_cnic = Add.E_cnic;
                    AddEmployee.E_gen = Add.E_gen;
                    AddEmployee.E_email = Add.E_email;
                    AddEmployee.E_c_num = Add.E_c_num;
                    AddEmployee.E_a_c_num = Add.E_a_c_num;
                    AddEmployee.E_desig = Add.E_desig;
                    AddEmployee.E_g_name = Add.E_g_name;
                    AddEmployee.E_g_cnic = Add.E_g_cnic;
                    AddEmployee.E_res_addr = Add.E_res_addr;
                    AddEmployee.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddEmployee.Month = DateTime.Today.ToString("MMM");
                    AddEmployee.Year = DateTime.Today.ToString("yyyy");
                    AddEmployee.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddEmployee(AddEmployee);
                    TempData["Msg"] = "New Employee Have Added Successfully";
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

                Employees employee = new Cateloge().SelectEmployee(id);

                if (employee == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Employee Formelements = new Employee
                    {
                        E_Id = employee.E_Id,
                        E_name = employee.E_name,
                        E_dob = employee.E_dob,
                        E_cnic = employee.E_cnic,
                        E_gen = employee.E_gen,
                        E_email = employee.E_email,
                        E_c_num = employee.E_c_num,
                        E_a_c_num = employee.E_a_c_num,
                        E_desig = employee.E_desig,
                        E_g_name = employee.E_g_name,
                        E_g_cnic = employee.E_g_cnic,
                        E_res_addr = employee.E_res_addr
                    };
                    return PartialView("_EmployeeForm", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Employees UpdateEmployee = new Employees();
                    UpdateEmployee.E_Id = Update.E_Id;
                    UpdateEmployee.E_name = Update.E_name;
                    UpdateEmployee.E_dob = Update.E_dob;
                    UpdateEmployee.E_cnic = Update.E_cnic;
                    UpdateEmployee.E_gen = Update.E_gen;
                    UpdateEmployee.E_email = Update.E_email;
                    UpdateEmployee.E_c_num = Update.E_c_num;
                    UpdateEmployee.E_a_c_num = Update.E_a_c_num;
                    UpdateEmployee.E_desig = Update.E_desig;
                    UpdateEmployee.E_g_name = Update.E_g_name;
                    UpdateEmployee.E_g_cnic = Update.E_g_cnic;
                    UpdateEmployee.E_res_addr = Update.E_res_addr;
                    new Cateloge().UpdateEmployee(UpdateEmployee, id);
                    TempData["Msg"] = "Employee Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
