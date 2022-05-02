using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvContact.Models;
using CsvContact.Persitence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsvContact.Pages
{
    public class ContactListModel : PageModel
    {

        private readonly AppDbContext _appDbContext;

        public ContactListModel(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void OnGet()
        {
            LoadData();
        }

        [BindProperty]
        public List<CsvFile> csvFile { get; set; }


        public void LoadData()
        {
            csvFile = _appDbContext.CsvFile.Where(itm => itm.User == User.Identity.Name).ToList();

            var mix = (from x in _appDbContext.CsvFile
                       join u in _appDbContext.Concatc on x.IdFile equals u.IdFile
                       where x.User == User.Identity.Name
                       select new { x.IdFile, x.Status, x.User, x.AmmountProcess, u.Name, u.Address, u.CreditCard, u.Email }
                       ).ToList();
        }
    }
}
