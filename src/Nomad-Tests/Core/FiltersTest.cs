// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class FiltersTest
    {

        [TestMethod]
        public void Matrices()
        {
            // ReSharper disable NotAccessedVariable
            // ReSharper disable RedundantAssignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var mat = new Matrix(1, 1);
            mat = Matrix.Filters.Sobel();
            mat = Matrix.Filters.Scharr();
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            // ReSharper enable RedundantAssignment
            // ReSharper enable NotAccessedVariable
        }
    }
}