// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;
using Nomad.Utility;

namespace NomadTest.Core
{
    [TestClass]
    public class RandomTest
    {
        [TestMethod]
        public void Random()
        {
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5, 0.5);
            mat.InRandomize(-0.5, 0.5, EDistribution.Uniform);
        }
    }
}
