using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EvalTask
{
    public class Replacer
    {
        public static List<Token> Replace(Dictionary<string, string> constants, List<Token> tokens)
        {
            var res = new List<Token>();

            foreach (var token in tokens)
                if (token.Type == TokenType.Constant && constants.ContainsKey(token.Value))
                    res.Add(new Token(TokenType.Number, constants[token.Value]));
                else
                    res.Add(token);

            return res;
        }
    }
}
