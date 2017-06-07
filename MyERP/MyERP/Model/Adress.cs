using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Adress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }

        public override string ToString()
        {
            return String.Format("г.{0} ул.{1} д.{2}", City, Street, HomeNumber);
        }
    }
}
