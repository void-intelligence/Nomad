// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest
{
    [TestClass]
    public class CiTest
    {
        [TestMethod]
        public void CiTestMethod()
        {
            Assert.IsTrue(true, "CI: Initial Test Successful");
        }
    }

}