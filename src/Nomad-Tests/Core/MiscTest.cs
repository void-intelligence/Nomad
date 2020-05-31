// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class MiscTest
    {
        [TestMethod]
        public void Misc()
        {
            // ReSharper disable RedundantAssignment
            // ReSharper disable UnusedVariable
            // ReSharper disable once RedundantAssignment
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5, 0.5);

            mat = mat.Softmax();
            mat = mat.Dropout(0.5);
            // ReSharper enable RedundantAssignment
            // ReSharper enable UnusedVariable
            // ReSharper enable once RedundantAssignment
        }
    }
}