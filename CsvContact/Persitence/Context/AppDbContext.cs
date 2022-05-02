using CsvContact.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsvContact.Persitence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public AppDbContext(): base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors();
        }

        public DbSet<CsvFile> CsvFile { get; set; }
        public DbSet<Contact> Concatc { get; set; }
        public DbSet<LogError> LogError { get; set; }
    }

}
