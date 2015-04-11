using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApTools.Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
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
    }
}
