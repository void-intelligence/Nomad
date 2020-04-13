// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomad.Matrix;

namespace NomadTest
{
    [TestClass]
    public class UnitTestMatrix
    {
        [TestMethod]
        public void MatrixEquals()
        {
            Matrix a = new Matrix(3);
            Matrix b = new Matrix(3);
            Matrix c = new Matrix(3);

            #region Matrix definition
            a[1, 1] = 11;
            a[1, 2] = 12;
            a[1, 3] = 13;
            a[2, 1] = 21;
            a[2, 2] = 22;
            a[2, 3] = 23;
            a[3, 1] = 31;
            a[3, 2] = 32;
            a[3, 3] = 33;

            b[1, 1] = 11;
            b[1, 2] = 12;
            b[1, 3] = 13;
            b[2, 1] = 21;
            b[2, 2] = 22;
            b[2, 3] = 23;
            b[3, 1] = 31;
            b[3, 2] = 32;
            b[3, 3] = 33;

            c[1, 1] = 21;
            c[1, 2] = 12;
            c[1, 3] = 13;
            c[2, 1] = 21;
            c[2, 2] = 22;
            c[2, 3] = 23;
            c[3, 1] = 31;
            c[3, 2] = 32;
            c[3, 3] = 33;
            #endregion

            Assert.IsTrue(a == b, "Matrices A and B are equal!");
            Assert.IsFalse(a == c, "Matrices A and C are not equal!");
        }

        [TestMethod]
        public void MatrixNotEquals()
        {
            Matrix a = new Matrix(3);
            Matrix b = new Matrix(3);
            Matrix c = new Matrix(4, 3);
            Matrix d = new Matrix(3, 4);

            #region Matrix definition
            a[1, 1] = 11;
            a[1, 2] = 12;
            a[1, 3] = 13;
            a[2, 1] = 21;
            a[2, 2] = 22;
            a[2, 3] = 23;
            a[3, 1] = 31;
            a[3, 2] = 32;
            a[3, 3] = 33;

            b[1, 1] = 21;
            b[1, 2] = 12;
            b[1, 3] = 13;
            b[2, 1] = 21;
            b[2, 2] = 22;
            b[2, 3] = 23;
            b[3, 1] = 31;
            b[3, 2] = 32;
            b[3, 3] = 33;
            #endregion

            Assert.IsTrue(a != b, "Matrices A and B are not equal!");
            Assert.IsFalse(a == b, "Matrices A and B are not equal!");
            Assert.IsTrue(a != c, "Matrices A and C are not equal!");
            Assert.IsTrue(a != d, "Matrices A and D are not equal!");
            Assert.IsTrue(c != d, "Matrices C and D are not equal!");
            Assert.IsFalse(c == d, "Matrices C and D are not equal!");
        }

        [TestMethod]
        public void MatrixAddition()
        {
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(2, 3);
            Matrix _trueResult = new Matrix(2, 3);

            #region Matrix definition
            a[1, 1] = 1;
            a[1, 2] = 2;
            a[1, 3] = 3;
            a[2, 1] = 4;
            a[2, 2] = 5;
            a[2, 3] = 6;

            b[1, 1] = 6;
            b[1, 2] = 5;
            b[1, 3] = 4;
            b[2, 1] = 3;
            b[2, 2] = 2;
            b[2, 3] = 1;

            _trueResult[1, 1] = a[1, 1] + b[1, 1];
            _trueResult[1, 2] = a[1, 2] + b[1, 2];
            _trueResult[1, 3] = a[1, 3] + b[1, 3];
            _trueResult[2, 1] = a[2, 1] + b[2, 1];
            _trueResult[2, 2] = a[2, 2] + b[2, 2];
            _trueResult[2, 3] = a[2, 3] + b[2, 3];
            #endregion


            var _calculatedResult = a + b;

            Assert.IsTrue(_calculatedResult == _trueResult, "Addition not correct!");
        }

        [TestMethod]
        public void MatrixMultiplication()
        {
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(3, 2);
            Matrix _trueResult = new Matrix(2);

            #region Matrix definition
            a[1, 1] = 1;
            a[1, 2] = 2;
            a[1, 3] = 3;
            a[2, 1] = 4;
            a[2, 2] = 5;
            a[2, 3] = 6;

            b[1, 1] = 1;
            b[1, 2] = 2;
            b[2, 1] = 3;
            b[2, 2] = 4;
            b[3, 1] = 5;
            b[3, 2] = 6;

            _trueResult[1, 1] = a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1] + a[1, 3] * b[3, 1];
            _trueResult[1, 2] = a[1, 1] * b[1, 2] + a[1, 2] * b[2, 2] + a[1, 3] * b[3, 2];
            _trueResult[2, 1] = a[2, 1] * b[1, 1] + a[2, 2] * b[2, 1] + a[2, 3] * b[3, 1];
            _trueResult[2, 2] = a[2, 1] * b[1, 2] + a[2, 2] * b[2, 2] + a[2, 3] * b[3, 2];
            #endregion

            var _calculatedResult = a * b;

            Assert.IsTrue(_calculatedResult == _trueResult, "Multiplication by matrix not correct!");
        }

        [TestMethod]
        public void MatrixMultiplicationScalar()
        {
            Matrix a = new Matrix(3);
            Matrix _trueResult = new Matrix(3);
            double _scalar = 5.0;

            #region Matrix definition
            a[1, 1] = 1;
            a[1, 2] = 2;
            a[1, 3] = 3;
            a[2, 1] = 4;
            a[2, 2] = 5;
            a[2, 3] = 6;
            a[3, 1] = 4;
            a[3, 2] = 5;
            a[3, 3] = 6;

            _trueResult[1, 1] = a[1, 1] * _scalar;
            _trueResult[1, 2] = a[1, 2] * _scalar;
            _trueResult[1, 3] = a[1, 3] * _scalar;
            _trueResult[2, 1] = a[2, 1] * _scalar;
            _trueResult[2, 2] = a[2, 2] * _scalar;
            _trueResult[2, 3] = a[2, 3] * _scalar;
            _trueResult[3, 1] = a[3, 1] * _scalar;
            _trueResult[3, 2] = a[3, 2] * _scalar;
            _trueResult[3, 3] = a[3, 3] * _scalar;
            #endregion

            var _calculatedResult = a * _scalar;

            Assert.IsTrue(_calculatedResult == _trueResult, "Multiplication by scalar not correct!");
        }

        [TestMethod]
        public void MatrixInverse()
        {
            Matrix a = new Matrix(3);
            Matrix _trueResult = new Matrix(3);

            #region Matrix definition
            a[1, 1] = 1;
            a[1, 2] = 3;
            a[1, 3] = 3;
            a[2, 1] = 1;
            a[2, 2] = 4;
            a[2, 3] = 3;
            a[3, 1] = 1;
            a[3, 2] = 3;
            a[3, 3] = 4;

            _trueResult[1, 1] = 7;
            _trueResult[1, 2] = -3;
            _trueResult[1, 3] = -3;
            _trueResult[2, 1] = -1;
            _trueResult[2, 2] = 1;
            _trueResult[2, 3] = 0;
            _trueResult[3, 1] = -1;
            _trueResult[3, 2] = 0;
            _trueResult[3, 3] = 1;
            #endregion

            var _calculatedResult = !a;

            Assert.IsTrue(_calculatedResult == _trueResult, "Inversion not correct!");
        }

        [TestMethod]
        public void MatrixSize()
        {
            Matrix a = new Matrix(3);
            Matrix b = new Matrix(3);
            Matrix c = new Matrix(4, 3);

            Assert.IsTrue(c > a, "Matrix C is bigger than A!");
            Assert.IsTrue(a < c, "Matrix A is smaller than C!");
            Assert.IsTrue(b >= a, "Matrix B is same size as A!");
            Assert.IsTrue(a <= b, "Matrix B is same size as A!");
            Assert.IsTrue(c >= a, "Matrix C is bigger than A!");
            Assert.IsTrue(a <= c, "Matrix C is bigger than A!");
        }

        [TestMethod]
        public void MatrixRandomize()
        {
            Matrix a = new Matrix(3);
            a.Randomize();
            a.Map(Math.Sin);
        }
    }
}
