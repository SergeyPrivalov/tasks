using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EvalTask
{
    [TestFixture]
    public class Calculator_Should
    {
        private Calculator calc;
        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }

        [Test]
        public void SumsTwoIntValues()
        {
            List<Token> input = new List<Token>{
                new Token(TokenType.Number, "1"),
                new Token(TokenType.Operation, "+"),
                new Token(TokenType.Number, "2"),
            };

            var res = calc.Calculate(input);

            Assert.AreEqual(3,res);
        }

        [Test]
        public void DividesTwoIntValues()
        {
            List<Token> input = new List<Token>{
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operation, "/"),
                new Token(TokenType.Number, "2"),
            };
            
            var res = calc.Calculate(input);

            Assert.AreEqual(2,res);
        }

        [Test]
        public void MulipliesTwoIntValues()
        {
            List<Token> input = new List<Token>{
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operation, "*"),
                new Token(TokenType.Number, "2"),
            };
            
            var res = calc.Calculate(input);

            Assert.AreEqual(8, res);
        }

        [Test]
        public void SubstractsTwoIntValues()
        {
            List<Token> input = new List<Token>{
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Operation, "-"),
                new Token(TokenType.Number, "2"),
            };
            var res = calc.Calculate(input);

            Assert.AreEqual(2, res);
        }

        [Test]
        public void ReturnsNumberItself_OnOneItemInput()
        {
            var input = new List<Token> { new Token(TokenType.Number,"1") };
            var res = calc.Calculate(input);

            Assert.AreEqual(1, res);
        }

        [Test]
        public void ReturnsZero_IfEmptyInput()
        {
            var res = calc.Calculate(new List<Token>());

            Assert.AreEqual(0, res);
        }
        
    }
}
