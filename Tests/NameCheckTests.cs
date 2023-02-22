using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    // TO-DO: Write more unit tests to cover all the edge cases
    /// <summary>
    /// This class tests out the NameCheck() method and ensures its correct behaviour.
    /// </summary>
    /// <seealso cref="ScenesSet.NameCheck(string)"/>
    [TestClass]
    public class NameCheckTests
    {
        ScenesSet set = new ScenesSet();
        [TestMethod]
        public void IllegalCharacters()
        {
            Assert.AreEqual(false, set.NameCheck("<>:\"/\\|?*"));
        }
        [TestMethod]
        public void Alphanumercs()
        {
            Assert.AreEqual(true, set.NameCheck("abcdefghijklmnopqrstuvwxyz0123456789"));
        }
    }
}
