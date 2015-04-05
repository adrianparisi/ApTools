using ApTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ApToolsTest
{
    [TestClass]
    public class CollectionExtensionMethodsTest
    {
        [TestMethod]
        public void IsNullCollectionTest()
        {
            List<object> objects = null;

            Assert.IsTrue(objects.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsEmptyCollectionTest()
        {
            List<object> objects = new List<object>();

            Assert.IsTrue(objects.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNotEmptyCollectionTest()
        {
            List<object> objects = new List<object>();
            objects.Add(new object());
            objects.Add(new object());

            Assert.IsFalse(objects.IsNullOrEmpty());
        }
    }
}
