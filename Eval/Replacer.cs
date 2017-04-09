using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EvalTask
{
    public class Replacer
    {
        public static List<Token> Replace(Dictionary<string, double> constants, List<Token> tokens)
        {

            var res = new List<Token>();

            foreach (var token in tokens)
                if (token.Type == TokenType.Constant && constants.ContainsKey(token.Value))
                    res.Add(new Token(TokenType.Number, constants[token.Value].ToString(CultureInfo.InvariantCulture)));
                else
                    res.Add(token);

            return res;
        }
    }
}
