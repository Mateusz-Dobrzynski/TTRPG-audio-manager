using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class GreatestCommonDivisor
    {
        [TestMethod]
        public void GreatestCommonDivisorTests()
        {
            Track track = new Track("name");
            Assert.AreEqual(6, track.GreatestCommonDivisor(48, 18));
            Assert.AreEqual(3, track.GreatestCommonDivisor(6, 15));
            Assert.AreEqual(25, track.GreatestCommonDivisor(100, 25));
            Assert.AreEqual(1, track.GreatestCommonDivisor(5, 3));
        }
    }
}
