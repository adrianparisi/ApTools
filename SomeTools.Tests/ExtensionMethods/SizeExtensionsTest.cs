using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace SomeTools.Tests.ExtensionMethods
{
    [TestClass]
    public class SizeExtensionsTest
    {
        [TestMethod]
        public void DivisionTest()
        {
            Size size = new Size(10, 30);

            Size expected = new Size(5, 15);
            Size actual = size.Divide(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroExceptionTest()
        {
            Size size = new Size(10, 10);

            size.Divide(0);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Size size = new Size(5, 10);

            Size expected = new Size(15, 30);
            Size actual = size.Multiply(3);

            Assert.AreEqual(expected, actual);
        }
    }
}
