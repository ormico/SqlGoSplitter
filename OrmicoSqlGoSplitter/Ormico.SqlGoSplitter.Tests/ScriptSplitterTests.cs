using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ormico.SqlGoSplitter;

namespace Ormico.SqlGoSplitter.Tests
{
    [TestClass]
    public class ScriptSplitterTests
    {
        [TestMethod]
        public void ScriptSplitterCanEnumerate()
        {
            var splitter = new ScriptSplitter("This is a test");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void ScriptSplitterCanEnumerate2()
        {
            var splitter = new ScriptSplitter("This is a test\nGO\nLast Line.");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(2, i);
        }
        
        [TestMethod]
        public void ScriptSplitterCanEnumerate3()
        {
            var splitter = new ScriptSplitter("This is a test\n--GO\nLast Line.");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void ScriptSplitterCanEnumerate4()
        {
            var splitter = new ScriptSplitter("This is a test\n/*GO*/\nLast Line.");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void ScriptSplitterCanEnumerate5()
        {
            var splitter = new ScriptSplitter("/*This is a test\nGO*/\nLast Line.");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(1, i);
        }


        [TestMethod]
        public void ScriptSplitterCanEnumerate6()
        {
            var splitter = new ScriptSplitter("declare @x='Hello.\nGO'\nselect @x");
            IEnumerable<string> enumerable = splitter;
            int i = 0;
            foreach (string s in enumerable)
            {
                i++;
            }
            Assert.AreEqual(1, i);
        }
    }
}
