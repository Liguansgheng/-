using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL7LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB.Tests
{
    [TestClass()]
    public class compositeTypeTests
    {
        [TestMethod()]
        public void compositeTypeTest()
        {
            compositeType obj = new compositeType(null,"FN");
            obj.delimiter = "&";
            Assert.AreEqual("FN", obj.Name);
            obj.Value = "de Jong-van Beethoven&de&Jong&van&Beethoven ";
            //Assert.AreEqual("de Jong-van Beethoven&de&Jong&van&Beethoven ", obj.Value);
        }

        [TestMethod()]
        public void ParseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}