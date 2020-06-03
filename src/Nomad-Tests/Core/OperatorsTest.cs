// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class OperatorsTest
    {
        [TestMethod]
        public void Operators()
        {
            // ReSharper disable EqualExpressionComparison
            // ReSharper disable RedundantAssignment
            // ReSharper disable UnusedVariable
            // ReSharper disable RedundantAssignment
            // ReSharper disable NotAccessedVariable
#pragma warning disable IDE0054 // Use compound assignment
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS1718 // Comparison made to same variable
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5, 0.5);
            mat = !mat;
            mat = mat + mat;
            mat = mat - mat;
            mat = mat * mat;
            mat = mat / mat;
            mat = mat + 1;
            mat = mat - 1;
            mat = mat * 1;
            mat = mat / 1;
            
            var b = mat == mat;
            b = mat != mat;

            var x = mat > mat;
            x = mat < mat;
            x = mat >= mat;
            x = mat <= mat;
#pragma warning restore CS1718 // Comparison made to same variable
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning restore IDE0054 // Use compound assignment
            // ReSharper enable NotAccessedVariable
            // ReSharper enable RedundantAssignment
            // ReSharper enable UnusedVariable
            // ReSharper enable once RedundantAssignment
            // ReSharper enable EqualExpressionComparison
        }
    }
}