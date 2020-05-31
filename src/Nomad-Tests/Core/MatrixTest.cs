// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class MatrixTest
    {
        public double CustomFunction(double val)
        {
            return val * Math.Log(val);
        }

        [TestMethod]
        public void Matrix()
        {
            // ReSharper disable RedundantAssignment
            // ReSharper disable UnusedVariable
            var mat = new Matrix(1, 1);
            mat = new Matrix(1, 1, 1);
            mat = new Matrix(5);
            mat = new Matrix(5, 1.0);
            mat = new Matrix( new double[,]{{0,0,0},{0,0,0}});
            mat = new Matrix(new double[]{1,2,3,4});
            mat = mat.Duplicate();
            mat = new Matrix(10, 10);
            mat = mat.SubMatrix(5, 5, 2, 2);
            mat = mat.Map(CustomFunction);
            var shape = mat.Shape();
            var type = mat.Type();
            var str = mat.ToString();
            mat.Print();

            // ReSharper disable once EqualExpressionComparison
            var eq = mat.Equals(mat );

            var hash = mat.GetHashCode();
            var guid = mat.GUID;
            // ReSharper enable UnusedVariable
            // ReSharper enable RedundantAssignment
        }
    }
}