using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvContact.Models.Enums;

namespace CsvContact.Models
{
    [Table("CsvFiles", Schema = "dbo")]
    public class CsvFile
    {
        [Column("IDFile")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdFile { get; set; }

        [Column("FilePath")]
        [StringLength(150)]
        [Required]
        public string FilePath { get; set; }

        public string Relation { get; set; }

        public int AmmountProcess { get; set; }

        [Required]
        public CsvStatus Status { get; set; }

        [Column("User")]
        [StringLength(100)]
        [Required]
        public string User { get; set; }

        public ICollection<Contact> ContactModels { get; set; }

        public ICollection<LogError> LogErrorModels { get; set; }
    }
}
