using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CsvContact.Models
{
    public class Contact
    {
        [Column("IdContact")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdContact { get; set; }

        [Column("Name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string DateBirht { get; set; }

        [Required]
        public string Phone { get; set; }

        [Column("Address")]
        [StringLength(500)]
        [Required]
        public string Address { get; set; }

        [Required]
        public string CreditCard { get; set; }

        public string Franchise { get; set; }

        [Column("Email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public long IdFile { get; set; }

        public CsvFile CsvFileModel { get; set; }
    }
}
