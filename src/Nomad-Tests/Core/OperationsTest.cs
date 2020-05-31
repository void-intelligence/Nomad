// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void Operators()
        {
            // ReSharper disable RedundantAssignment
            // ReSharper disable UnusedVariable
            // ReSharper disable once RedundantAssignment
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5, 0.5);
            mat = mat.Transpose();
            mat = mat.T();

            var sum = mat.Sum();
            var avg = mat.Average();
            var mean = mat.Mean();
            var variance = mat.Variance();

            mat = mat.Add(0);
            mat = mat.Sub(0);
            mat = mat.Hadamard(0);
            mat = mat.HadamardDivision(0);
            mat = mat.Power(0);
            mat = mat.Root(0);
            mat = mat.HadamardPower(mat);
            mat = mat.Dot(mat.T());
            mat = mat.DotDivision(mat.T());
            mat = mat.Inverse();
            mat = mat.Fill(10);
            // ReSharper enable RedundantAssignment
            // ReSharper enable UnusedVariable
            // ReSharper enable once RedundantAssignment
        }
    }
}