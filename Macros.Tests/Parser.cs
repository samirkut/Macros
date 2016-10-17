using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Macros.Expressions;

namespace Macros.Tests
{
    [TestClass]
    public class Parser
    {
        Runner _runner;

        [TestInitialize]
        public void Setup()
        {
            _runner = new Runner();
            _runner.Scope.SetVariable("x", 10);
            _runner.Scope.SetVariable("y", 5);
        }

        [TestMethod]
        public void TestAddOp()
        {
            var result = _runner.Parse("x+y");
            Assert.AreEqual("+(x, y)", result.ToString());
        }

        [TestMethod]
        public void TestSubOp()
        {
            var result = _runner.Parse("x - 5");
            Assert.AreEqual("-(x, 5)", result.ToString());
        }

        [TestMethod]
        public void TestArithmeticPrecedence()
        {
            var parsed = _runner.Parse("10/5-4*2");

            var result = _runner.Evaluate("10/5-4*2");
            Assert.AreEqual(-6, (result as NumberExpr).Value);
        }
    }
}
