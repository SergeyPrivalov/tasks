using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsonConversion
{
    public class JsonV2
    {
        public string version { get; set; } = "2";
       public Dictionary<string, Product>  products { get; set; }
    }

    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
}
