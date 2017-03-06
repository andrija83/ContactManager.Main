using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Util;
using ContactManageMVC.View.Models;
using ContactManagerDB.Entity;

namespace ContactManageMVC.View.Controllers
{
    public class HomeController : Controller
    {
        //Konekcija za bazon preko Entity framework
        private readonly ContactManagerDBEntities db = new ContactManagerDBEntities();

        public ActionResult Index()
        {

            var listaContacts = db.Contacts.Select(x => new ContactsDetailsModel
            {
                ContactID = x.ContactID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                InsertDate = x.InsertDate,
                caption = x.ContactType.Caption,
                

            }).ToList();


            return View(listaContacts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //var contactCaption = new SelectList(db.ContactTypes,"ContactTypeId","Caption");
            //ViewBag.contacts = new SelectList(db.ContactTypes, "ContactTypeID","Caption");
            ViewBag.ContactTypeID =new SelectList(db.ContactTypes, "ContactTypeID","Caption");

            return View();
        }

        //da posalje napravljen model *POST*
        [HttpPost]
        public ActionResult Create(ContactsDetailsModel contact)
        {
            if (ModelState.IsValid)
            {
                var contactType = db.ContactTypes.Where(x => x.Caption.Equals(contact.caption)).FirstOrDefault();
                var work = db.Works.Where(x => x.BussinessSkype.Equals(contact.BussinessSkype)).FirstOrDefault();
                              
                db.Contacts.Add(new Contact
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Address = contact.Address,
                    InsertDate = contact.InsertDate,
                    ContactType = contactType
                    
                });

                db.SaveChanges();
                return RedirectToAction("Index");
                //redirect
            }
            return View(contact);
        }


        //EDIT *GET*
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var vid = db.Contacts.Where(v => v.ContactID == id).SingleOrDefault();
            var kontakt = new ContactsDetailsModel();
            

            if (vid != null)
            {
                kontakt.ContactID = vid.ContactID;
                kontakt.FirstName = vid.FirstName;
                kontakt.LastName = vid.LastName;
                kontakt.Address = vid.Address;
                kontakt.InsertDate = vid.InsertDate;
                kontakt.caption = vid.ContactType.Caption;
            }

           
            return View(kontakt);
        }

        //EDIT *POST*
        [HttpPost]
        public ActionResult Edit(int? id, ContactsDetailsModel contact)
        {
            try
            {
                var contactType = db.ContactTypes.Where(x => x.Caption.Equals(contact.caption)).FirstOrDefault();
                var kontakt = db.Contacts.Where(v => v.ContactID == id).SingleOrDefault();
               
                if (kontakt != null)
                {
                    //contactDetaild.ContactID = kontakt.ContactID;
                    kontakt.FirstName = contact.FirstName;
                    kontakt.LastName = contact.LastName;
                    kontakt.Address = contact.Address;
                    kontakt.InsertDate = contact.InsertDate;
                    kontakt.ContactType = contactType;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int id)
        {
            
            var contactDetails = db.Contacts.FirstOrDefault(x => x.ContactID == id);
            var model = new ContactsDetailsModel();
            if (contactDetails != null)
            {
                model.ContactID = contactDetails.ContactID;
                model.FirstName = contactDetails.FirstName;
                model.LastName = contactDetails.LastName;
                model.Address = contactDetails.Address;
                model.InsertDate = contactDetails.InsertDate;
                model.caption = contactDetails.ContactType.Caption;
            }
            return View(model);
        }


        public ActionResult Delete(int? id)
        {
            var contactDetails = db.Contacts.FirstOrDefault(x => x.ContactID == id);
            var model = new ContactsDetailsModel();
            if (contactDetails != null)
            {
                model.ContactID = contactDetails.ContactID;
                model.FirstName = contactDetails.FirstName;
                model.LastName = contactDetails.LastName;
                model.Address = contactDetails.Address;
                model.InsertDate = contactDetails.InsertDate;
                model.caption = contactDetails.ContactType.Caption;
            }
            return View(model);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Test()
        {

            var dictionary = new Dictionary<ContactType, IEnumerable<ContactsDetailsModel>>();
            ContactsInfoModel model = new ContactsInfoModel
            {
                ContactsDictionary = dictionary
                
            };
            foreach (var x in dictionary)
            {
                dictionary.Add();
            }
                    
           
            ViewBag.Message = "Test";

            return View(model);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

    }
}