// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class MatricesTest
    {

        [TestMethod]
        public void Matrices()
        {
            // ReSharper disable NotAccessedVariable
            // ReSharper disable RedundantAssignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var mat = new Matrix(1, 1);
            mat = Matrix.Zero(5);
            mat = Matrix.Zero(5, 5);
            mat = Matrix.Identity(5);
            mat = Matrix.Vandermonde(5, 5);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            // ReSharper enable RedundantAssignment
            // ReSharper enable NotAccessedVariable
        }
    }
}