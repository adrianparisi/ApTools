using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTools.Reflection;
using System;

namespace SomeTools.Tests.Reflection
{
    [TestClass]
    public class ReflectionHelperTest
    {
        #region Contructor

        [TestMethod]
        public void RunPrivateContructorWithoutParameterTest()
        {
            MyFakeClass myClass = (MyFakeClass)ReflectionHelper.RunConstructor(typeof(MyFakeClass));

            Assert.IsNotNull(myClass);
        }

        [TestMethod]
        public void RunPrivateContructorWithOneParameterTest()
        {
            MyFakeClass myClass = (MyFakeClass)ReflectionHelper.RunConstructor(typeof(MyFakeClass), 1);

            Assert.IsNotNull(myClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunPrivateContructorWithFailParameterTest()
        {
            ReflectionHelper.RunConstructor(typeof(MyFakeClass), 123.456);
        }

        #endregion Contructor

        #region Methods

        [TestMethod]
        public void RunPrivateMethodWith1BooleanParameterTesT()
        {
            MyFakeClass myClass = new MyFakeClass("OK");
            
            int expected = 1;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", myClass, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunPrivateStaticMethodWith1StringParameterTesT()
        {
            int expected = 2;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", typeof(MyFakeClass), "OK");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunPrivateMethodWith2ParameterTesT()
        {
            MyFakeClass myClass = new MyFakeClass("OK");            
            
            int expected = 3;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", myClass, true, "OK");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunPrivateMethodFailParameterTesT()
        {
            MyFakeClass myClass = new MyFakeClass("OK");

            ReflectionHelper.RunMethod("MyMethod", myClass);
        }

        #endregion Methods
    }
}
