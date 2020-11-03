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
    public class uniformController : Controller
    {
        //
        // GET: /uniform/

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
                    List<Uniforms> Searched = new Cateloge().SearchUniforms(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Uniform_s = new List<Uniform>();
                        foreach (var gdfc in Searched)
                        {
                            Uniform dbr = new Uniform();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Class_lvl_id = dbr.Class_lvl_id;
                            dbr.Picture = gdfc.Picture;
                            Data.Uniform_s.Add(dbr);
                        }
                        Data.Uniform_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Uniforms> uniforms = new Cateloge().Uniforms();

                    if (uniforms == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Uniform_s = new List<Uniform>();
                        foreach (var gdfc in uniforms)
                        {
                            Uniform dbr = new Uniform();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Class_lvl_id = dbr.Class_lvl_id;
                            dbr.Picture = gdfc.Picture;
                            Data.Uniform_s.Add(dbr);
                        }
                        Data.Uniform_s.TrimExcess();
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
                    return PartialView("_CreateNewUniform");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uniform Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Uniforms AddUniform = new Uniforms();
                    AddUniform.Name = Add.Name;
                    AddUniform.Class_lvl_id = Add.Class_lvl_id;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Uniforms/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddUniform.Picture = imgName;
                    }
                    AddUniform.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddUniform.Month = DateTime.Today.ToString("MMM");
                    AddUniform.Year = DateTime.Today.ToString("yyyy");
                    AddUniform.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddUniform(AddUniform);
                    TempData["Msg"] = "New Uniform Have Added Successfully";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
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
                AllClasses Data = new AllClasses();
                Data.Uniform_ = new Uniform();

                Uniforms uniform = new Cateloge().SelectUniforms(id);

                if (uniform == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {

                    Data.Uniform_ = new Uniform{
                        Id = uniform.db_Id,
                        Name = uniform.Name,
                        Class_lvl_id = uniform.Class_lvl_id,
                        Picture = uniform.Picture,
                        Publish = uniform.Publish
                    };
                    return View(Data);
                }
                return View();
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
        public ActionResult Publish(Uniform pu, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Uniforms PublishUniform = new Uniforms();
                    PublishUniform.Publish = pu.Publish;
                    new Cateloge().PublishUniform(PublishUniform, id);
                    if (pu.Publish == "2")
                    {
                        TempData["Msg"] = "This Uniform Have Published Successfully";

                    }
                    else
                    {
                        TempData["Msg"] = "This Uniform Have Blocked Successfully";
                    }
                    return RedirectToAction("View", new { id = id });
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

                Uniforms uniform = new Cateloge().SelectUniforms(id);

                if (uniform == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Uniform Formelements = new Uniform
                    {
                        Name = uniform.Name,
                        Class_lvl_id = uniform.Class_lvl_id,
                        Picture = uniform.Picture,
                    };
                    return PartialView("_EditUniform", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Uniform Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Uniforms UpdateUniform = new Uniforms();
                    UpdateUniform.Name = Update.Name;
                    UpdateUniform.Class_lvl_id = Update.Class_lvl_id;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Uniforms/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateUniform.Picture = imgName;
                        new Cateloge().UpdateUniform_img(UpdateUniform, id);
                    }
                    else
                    {
                        new Cateloge().UpdateUniform(UpdateUniform, id);
                    }
                    TempData["Msg"] = "Uniform Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelUniform(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Uniforms uniform = new Cateloge().SelectUniforms(id);
                string filePath = Request.MapPath("~/Uniforms/" + uniform.Picture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    new Cateloge().DelUniform(id);
                }
                else
                {
                    new Cateloge().DelUniform(id);
                }
                TempData["Msg"] = "Selected Uniform Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
