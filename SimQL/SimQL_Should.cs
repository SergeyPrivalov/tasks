﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace SimQLTask
{
    [TestFixture]
    class SimQL_Should
    {
        private SimQLProgram simQl;
        [SetUp]
        public void SetUp()
        {
            simQl = new SimQLProgram();
        }

        [Test]
        public void ReturnData()
        {
            var str = "{'data':{'a':4}," +
                      "'queries':['a']}";

            var result = SimQLProgram.ExecuteQueries(str);

            Assert.AreEqual("a = 4", result.Single());
        }

        [Test]
        public void ReturnData_WhenCompositePath()
        {
            var str = "{'data': {'a': {'x': 3.14}}," +
                      "'queries':['a.x']}";

            var result = SimQLProgram.ExecuteQueries(str);

            Assert.AreEqual("a.x = 3.14", result.Single());
        }

        [Test]
        public void ReturnMultiData()
        {
            var str = "{'data': {'a': 2," +
                      "'x': 3.14}," +
                      "'queries':['a', 'x']}";

            var result = SimQLProgram.ExecuteQueries(str);

            Assert.AreEqual(new [] { "a = 2","x = 3.14"}, result.ToArray());
        }

        [Test]
        public void FaildTest()
        {
            var str = "{\"data\":{\"empty\":{},\"ab\":0,\"x1\":1,\"x2\":2,\"y1\":{\"y2\":{\"y3\":3}}}," +
                      "\"queries\":[\"empty\",\"xyz\",\"x1.x2\",\"y1.y2.z\",\"empty.foobar\"]}";

            var result = SimQLProgram.ExecuteQueries(str);

            Assert.AreEqual(5, result.Count());
        }
    }
}