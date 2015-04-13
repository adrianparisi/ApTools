using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTools.Tests
{
    [TestClass]
    public class MsCryptographerTest
    {
        #region Argument validation

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void FailsWhenTheTextToEncryptIsNullTest()
        {
            MsCryptographer cryptographer = new MsCryptographer();
            
            cryptographer.Encrypt(null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void FailsWhenTheTextToEncryptIsEmptyTest()
        {
            MsCryptographer cryptographer = new MsCryptographer();

            cryptographer.Encrypt(String.Empty);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void FailsWhenTheTextToEncryptIsTooLongTest()
        {
            MsCryptographer cryptographer = new MsCryptographer();

            cryptographer.Encrypt("01234567890");
        }

        #endregion Argument validation

        #region Encryptation
        
        [TestMethod]
        public void EncryptTest()
        {
            MsCryptographer cryptographer = new MsCryptographer();

            string expected = "eFgXX[Y\\";
            string actual = cryptographer.Encrypt("soplky7u");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptTest()
        {
            MsCryptographer cryptographer = new MsCryptographer();

            string expected = "soplky7u";
            string actual = cryptographer.Decrypt("eFgXX[Y\\");

            Assert.AreEqual(expected, actual);
        }

        #endregion Encryptation
    }
}
