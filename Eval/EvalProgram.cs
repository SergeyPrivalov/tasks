using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
			string input = Console.In.ReadToEnd();
            var parser = new Parser();
		    var numbersWithOperations = parser.Parse(input);
            
            var calculator = new Calculator();
			Console.WriteLine(calculator.Calculate(numbersWithOperations));
		}

	}

    class  Parser
    {
        private string operations = @"+-*/";

        public List<string> Parse(string input)
        {
            List<string> result = new List<string>();;
            string number = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (!operations.Contains(input[i].ToString()))
                    number += input[i];
                else
                {
                    result.Add(number);
                    result.Add(input[i].ToString());
                    number = "";
                }
            }
            result.Add(number);
            return result;
        }
    }

    class  Calculator
    {
        private List<IIOperation> operations = new List<IIOperation>()
        {
            new Sum(),
            new Substract(),
            new Divide(),
            new Multiply()
        }; 

        public double Calculate(List<string> input)
        {
            if (input.Count == 0)
                return 0;
            if (input.Count == 1)
                return Double.Parse(input[0]);
            var operation = operations.Where(o => o.Sign == input[1]).FirstOrDefault();
            return operation.Calculate(int.Parse(input[0]), int.Parse(input[2]));
        }
    }

    interface IIOperation
    {
        string Sign { get; }
        double Calculate(double first, double second);
    }

    class Sum : IIOperation
    {
        public double Calculate(double first, double second)
        {
            return first + second;
        }

        public string Sign => "+";
    }
    class Multiply : IIOperation
    {
        public double Calculate(double first, double second)
        {
            return first * second;
        }

        public string Sign => "*";
    }

    class Divide : IIOperation
    {
        public double Calculate(double first, double second)
        {
            return first / second;
        }

        public string Sign => "/";
    }

    class Substract : IIOperation
    {
        public double Calculate(double first, double second)
        {
            return first - second;
        }

        public string Sign => "-";
    }
}
