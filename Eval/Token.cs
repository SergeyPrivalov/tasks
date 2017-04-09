using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    public enum TokenType
    {
        Operation,
        Number,
        Constant,
        OpenBracket,
        CloseBracket
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }


        public static Token GetNumberToken(double value)
        {
            return new Token() { Type = TokenType.Number, Value = value.ToString(CultureInfo.InvariantCulture) };
        }

        public Token()
        {
        }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public const string Operations = @"+-*/";
        public const string Brackets = @"()";

        public static List<Token> GetTokensFromString(string input)
        {
            input = input.Replace(',', '.');
            var result = new List<Token>();
            var value = "";
            foreach (var t in input)
            {
                if (!Operations.Contains(t.ToString()) && !Brackets.Contains(t.ToString()))
                    value += t;
                else
                {
                    if (value != "")
                        result.Add(char.IsDigit(value[0])
                        ? new Token(TokenType.Number, value)
                        : new Token(TokenType.Constant, value));
                    switch (t)
                    {
                        case '(':
                            result.Add(new Token() {Type = TokenType.OpenBracket, Value = t.ToString()});
                            break;
                        case ')':
                            result.Add(new Token() {Type = TokenType.CloseBracket, Value = t.ToString()});
                            break;
                        default:
                            result.Add(new Token() {Type = TokenType.Operation, Value = t.ToString()});
                            break;
                    }
                    value = "";
                }
            }
            if (value!="")
            result.Add(char.IsDigit(value[0])
                ? new Token(TokenType.Number, value)
                : new Token(TokenType.Constant, value));

            return result;
        }
        
    }

}
