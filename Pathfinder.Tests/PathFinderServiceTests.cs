using Microsoft.Extensions.Caching.Memory;
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
            var cache = new MemoryCache(new MemoryCacheOptions());
            IPathFinderService service = new PathFinderService(cache);
            var result = service.FindPath(testData);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_FindPath_ShouldReturn_EmptyPath()
        {
            var testData = new int[] { 1, 2, 0, 1, 0, 2, 0 };

            var cache = new MemoryCache(new MemoryCacheOptions());
            IPathFinderService service = new PathFinderService(cache);
            var result = service.FindPath(testData);
            Assert.IsTrue(result.Length == 0);
        }
    }

}
