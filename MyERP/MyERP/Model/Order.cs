using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Order
    {
        public string NameOrder { get; set; }
        public string NameOfCustomer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public double Completion { get; set; }
    }
}
