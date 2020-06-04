// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class ConvolutionTest
    {

        [TestMethod]
        public void Convolution()
        {
            // ReSharper disable NotAccessedVariable
            // ReSharper disable RedundantAssignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var mat = new Matrix(10, 10);
            mat.InRandomize();
            var x = mat.Duplicate();
            mat = mat.Convolve(Matrix.Filters.Sobel(), 1, 1);
            mat = mat.Convolve(Matrix.Filters.Sobel(), 1, 1, 0, 4);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            // ReSharper enable RedundantAssignment
            // ReSharper enable NotAccessedVariable
        }
    }
}