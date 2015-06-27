using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTools.Tests.ExtensionMethods
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        #region Between

        [TestMethod]
        public void NowIsBetweenYesterdayAndTomorrowTest()
        {
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);
            DateTime tomorrow = now.AddDays(+1);

            bool expected = true;
            bool actual = now.Between(yesterday, tomorrow);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsBetweenNowAndTomorrowTest()
        {
            DateTime now = DateTime.Now;
            DateTime tomorrow = now.AddDays(+1);

            bool expected = true;
            bool actual = now.Between(now, tomorrow);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsBetweenYesterdayAndNowTest()
        {
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);

            bool expected = true;
            bool actual = now.Between(yesterday, now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotBetweenLasYearAndYesterdayTest()
        {
            DateTime now = DateTime.Now;
            DateTime lastYear = now.AddYears(-1);
            DateTime yesterday = now.AddDays(-1);

            bool expected = false;
            bool actual = now.Between(lastYear, yesterday);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotBetweenTomorrowAndNextYearTest()
        {
            DateTime now = DateTime.Now;
            DateTime tomorrow = now.AddDays(+1);
            DateTime nextYear = now.AddYears(+1);

            bool expected = false;
            bool actual = now.Between(tomorrow, nextYear);

            Assert.AreEqual(expected, actual);
        }

        #endregion Between

        #region OutOf

        [TestMethod]
        public void NowIsOutOfLastYearAndYesterdayTest()
        {
            DateTime now = DateTime.Now;
            DateTime lastYear = now.AddYears(-1);
            DateTime Yesterday = now.AddDays(-1);

            bool expected = true;
            bool actual = now.OutOf(lastYear, Yesterday);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsOutOfTomorrowAndNextYearTest()
        {
            DateTime now = DateTime.Now;
            DateTime tomorrow = now.AddDays(+1);
            DateTime nextYear = now.AddYears(+1);

            bool expected = true;
            bool actual = now.OutOf(tomorrow, nextYear);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotOutOfYesterdayAndTomorrowTest()
        {
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);
            DateTime tomorrow = now.AddDays(+1);

            bool expected = false;
            bool actual = now.OutOf(yesterday, tomorrow);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotOutOfYesterdayAndNoEndTest()
        {
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);
            DateTime? end = null;

            bool expected = false;
            bool actual = now.OutOf(yesterday, end);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotOutOfNoStartAndTomorrowTest()
        {
            DateTime now = DateTime.Now;
            DateTime? start = null;
            DateTime tomorrow = now.AddDays(+1);

            bool expected = false;
            bool actual = now.OutOf(start, tomorrow);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NowIsNotOutOfNoStartAndNoEndTest()
        {
            DateTime now = DateTime.Now;
            DateTime? start = null;
            DateTime? end = null;

            bool expected = false;
            bool actual = now.OutOf(start, end);

            Assert.AreEqual(expected, actual);
        }

        #endregion OutOf
    }
}
