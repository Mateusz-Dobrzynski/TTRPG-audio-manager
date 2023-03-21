using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tests
{
    /// <summary>
    /// This class tests out the ScenesSet.NameCheck() method and ensures its correct behaviour.
    /// </summary>
    /// <seealso cref="ScenesSet.NameCheck(string)"/>
    [TestClass]
    public class NameCheckTests
    {
        ScenesSet set = new ScenesSet();

        /// <summary>
        /// Illegal characters cannot be used in set names
        /// </summary>
        [TestMethod]
        public void IllegalCharacters()
        {
            Assert.AreEqual(false, set.NameCheck("<"));
            Assert.AreEqual(false, set.NameCheck(">"));
            Assert.AreEqual(false, set.NameCheck(":"));
            Assert.AreEqual(false, set.NameCheck("\""));
            Assert.AreEqual(false, set.NameCheck("/"));
            Assert.AreEqual(false, set.NameCheck("\\"));
            Assert.AreEqual(false, set.NameCheck("|"));
            Assert.AreEqual(false, set.NameCheck("?"));
            Assert.AreEqual(false, set.NameCheck("*"));
        }

        /// <summary>
        /// Alphanumeric characters can be used in set names
        /// </summary>
        [TestMethod]
        public void Alphanumerics()
        {
            Assert.AreEqual(true, set.NameCheck("abcdefghijklmnopqrstuvwxyz0123456789"));
        }

        /// <summary>
        /// Special characters which are not illegal characters can be used in set names
        /// </summary>
        [TestMethod]
        public void SpecialCharacters()
        {
            Assert.AreEqual(true, set.NameCheck("_-!@#$%^&()"));
        }
    }
}
