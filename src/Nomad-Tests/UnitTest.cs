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
            var a = new Matrix(3)
            {
                [0, 0] = 11,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };

            var b = new Matrix(3)
            {
                [0, 0] = 11,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };

            var c = new Matrix(3)
            {
                [0, 0] = 21,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };

            Assert.IsTrue(a == b, "Matrices A and B are equal!");
            Assert.IsFalse(a == c, "Matrices A and C are not equal!");
        }

        [TestMethod]
        public void MatrixNotEquals()
        {
            var a = new Matrix(3)
            {
                [0, 0] = 11,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };


            var b = new Matrix(3)
            {
                [0, 0] = 21,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };

            var c = new Matrix(4, 3);
            var d = new Matrix(3, 4);

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
<<<<<<< Updated upstream
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(2, 3);
            Matrix _trueResult = new Matrix(2, 3);

            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 3;
            a[1, 0] = 4;
            a[1, 1] = 5;
            a[1, 2] = 6;

            b[0, 0] = 6;
            b[0, 1] = 5;
            b[0, 2] = 4;
            b[1, 0] = 3;
            b[1, 1] = 2;
            b[1, 2] = 1;

            _trueResult[0, 0] = a[0, 0] + b[0, 0];
            _trueResult[0, 1] = a[0, 1] + b[0, 1];
            _trueResult[0, 2] = a[0, 2] + b[0, 2];
            _trueResult[1, 0] = a[1, 0] + b[1, 0];
            _trueResult[1, 1] = a[1, 1] + b[1, 1];
            _trueResult[1, 2] = a[1, 2] + b[1, 2];

            var _calculatedResult = a + b;

            Assert.IsTrue(_calculatedResult == _trueResult, "Addition not correct!");
=======
            var a = new Matrix(2, 3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6
            };

            var b = new Matrix(2, 3)
            {
                [0, 0] = 6,
                [0, 1] = 5,
                [0, 2] = 4,
                [1, 0] = 3,
                [1, 1] = 2,
                [1, 2] = 1
            };

            var trueResult = new Matrix(2, 3)
            {
                [0, 0] = a[0, 0] + b[0, 0],
                [0, 1] = a[0, 1] + b[0, 1],
                [0, 2] = a[0, 2] + b[0, 2],
                [1, 0] = a[1, 0] + b[1, 0],
                [1, 1] = a[1, 1] + b[1, 1],
                [1, 2] = a[1, 2] + b[1, 2]
            };

            var calculatedResult = a + b;

            Assert.IsTrue(calculatedResult == trueResult, "Addition not correct!");
>>>>>>> Stashed changes
        }

        [TestMethod]
        public void MatrixMultiplication()
        {
            var a = new Matrix(2, 3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6
            };

            var b = new Matrix(3, 2)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [1, 0] = 3,
                [1, 1] = 4,
                [2, 0] = 5,
                [2, 1] = 6
            };

            var trueResult = new Matrix(2)
            {
                [0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0] + a[0, 2] * b[2, 0],
                [0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] + a[0, 2] * b[2, 1],
                [1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0] + a[1, 2] * b[2, 0],
                [1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1]
            };

            var calculatedResult = a * b;

            Assert.IsTrue(calculatedResult == trueResult, "Multiplication by matrix not correct!");
        }

        [TestMethod]
        public void MatrixMultiplicationScalar()
        {
            var a = new Matrix(3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6,
                [2, 0] = 4,
                [2, 1] = 5,
                [2, 2] = 6
            };

            var trueResult = new Matrix(3)
            {
                [0, 0] = a[0, 0] * 5.0,
                [0, 1] = a[0, 1] * 5.0,
                [0, 2] = a[0, 2] * 5.0,
                [1, 0] = a[1, 0] * 5.0,
                [1, 1] = a[1, 1] * 5.0,
                [1, 2] = a[1, 2] * 5.0,
                [2, 0] = a[2, 0] * 5.0,
                [2, 1] = a[2, 1] * 5.0,
                [2, 2] = a[2, 2] * 5.0
            };

            var calculatedResult = a * 5.0;

            Assert.IsTrue(calculatedResult == trueResult, "Multiplication by scalar not correct!");
        }

        [TestMethod]
        public void MatrixInverse()
        {
            var a = new Matrix(3)
            {
                [0, 0] = 1,
                [0, 1] = 3,
                [0, 2] = 3,
                [1, 0] = 1,
                [1, 1] = 4,
                [1, 2] = 3,
                [2, 0] = 1,
                [2, 1] = 3,
                [2, 2] = 4
            };

            var trueResult = new Matrix(3)
            {
                [0, 0] = 7,
                [0, 1] = -3,
                [0, 2] = -3,
                [1, 0] = -1,
                [1, 1] = 1,
                [1, 2] = 0,
                [2, 0] = -1,
                [2, 1] = 0,
                [2, 2] = 1
            };

            var calculatedResult = !a;

            Assert.IsTrue(calculatedResult == trueResult, "Inversion not correct!");
        }

        [TestMethod]
        public void MatrixSize()
        {
            var a = new Matrix(3);
            var b = new Matrix(3);
            var c = new Matrix(4, 3);

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
            var a = new Matrix(3);
            a.Randomize();
            a.Map(Math.Sin);
        }

        [TestMethod]
        public void MatrixFill()
        {
            var a = new Matrix(2);
            a.InFill(10);

            Assert.IsTrue(Math.Abs(a[0, 0] - 10) < 0.01, "a[1, 1] has the value 10.");
            Assert.IsTrue(Math.Abs(a[0, 1] - 10) < 0.01, "a[1, 2] has the value 10.");
            Assert.IsTrue(Math.Abs(a[1, 0] - 10) < 0.01, "a[2, 1] has the value 10.");
            Assert.IsTrue(Math.Abs(a[1, 1] - 10) < 0.01, "a[2, 2] has the value 10.");
        }

        [TestMethod]
        public void MatrixFlatten()
        {
            var a = new Matrix(2, 2);
            a.InRandomize();

            var b = a.Flatten();

            Assert.IsTrue(Math.Abs(a[0, 0] - b[0, 0]) < 0.01, "a[0, 0] has the value of b[0, 0].");
            Assert.IsTrue(Math.Abs(a[0, 1] - b[1, 0]) < 0.01, "a[0, 1] has the value of b[1, 0].");
            Assert.IsTrue(Math.Abs(a[1, 0] - b[2, 0]) < 0.01, "a[1, 0] has the value of b[2, 0].");
            Assert.IsTrue(Math.Abs(a[1, 1] - b[3, 0]) < 0.01, "a[1, 1] has the value of b[3, 0].");
        }

        [TestMethod]
        public void MatrixWiden()
        {
            var a = new Matrix(4, 1);
            a.InRandomize();

            var b = a.Widen(2, 2);

            Assert.IsTrue(Math.Abs(b[0, 0] - a[0, 0]) < 0.01, "b[0, 0] has the value of a[0, 0].");
            Assert.IsTrue(Math.Abs(b[0, 1] - a[1, 0]) < 0.01, "b[0, 1] has the value of a[1, 0].");
            Assert.IsTrue(Math.Abs(b[1, 0] - a[2, 0]) < 0.01, "b[1, 0] has the value of a[2, 0].");
            Assert.IsTrue(Math.Abs(b[1, 1] - a[3, 0]) < 0.01, "b[1, 1] has the value of a[3, 0].");
        }

        [TestMethod]
        public void MatrixTypes()
        {
            var vector = new Matrix(4, 1);
            var square = new Matrix(4, 4);
            var vectorT = new Matrix(1, 4);
            var matrix = new Matrix(4, 3);
            var scalar = new Matrix(1, 1);

            Assert.IsTrue(vector.Type() == Nomad.Utility.EType.Vector, "Vector is a matrix of type Vector.");
            Assert.IsTrue(square.Type() == Nomad.Utility.EType.SquareMatrix,
                "Square is a matrix of type SquareMatrix.");
            Assert.IsTrue(vectorT.Type() == Nomad.Utility.EType.VectorTransposed,
                "VectorT is a matrix of type VectorTransposed.");
            Assert.IsTrue(matrix.Type() == Nomad.Utility.EType.Matrix, "Matrix is a matrix of type Matrix.");
            Assert.IsTrue(scalar.Type() == Nomad.Utility.EType.Scalar, "Scalar is a matrix of type Scalar.");
        }

        [TestMethod]
        public void MatrixShape()
        {
            var a = new Matrix(4, 3);

            Assert.IsTrue(a.Shape().X == 4, "a.Shape.X is 4.");
            Assert.IsTrue(a.Shape().Y == 3, "a.Shape.Y is 3.");

            // Transpose Test
            a.InTranspose();
            Assert.IsTrue(a.Shape().X == 3, "aT.Shape.X is 3.");
            Assert.IsTrue(a.Shape().Y == 4, "aT.Shape.Y is 4.");
        }

        [TestMethod]
        public void SubMatrix()
        {
            var a = new Matrix(10, 10);
            a.InRandomize();

            var b = a.SubMatrix(3, 3, 5, 5);

            Assert.IsTrue(Math.Abs(b[0, 0] - a[3, 3]) < 0.01, "b[0, 0] has the value of a[3, 3].");
            Assert.IsTrue(Math.Abs(b[0, 1] - a[3, 4]) < 0.01, "b[0, 1] has the value of a[3, 4].");
            Assert.IsTrue(Math.Abs(b[1, 0] - a[4, 3]) < 0.01, "b[1, 0] has the value of a[4, 3].");
            Assert.IsTrue(Math.Abs(b[1, 1] - a[4, 4]) < 0.01, "b[1, 1] has the value of a[4, 4].");
        }

        [TestMethod]
        public void MatrixDuplicate()
        {
            var a = new Matrix(2, 2);
            a.InRandomize();

            var b = a.Duplicate();

            Assert.IsTrue(Math.Abs(a[0, 0] - b[0, 0]) < 0.01, "b[0, 0] has the value of a[0, 0].");
            Assert.IsTrue(Math.Abs(a[0, 1] - b[0, 1]) < 0.01, "b[0, 1] has the value of a[0, 1].");
            Assert.IsTrue(Math.Abs(a[1, 0] - b[1, 0]) < 0.01, "b[1, 0] has the value of a[1, 0].");
            Assert.IsTrue(Math.Abs(a[1, 1] - b[1, 1]) < 0.01, "b[1, 1] has the value of a[1, 1].");
        }

        [TestMethod]
        public void MatrixToString()
        {
            var a = new Matrix(1, 1) {[0, 0] = 1};
            var fnString = a.ToString();
            const string calculatedString = "[1, \n]";
            Assert.IsTrue(fnString == calculatedString, "String calculation is successful.");
        }

        [TestMethod]
        public void MatrixReshape()
        {
            // Regular Reshape
            var a = new Matrix(3, 2);
            a.InRandomize();
            var b = a.Reshape(2, 3);

<<<<<<< Updated upstream
            bool equality = true;
            equality &= (a[0, 0] == b[0, 0]);
            equality &= (a[0, 1] == b[0, 1]);
            equality &= (a[1, 0] == b[0, 2]);
            equality &= (a[1, 1] == b[1, 0]);
            equality &= (a[2, 0] == b[1, 1]);
            equality &= (a[2, 1] == b[1, 2]);
=======
<<<<<<< Updated upstream
            bool condition = true;
            condition &= (a[0, 0] == b[0, 0]);
            condition &= (a[0, 1] == b[0, 1]);
            condition &= (a[1, 0] == b[0, 2]);
            condition &= (a[1, 1] == b[1, 0]);
            condition &= (a[2, 0] == b[1, 1]);
            condition &= (a[2, 1] == b[1, 2]);
=======
            var equality = true;
            equality &= Math.Abs(a[0, 0] - b[0, 0]) < 0.01;
            equality &= Math.Abs(a[0, 1] - b[0, 1]) < 0.01;
            equality &= Math.Abs(a[1, 0] - b[0, 2]) < 0.01;
            equality &= Math.Abs(a[1, 1] - b[1, 0]) < 0.01;
            equality &= Math.Abs(a[2, 0] - b[1, 1]) < 0.01;
            equality &= Math.Abs(a[2, 1] - b[1, 2]) < 0.01;
>>>>>>> Stashed changes
>>>>>>> Stashed changes

            Assert.IsTrue(equality, "Reshape operation is successful.");

            // Flatten Reshape    
<<<<<<< Updated upstream
            Matrix matrix = a.Reshape(6, 1);
            Matrix c = matrix;

            bool secondEquality = true;
            secondEquality &= (a[0, 0] == c[0, 0]);
            secondEquality &= (a[0, 1] == c[1, 0]);
            secondEquality &= (a[1, 0] == c[2, 0]);
            secondEquality &= (a[1, 1] == c[3, 0]);
            secondEquality &= (a[2, 0] == c[4, 0]);
            secondEquality &= (a[2, 1] == c[5, 0]);
            Assert.IsTrue(secondEquality, "Flatten Reshape operation is successful.");

            // Flatten Transpose Reshape
            Matrix d = a.Reshape(1, 6);

<<<<<<< Updated upstream
            bool thirdEquality = true;
            thirdEquality &= (a[0, 0] == d[0, 0]);
            thirdEquality &= (a[0, 1] == d[0, 1]);
            thirdEquality &= (a[1, 0] == d[0, 2]);
            thirdEquality &= (a[1, 1] == d[0, 3]);
            thirdEquality &= (a[2, 0] == d[0, 4]);
            thirdEquality &= (a[2, 1] == d[0, 5]);
            Assert.IsTrue(secondEquality, "Flatten Transpose Reshape operation is successful.");
=======
            bool thirdcondition = true;
            thirdcondition &= (a[0, 0] == d[0, 0]);
            thirdcondition &= (a[0, 1] == d[0, 1]);
            thirdcondition &= (a[1, 0] == d[0, 2]);
            thirdcondition &= (a[1, 1] == d[0, 3]);
            thirdcondition &= (a[2, 0] == d[0, 4]);
            thirdcondition &= (a[2, 1] == d[0, 5]);
            Assert.IsTrue(seconditioncondition, "Flatten Transpose Reshape operation is successful.");


=======
            var matrix = a.Reshape(6, 1);
            var c = matrix;

            var secondEquality = true;
            secondEquality &= Math.Abs(a[0, 0] - c[0, 0]) < 0.01;
            secondEquality &= Math.Abs(a[0, 1] - c[1, 0]) < 0.01;
            secondEquality &= Math.Abs(a[1, 0] - c[2, 0]) < 0.01;
            secondEquality &= Math.Abs(a[1, 1] - c[3, 0]) < 0.01;
            secondEquality &= Math.Abs(a[2, 0] - c[4, 0]) < 0.01;
            secondEquality &= Math.Abs(a[2, 1] - c[5, 0]) < 0.01;
            Assert.IsTrue(secondEquality, "Flatten Reshape operation is successful.");

            // Flatten Transpose Reshape
            var d = a.Reshape(1, 6);

            var thirdEquality = true;
            thirdEquality &= Math.Abs(a[0, 0] - d[0, 0]) < 0.01;
            thirdEquality &= Math.Abs(a[0, 1] - d[0, 1]) < 0.01;
            thirdEquality &= Math.Abs(a[1, 0] - d[0, 2]) < 0.01;
            thirdEquality &= Math.Abs(a[1, 1] - d[0, 3]) < 0.01;
            thirdEquality &= Math.Abs(a[2, 0] - d[0, 4]) < 0.01;
            thirdEquality &= Math.Abs(a[2, 1] - d[0, 5]) < 0.01;
            Assert.IsTrue(thirdEquality, "Flatten Transpose Reshape operation is successful.");
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        }

        [TestMethod]
        public void MatrixNormTest()
        {
            var a = new Matrix(3, 3)
            {
                [0, 0] = 11,
                [0, 1] = 12,
                [0, 2] = 13,
                [1, 0] = 21,
                [1, 1] = 22,
                [1, 2] = 23,
                [2, 0] = 31,
                [2, 1] = 32,
                [2, 2] = 33
            };

            var tax = a.TaxicabNorm();
            var abs = a.AbsoluteNorm();
            var frob = a.EuclideanNorm();
            var man = a.ManhattanNorm();
            var max = a.MaximumNorm();
            var p = a.PNorm(3);

            Assert.IsTrue(Math.Abs(tax - 198) < 0.01, "Max norm operation is successful.");
            Assert.IsTrue(Math.Abs(abs - 198) < 0.01, "Absolute norm operation is successful.");
            Assert.IsTrue(Math.Abs(frob - 70.441465061425291) < 0.01, "Euclidean norm operation is successful.");
            Assert.IsTrue(Math.Abs(man - 198) < 0.01, "Manhattan norm operation is successful.");
            Assert.IsTrue(Math.Abs(max - 33) < 0.01, "Maximum norm operation is successful.");
            Assert.IsTrue(Math.Abs(p - 51.403943234349725) < 0.01, "P norm operation is successful.");
        }

        [TestMethod]
        public void MatrixBroadcasting()
        {
<<<<<<< Updated upstream
            Matrix a = new Matrix(3, 3);
            a[0, 0] = 10;
            a[0, 1] = 10;
            a[0, 2] = 10;
            a[1, 0] = 20;
            a[1, 1] = 20;
            a[1, 2] = 20;
            a[2, 0] = 30;
            a[2, 1] = 30;
            a[2, 2] = 30;

            Matrix b = new Matrix(3, 1);
            b[0, 0] = 10;
            b[1, 0] = 10;
            b[2, 0] = 10;

            Matrix c = a + b;
            Matrix d = a - b;

            bool equality = true;
            equality &= (c[0, 0] == 20);
            equality &= (c[0, 1] == 20);
            equality &= (c[0, 2] == 20);
            equality &= (c[1, 0] == 30);
            equality &= (c[1, 1] == 30);
            equality &= (c[1, 2] == 30);
            equality &= (c[2, 0] == 40);
            equality &= (c[2, 1] == 40);
            equality &= (c[2, 2] == 40);

            equality &= (d[0, 0] == 0);
            equality &= (d[0, 1] == 0);
            equality &= (d[0, 2] == 0);
            equality &= (d[1, 0] == 10);
            equality &= (d[1, 1] == 10);
            equality &= (d[1, 2] == 10);
            equality &= (d[2, 0] == 20);
            equality &= (d[2, 1] == 20);
            equality &= (d[2, 2] == 20);

            Assert.IsTrue(equality, "Broadcasting in addition / subtraction is successful.");
        }

        [TestMethod]
        public void MatrixDropout()
        {
            Matrix mat = new Matrix(10, 1);
            mat.InRandomize();
            mat.InDropout(1.0f);

            bool condition = true;
<<<<<<< Updated upstream
            condition &= (mat[0, 0] == 0.0);
            condition &= (mat[1, 0] == 0.0);
            condition &= (mat[2, 0] == 0.0);
            condition &= (mat[3, 0] == 0.0);
            condition &= (mat[4, 0] == 0.0);
            condition &= (mat[5, 0] == 0.0);
            condition &= (mat[6, 0] == 0.0);
            condition &= (mat[7, 0] == 0.0);
            condition &= (mat[8, 0] == 0.0);
            condition &= (mat[9, 0] == 0.0);

            Assert.IsTrue(condition, "Dropout is successful.");
=======
            condition &= (c[0, 0] == 20);
            condition &= (c[0, 1] == 20);
            condition &= (c[0, 2] == 20);
            condition &= (c[1, 0] == 30);
            condition &= (c[1, 1] == 30);
            condition &= (c[1, 2] == 30);
            condition &= (c[2, 0] == 40);
            condition &= (c[2, 1] == 40);
            condition &= (c[2, 2] == 40);

            condition &= (d[0, 0] == 0);
            condition &= (d[0, 1] == 0);
            condition &= (d[0, 2] == 0);
            condition &= (d[1, 0] == 10);
            condition &= (d[1, 1] == 10);
            condition &= (d[1, 2] == 10);
            condition &= (d[2, 0] == 20);
            condition &= (d[2, 1] == 20);
            condition &= (d[2, 2] == 20);

            Assert.IsTrue(condition, "Broadcasting in addition / subtraction is successful.");
=======
            var a = new Matrix(3, 3)
            {
                [0, 0] = 10,
                [0, 1] = 10,
                [0, 2] = 10,
                [1, 0] = 20,
                [1, 1] = 20,
                [1, 2] = 20,
                [2, 0] = 30,
                [2, 1] = 30,
                [2, 2] = 30
            };

            var b = new Matrix(3, 1) {[0, 0] = 10, [1, 0] = 10, [2, 0] = 10};

            var c = a + b;
            var d = a - b;

            var equality = true;
            equality &= Math.Abs(c[0, 0] - 20) < 0.01;
            equality &= Math.Abs(c[0, 1] - 20) < 0.01;
            equality &= Math.Abs(c[0, 2] - 20) < 0.01;
            equality &= Math.Abs(c[1, 0] - 30) < 0.01;
            equality &= Math.Abs(c[1, 1] - 30) < 0.01;
            equality &= Math.Abs(c[1, 2] - 30) < 0.01;
            equality &= Math.Abs(c[2, 0] - 40) < 0.01;
            equality &= Math.Abs(c[2, 1] - 40) < 0.01;
            equality &= Math.Abs(c[2, 2] - 40) < 0.01;

            equality &= Math.Abs(d[0, 0]) < 0.01;
            equality &= Math.Abs(d[0, 1]) < 0.01;
            equality &= Math.Abs(d[0, 2]) < 0.01;
            equality &= Math.Abs(d[1, 0] - 10) < 0.01;
            equality &= Math.Abs(d[1, 1] - 10) < 0.01;
            equality &= Math.Abs(d[1, 2] - 10) < 0.01;
            equality &= Math.Abs(d[2, 0] - 20) < 0.01;
            equality &= Math.Abs(d[2, 1] - 20) < 0.01;
            equality &= Math.Abs(d[2, 2] - 20) < 0.01;

            Assert.IsTrue(equality, "Broadcasting in addition / subtraction is successful.");
        }

        [TestMethod]
        public void MatrixDropout()
        {
            var mat = new Matrix(10, 1);
            mat.InRandomize();
            mat.InDropout(1.0f);

            var condition = true;
            condition &= Math.Abs(mat[0, 0]) < 0.01;
            condition &= Math.Abs(mat[1, 0]) < 0.01;
            condition &= Math.Abs(mat[2, 0]) < 0.01;
            condition &= Math.Abs(mat[3, 0]) < 0.01;
            condition &= Math.Abs(mat[4, 0]) < 0.01;
            condition &= Math.Abs(mat[5, 0]) < 0.01;
            condition &= Math.Abs(mat[6, 0]) < 0.01;
            condition &= Math.Abs(mat[7, 0]) < 0.01;
            condition &= Math.Abs(mat[8, 0]) < 0.01;
            condition &= Math.Abs(mat[9, 0]) < 0.01;

            Assert.IsTrue(condition, "Dropout is successful.");
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        }

        [TestMethod]
        public void MatrixOneMinus()
        {
<<<<<<< Updated upstream
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 11;
            mat[1, 0] = 20;
            mat[1, 1] = 21;

            mat.InOneMinus();
=======
<<<<<<< Updated upstream
            Matrix a = new Matrix(2, 2);
            a.InRandomize();
=======
            var mat = new Matrix(2, 2) {[0, 0] = 10, [0, 1] = 11, [1, 0] = 20, [1, 1] = 21};

            mat.InOneMinus();

            var condition = true;
            condition &= Math.Abs(mat[0, 0] - (1 - 10)) < 0.01;
            condition &= Math.Abs(mat[0, 1] - (1 - 11)) < 0.01;
            condition &= Math.Abs(mat[1, 0] - (1 - 20)) < 0.01;
            condition &= Math.Abs(mat[1, 1] - (1 - 21)) < 0.01;
>>>>>>> Stashed changes
>>>>>>> Stashed changes

            bool condition = true;
            condition &= (mat[0, 0] == (1 - 10));
            condition &= (mat[0, 1] == (1 - 11));
            condition &= (mat[1, 0] == (1 - 20));
            condition &= (mat[1, 1] == (1 - 21));

<<<<<<< Updated upstream
            Assert.IsTrue(condition, "Dropout is successful.");
        }

        [TestMethod]
        public void MatrixOneOver()
        {
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 11;
            mat[1, 0] = 20;
            mat[1, 1] = 21;

            mat.InOneOver();

            bool condition = true;
            condition &= (mat[0, 0] == (1.0 / 10.0));
            condition &= (mat[0, 1] == (1.0 / 11.0));
            condition &= (mat[1, 0] == (1.0 / 20.0));
            condition &= (mat[1, 1] == (1.0 / 21.0));

            Assert.IsTrue(condition, "Dropout is successful.");
=======
<<<<<<< Updated upstream
            int mergePoint;
            Matrix c = a.Merge(b, out mergePoint);

            bool condition = true;
            condition &= (c[0, 0] == a[0, 0]);
            condition &= (c[1, 0] == a[0, 1]);
            condition &= (c[2, 0] == a[1, 0]);
            condition &= (c[3, 0] == a[1, 1]);
            condition &= (c[4, 0] == b[0, 0]);
            condition &= (c[5, 0] == b[0, 1]);
            condition &= (c[6, 0] == b[1, 0]);
            condition &= (c[7, 0] == b[1, 1]);

            Assert.IsTrue(condition, "Merge is successful.");
=======
        [TestMethod]
        public void MatrixOneOver()
        {
            var mat = new Matrix(2, 2) {[0, 0] = 10, [0, 1] = 11, [1, 0] = 20, [1, 1] = 21};

            mat.InOneOver();

            var condition = true;
            condition &= Math.Abs(mat[0, 0] - 1.0 / 10.0) < 0.01;
            condition &= Math.Abs(mat[0, 1] - 1.0 / 11.0) < 0.01;
            condition &= Math.Abs(mat[1, 0] - 1.0 / 20.0) < 0.01;
            condition &= Math.Abs(mat[1, 1] - 1.0 / 21.0) < 0.01;

            Assert.IsTrue(condition, "Dropout is successful.");
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        }

        [TestMethod]
        public void MatrixPower2()
        {
<<<<<<< Updated upstream
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 11;
            mat[1, 0] = 20;
            mat[1, 1] = 21;
=======
<<<<<<< Updated upstream
            // Vector Transpose Test
            Matrix v = new Matrix(1, 4);
            v.InRandomize();
=======
            var mat = new Matrix(2, 2) {[0, 0] = 10, [0, 1] = 11, [1, 0] = 20, [1, 1] = 21};
>>>>>>> Stashed changes
>>>>>>> Stashed changes

            mat.InPower2();

<<<<<<< Updated upstream
            bool condition = true;
            condition &= (mat[0, 0] == (100));
            condition &= (mat[0, 1] == (121));
            condition &= (mat[1, 0] == (400));
            condition &= (mat[1, 1] == (441));

<<<<<<< Updated upstream
=======
            Assert.IsTrue(condition, "Split is successful.");
=======
            var condition = true;
            condition &= Math.Abs(mat[0, 0] - 100) < 0.01;
            condition &= Math.Abs(mat[0, 1] - 121) < 0.01;
            condition &= Math.Abs(mat[1, 0] - 400) < 0.01;
            condition &= Math.Abs(mat[1, 1] - 441) < 0.01;

>>>>>>> Stashed changes
            Assert.IsTrue(condition, "Dropout is successful.");
        }

        [TestMethod]
        public void MatrixSoftmax()
        {
<<<<<<< Updated upstream
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 20;
            mat[1, 0] = 30;
            mat[1, 1] = 40;

            mat.InSoftmax();

            bool condition = true;
            condition &= (mat[0, 0] == (10.0 / 100.0));
            condition &= (mat[0, 1] == (20.0 / 100.0));
            condition &= (mat[1, 0] == (30.0 / 100.0));
            condition &= (mat[1, 1] == (40.0 / 100.0));
=======
            var mat = new Matrix(2, 2) {[0, 0] = 10, [0, 1] = 20, [1, 0] = 30, [1, 1] = 40};

            mat.InSoftmax();

            var condition = true;
            condition &= Math.Abs(mat[0, 0] - 10.0 / 100.0) < 0.01;
            condition &= Math.Abs(mat[0, 1] - 20.0 / 100.0) < 0.01;
            condition &= Math.Abs(mat[1, 0] - 30.0 / 100.0) < 0.01;
            condition &= Math.Abs(mat[1, 1] - 40.0 / 100.0) < 0.01;

            Assert.IsTrue(condition, "Dropout is successful.");
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        }
    }
}