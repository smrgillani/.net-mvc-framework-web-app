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
    public class contactinfoController : Controller
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
                    List<ContactsInfo> Searched = new Cateloge().SearchContactsInfo(Search_key);

                    if (Searched == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Contact_sInfo_s = new List<ContactInfo>();
                        foreach (var gdfc in Searched)
                        {
                            ContactInfo dbr = new ContactInfo();
                            dbr.Id = gdfc.db_Id;
                            dbr.Title = gdfc.Title;
                            dbr.Contact_Cell = gdfc.Contact_Cell;
                            dbr.Contact_Phone = gdfc.Contact_Phone;
                            dbr.Contact_Email = gdfc.Contact_Email;
                            dbr.Contact_Website = gdfc.Contact_Website;
                            dbr.Contact_Address = gdfc.Contact_Address;
                            dbr.Publish = gdfc.Publish;
                            Data.Contact_sInfo_s.Add(dbr);
                        }
                        Data.Contact_sInfo_s.TrimExcess();
                        return View(Data);
                    }

                }
                else
                {
                    List<ContactsInfo> contactsinfo = new Cateloge().ContactsInfo();

                    if (contactsinfo == null)
                    {
                        ViewBag.StatusMessage = " No Any Data Found ! ";
                    }
                    else
                    {
                        AllClasses Data = new AllClasses();
                        Data.Contact_sInfo_s = new List<ContactInfo>();
                        foreach (var gdfc in contactsinfo)
                        {
                            ContactInfo dbr = new ContactInfo();
                            dbr.Id = gdfc.db_Id;
                            dbr.Title = gdfc.Title;
                            dbr.Contact_Cell = gdfc.Contact_Cell;
                            dbr.Contact_Phone = gdfc.Contact_Phone;
                            dbr.Contact_Email = gdfc.Contact_Email;
                            dbr.Contact_Website = gdfc.Contact_Website;
                            dbr.Contact_Address = gdfc.Contact_Address;
                            dbr.Publish = gdfc.Publish;
                            Data.Contact_sInfo_s.Add(dbr);
                        }
                        Data.Contact_sInfo_s.TrimExcess();
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

                ContactsInfo contactsinfo = new Cateloge().SelectContactInfo(id);

                if (contactsinfo == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    AllClasses Data = new AllClasses();
                    Data.ContactInfo = new ContactInfo
                    {
                        Id = contactsinfo.db_Id,
                        Title = contactsinfo.Title,
                        Contact_Cell = contactsinfo.Contact_Cell,
                        Contact_Phone = contactsinfo.Contact_Phone,
                        Contact_Email = contactsinfo.Contact_Email,
                        Contact_Website = contactsinfo.Contact_Website,
                        Contact_Location = contactsinfo.Contact_Location,
                        Contact_Address = contactsinfo.Contact_Address,
                        Publish = contactsinfo.Publish
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
        public ActionResult Publish(ContactInfo pci, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ContactsInfo PublishContactInfo = new ContactsInfo();
                    PublishContactInfo.Publish = pci.Publish;
                    new Cateloge().PublishContactInfo(PublishContactInfo, id);
                    if (pci.Publish == "2")
                    {
                        TempData["Msg"] = "This Contact Have Published Successfully";

                    }
                    else
                    {
                        TempData["Msg"] = "This Contact Have Blocked Successfully";
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
                    return PartialView("_ContactForm");
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactInfo Add)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ContactsInfo AddContactInfo = new ContactsInfo();
                    AddContactInfo.Title = Add.Title;
                    AddContactInfo.Contact_Cell = Add.Contact_Cell;
                    AddContactInfo.Contact_Phone = Add.Contact_Phone;
                    AddContactInfo.Contact_Email = Add.Contact_Email;
                    AddContactInfo.Contact_Website = Add.Contact_Website;
                    AddContactInfo.Contact_Location = Add.Contact_Location;
                    AddContactInfo.Contact_Address = Add.Contact_Address;
                    AddContactInfo.Date = DateTime.Today.ToString("dd-MM-yyyy");
                    AddContactInfo.Month = DateTime.Today.ToString("MMM");
                    AddContactInfo.Year = DateTime.Today.ToString("yyyy");
                    AddContactInfo.Time = DateTime.Now.ToString("HH:mm:ss");
                    new Cateloge().AddContactInfo(AddContactInfo);
                    TempData["Msg"] = "New Contact Info Have Added Successfully";
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

                ContactsInfo contactsinfo = new Cateloge().SelectContactInfo(id);

                if (contactsinfo == null)
                {
                    ViewBag.StatusMessage = " No Any Result Founded ! ";
                }
                else
                {
                    ContactInfo Formelements = new ContactInfo
                    {
                        Title = contactsinfo.Title,
                        Contact_Cell = contactsinfo.Contact_Cell,
                        Contact_Phone = contactsinfo.Contact_Phone,
                        Contact_Email = contactsinfo.Contact_Email,
                        Contact_Website = contactsinfo.Contact_Website,
                        Contact_Location = contactsinfo.Contact_Location,
                        Contact_Address = contactsinfo.Contact_Address
                    };
                    return PartialView("_ContactForm", Formelements);
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ContactInfo Update, int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ContactsInfo UpdateContactInfo = new ContactsInfo();
                    UpdateContactInfo.Title = Update.Title;
                    UpdateContactInfo.Contact_Cell = Update.Contact_Cell;
                    UpdateContactInfo.Contact_Phone = Update.Contact_Phone;
                    UpdateContactInfo.Contact_Email = Update.Contact_Email;
                    UpdateContactInfo.Contact_Website = Update.Contact_Website;
                    UpdateContactInfo.Contact_Location = Update.Contact_Location;
                    UpdateContactInfo.Contact_Address = Update.Contact_Address;
                    new Cateloge().UpdateContactInfo(UpdateContactInfo, id);
                    TempData["Msg"] = "Contact Have Updated Successfully";
                    return RedirectToAction("Index");
                }
                return View(Update);
            }
        }

        [HttpGet]
        public ActionResult DelContactInfo(int id)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }
            else
            {

                new Cateloge().DelContactInfo(id);
                TempData["Msg"] = "Selected Contact Info Have Deleted Successfully";
                return RedirectToAction("Index");
            }
        }

    }
}
