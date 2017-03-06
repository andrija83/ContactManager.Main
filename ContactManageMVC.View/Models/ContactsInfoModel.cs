using ContactManagerDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManageMVC.View.Models
{
    public class ContactsInfoModel { 
        public Dictionary<ContactType, IEnumerable<ContactsDetailsModel>> ContactsDictionary { get; set; }
        int NumberOfContacts { get; set; }
        DateTime DateLastContactAdded { get; set; }

     
     }
    }
