// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Core;

namespace NomadTest.Core
{
    [TestClass]
    public class TransformationTest
    {
        [TestMethod]
        public void Rotation2D()
        {
            Matrix.MatrixRotation2D(1);
        }

        [TestMethod]
        public void Rotation3D()
        {
            Matrix.MatrixRotation3Dx(1);
            Matrix.MatrixRotation3Dy(1);
            Matrix.MatrixRotation3Dz(1);
        }

        [TestMethod]
        public void Scaling()
        {
            Matrix.Scaling(1);
            Matrix.Scaling(1,1,1);
        }

        [TestMethod]
        public void Translation()
        {
            Matrix.Translation(1,1,1);
        }
    }
}
