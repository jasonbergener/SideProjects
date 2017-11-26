using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RangeExtractorTest1() //ends on single
        {
            // arrange
            List<int> test = new List<int> { 1, 2, 3, 6, 8, 10, 11, 12, 15, 16, 18 };
            string expected = "1-3, 6, 8, 10-12, 15, 16, 18";

            // act
            string actual = SideProjects.RangeExtractor.RangeExtract(test);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RangeExtractorTest2() //ends on range
        {
            // arrange
            List<int> test = new List<int> { 1, 2, 3, 6, 8, 10, 11, 12, 15, 16, 17, 18 };
            string expected = "1-3, 6, 8, 10-12, 15-18";

            // act
            string actual = SideProjects.RangeExtractor.RangeExtract(test);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RangeExtractorTest3() //ends on possible
        {
            // arrange
            List<int> test = new List<int> { 1, 2, 3, 6, 8, 10, 11, 12, 15, 17, 18 };
            string expected = "1-3, 6, 8, 10-12, 15, 17, 18";

            // act
            string actual = SideProjects.RangeExtractor.RangeExtract(test);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
