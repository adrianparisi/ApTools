using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace SomeTools.Tests
{
    [TestClass]
    public class ExceptionLoggerTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this.RemoveExistingLog();
        }

        private void RemoveExistingLog()
        {
            if (File.Exists(ExceptionLogger.FullName))
            {
                File.SetAttributes(ExceptionLogger.FullName, FileAttributes.Normal);
                File.Delete(ExceptionLogger.FullName);

                if (File.Exists(ExceptionLogger.FullName))
                    throw new Exception("Can't remove error log.");
            }
        }


        [TestMethod]
        public void LogAndReadAnExceptionTest()
        {
            ExceptionLogger.Log(new Exception("some messagge"));
            byte[] log = File.ReadAllBytes(ExceptionLogger.FullName);
            
            Assert.IsTrue(log.Count() > 0);
        }


        [TestMethod]
        public void AppendASecondException()
        {
            ExceptionLogger.Log(new Exception("messagge 1"));
            byte[] log1 = File.ReadAllBytes(ExceptionLogger.FullName);

            ExceptionLogger.Log(new Exception("messagge 2"));
            byte[] log2 = File.ReadAllBytes(ExceptionLogger.FullName);

            Assert.IsTrue(log1.Count() > 0, "First log dosent contain information.");
            Assert.IsTrue(log2.Count() > 0, "Second log dosent contain information.");
            Assert.IsTrue(log1.Count() < log2.Count(), "First file is bigger than second file.");
        }

        [TestMethod]
        public void CantOpenFileAndNotFail()
        {
            ExceptionLogger.Log(new Exception("messagge"));
            byte[] log1 = File.ReadAllBytes(ExceptionLogger.FullName);

            File.SetAttributes(ExceptionLogger.FullName, FileAttributes.ReadOnly);

            ExceptionLogger.Log(new Exception("unwritten message"));
            byte[] log2 = File.ReadAllBytes(ExceptionLogger.FullName);

            Assert.AreEqual(log1.Count(), log2.Count());
        }
    }
}
