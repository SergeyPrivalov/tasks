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
    public class ReplaceTests
    {

    /*    [Test]
        public void TestReplace()
        {
            var tokens = new List<Token>();
            tokens.Add(new Token(TokenType.Constant, "a"));
            tokens.Add(new Token(TokenType.Operation, "+"));
            tokens.Add(new Token(TokenType.Constant, "b"));
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("a", "2");
            dictionary.Add("b", "22");
            var actual = new List<Token>();
            actual.Add(new Token(TokenType.Number, "2"));
            actual.Add(new Token(TokenType.Operation, "+"));
            actual.Add(new Token(TokenType.Number, "22"));
            Assert.AreEqual(JsonConvert.SerializeObject(actual),
                JsonConvert.SerializeObject(Replacer.Replace(dictionary, tokens)))
            ;
        }*/

    }
}
