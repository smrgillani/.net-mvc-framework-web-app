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
    public class yourstorageController : Controller
    {
        //
        // GET: /yourstorage/

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
                    List<StuffsInStorages> Searched = new Cateloge().SearchStuffsInStorages(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Stuff_sInStorage_s = new List<StuffInStorage>();
                        foreach (var gdfc in Searched)
                        {
                            StuffInStorage dbr = new StuffInStorage();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.User_File = gdfc.User_File;
                            string get_File_form = gdfc.User_File;
                            string ext = get_File_form.Substring(get_File_form.LastIndexOf("."));
                            if (ext == ".gif" || ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".Gif" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                            {
                                dbr.File_type = "Image";
                                dbr.File_cls_ico = "img.png";

                            }
                            else if (ext == ".pdf" || ext == ".xls" || ext == ".xlsx" || ext == ".doc" || ext == ".docx" || ext == ".ppt" || ext == ".pptx" || ext == ".PDF" || ext == ".XLS" || ext == ".XLSX" || ext == ".DOC" || ext == ".DOCX" || ext == ".PPT" || ext == ".PPTX")
                            {
                                dbr.File_type = "Document";
                                dbr.File_cls_ico = "doc.png";
                            }
                            else if (ext == ".ZIP" || ext == ".RAR" || ext == ".zip" || ext == ".rar")
                            {
                                dbr.File_type = "Package File";
                                dbr.File_cls_ico = "pckg.png";
                            }
                            else
                            {
                                dbr.File_type = "Unknown";
                                dbr.File_cls_ico = "unkwn.png";
                            }
                            Data.Stuff_sInStorage_s.Add(dbr);
                        }
                        Data.Stuff_sInStorage_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<StuffsInStorages> stuffsinstorage = new Cateloge().StuffsInStorages();

                    if (stuffsinstorage == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Stuff_sInStorage_s = new List<StuffInStorage>();
                        foreach (var gdfc in stuffsinstorage)
                        {
                            StuffInStorage dbr = new StuffInStorage();
                            dbr.Id = gdfc.db_Id;
                            dbr.Name = gdfc.Name;
                            dbr.User_File = gdfc.User_File;
                            string get_File_form = gdfc.User_File;
                            string ext = get_File_form.Substring(get_File_form.LastIndexOf("."));
                            if (ext == ".gif" || ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".Gif" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                            {
                                dbr.File_type = "Image";
                                dbr.File_cls_ico = "img.png";

                            }
                            else if (ext == ".pdf" || ext == ".xls" || ext == ".xlsx" || ext == ".doc" || ext == ".docx" || ext == ".ppt" || ext == ".pptx" || ext == ".PDF" || ext == ".XLS" || ext == ".XLSX" || ext == ".DOC" || ext == ".DOCX" || ext == ".PPT" || ext == ".PPTX")
                            {
                                dbr.File_type = "Document";
                                dbr.File_cls_ico = "doc.png";
                            }
                            else if (ext == ".ZIP" || ext == ".RAR" || ext == ".zip" || ext == ".rar")
                            {
                                dbr.File_type = "Package File";
                                dbr.File_cls_ico = "pckg.png";
                            }
                            else
                            {
                                dbr.File_type = "Unknown";
                                dbr.File_cls_ico = "unkwn.png";
                            }
                            Data.Stuff_sInStorage_s.Add(dbr);
                        }
                        Data.Stuff_sInStorage_s.TrimExcess();
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

        public ActionResult AddNewFile()
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_AddNewFile");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewFile(StuffInStorage Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    StuffsInStorages AddStuffInStorage = new StuffsInStorages();
                    AddStuffInStorage.Name = Add.Name;
                    HttpPostedFileBase File = Request.Files["User_File"];
                    if (File.ContentLength > 0)
                    {
                        string ext = File.FileName.Substring(File.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/p_storage/" + imgName;
                        File.SaveAs(Request.MapPath(webpath));
                        AddStuffInStorage.User_File = imgName;
                    }
                    AddStuffInStorage.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddStuffInStorage.Month = DateTime.Today.ToString("MMM");
                    AddStuffInStorage.Year = DateTime.Today.ToString("yyyy");
                    AddStuffInStorage.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddStuffInStorage(AddStuffInStorage);
                    TempData["Msg"] = "New Item Have Added Successfully";
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

                StuffsInStorages stuffsinstorage = new Cateloge().SelectStuffInStorage(id);

                if (stuffsinstorage == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    StuffInStorage Formelements = new StuffInStorage
                    {
                        Name = stuffsinstorage.Name
                    };
                    return PartialView("_EditFile", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StuffInStorage Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    StuffsInStorages UpdateStuffInStorage = new StuffsInStorages();
                    UpdateStuffInStorage.Name = Update.Name;
                    HttpPostedFileBase File = Request.Files["User_File"];
                    if (File.ContentLength > 0)
                    {
                        string ext = File.FileName.Substring(File.FileName.LastIndexOf("."));
                        string imgName = DateTime.Now.Ticks + ext;
                        string webpath = "~/p_storage/" + imgName;
                        File.SaveAs(Request.MapPath(webpath));
                        UpdateStuffInStorage.User_File = imgName;
                        new Cateloge().UpdateStuffInStorage_file(UpdateStuffInStorage, id);
                    }
                    else
                    {
                        new Cateloge().UpdateStuffInStorage(UpdateStuffInStorage, id);
                    }
                    TempData["Msg"] = "Item Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }
    }
}
