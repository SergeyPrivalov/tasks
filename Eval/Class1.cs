using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    interface IExpression
    {
        bool IsExpression(string );
    }
    class Number : IExpression
    {

    }

    class Sign : IExpression
    {

    }

    class Bracket : IExpression
    {

    }


}
