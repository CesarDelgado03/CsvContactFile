using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvContact.Helpers;
using CsvContact.Models;
using CsvContact.Persitence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CsvContact.Pages
{
    public class FileUploadModel : PageModel
    {
        [BindProperty]
        public FileUploadProperties fileUploadProperties { get; set; }
        private readonly AppDbContext _appDbContext;

        public FileUploadModel(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //var t = _appDbContext.CsvFile.Where(itm => itm.User == User.Identity.Name).ToList();
            FileHelper helper = new FileHelper();

            string ColumnsPositions = string.Empty;
            ColumnsPositions = $@"{fileUploadProperties.NamePosition}|{fileUploadProperties.DateBirth}|{fileUploadProperties.Address}|
                                        {fileUploadProperties.Phone}|{fileUploadProperties.CreditCard}|{fileUploadProperties.Franchise}|
                                        {fileUploadProperties.Email}";

            var filesFolder = $@"{Directory.GetCurrentDirectory()}\files";
            var tempFile = Path.GetTempFileName();


            var fileStream = new FileStream(path: tempFile, FileMode.OpenOrCreate);
            fileUploadProperties.csvFile.CopyTo(fileStream);
            fileStream.Close();
            fileStream.Dispose();

            if (!Directory.Exists(filesFolder))
            {
                Directory.CreateDirectory(filesFolder);
            }

            var dtNow = DateTime.Now.ToString().Replace(" ", "").Replace("/", "_").Replace(":", "_");
            var filePath = $@"{filesFolder}\{fileUploadProperties.csvFile.FileName}_{dtNow}.csv";
            System.IO.File.Move(tempFile, filePath, true);

            var dt = helper.GetDAtaFromCsv(filePath, ColumnsPositions);
            var NewFilePath = helper.DataToCsv(dt, filesFolder);

            _appDbContext.CsvFile.Add(new CsvFile
            {
                FilePath = NewFilePath,
                Status = Models.Enums.CsvStatus.OnHold,
                User = User.Identity.Name,
                Relation = ColumnsPositions
            });

            //var result = _appDbContext.SaveChanges();


        }

        
    }
}
