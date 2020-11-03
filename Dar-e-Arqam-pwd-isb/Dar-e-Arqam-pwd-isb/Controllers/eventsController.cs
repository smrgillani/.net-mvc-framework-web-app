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
    public class eventsController : Controller
    {
        //
        // GET: /events/

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
                    List<Events> Searched = new Cateloge().SearchEvents(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Event_s = new List<Event>();
                        foreach (var gdfc in Searched)
                        {
                            Event dbr = new Event();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.Event_s.Add(dbr);
                        }
                        Data.Event_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Events> Events = new Cateloge().Events();

                    if (Events == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Event_s = new List<Event>();
                        foreach (var gdfc in Events)
                        {
                            Event dbr = new Event();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Detail = gdfc.Detail;
                            dbr.Picture = gdfc.Picture;
                            Data.Event_s.Add(dbr);
                        }
                        Data.Event_s.TrimExcess();
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
        public ActionResult Gallery(string Search_key)
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

                Events Event = new Cateloge().SelectEvent(id);

                if (Event == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Events = new Event
                    {
                        Id = Event.db_Id,
                        Name = Event.Name,
                        Detail = Event.Detail,
                        Picture = Event.Picture,
                        Publish = Event.Publish
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
        public ActionResult Publish(Event pe, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Events PublishEvent = new Events();
                    PublishEvent.Publish = pe.Publish;
                    new Cateloge().PublishEvent(PublishEvent, id);
                    TempData["Msg"] = "Event Settings Have Updated Successfully";
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
                    return PartialView("_CreateEvent");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Events AddEvent = new Events();
                    AddEvent.Name = Add.Name;
                    AddEvent.Detail = Add.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Event/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddEvent.Picture = imgName;
                    }
                    AddEvent.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddEvent.Month = DateTime.Today.ToString("MMM");
                    AddEvent.Year = DateTime.Today.ToString("yyyy");
                    AddEvent.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddEvent(AddEvent);
                    TempData["Msg"] = "New Event Have Added Successfully";
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

                Events Event = new Cateloge().SelectEvent(id);

                if (Event == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Event Formelements = new Event
                    {
                        Name = Event.Name,
                        Detail = Event.Detail,
                        Picture = Event.Picture,
                    };
                    return PartialView("_EditEvent", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Event Update ,int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Events UpdateEvent = new Events();
                    UpdateEvent.Name = Update.Name;
                    UpdateEvent.Detail = Update.Detail;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Event/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateEvent.Picture = imgName;
                        new Cateloge().UpdateEvent_img(UpdateEvent, id);
                    }
                    else
                    {
                        new Cateloge().UpdateEvent(UpdateEvent, id);
                    }
                    TempData["Msg"] = "Event Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelEvent(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Events Event = new Cateloge().SelectEvent(id);
                string filePath = Request.MapPath("~/Event/" + Event.Picture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    new Cateloge().DelEvent(id);
                }
                else
                {
                    new Cateloge().DelEvent(id);
                }
                TempData["Msg"] = "Selected Event Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
