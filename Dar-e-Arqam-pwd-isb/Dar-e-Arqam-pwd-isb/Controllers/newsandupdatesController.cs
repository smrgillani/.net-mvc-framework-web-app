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
    public class newsandupdatesController : Controller
    {
        //
        // GET: /newsandupdates/
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
                    List<NewsUpdts> Searched = new Cateloge().SearchNewsAndUpdts(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.New_sAndUpdt_s = new List<NewsUpdt>();
                        foreach (var gdfc in Searched)
                        {
                            NewsUpdt dbr = new NewsUpdt();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.New_sAndUpdt_s.Add(dbr);
                        }
                        Data.New_sAndUpdt_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<NewsUpdts> NewsandUpdates = new Cateloge().NewsAndUpdts();

                    if (NewsandUpdates == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.New_sAndUpdt_s = new List<NewsUpdt>();
                        foreach (var gdfc in NewsandUpdates)
                        {
                            NewsUpdt dbr = new NewsUpdt();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.New_sAndUpdt_s.Add(dbr);
                        }
                        Data.New_sAndUpdt_s.TrimExcess();
                        return View(Data);
                    }
                }
                return View();
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

        public ActionResult View(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                NewsUpdts Update = new Cateloge().SelectNewsAndUpdts(id);

                if (Update == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.NewsAndUpdt = new NewsUpdt
                    {
                        Id = Update.db_Id,
                        Name = Update.Name,
                        Detail = Update.Detail,
                        Picture = Update.Picture,
                        Publish = Update.Publish
                    };
                    return View(Data);
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
                    return PartialView("_CreateNewsOrUpdate");
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
        public ActionResult Publish( NewsUpdt pnu , int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    NewsUpdts PublishNewsUpdt = new NewsUpdts();
                    PublishNewsUpdt.Publish = pnu.Publish;
                    new Cateloge().PublishNewsOrUpdate(PublishNewsUpdt, id);
                    TempData["Msg"] = "This News or Update Have Published Successfully";
                    return RedirectToAction("View", new { id = id });
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsUpdt Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    NewsUpdts AddNewsUpdt = new NewsUpdts();
                    AddNewsUpdt.Name = Add.Name;
                    AddNewsUpdt.Detail = Add.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/News_And_Updates/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddNewsUpdt.Picture = imgName;
                    }
                    AddNewsUpdt.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddNewsUpdt.Month = DateTime.Today.ToString("MMM");
                    AddNewsUpdt.Year = DateTime.Today.ToString("yyyy");
                    AddNewsUpdt.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddNewsUpdt(AddNewsUpdt);
                    TempData["Msg"] = "New News And Update Have Added Successfully";
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

                NewsUpdts Update = new Cateloge().SelectNewsAndUpdts(id);

                if (Update == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    NewsUpdt Formelements = new NewsUpdt
                    {
                        Name = Update.Name,
                        Detail = Update.Detail,
                        Picture = Update.Picture,
                    };
                    return PartialView("_EditNewsOrUpdate", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(NewsUpdt Update,int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    NewsUpdts UpdateNewsAndUpdt = new NewsUpdts();
                    UpdateNewsAndUpdt.Name = Update.Name;
                    UpdateNewsAndUpdt.Detail = Update.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/News_And_Updates/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateNewsAndUpdt.Picture = imgName;
                        new Cateloge().UpdateNewsAndUpdts_img(UpdateNewsAndUpdt, id);
                    }
                    else
                    {
                        new Cateloge().UpdateNewsAndUpdts(UpdateNewsAndUpdt, id);
                    }
                    TempData["Msg"] = "News And Updates Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelNewsUpdt(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                NewsUpdts Update = new Cateloge().SelectNewsAndUpdts(id);
                string filePath = Request.MapPath("~/News_And_Updates/" + Update.Picture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    new Cateloge().DelNewsUpdt(id);
                }
                else
                {
                    new Cateloge().DelNewsUpdt(id);
                }
                TempData["Msg"] = "Selected News Or Update Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }

    }
}
