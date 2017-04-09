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
        public Dictionary<string, double> constants { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, Product> products { get; set; } = new Dictionary<string, Product>();
    }

    public class Product
    {
        public string name { get; set; }
        public string price { get; set; }
        public int count { get; set; }
    }
}