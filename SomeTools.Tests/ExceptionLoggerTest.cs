using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace SomeTools.Tests
{
    [TestClass]
    public class ExceptionLoggerTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this.RemoveLog();
        }

        private void RemoveLog()
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
        public void AppendASecondExceptionTest()
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
        public void CantOpenFileAndNotFailTest()
        {
            ExceptionLogger.Log(new Exception("some messagge"));
            byte[] log1 = File.ReadAllBytes(ExceptionLogger.FullName);

            File.SetAttributes(ExceptionLogger.FullName, FileAttributes.ReadOnly);

            ExceptionLogger.Log(new Exception("unwritten message"));
            byte[] log2 = File.ReadAllBytes(ExceptionLogger.FullName);

            Assert.AreEqual(log1.Count(), log2.Count());
        }

        [TestMethod]
        public void CreateFolderThenCreateLogTest()
        {
            if (Directory.Exists(ExceptionLogger.Path))
                Directory.Delete(ExceptionLogger.Path);

            Assert.IsFalse(Directory.Exists(ExceptionLogger.Path), "Could not delete the logs directory.");

            ExceptionLogger.Log(new Exception("some messagge"));
            byte[] log = File.ReadAllBytes(ExceptionLogger.FullName);

            Assert.IsTrue(log.Count() > 0, "The log does not contains information.");
        }
    }
}
