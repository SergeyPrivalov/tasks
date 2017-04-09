using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JsonConversion
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConvertTest()
        {
            var dictionary = new Dictionary<string, Product>
            {
                {"1", new Product() {count = 1, price = "2", name = "fr"}},
                {"2", new Product() {count = 2, price = "22", name = "frr"}}
            };
            var jsonV2 = new JsonV2()
            {
                products = dictionary
            };
            var actual = Convertor.Convert(jsonV2);
            var jsonV3 = new JsonV3()
            {
                products =
                    new List<Product2>()
                    {
                        new Product2() {id = 1, count = 1, price = 2, name = "fr"},
                        new Product2() {id = 2, count = 2, price = 22, name = "frr"}
                    }
            };
            Assert.AreEqual(JsonConvert.SerializeObject(jsonV3), JsonConvert.SerializeObject(actual));
        }
        [Test]
        public void ConvertWithConstantsTest()
        {
            var dictionary = new Dictionary<string, Product>
            {
                {"1", new Product() {count = 1, price = "2", name = "fr"}},
                {"2", new Product() {count = 2, price = "a+b", name = "frr"}}
            };
            var dict = new Dictionary<string, double>();
            dict.Add("a", 2.2);
            dict.Add("b", 2.5);
            var jsonV2 = new JsonV2()
            {
                products = dictionary,
                constants = dict
            };
            var actual = Convertor.Convert(jsonV2);
            var jsonV3 = new JsonV3()
            {
                products =
                    new List<Product2>()
                    {
                        new Product2() {id = 1, count = 1, price = 2, name = "fr"},
                        new Product2() {id = 2, count = 2, price = 4.7, name = "frr"}
                    }
            };
            Assert.AreEqual(JsonConvert.SerializeObject(jsonV3), JsonConvert.SerializeObject(actual));
        }
    }
}
