using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalTask;
namespace JsonConversion
{
    public  class Convertor
    {
        public static JsonV3 Convert(JsonV2 jsonV2)
        {
            var res = new JsonV3 ();
            foreach (var product in jsonV2.products)
            {
                res.products.Add(new Product2()
                {
                   id=int.Parse(product.Key),
                   count = product.Value.count,
                   name = product.Value.name,
                   price = GetPrice(product.Value.price, jsonV2.constants )
                });
            }
            return res;
        }

        private static double GetPrice(string price, Dictionary<string, double> constants)
        {

            var tokens =  Replacer.Replace(constants, Token.GetTokensFromString(price));
            return new Calculator().Calculate(tokens);
        }
    }
}
