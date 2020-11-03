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
    public class shiningstarsController : Controller
    {
        //
        // GET: /shiningstars/

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
                    List<Stars> Searched = new Cateloge().SearchStars(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Star_s = new List<Star>();
                        foreach (var gdfc in Searched)
                        {
                            Star dbr = new Star();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Star_type = gdfc.Star_type;
                            dbr.Achievement = gdfc.Achievement;
                            dbr.Picture = gdfc.Picture;
                            Data.Star_s.Add(dbr);
                        }
                        Data.Star_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Stars> stars = new Cateloge().Stars();

                    if (stars == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Star_s = new List<Star>();
                        foreach (var gdfc in stars)
                        {
                            Star dbr = new Star();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Star_type = gdfc.Star_type;
                            dbr.Achievement = gdfc.Achievement;
                            dbr.Picture = gdfc.Picture;
                            Data.Star_s.Add(dbr);
                        }
                        Data.Star_s.TrimExcess();
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

                Stars star = new Cateloge().SelectStars(id);

                if (star == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Star = new Star
                    {
                        Id = star.db_Id,
                        Name = star.Name,
                        Star_type = star.Star_type,
                        Achievement = star.Achievement,
                        Picture = star.Picture,
                        Publish = star.Publish
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
        public ActionResult Publish(Star pss, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Stars PublishStar = new Stars();
                    PublishStar.Publish = pss.Publish;
                    new Cateloge().PublishShiningStar(PublishStar, id);
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
                    return PartialView("_CreateNewShiningStar");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Star Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Stars AddStar = new Stars();
                    AddStar.Name = Add.Name;
                    AddStar.Star_type = Add.Star_type;
                    AddStar.Achievement = Add.Achievement;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Stars/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddStar.Picture = imgName;
                    }
                    AddStar.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddStar.Month = DateTime.Today.ToString("MMM");
                    AddStar.Year = DateTime.Today.ToString("yyyy");
                    AddStar.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddStar(AddStar);
                    TempData["Msg"] = "New Shining Star Have Added Successfully";
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

                Stars star = new Cateloge().SelectStars(id);

                if (star == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Star Formelements = new Star
                    {
                        Name = star.Name,
                        Star_type = star.Star_type,
                        Achievement = star.Achievement,
                        Picture = star.Picture
                    };
                    return PartialView("_EditShiningStar", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Star Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Stars UpdateStar = new Stars();
                    UpdateStar.Name = Update.Name;
                    UpdateStar.Star_type = Update.Star_type;
                    UpdateStar.Achievement = Update.Achievement;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Stars/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateStar.Picture = imgName;
                        new Cateloge().UpdateStar_img(UpdateStar, id);
                    }
                    else
                    {
                        new Cateloge().UpdateStar(UpdateStar, id);
                    }
                    TempData["Msg"] = "Shining Star Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelStar(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Stars star = new Cateloge().SelectStars(id);
                string filePath = Request.MapPath("~/Stars/" + star.Picture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    new Cateloge().DelStar(id);
                }
                else
                {
                    new Cateloge().DelStar(id);
                }
                TempData["Msg"] = "Selected Shining Star Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
