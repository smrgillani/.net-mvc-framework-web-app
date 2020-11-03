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
    public class bookController : Controller
    {
        //
        // GET: /book/
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
                    List<Books> Searched = new Cateloge().SearchBooks(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Book_s = new List<Book>();
                        foreach (var gdfc in Searched)
                        {
                            Book dbr = new Book();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Class_name = (gdfc.Class_name != null) ? gdfc.Class_name.Name : null;
                            dbr.Picture = gdfc.Picture;
                            Data.Book_s.Add(dbr);
                        }
                        Data.Book_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<Books> Books = new Cateloge().Books();

                    if (Books == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Book_s = new List<Book>();
                        foreach (var gdfc in Books)
                        {
                            Book dbr = new Book();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.Class_name = (gdfc.Class_name != null) ? gdfc.Class_name.Name : null;
                            dbr.Picture = gdfc.Picture;
                            Data.Book_s.Add(dbr);
                        }
                        Data.Book_s.TrimExcess();
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

        public ActionResult Active()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                List<Books> Books = new Cateloge().ActiveBooks();

                if (Books == null)
                {
                    ViewBag.StatusMessage = " No Any Data Found ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.Book_s = new List<Book>();
                    foreach (var gdfc in Books)
                    {
                        Book dbr = new Book();
                        dbr.Id = gdfc.db_Id;
                        dbr.Name = gdfc.Name;
                        dbr.Class_name = (gdfc.Class_name != null) ? gdfc.Class_name.Name : null;
                        dbr.Picture = gdfc.Picture;
                        Data.Book_s.Add(dbr);
                    }
                    Data.Book_s.TrimExcess();
                    return View(Data);
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
        public ActionResult Publish(Book pb, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Books PublishBook = new Books();
                    PublishBook.Publish = pb.Publish;
                    new Cateloge().PublishBook(PublishBook, id);
                    if (pb.Publish == "2")
                    {
                        TempData["Msg"] = "This Book Have Published Successfully";

                    }
                    else
                    {
                        TempData["Msg"] = "This Book Have Blocked Successfully";
                    }
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
                    return PartialView("_CreateNewBook");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Books AddBook = new Books();
                    AddBook.Name = Add.Name;
                    AddBook.Class_subject_id = Add.Class_subject_id;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Books/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        AddBook.Picture = imgName;
                    }
                    AddBook.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddBook.Month = DateTime.Today.ToString("MMM");
                    AddBook.Year = DateTime.Today.ToString("yyyy");
                    AddBook.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddBook(AddBook);
                    TempData["Msg"] = "New Book Have Added Successfully";
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

                Books book = new Cateloge().SelectBook(id);

                if (book == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Book Formelements = new Book
                    {
                        Name = book.Name,
                        Class_subject_id = book.Class_subject_id,
                        Picture = book.Picture,
                    };
                    return PartialView("_EditBook", Formelements);
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

                Books book = new Cateloge().SelectBook(id);

                if (book == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    Data.Book_ = new Book
                    {
                        Id = book.db_Id,
                        Name = book.Name,
                        Class_name = (book.Class_name != null) ? book.Class_name.Name : null,
                        Picture = book.Picture,
                        Publish = book.Publish
                    };
                    return View(Data);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Book Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    Books UpdateBook = new Books();
                    UpdateBook.Name = Update.Name;
                    UpdateBook.Class_subject_id = Update.Class_subject_id;
                    HttpPostedFileBase imgFile = Request.Files["Picture"];
                    if (imgFile.ContentLength > 0)
                    {
                        string ext = imgFile.FileName.Substring(imgFile.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/Books/" + imgName;
                        imgFile.SaveAs(Request.MapPath(webpath));
                        UpdateBook.Picture = imgName;
                        new Cateloge().UpdateBooks_img(UpdateBook, id);
                    }
                    else
                    {
                        new Cateloge().UpdateBooks(UpdateBook, id);
                    }
                    TempData["Msg"] = "Book Have Updated Successfully";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult DelBook(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {
                Books book = new Cateloge().SelectBook(id);
                string filePath = Request.MapPath("~/Books/" + book.Picture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    new Cateloge().DelBook(id);
                }
                else
                {
                    new Cateloge().DelBook(id);
                }
                TempData["Msg"] = "Selected Book Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
