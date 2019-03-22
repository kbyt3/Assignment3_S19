using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_S19.Models
{
    public class DashboardViewModel
    {
        public ApplicationUser User { get; set; }
        public Dictionary<string, IEXApiResponse> StockData { get; set; }
    }
}
