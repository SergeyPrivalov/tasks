using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        [Test]
        public void TestParse()
        {
            var input = "2+3";
            var actual = Token.GetTokensFromString(input);
            var tokens = new List<Token>();
            tokens.Add(new Token(TokenType.Number, "2"));
            tokens.Add(new Token(TokenType.Operation, "+"));
            tokens.Add(new Token(TokenType.Number, "3"));
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
        }

        [Test]
        public void TestParse1()
        {
            var input = "abc*a";
            var actual = Token.GetTokensFromString(input);
            var tokens = new List<Token>();
            tokens.Add(new Token(TokenType.Constant, "abc"));
            tokens.Add(new Token(TokenType.Operation, "*"));
            tokens.Add(new Token(TokenType.Constant, "a"));
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
        }

             [Test]
             public void ParseWithBrackets()
             {
                 var input = "(2+3)";
                 var actual = Token.GetTokensFromString(input);
                 var tokens = new List<Token>();
                 tokens.Add(new Token(TokenType.OpenBracket, "("));
                 tokens.Add(new Token(TokenType.Number, "2"));
                 tokens.Add(new Token(TokenType.Operation, "+"));
                 tokens.Add(new Token(TokenType.Number, "3"));
                 tokens.Add(new Token(TokenType.CloseBracket, ")"));
                 Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
             }

             [Test]
             public void ParseWithConstant()
             {
                 var input = "a+3";
                 var actual = Token.GetTokensFromString(input);
                 var tokens = new List<Token>();
                 tokens.Add(new Token(TokenType.Constant, "a"));
                 tokens.Add(new Token(TokenType.Operation, "+"));
                 tokens.Add(new Token(TokenType.Number, "3"));
                 Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
             }

        [Test]
        public void floatNumber()
        {
            var input = "a+3.4";
            var actual = Token.GetTokensFromString(input);
            var tokens = new List<Token>();
            tokens.Add(new Token(TokenType.Constant, "a"));
            tokens.Add(new Token(TokenType.Operation, "+"));
            tokens.Add(new Token(TokenType.Number, "3.4"));
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
        }

        [Test]
        public void NegativeNumber()
        {
            var input = "-3+3.4";
            var actual = Token.GetTokensFromString(input);
            var tokens = new List<Token>();
            tokens.Add(new Token(TokenType.Operation, "-"));
            tokens.Add(new Token(TokenType.Number, "3"));
            tokens.Add(new Token(TokenType.Operation, "+"));
            tokens.Add(new Token(TokenType.Number, "3.4"));
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(tokens));
        }
    }
}
