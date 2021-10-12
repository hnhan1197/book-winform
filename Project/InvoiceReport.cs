using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class InvoiceReport
    {
        public int InvoiceNo { get; set; }
        public DateTime DateCheckOut { get; set; }
        public string EmployeeName { get; set; }
        public string BookID { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
