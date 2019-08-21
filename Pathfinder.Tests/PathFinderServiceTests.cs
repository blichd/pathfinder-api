using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinder.Interfaces;
using Pathfinder.Services;

namespace Pathfinder.Tests
{
    [TestClass]
    public class PathFinderServiceTests
    {
        [TestMethod]
        public void Test_FindPath_ShouldReturn_OptimalPath()
        {
            var testData = new int[] { 1, 2, 0, 3, 0, 2, 0 };
            var expected = new int[] { 1, 2, 3, 0 };



            IPathFinderService service = new PathFinderService();
            var result = service.FindPath(testData);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_FindPath_ShouldFail()
        {
            var testData = new int[] { 1, 2, 0, 1, 0, 2, 0 };

            IPathFinderService service = new PathFinderService();
            var result = service.FindPath(testData);

            Assert.IsNull(result);
        }
    }
}
