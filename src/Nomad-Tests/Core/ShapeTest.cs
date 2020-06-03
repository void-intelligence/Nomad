// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void Shape()
        {
            var mat = new Matrix(10, 10);
            mat.InRandomize(-0.5,0.5);
            mat = mat.Flatten();
            mat = mat.Widen(10, 10);
            mat.InFlatten();
            mat.InWiden(10, 10);
            mat = mat.Reshape(100, 1);
            mat.InReshape(10, 10);
            mat = mat.Merge(mat, out var mergepoint);
            mat.InMerge(mat, out mergepoint);
            mat.Split(mergepoint);

            mat = new Matrix(10, 5);
            mat.InRandomize(-0.5, 0.5);
            mat.InReshape(5, 10);
        }
    }
}
