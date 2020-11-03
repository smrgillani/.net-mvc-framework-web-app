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
    public class feestructureController : Controller
    {
        //
        // GET: /feestructure/

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
                    List<FeeStructures> Searched = new Cateloge().SearchFeeStructures(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.FeeStructure_s = new List<FeeStructure>();
                        foreach (var gdfc in Searched)
                        {
                            FeeStructure dbr = new FeeStructure();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name_of_lvl = gdfc.Name_of_lvl;
                            dbr.Reg_fee = gdfc.Reg_fee;
                            dbr.Monthly_fee = gdfc.Monthly_fee;
                            Data.FeeStructure_s.Add(dbr);
                        }
                        Data.FeeStructure_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<FeeStructures> feestructures = new Cateloge().FeeStructures();

                    if (feestructures == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.FeeStructure_s = new List<FeeStructure>();
                        foreach (var gdfc in feestructures)
                        {
                            FeeStructure dbr = new FeeStructure();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name_of_lvl = gdfc.Name_of_lvl;
                            dbr.Reg_fee = gdfc.Reg_fee;
                            dbr.Monthly_fee = gdfc.Monthly_fee;
                            Data.FeeStructure_s.Add(dbr);
                        }
                        Data.FeeStructure_s.TrimExcess();
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

                FeeStructures feestructure = new Cateloge().SelectFeeStructures(id);

                if (feestructure == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.FeeStructure = new FeeStructure
                    {
                        Id = feestructure.db_Id,
                        Name_of_lvl = feestructure.Name_of_lvl,
                        Reg_fee = feestructure.Reg_fee,
                        Monthly_fee = feestructure.Monthly_fee,
                        Publish = feestructure.Publish
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
        public ActionResult Publish(FeeStructure pfs, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    FeeStructures PublishFeeStructures = new FeeStructures();
                    PublishFeeStructures.Publish = pfs.Publish;
                    new Cateloge().PublishFeeStructure(PublishFeeStructures, id);
                    TempData["Msg"] = "This Star Have Published Successfully";
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
                    return PartialView("_CreateNewFeeSTructure");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeeStructure Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    FeeStructures AddFeeStructure = new FeeStructures();
                    AddFeeStructure.Name_of_lvl = Add.Name_of_lvl;
                    AddFeeStructure.Reg_fee = Add.Reg_fee;
                    AddFeeStructure.Monthly_fee = Add.Monthly_fee;
                    AddFeeStructure.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddFeeStructure.Month = DateTime.Today.ToString("MMM");
                    AddFeeStructure.Year = DateTime.Today.ToString("yyyy");
                    AddFeeStructure.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddFeeStructure(AddFeeStructure);
                    TempData["Msg"] = "New Fee Structure Have Added Successfully";
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

                FeeStructures feestructure = new Cateloge().SelectFeeStructures(id);

                if (feestructure == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    FeeStructure Formelements = new FeeStructure
                    {
                        Name_of_lvl = feestructure.Name_of_lvl,
                        Reg_fee = feestructure.Reg_fee,
                        Monthly_fee = feestructure.Monthly_fee
                    };
                    return PartialView("_CreateNewFeeSTructure", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(FeeStructure Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    FeeStructures UpdateFeeStructure = new FeeStructures();
                    UpdateFeeStructure.Name_of_lvl = Update.Name_of_lvl;
                    UpdateFeeStructure.Reg_fee = Update.Reg_fee;
                    UpdateFeeStructure.Monthly_fee = Update.Monthly_fee;
                    new Cateloge().UpdateFeeStructure(UpdateFeeStructure, id);
                    TempData["Msg"] = "Fee Stucture Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
