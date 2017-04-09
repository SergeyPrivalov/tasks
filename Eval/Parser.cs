using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    interface iCalculator
    {
        List<string> Parse(List<string> input);
    }

    partial class Parser : iCalculator
    {

        public List<string> Parse(List<string> input)
        {
            int inclosure = 0;
            
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "(")
                {
                    inclosure++;
                }

            }
            return null;
        }
    }

    
}
