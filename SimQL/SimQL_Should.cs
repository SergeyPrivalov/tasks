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

            var result = SimQLProgram.ExecuteQueries(str).ToArray();

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(new [] {"empty", "xyz", "x1.x2", "y1.y2.z", "empty.foobar" }, result);
        }

        [Test]
        public void ReturnValues_WhenGetArrays()
        {
            var str = "{'data': { 'a':{ 'x':3.14, 'b':[{'c':15}, {'c':9}]}, 'z':[2.65, 35]}," +
                      "'queries': ['sum(a.b.c)','min(z)','max(a.x)']}";

            var result = SimQLProgram.ExecuteQueries(str).ToArray();

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(new[] {"sum(a.b.c) = 24", "min(z) = 2.65", "max(a.x) = 3.14"}, result);
        }

        [Test]
        public void ReturnValues_InBaseTestQL()
        {
            var str =
                "{\"data\":{\"empty\":[],\"x\":[0.1,0.2,0.3],\"a\":[{\"b\":10,\"c\":[1,2,3]},{\"b\":30,\"c\":[4]},{\"d\":500}]}," +
                "\"queries\":[\"sum(empty)\",\"sum(a.b)\",\"sum(a.c)\",\"sum(a.d)\",\"sum(x)\"]}";

            var result = SimQLProgram.ExecuteQueries(str);

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(new[] { "sum(empty) = 0","sum(a.b) = 40", "sum(a.c) = 10", "sum(a.d) = 500", "sum(x) = 0.6" }, result);

        }
    }
}
