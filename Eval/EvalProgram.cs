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
            var actual = Token.GetTokensFromString(input);
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Calculate(actual));
        }

    }
}
