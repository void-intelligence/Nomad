// © 2021 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Polynomials;

namespace NomadTest.Polynomials
{
    [TestClass]
    public class PolynomialTest
    {
        [TestMethod]
        public void PolynomialEvaluation()
        {
            // 1x^0 + 2x^1 + 3x^2
            double[] coeffs = { 4, 2, 3 };

            Polynomial p1 = new Polynomial(coeffs);
            Assert.AreEqual(p1.Evaluate(2), 20);
        }

    }
}
