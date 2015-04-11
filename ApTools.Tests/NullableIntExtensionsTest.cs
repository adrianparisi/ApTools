using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApTools.Tests
{
    [TestClass]
    public class NullableIntExtensionsTest
    {
        [TestMethod]
        public void NegativeIsTrueTest()
        {
            int? number = -10;

            Assert.IsTrue(number.ToBool());
        }

        [TestMethod]
        public void PositiveIsTrueTest()
        {
            int? number = 10;

            Assert.IsTrue(number.ToBool());
        }

        [TestMethod]
        public void CeroIsFalseTest()
        {
            int? number = 0;

            Assert.IsFalse(number.ToBool());
        }

        [TestMethod]
        public void NullIsFalseTest()
        {
            int? number = null;

            Assert.IsFalse(number.ToBool());
        }
    }
}
