using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    public enum TokenType
    {
        Operation,
        Number,
        Constant
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token()
        {
        }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public const string operations = @"+-*/";

        public static List<Token> GetTokensFromString(string input)
        {
            var result = new List<Token>();
            var value = "";
            foreach (var t in input)
            {
                if (!operations.Contains(t.ToString()))
                    value += t;
                else
                {
                    result.Add(char.IsDigit(value[0])
                        ? new Token(TokenType.Number, value)
                        : new Token(TokenType.Constant, value));
                    result.Add(new Token() {Type = TokenType.Operation, Value = t.ToString()});
                    value = "";
                }
            }
            result.Add(char.IsDigit(value[0])
                ? new Token(TokenType.Number, value)
                : new Token(TokenType.Constant, value));

            return result;
        }

    }
}
