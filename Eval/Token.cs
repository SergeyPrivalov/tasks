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
            return new Token() { Type = TokenType.Number, Value = value.ToString() };
        }

        public Token()
        {
        }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

}
