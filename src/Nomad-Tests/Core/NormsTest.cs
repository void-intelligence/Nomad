// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class NormsTest
    {
        public double CustomNormFunction(double val)
        {
            return val * 1.5;
        }

        [TestMethod]
        public void Operators()
        {
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5, 0.5);

            mat.MaximumNorm();
            mat.ManhattanNorm();
            mat.TaxicabNorm();
            mat.PNorm(0);
            mat.EuclideanNorm();
            mat.FrobeniusNorm();
            mat.AbsoluteNorm();
            mat.IntegrateCustomNorm(CustomNormFunction);
        }
    }
}