using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CsvContact.Models
{
    public class FileUploadProperties
    {
        //[BindProperty(Name = "csvFile")]
        public IFormFile csvFile { get; set; }

        //[BindProperty(Name = "NamePosition")]
        public int NamePosition { get; set; }

        //[BindProperty(Name = "DateBirth")]
        public int DateBirth { get; set; }

        //[BindProperty(Name = "Address")]
        public int Address { get; set; }

        //[BindProperty(Name = "Phone")]
        public int Phone { get; set; }

        //[BindProperty(Name = "CreditCard")]
        public int CreditCard { get; set; }

        //[BindProperty(Name = "Franchise")]
        public int Franchise { get; set; }

        //[BindProperty(Name = "Email")]
        public int Email { get; set; }
    }
}