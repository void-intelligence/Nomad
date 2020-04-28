// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

/********************************************\
         Primary Matrix class logic.
\********************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using Nomad.Utility;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        private double[,] _matrix;

        public int Rows => _matrix.GetLength(0);

        public int Columns => _matrix.GetLength(1);

        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        public Matrix(int rows, int columns)
        {
            _matrix = new double[rows, columns];
        }

        public Matrix(int m) : this(m, m)
        {
        }

        #region Dot Product

        public void InDot(Matrix matrix)
        {
            if (Columns != matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");

            var result = new double[Rows, matrix.Columns];
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < matrix.Columns; col++)
            {
                double sum = 0;
                for (var i = 0; i < Columns; i++) sum += _matrix[row, i] * matrix[i, col];
                result[row, col] = sum;
            }

            _matrix = result;
        }

        public Matrix Dot(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InDot(matrix);
            return mat;
        }

        #endregion

        #region Hadamard (Element Multiplication)

        public void InHadamard(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");

            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] *= matrix[row, col];
        }

        public Matrix Hadamard(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InHadamard(matrix);
            return mat;
        }

        #endregion

        #region Scale Operation

        public void InScale(double scalar)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] *= scalar;
        }

        public Matrix Scale(double scalar)
        {
            var mat = Duplicate();
            mat.InScale(scalar);
            return mat;
        }

        #endregion

        #region Add Operation

        public void InAdd(Matrix matrix)
        {
            var transpose = false;
            // Vector Broadcasting
            if (matrix.Shape().Type() == EType.VectorTransposed)
            {
                transpose = true;
                matrix.InTranspose();
            }

            if (matrix.Shape().Type() == EType.Vector)
            {
                if (Rows != matrix.Rows) throw new InvalidOperationException("Cannot broadcast Vector.");

                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] += matrix[row, 0];
                if (transpose) matrix.InTranspose();
                return;
            }

            // Regular Addition
            if (Rows != matrix.Rows || Columns != matrix.Columns)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] += matrix[row, col];
        }

        public Matrix Add(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InAdd(matrix);
            return mat;
        }

        #endregion

        #region Subtraction Operation

        public void InSub(Matrix matrix)
        {
            var transpose = false;

            // Vector Broadcasting
            if (matrix.Shape().Type() == EType.VectorTransposed)
            {
                transpose = true;
                matrix.InTranspose();
            }

            if (matrix.Shape().Type() == EType.Vector)
            {
                if (Rows != matrix.Rows) throw new InvalidOperationException("Cannot broadcast Vector.");

                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] -= matrix[row, 0];
                if (transpose) matrix.InTranspose();
                return;
            }

            // Regular Subtraction
            if (Rows != matrix.Rows || Columns != matrix.Columns)
                throw new InvalidOperationException("Cannot sub matrices of different sizes.");
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] -= matrix[row, col];
        }

        public Matrix Sub(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InSub(matrix);
            return mat;
        }

        #endregion

        #region Inverse Operation

        public void InInverse()
        {
            if (Rows != Columns) throw new InvalidOperationException("Only square matrices can be inverted.");

            var dimension = Rows;
            var result = _matrix.Clone() as double[,];
            var identity = _matrix.Clone() as double[,];

            if (result == null) throw new InvalidOperationException("Fatal Error!");
            if (identity == null) throw new InvalidOperationException("Fatal Error!");

            //make identity matrix
            for (var row = 0; row < dimension; row++)
            for (var col = 0; col < dimension; col++)
                identity[row, col] = row == col ? 1.0 : 0.0;

            //invert
            for (var i = 0; i < dimension; i++)
            {
                var tmp = result[i, i];
                for (var j = 0; j < dimension; j++)
                {
                    result[i, j] = result[i, j] / tmp;
                    identity[i, j] = identity[i, j] / tmp;
                }

                for (var k = 0; k < dimension; k++)
                {
                    if (i == k) continue;
                    tmp = result[k, i];
                    for (var n = 0; n < dimension; n++)
                    {
                        result[k, n] = result[k, n] - tmp * result[i, n];
                        identity[k, n] = identity[k, n] - tmp * identity[i, n];
                    }
                }
            }

            _matrix = identity;
        }

        public Matrix Inverse()
        {
            var mat = Duplicate();
            mat.InInverse();
            return mat;
        }

        #endregion

        #region Transpose Operation

        public void InTranspose()
        {
            var result = new double[Columns, Rows];

            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                result[col, row] = _matrix[row, col];

            _matrix = result;
        }

        public Matrix Transpose()
        {
            var mat = Duplicate();
            mat.InTranspose();
            return mat;
        }

        public void InT()
        {
            InTranspose();
        }

        public Matrix T()
        {
            var mat = Duplicate();
            mat.InTranspose();
            return mat;
        }

        #endregion

        #region Map Functionality

        public void InMap(Func<double, double> func)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = func(_matrix[row, col]);
        }

        public Matrix Map(Func<double, double> func)
        {
            var mat = Duplicate();
            mat.InMap(func);
            return mat;
        }

        #endregion

        #region Randomization

        public void InRandomize(double lowest = 0.0, double highest = 1.0,
            EDistribution distribution = EDistribution.Uniform)
        {
            var diff = highest - lowest;
            switch (distribution)
            {
                case EDistribution.Invalid:
                {
                    throw new InvalidOperationException("Invalid Random Distribution Mode!");
                }
                case EDistribution.Uniform:
                {
                    var random = new Random();
                    for (var row = 0; row < _matrix.GetLength(0); row++)
                    for (var col = 0; col < _matrix.GetLength(1); col++)
                        _matrix[row, col] = random.NextDouble() * diff + lowest;

                    break;
                }
                case EDistribution.Gaussian:
                {
                    var dispersion = diff / 2;
                    var random = new Random(); //reuse this if you are generating many
                    for (var row = 0; row < _matrix.GetLength(0); row++)
                    for (var col = 0; col < _matrix.GetLength(1); col++)
                    {
                        //uniform(0,1] random doubles
                        var u1 = 1.0 - random.NextDouble();
                        var u2 = 1.0 - random.NextDouble();

                        //random normal(0,1)
                        var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

                        //random normal(mean,stdDev^2)
                        var randNormal = 0 + dispersion * randStdNormal;

                        _matrix[row, col] = randNormal;
                    }

                    break;
                }
            }
        }

        public Matrix Randomize(double lowest = 0.0, double highest = 1.0,
            EDistribution distribution = EDistribution.Uniform)
        {
            var mat = Duplicate();
            mat.InRandomize(lowest, highest, distribution);
            return mat;
        }

        #endregion

        #region Fill

        public void InFill(double value)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = value;
        }

        public Matrix Fill(double value)
        {
            var mat = Duplicate();
            mat.InFill(value);
            return mat;
        }

        #endregion

        #region Flatten & Widen Functionality

        public void InFlatten()
        {
            _matrix = Flatten()._matrix;
        }

        public Matrix Flatten()
        {
            var result = new Matrix(Rows * Columns, 1);
            var k = 0;
            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
            {
                result[k, 0] = _matrix[i, j];
                k++;
            }

            return result;
        }

        public void InWiden(int newX, int newY)
        {
            _matrix = Widen(newX, newY)._matrix;
        }

        public Matrix Widen(int newX, int newY)
        {
            if (Rows != newX * newY) throw new InvalidOperationException("Invalid matrix size.");

            var transpose = false;
            if (Type() != EType.Vector && Type() != EType.VectorTransposed)
                throw new InvalidOperationException("Cannot widen a non-vector matrix.");
            if (Type() == EType.VectorTransposed)
            {
                InTranspose();
                transpose = true;
            }

            var result = new Matrix(newX, newY);

            var k = 0;
            for (var i = 0; i < newX; i++)
            for (var j = 0; j < newY; j++)
            {
                result[i, j] = this[k, 0];
                k++;
            }

            if (transpose) InTranspose();

            return result;
        }

        public void InReshape(int newX, int newY)
        {
            _matrix = Reshape(newX, newY)._matrix;
        }

        public Matrix Reshape(int newX, int newY)
        {
            var flattened = Flatten();

            var shape = flattened.Shape();
            // Flatten
            if (shape.X == newX && shape.Y == newY) return flattened;
            // Flatten Transpose
            if (shape.X == newY && shape.Y == newX) return flattened.Transpose();

            var widened = flattened.Widen(newX, newY);
            return widened;
        }

        #endregion

        #region Element-Wise Function Operations

        public void InOneMinus()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = 1 - _matrix[row, col];
        }

        public Matrix OneMinus()
        {
            var mat = Duplicate();
            mat.InOneMinus();
            return mat;
        }

        public void InOneOver()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = 1 / _matrix[row, col];
        }

        public Matrix OneOver()
        {
            var mat = Duplicate();
            mat.InOneOver();
            return mat;
        }

        public void InPower2()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = _matrix[row, col] * _matrix[row, col];
        }

        public Matrix Power2()
        {
            var mat = Duplicate();
            mat.InPower2();
            return mat;
        }

        #endregion

        #region Softmax

        public void InSoftmax()
        {
            var sum = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                sum += _matrix[row, col];
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = _matrix[row, col] / sum;
        }

        public Matrix Softmax()
        {
            var mat = Duplicate();
            mat.InSoftmax();
            return mat;
        }

        #endregion

        #region Merge / Split

        public void InMerge(Matrix matrix, out int mergeIndex)
        {
            _matrix = Merge(matrix, out mergeIndex)._matrix;
        }

        public Matrix Merge(Matrix matrix, out int mergeIndex)
        {
            var av = Flatten();
            var bv = matrix.Flatten();
            var result = new Matrix(av.Rows + bv.Rows, 1);

            var k = 0;

            // Append vector a to result
            for (var i = 0; i < av.Rows; i++)
            {
                result[k, 0] = av[i, 0];
                k++;
            }

            // Append vector b to result
            for (var i = 0; i < bv.Rows; i++)
            {
                result[k, 0] = bv[i, 0];
                k++;
            }

            mergeIndex = av.Rows;
            return result;
        }

        public List<Matrix> Split(int mergeIndex)
        {
            // If current matrix is a transposed vector (1, n)
            // Transpose it inplace so it'll be proper
            var transpose = false;
            if (Type() == EType.VectorTransposed)
            {
                transpose = true;
                InT();
            }

            if (Type() != EType.Vector) throw new InvalidOperationException("Split can only work on vectors");

            var result = new List<Matrix>();
            var a = Flatten();

            var len0 = mergeIndex;
            var len1 = a.Rows - mergeIndex;

            var res0 = new Matrix(len0, 1);
            var res1 = new Matrix(len1, 1);

            var count = 0;
            for (var i = 0; i < len0; i++)
            {
                res0[i, 0] = a[count, 0];
                count++;
            }

            for (var i = 0; i < len1; i++)
            {
                res1[i, 0] = a[count, 0];
                count++;
            }

            result.Add(res0);
            result.Add(res1);

            if (transpose) InT();

            return result;
        }

        #endregion

        #region Dropout

        public void InDropout(float chance)
        {
            Math.Clamp(chance, 0.0f, 1.0f);
            var random = new Random();
            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
            {
                var d = (float) random.NextDouble();
                if (d < chance) _matrix[i, j] = 0.0;
            }
        }

        public Matrix Dropout(float chance)
        {
            var result = Duplicate();
            result.InDropout(chance);
            return result;
        }

        #endregion

        #region Utility

        public Matrix Duplicate()
        {
            var result = new Matrix(Rows, Columns);
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                result[row, col] = _matrix[row, col];
            return result;
        }

        public Matrix SubMatrix(int startX, int startY, uint dX, uint dY)
        {
            if (!(startX >= 0 && startX + dX <= Rows && startY >= 0 && startY + dY <= Columns))
                throw new InvalidOperationException("Index out of bounds.");

            var result = new Matrix((int) dX, (int) dY);
            for (var i = startX; i < startX + dX; i++)
            for (var j = startY; j < startY + dY; j++)
                result._matrix[i - startX, j - startY] = _matrix[i, j];

            return result;
        }

        public Shape Shape()
        {
            return new Shape(Rows, Columns);
        }

        public EType Type()
        {
            return Shape().Type();
        }

        public override string ToString()
        {
            var buffer = string.Empty;
            buffer += "[";
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                    buffer += _matrix[row, col].ToString(CultureInfo.InvariantCulture) + ", ";
                buffer += "\n";
            }

            buffer += "]";
            return buffer;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        #endregion
    }
}