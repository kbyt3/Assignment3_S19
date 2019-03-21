using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_S19.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        [MaxLength(50)]
        public string Symbol { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public int IexId { get; set; }
    }
}
