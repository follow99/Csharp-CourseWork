using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA1_MVC1.Models;

namespace CA1_MVC1.Controllers
{
    public class ContactListController : Controller
    {
        private ContactListDb db = new ContactListDb();
        // GET: ContactList
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }


    }
}