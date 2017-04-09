using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    public class Calculator
    {
        private HighPriorityCalculator highPriorityCalculator;
        private LowPriorityCalculator lowPriorityCalculator;

        public Calculator()
        {
            highPriorityCalculator = new HighPriorityCalculator();
            lowPriorityCalculator = new LowPriorityCalculator();
        }

        public double Calculate(List<Token> tokens)
        {
            if (tokens.Count == 0)
                return 0 ;

            int bracketCounter = 0;
            List<Token> inbracketValues = new List<Token>();
            List<Token> nonBracketValue = new List<Token>();
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == TokenType.OpenBracket)
                {
                    bracketCounter++;
                    continue;
                }
                if (tokens[i].Type == TokenType.CloseBracket)
                    bracketCounter--;
                if (bracketCounter == 0 && inbracketValues.Count != 0)
                {
                    nonBracketValue.Add(new Token(TokenType.Number, Calculate(inbracketValues).ToString()));
                    continue;
                }

                if (bracketCounter > 0)
                {
                    inbracketValues.Add(tokens[i]);
                }
                else
                {
                    nonBracketValue.Add(tokens[i]);
                }
            }
            var withoutHighPriority = highPriorityCalculator.Calculate(nonBracketValue);
            return lowPriorityCalculator.Calculate(withoutHighPriority);
        }
     
        
    }
    class HighPriorityCalculator
    {
        private List<IOperation> operations = new List<IOperation>()
        {
            new Devider(),
            new Multiplier()
        };
        public List<Token> Calculate(List<Token> tokens)
        {
            var result = new List<Token>();
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == TokenType.Operation)
                {
                    var index = operations.FindIndex(op => op.Value == tokens[i].Value);
                    if (index != -1)
                    {
                        result[result.Count-1] = operations[index].Calculate(result[result.Count - 1], tokens[i + 1]);
                        i++;
                        continue;
                    }
                }
                result.Add(tokens[i]);
            }
            return result;
        }
    }


    class LowPriorityCalculator
    {

        private List<IOperation> operations = new List<IOperation>()
        {
            new Substractor(),
            new Summator()
        };

        public double Calculate(List<Token> tokens)
        {
            double result = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == TokenType.Operation)
                {
                    var index = operations.FindIndex(op => op.Value == tokens[i].Value);
                    if (index != -1)
                    {
                        result = Double.Parse(operations[index].Calculate(Token.GetNumberToken(result), tokens[i + 1]).Value, CultureInfo.InvariantCulture);
                        i++;
                    }
                    else
                        result += Double.Parse(tokens[i].Value, CultureInfo.InvariantCulture);
                }
                else
                {
                    result += Double.Parse(tokens[i].Value, CultureInfo.InvariantCulture);
                }
            }
            return result;
        }
    }

    interface IOperation
    {
        string Value { get; }
        Token Calculate(Token first, Token second);
    }
    public class Devider : IOperation
    {
        public string Value => @"/";
        public Token Calculate(Token first, Token second)
        {
            var firstNum = Double.Parse(first.Value, CultureInfo.InvariantCulture);
            var secondNum = Double.Parse(second.Value, CultureInfo.InvariantCulture);
            var result = firstNum / secondNum;
            return Token.GetNumberToken(result);
        }
    }

    public class Multiplier : IOperation
    {
        public string Value => @"*";
        public Token Calculate(Token first, Token second)
        {
            var firstNum = Double.Parse(first.Value, CultureInfo.InvariantCulture);
            var secondNum = Double.Parse(second.Value, CultureInfo.InvariantCulture);
            var result = firstNum * secondNum;
            return Token.GetNumberToken(result);
        }
    }

    public class Summator : IOperation
    {
        public string Value => @"+";
        public Token Calculate(Token first, Token second)
        {
            var firstNum = Double.Parse(first.Value, CultureInfo.InvariantCulture);
            var secondNum = Double.Parse(second.Value, CultureInfo.InvariantCulture);
            var result = firstNum + secondNum;
            return Token.GetNumberToken(result);
        }
    }

    public class Substractor : IOperation
    {
        public string Value => @"-";
        public Token Calculate(Token first, Token second)
        {
            var firstNum = Double.Parse(first.Value, CultureInfo.InvariantCulture);
            var secondNum = Double.Parse(second.Value, CultureInfo.InvariantCulture);
            var result = firstNum - secondNum;
            return Token.GetNumberToken(result);
        }
    }
}

