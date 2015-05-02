using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTools.Tests.ExtensionMethods
{
    [TestClass]
    public class StringExtensionsTest
    {
        #region IsNullOrEmpty

        [TestMethod]
        public void NullStringIsNullOrEmptyTest()
        {
            string text = null;

            Assert.IsTrue(text.IsNullOrEmpty());
        }

        [TestMethod]
        public void EmptyStringIsNullOrEmptyTest()
        {
            string text = String.Empty;

            Assert.IsTrue(text.IsNullOrEmpty());
        }

        [TestMethod]
        public void StringWithTextIsNotNullOrEmptyTest()
        {
            string text = "some text";

            Assert.IsFalse(text.IsNullOrEmpty());
        }

        #endregion IsNullOrEmpty

        #region IsNullOrWhiteSpace

        [TestMethod]
        public void NullStringIsNullOrWitheSpaceTest()
        {
            string text = null;

            Assert.IsTrue(text.IsNullOrWhiteSpace());
        }

        [TestMethod]
        public void SpaceStringIsNullOrWitheSpaceTest()
        {
            string text = "   ";

            Assert.IsTrue(text.IsNullOrWhiteSpace());
        }

        [TestMethod]
        public void StringWithTextIsNotNullOrWitheSpaceTest()
        {
            string text = "some text";

            Assert.IsFalse(text.IsNullOrWhiteSpace());
        }

        #endregion IsNullOrWhiteSpace
    }
}
