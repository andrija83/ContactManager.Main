using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagerDB.Entity;

namespace ContactManageMVC.View.Models
{
    public class ContactsDetailsModel
    {
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InsertDate { get; set; }      
        public string caption { get; set; }


        public string BussinessSkype { get; set; }
        public string EmailType { get; set; }
        public string WebSite { get; set; }



       
       
    }


    public enum CaptionTypeEnum : int
    {
        Family = 1,
        Friends = 2,
        Work = 3
    }
}