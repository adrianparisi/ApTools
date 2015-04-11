using SomeTools.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTools.Tests
{
    [TestClass]
    public class ReflectionHelperTesT
    {
        class MyClass
        {
            private MyClass() { }
            private MyClass(int intiger) { }
            public MyClass(string text) { }


            private int MyMethod(bool boolean) 
            {
                return 1;
            }

            private int MyMethod(string text)
            {
                return 2;
            }

            private int MyMethod(bool boolean, string text)
            {
                return 3;
            }
        }

        #region Contructor

        [TestMethod]
        public void RunPrivateContructorWithoutParameterTest()
        {
            MyClass myClass = (MyClass)ReflectionHelper.RunConstructor(typeof(MyClass));

            Assert.IsNotNull(myClass);
        }

        [TestMethod]
        public void RunPrivateContructorWithOneParameterTest()
        {
            MyClass myClass = (MyClass)ReflectionHelper.RunConstructor(typeof(MyClass), 1);

            Assert.IsNotNull(myClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunPrivateContructorWithFailParameterTest()
        {
            ReflectionHelper.RunConstructor(typeof(MyClass), 123.456);
        }

        #endregion Contructor

        #region Methods

        [TestMethod]
        public void RunPrivateMethodWith1BooleanParameterTesT()
        {
            MyClass myClass = new MyClass("OK");
            
            int expected = 1;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", myClass, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunPrivateMethodWith1StringParameterTesT()
        {
            int expected = 2;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", typeof(MyClass), "OK");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunPrivateMethodWith2ParameterTesT()
        {
            MyClass myClass = new MyClass("OK");            
            
            int expected = 3;
            int actual = (int)ReflectionHelper.RunMethod("MyMethod", myClass, true, "OK");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunPrivateMethodFailParameterTesT()
        {
            MyClass myClass = new MyClass("OK");

            ReflectionHelper.RunMethod("MyMethod", myClass);
        }

        #endregion Methods
    }
}
