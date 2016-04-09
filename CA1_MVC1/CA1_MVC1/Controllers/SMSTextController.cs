using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CA1_MVC1.Models;
using System.Diagnostics;

namespace CA1_MVC1.Controllers
{
    public class SMSTextController : Controller
    {
        
        private ContactListDb db = new ContactListDb();
         public ActionResult Index(int? id)
         {
            //for app.log save to file;
            //
            //Debug.Listeners.Clear();
            //Debug.AutoFlush = true;
            //Debug.Listeners.Add(new TextWriterTraceListener("d:\\app.log"));

             if (id == null) return View();
             ContactList smsText = db.Contacts.Find(id);
             SMSText smSText = new SMSText
             {
                 AreaCodeSmS = smsText.AreaCode,
                 PhoneNumberSmS = smsText.PhoneNumber
             };
             return View(smSText);
         }
            
        //keep for other use
        // AreaCode PhoneNumber passed without db connection
        /**
        public ActionResult Index(string areaCodeSmS, string phoneNumberSmS )
        {
            
            SMSText smsText = new SMSText
            {
                AreaCodeSmS = areaCodeSmS,
                PhoneNumberSmS = phoneNumberSmS
            };
            return View(smsText);
        }*/
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "AreaCodeSmS,PhoneNumberSmS,TextContentSmS")] SMSText smsText)
        {
            if (ModelState.IsValid)
            {
                if (db.Contacts.Count(n=>n.AreaCode.Equals(smsText.AreaCodeSmS)&&n.PhoneNumber.Equals(smsText.PhoneNumberSmS))==0)
                {
                    Debug.WriteLine("Message send failed :"+DateTime.Now.ToString() + ":" + smsText.AreaCodeSmS + "-" + smsText.PhoneNumberSmS + "," + smsText.TextContentSmS);
                    return RedirectToAction("NotFound", smsText);
                }

            }
            Debug.WriteLine("Message send succeed :" + DateTime.Now.ToString() + ":" + smsText.AreaCodeSmS + "-" + smsText.PhoneNumberSmS + "," + smsText.TextContentSmS);
            return RedirectToAction("Confirmed", smsText);
        }

        public ActionResult Confirmed(SMSText smsText)
        {
            return View(smsText);
        }

        public ActionResult NotFound(SMSText smsText)
        {
            return View(smsText);
        }


        
        public ActionResult About()
        {
            ViewBag.Message = "Description page.";

            return View();
        }

    }
}