using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EvalTask
{
    [TestFixture]
    public class ParserTests_Should
    {
        private Parser parser;
        [SetUp]
        public void SetUp()
        {
            parser = new Parser();
        }


        [Test]
        public void ReturnsSingleNumber_IfSungleNumberInInput()
        {
            string input = "1";
            var expected = new List<string>() {"1"};
            var res = parser.Parse(input);

            CollectionAssert.AreEqual(expected, res);
        }
    }
}
