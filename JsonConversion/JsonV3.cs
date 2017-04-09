using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConversion
{
    public class JsonV3
    {
        public string version { get; set; } = "3";
        public List< Product2> products { get; set; }= new List<Product2>();
    }

    public class Product2
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
}
