using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsvContact.Models
{
    public class LogError
    {
        [Column("IdError")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long IdError { get; set; }

        [Column("Field")]
        [StringLength(50)]
        [Required]
        public string Field { get; set; }

        [Column("Error")]
        [StringLength(200)]
        [Required]
        public string Error { get; set; }

        [Required]
        public long IdFile { get; set; }

        public CsvFile CsvFileModel { get; set; }
    }
}
