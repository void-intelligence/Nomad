// � 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

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
            a[0, 0] = 11;
            a[0, 1] = 12;
            a[0, 2] = 13;
            a[1, 0] = 21;
            a[1, 1] = 22;
            a[1, 2] = 23;
            a[2, 0] = 31;
            a[2, 1] = 32;
            a[2, 2] = 33;

            b[0, 0] = 11;
            b[0, 1] = 12;
            b[0, 2] = 13;
            b[1, 0] = 21;
            b[1, 1] = 22;
            b[1, 2] = 23;
            b[2, 0] = 31;
            b[2, 1] = 32;
            b[2, 2] = 33;

            c[0, 0] = 21;
            c[0, 1] = 12;
            c[0, 2] = 13;
            c[1, 0] = 21;
            c[1, 1] = 22;
            c[1, 2] = 23;
            c[2, 0] = 31;
            c[2, 1] = 32;
            c[2, 2] = 33;

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

            a[0, 0] = 11;
            a[0, 1] = 12;
            a[0, 2] = 13;
            a[1, 0] = 21;
            a[1, 1] = 22;
            a[1, 2] = 23;
            a[2, 0] = 31;
            a[2, 1] = 32;
            a[2, 2] = 33;

            b[0, 0] = 21;
            b[0, 1] = 12;
            b[0, 2] = 13;
            b[1, 0] = 21;
            b[1, 1] = 22;
            b[1, 2] = 23;
            b[2, 0] = 31;
            b[2, 1] = 32;
            b[2, 2] = 33;

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
        }

        [TestMethod]
        public void MatrixMultiplication()
        {
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(3, 2);
            Matrix _trueResult = new Matrix(2);

            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 3;
            a[1, 0] = 4;
            a[1, 1] = 5;
            a[1, 2] = 6;

            b[0, 0] = 1;
            b[0, 1] = 2;
            b[1, 0] = 3;
            b[1, 1] = 4;
            b[2, 0] = 5;
            b[2, 1] = 6;

            _trueResult[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0] + a[0, 2] * b[2, 0];
            _trueResult[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] + a[0, 2] * b[2, 1];
            _trueResult[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0] + a[1, 2] * b[2, 0];
            _trueResult[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1];

            var _calculatedResult = a * b;

            Assert.IsTrue(_calculatedResult == _trueResult, "Multiplication by matrix not correct!");
        }

        [TestMethod]
        public void MatrixMultiplicationScalar()
        {
            Matrix a = new Matrix(3);
            Matrix _trueResult = new Matrix(3);
            double _scalar = 5.0;

            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 3;
            a[1, 0] = 4;
            a[1, 1] = 5;
            a[1, 2] = 6;
            a[2, 0] = 4;
            a[2, 1] = 5;
            a[2, 2] = 6;

            _trueResult[0, 0] = a[0, 0] * _scalar;
            _trueResult[0, 1] = a[0, 1] * _scalar;
            _trueResult[0, 2] = a[0, 2] * _scalar;
            _trueResult[1, 0] = a[1, 0] * _scalar;
            _trueResult[1, 1] = a[1, 1] * _scalar;
            _trueResult[1, 2] = a[1, 2] * _scalar;
            _trueResult[2, 0] = a[2, 0] * _scalar;
            _trueResult[2, 1] = a[2, 1] * _scalar;
            _trueResult[2, 2] = a[2, 2] * _scalar;

            var _calculatedResult = a * _scalar;

            Assert.IsTrue(_calculatedResult == _trueResult, "Multiplication by scalar not correct!");
        }

        [TestMethod]
        public void MatrixInverse()
        {
            Matrix a = new Matrix(3);
            Matrix _trueResult = new Matrix(3);

            a[0, 0] = 1;
            a[0, 1] = 3;
            a[0, 2] = 3;
            a[1, 0] = 1;
            a[1, 1] = 4;
            a[1, 2] = 3;
            a[2, 0] = 1;
            a[2, 1] = 3;
            a[2, 2] = 4;

            _trueResult[0, 0] = 7;
            _trueResult[0, 1] = -3;
            _trueResult[0, 2] = -3;
            _trueResult[1, 0] = -1;
            _trueResult[1, 1] = 1;
            _trueResult[1, 2] = 0;
            _trueResult[2, 0] = -1;
            _trueResult[2, 1] = 0;
            _trueResult[2, 2] = 1;

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

        [TestMethod]
        public void MatrixFill()
        {
            Matrix a = new Matrix(2);
            a.InFill(10);

            Assert.IsTrue(a[0, 0] == 10, "a[1, 1] has the value 10.");
            Assert.IsTrue(a[0, 1] == 10, "a[1, 2] has the value 10.");
            Assert.IsTrue(a[1, 0] == 10, "a[2, 1] has the value 10.");
            Assert.IsTrue(a[1, 1] == 10, "a[2, 2] has the value 10.");
        }

        [TestMethod]
        public void MatrixFlatten()
        {
            Matrix a = new Matrix(2, 2);
            a.InRandomize();

            Matrix b = a.Flatten();

            Assert.IsTrue(a[0, 0] == b[0, 0], "a[0, 0] has the value of b[0, 0].");
            Assert.IsTrue(a[0, 1] == b[1, 0], "a[0, 1] has the value of b[1, 0].");
            Assert.IsTrue(a[1, 0] == b[2, 0], "a[1, 0] has the value of b[2, 0].");
            Assert.IsTrue(a[1, 1] == b[3, 0], "a[1, 1] has the value of b[3, 0].");
        }

        [TestMethod]
        public void MatrixWiden()
        {
            Matrix a = new Matrix(4, 1);
            a.InRandomize();

            Matrix b = a.Widen(2, 2);

            Assert.IsTrue(b[0, 0] == a[0, 0], "b[0, 0] has the value of a[0, 0].");
            Assert.IsTrue(b[0, 1] == a[1, 0], "b[0, 1] has the value of a[1, 0].");
            Assert.IsTrue(b[1, 0] == a[2, 0], "b[1, 0] has the value of a[2, 0].");
            Assert.IsTrue(b[1, 1] == a[3, 0], "b[1, 1] has the value of a[3, 0].");
        }

        [TestMethod]
        public void MatrixTypes()
        {
            Matrix vector = new Matrix(4, 1);
            Matrix square = new Matrix(4, 4);
            Matrix vectorT = new Matrix(1, 4);
            Matrix matrix = new Matrix(4, 3);
            Matrix scalar = new Matrix(1, 1);

            Assert.IsTrue(vector.Type() == Nomad.Utility.EType.Vector, "Vector is a matrix of type Vector.");
            Assert.IsTrue(square.Type() == Nomad.Utility.EType.SquareMatrix, "Square is a matrix of type SquareMatrix.");
            Assert.IsTrue(vectorT.Type() == Nomad.Utility.EType.VectorTransposed, "VectorT is a matrix of type VectorTransposed.");
            Assert.IsTrue(matrix.Type() == Nomad.Utility.EType.Matrix, "Matrix is a matrix of type Matrix.");
            Assert.IsTrue(scalar.Type() == Nomad.Utility.EType.Scalar, "Scalar is a matrix of type Scalar.");
        }

        [TestMethod]
        public void MatrixShape()
        {
            Matrix a = new Matrix(4, 3);

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
            Matrix a = new Matrix(10, 10);
            a.InRandomize();

            Matrix b = a.SubMatrix(3, 3, 5, 5);

            Assert.IsTrue(b[0, 0] == a[3, 3], "b[0, 0] has the value of a[3, 3].");
            Assert.IsTrue(b[0, 1] == a[3, 4], "b[0, 1] has the value of a[3, 4].");
            Assert.IsTrue(b[1, 0] == a[4, 3], "b[1, 0] has the value of a[4, 3].");
            Assert.IsTrue(b[1, 1] == a[4, 4], "b[1, 1] has the value of a[4, 4].");
        }

        [TestMethod]
        public void MatrixDuplicate()
        {
            Matrix a = new Matrix(2, 2);
            a.InRandomize();

            Matrix b = a.Duplicate();

            Assert.IsTrue(a[0, 0] == b[0, 0], "b[0, 0] has the value of a[0, 0].");
            Assert.IsTrue(a[0, 1] == b[0, 1], "b[0, 1] has the value of a[0, 1].");
            Assert.IsTrue(a[1, 0] == b[1, 0], "b[1, 0] has the value of a[1, 0].");
            Assert.IsTrue(a[1, 1] == b[1, 1], "b[1, 1] has the value of a[1, 1].");
        }

        [TestMethod]
        public void MatrixToString()
        {
            Matrix a = new Matrix(1, 1);
            a[0, 0] = 1;
            string fnString = a.ToString();
            string calculatedString = "[1, \n]";
            Assert.IsTrue(fnString == calculatedString, "String calculation is successful.");
        }

        [TestMethod]
        public void MatrixReshape()
        {
            // Regular Reshape
            Matrix a = new Matrix(3, 2);
            a.InRandomize();
            Matrix b = a.Reshape(2, 3);

            bool equality = true;
            equality &= (a[0, 0] == b[0, 0]);
            equality &= (a[0, 1] == b[0, 1]);
            equality &= (a[1, 0] == b[0, 2]);
            equality &= (a[1, 1] == b[1, 0]);
            equality &= (a[2, 0] == b[1, 1]);
            equality &= (a[2, 1] == b[1, 2]);

            Assert.IsTrue(equality, "Reshape operation is successful.");

            // Flatten Reshape    
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

            bool thirdEquality = true;
            thirdEquality &= (a[0, 0] == d[0, 0]);
            thirdEquality &= (a[0, 1] == d[0, 1]);
            thirdEquality &= (a[1, 0] == d[0, 2]);
            thirdEquality &= (a[1, 1] == d[0, 3]);
            thirdEquality &= (a[2, 0] == d[0, 4]);
            thirdEquality &= (a[2, 1] == d[0, 5]);
            Assert.IsTrue(secondEquality, "Flatten Transpose Reshape operation is successful.");
        }

        [TestMethod]
        public void MatrixNormTest()
        {
            Matrix a = new Matrix(3, 3);
            a[0, 0] = 11;
            a[0, 1] = 12;
            a[0, 2] = 13;
            a[1, 0] = 21;
            a[1, 1] = 22;
            a[1, 2] = 23;
            a[2, 0] = 31;
            a[2, 1] = 32;
            a[2, 2] = 33;

            double _Tax = a.TaxicabNorm();
            double _Abs = a.AbsoluteNorm();
            double _Frob = a.EuclideanNorm();
            double _Man = a.ManhattanNorm();
            double _Max = a.MaximumNorm();
            double _P = a.PNorm(3);

            Assert.IsTrue(_Tax == 198, "Max norm operation is successful.");
            Assert.IsTrue(_Abs == 198, "Absolute norm operation is successful.");
            Assert.IsTrue(_Frob == 70.441465061425291, "Euclidean norm operation is successful.");
            Assert.IsTrue(_Man == 198, "Manhattan norm operation is successful.");
            Assert.IsTrue(_Max == 33, "Maximum norm operation is successful.");
            Assert.IsTrue(_P == 51.403943234349725, "P norm operation is successful.");
        }

        [TestMethod]
        public void MatrixBroadcasting()
        {
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
        }

        [TestMethod]
        public void MatrixOneMinus()
        {
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 11;
            mat[1, 0] = 20;
            mat[1, 1] = 21;

            mat.InOneMinus();

            bool condition = true;
            condition &= (mat[0, 0] == (1 - 10));
            condition &= (mat[0, 1] == (1 - 11));
            condition &= (mat[1, 0] == (1 - 20));
            condition &= (mat[1, 1] == (1 - 21));

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
        }

        [TestMethod]
        public void MatrixPower2()
        {
            Matrix mat = new Matrix(2, 2);
            mat[0, 0] = 10;
            mat[0, 1] = 11;
            mat[1, 0] = 20;
            mat[1, 1] = 21;

            mat.InPower2();

            bool condition = true;
            condition &= (mat[0, 0] == (100));
            condition &= (mat[0, 1] == (121));
            condition &= (mat[1, 0] == (400));
            condition &= (mat[1, 1] == (441));

            Assert.IsTrue(condition, "Dropout is successful.");
        }

        [TestMethod]
        public void MatrixSoftmax()
        {
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
        }
    }
}
