using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_S19.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [MaxLength(50)]
        public string Symbol { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public string IexId { get; set; }
    }
}
