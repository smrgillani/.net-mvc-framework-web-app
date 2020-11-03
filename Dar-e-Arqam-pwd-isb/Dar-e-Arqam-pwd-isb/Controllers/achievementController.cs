using Dar_e_Arqam_pwd_isb.Models;
using Dar_e_Arqam_pwd_isb.ENT;
using Dar_e_Arqam_pwd_isb.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dar_e_Arqam_pwd_isb.Controllers
{
    public class achievementController : Controller
    {
        //
        // GET: /achievement/

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
                    List<Achvmnts> Searched = new Cateloge().SearchAchvmnts(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Achvmnt_s = new List<Achvmnt>();
                        foreach (var gdfc in Searched)
                        {
                            Achvmnt dbr = new Achvmnt();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.Achvmnt_s.Add(dbr);
                        }
                        Data.Achvmnt_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Achvmnts> achvmnts = new Cateloge().Achvmnts();

                    if (achvmnts == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Achvmnt_s = new List<Achvmnt>();
                        foreach (var gdfc in achvmnts)
                        {
                            Achvmnt dbr = new Achvmnt();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.Achvmnt_s.Add(dbr);
                        }
                        Data.Achvmnt_s.TrimExcess();
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
                Achvmnts achvmnt = new Cateloge().SelectAchvmnts(id);

                if (achvmnt == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Achvmnt = new Achvmnt
                    {
                        Id = achvmnt.db_Id,
                        Name = achvmnt.Name,
                        Detail = achvmnt.Detail,
                        Picture = achvmnt.Picture,
                        Publish = achvmnt.Publish
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
        public ActionResult Publish(Achvmnt pa, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Achvmnts PublishAchvmnt = new Achvmnts();
                    PublishAchvmnt.Publish = pa.Publish;
                    new Cateloge().PublishAchvmnt(PublishAchvmnt, id);
                    TempData["Msg"] = "This Achievement Have Published Successfully";
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
                    return PartialView("_CreateNewAchievement");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Achvmnt Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Achvmnts AddAchvmnt = new Achvmnts();
                    AddAchvmnt.Name = Add.Name;
                    AddAchvmnt.Detail = Add.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Achvmnts/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddAchvmnt.Picture = imgName;
                    }
                    AddAchvmnt.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddAchvmnt.Month = DateTime.Today.ToString("MMB");
                    AddAchvmnt.Year = DateTime.Today.ToString("yyyy");
                    AddAchvmnt.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddAchvmnt(AddAchvmnt);
                    TempData["Msg"] = "New Achievement Have Added Successfully";
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

            Achvmnts achvmnt = new Cateloge().SelectAchvmnts(id);

            if (achvmnt == null)
            {
                ViewBag.StatusMessage = " No Any Result Founded ! ";
            }
            else
            {
                Achvmnt Formelements = new Achvmnt
                {
                    Name = achvmnt.Name,
                    Detail = achvmnt.Detail,
                    Picture = achvmnt.Picture
                };
                return PartialView("_EditAchvmnt", Formelements);
            }

            return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public ActionResult Edit(Achvmnt Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Achvmnts UpdateAchvmnt = new Achvmnts();
                    UpdateAchvmnt.Name = Update.Name;
                    UpdateAchvmnt.Detail = Update.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Achvmnts/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateAchvmnt.Picture = imgName;
                        new Cateloge().UpdateAchvmnt_img(UpdateAchvmnt, id);
                    }
                    else
                    {
                        new Cateloge().UpdateAchvmnt(UpdateAchvmnt, id);
                    }
                    TempData["Msg"] = "Achievement Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);

            }
        }
    }
}
