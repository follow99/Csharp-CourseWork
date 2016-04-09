using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA1_MVC1.Models
{
    public class ContactList
    {
        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }

    }

    public class ContactListDb : DbContext
    {
        /**
        public ContactListDb() : base("DefaultConnection", false)
    {
            // This is mandatory to run the db related test

            Database.SetInitializer<CA1_MVC1.Models.ContactListDb>(null);
        }*/
        public DbSet<ContactList> Contacts { get; set; }
    }

}