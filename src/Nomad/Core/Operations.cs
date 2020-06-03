// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using Nomad.Utility;

namespace Nomad.Core
{
    public partial class Matrix
    {
        #region Transpose

        /// <summary>
        /// Get the transposed Matrix
        /// </summary>
        /// <returns>The transposed Matrix</returns>
        public Matrix Transpose()
        {
            var mat = Duplicate();
            mat.InTranspose();
            return mat;
        }

        /// <summary>
        /// Transpose the matrix inplace
        /// </summary>
        public void InTranspose()
        {
            var result = new double[Columns, Rows];

            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                result[col, row] = _matrix[row, col];

            _matrix = result;
        }

        /// <summary>
        /// Get the transposed Matrix
        /// </summary>
        /// <returns>The transposed Matrix</returns>
        // ReSharper disable once InconsistentNaming
        public Matrix T()
        {
            var mat = Duplicate();
            mat.InT();
            return mat;
        }

        /// <summary>
        /// Transpose the matrix inplace
        /// </summary>
        public void InT()
        {
            InTranspose();
        }

        #endregion

        #region Sum, Mean and Variance
        
        /// <summary>
        /// Sum of Matrix
        /// </summary>
        /// <returns>Sum of all the elements of the Matrix</returns>
        public double Sum()
        {
            var sum = 0.0;
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                sum += _matrix[row, col];
            return sum;
        }

        /// <summary>
        /// Average of Matrix
        /// </summary>
        /// <returns>Sum of all the elements of the Matrix divided by the number of elements</returns>
        public double Average()
        {
            var avg = 0.0;
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                avg += _matrix[row, col];
            avg /= Rows * Columns;
            return avg;
        }

        /// <summary>
        /// Mean of Matrix
        /// </summary>
        /// <returns>Sum of all the elements of the Matrix divided by the number of elements</returns>
        public double Mean()
        {
            return Average();
        }

        /// <summary>
        /// Variance of Matrix
        /// </summary>
        /// <returns>Measure of the spread between the values compared to the average.</returns>
        public double Variance()
        {
            var mat = Duplicate();
            var mean = mat.Mean();

            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
            {
                mat[i, j] -= mean;
                mat[i, j] = Math.Pow(mat[i, j], 2);
            }

            return mat.Sum() / (Rows * Columns);
        }

        #endregion

        #region Mathematical Operations

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="value">Value Parameter</param>
        /// <returns>Sum of matrix and value</returns>
        public Matrix Add(double value)
        {
            var mat = new Matrix(1, 1, value);
            return Add(mat);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="value">Value Parameter</param>
        /// <returns>Sum of matrix and value</returns>
        public void InAdd(double value)
        {
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] += value;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>Sum of two matrices</returns>
        public Matrix Add(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InAdd(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Add
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InAdd(Matrix matrix)
        {
            if (matrix.Shape().Type() == EType.Scalar)
            {
                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] += matrix[0, 0];
                return;
            }

            var transpose = false;
            // Vector Broadcasting
            if (matrix.Shape().Type() == EType.VectorTransposed)
            {
                transpose = true;
                matrix.InTranspose();
                InTranspose();
            }

            if (matrix.Shape().Type() == EType.Vector)
            {
                if (Rows != matrix.Rows) throw new InvalidOperationException("Cannot broadcast Vector.");

                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] += matrix[row, 0];
                if (!transpose) return;
                matrix.InTranspose();
                InTranspose();
                return;
            }

            // Regular Addition
            if (Rows != matrix.Rows || Columns != matrix.Columns)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] += matrix[row, col];
        }

        /// <summary>
        /// Sub
        /// </summary>
        /// <param name="value">Value Parameter</param>
        /// <returns>Difference of matrix and value</returns>
        public Matrix Sub(double value)
        {
            var mat = new Matrix(1, 1, value);
            return Sub(mat);
        }

        /// <summary>
        /// Sub
        /// </summary>
        /// <param name="value">Value Parameter</param>
        /// <returns>Difference of matrix and value</returns>
        public void InSub(double value)
        {
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] -= value;
        }

        /// <summary>
        /// Subtract
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>Difference of two matrices</returns>
        public Matrix Sub(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InSub(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Subtract
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InSub(Matrix matrix)
        {
            if (matrix.Shape().Type() == EType.Scalar)
            {
                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] -= matrix[0, 0];
                return;
            }

            var transpose = false;

            // Vector Broadcasting
            if (matrix.Shape().Type() == EType.VectorTransposed)
            {
                transpose = true;
                matrix.InTranspose();
                InTranspose();
            }

            if (matrix.Shape().Type() == EType.Vector)
            {
                if (Rows != matrix.Rows) throw new InvalidOperationException("Cannot broadcast Vector.");

                for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] -= matrix[row, 0];
                if (!transpose) return;
                matrix.InTranspose();
                InTranspose();
                return;
            }

            // Regular Subtraction
            if (Rows != matrix.Rows || Columns != matrix.Columns)
                throw new InvalidOperationException("Cannot sub matrices of different sizes.");
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] -= matrix[row, col];
        }

        /// <summary>
        /// Scale
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>The scale product</returns>
        public Matrix Scale(double value)
        {
            return Duplicate().Hadamard(value);
        }

        /// <summary>
        /// Scale
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>The scale product</returns>
        public void InScale(double value)
        {
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] *= value;
        }

        /// <summary>
        /// Hadamard
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>The hadamard product</returns>
        public Matrix Hadamard(double value)
        {
            var mat = Duplicate();
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                mat[row, col] *= value;
            return mat;
        }

        /// <summary>
        /// Hadamard Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>The element-wise multiplication product</returns>
        public Matrix Hadamard(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InHadamard(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Hadamard Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InHadamard(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");

            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] *= matrix[row, col];
        }

        /// <summary>
        /// Divide
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>The division product</returns>
        public Matrix Divide(double value)
        {
            return Duplicate().HadamardDivision(value);
        }

        /// <summary>
        /// Divide
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>The division product</returns>
        public void InDivide(double value)
        {
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] /= value;
        }

        /// <summary>
        /// Divide
        /// </summary>
        /// <param name="value">Matrix parameter</param>
        /// <returns>The division product</returns>
        public Matrix HadamardDivision(double value)
        {
            var mat = Duplicate();
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                mat[row, col] /= value + double.Epsilon;
            return mat;
        }

        /// <summary>
        /// Hadamard Division Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>The element-wise division product</returns>
        public Matrix HadamardDivision(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InHadamardDivision(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Hadamard Division Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InHadamardDivision(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");

            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] /= matrix[row, col] + double.Epsilon;
        }
        
        /// <summary>
        /// Calclate the power of matrix 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>The product of matrix to the power of a number</returns>
        public Matrix Power(double p = 2.0)
        {
            var mat = Duplicate();
            mat.InPower(p);
            return mat;
        }

        /// <summary>
        /// Inplacely calculate the power of matrix
        /// </summary>
        /// <param name="p"></param>
        public void InPower(double p = 2.0)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = Math.Pow(_matrix[row, col], p);
        }

        /// <summary>
        /// Hadamard Power Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>The element-wise power product</returns>
        public Matrix HadamardPower(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InHadamardPower(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Hadamard Power Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InHadamardPower(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new InvalidOperationException("Cannot evaluate matrices of different sizes.");

            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] = Math.Pow(_matrix[row, col], matrix[row, col]);
        }

        /// <summary>
        /// Calclate the root of matrix 
        /// </summary>
        /// <param name="r">Root parameter</param>
        /// <returns>The product of matrix to the root of a number</returns>
        public Matrix Root(double r = 2.0)
        {
            var mat = Duplicate();
            mat.InPower(r);
            return mat;
        }

        /// <summary>
        /// Inplacely calculate the root of matrix
        /// </summary>
        /// <param name="r">Root parameter</param>
        public void InRoot(double r = 2.0)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = Math.Pow(_matrix[row, col], 1.0 / (r + double.Epsilon));
        }

        /// <summary>
        /// Hadamard Root Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>The element-wise root product</returns>
        public Matrix HadamardRoot(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InHadamardRoot(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Hadamard Power Product
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InHadamardRoot(Matrix matrix)
        {
            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new InvalidOperationException("Cannot evaluate matrices of different sizes.");

            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                _matrix[row, col] = Math.Pow(_matrix[row, col], 1.0 / (matrix[row, col] + double.Epsilon));
        }

        /// <summary>
        /// Dot Product 
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>(a . b)</returns>
        public Matrix Dot(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InDot(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Dot Product 
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
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

        /// <summary>
        /// Dot Division Product 
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <returns>Dot division product</returns>
        public Matrix DotDivision(Matrix matrix)
        {
            var mat = Duplicate();
            mat.InDotDivision(matrix);
            return mat;
        }

        /// <summary>
        /// Inplace Dot Division Product 
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        public void InDotDivision(Matrix matrix)
        {
            if (Columns != matrix.Rows)
                throw new InvalidOperationException("Cannot evaluate on matrices of different sizes.");

            var result = new double[Rows, matrix.Columns];
            for (var row = 0; row < Rows; row++)
            for (var col = 0; col < matrix.Columns; col++)
            {
                double sum = 0;
                for (var i = 0; i < Columns; i++) sum += _matrix[row, i] / (matrix[i, col] + double.Epsilon);
                result[row, col] = sum;
            }

            _matrix = result;
        }

        /// <summary>
        /// Calculate the inverse of a square matrix.
        /// </summary>
        public Matrix Inverse()
        {
            var mat = Duplicate();
            mat.InInverse();
            return mat;
        }

        /// <summary>
        /// Inplacely calculate the inverse of a square matrix.
        /// </summary>
        public void InInverse()
        {
            if (Rows != Columns) throw new InvalidOperationException("Only square matrices can be inverted.");

            var dimension = Rows;

            if (!(_matrix.Clone() is double[,] result)) throw new InvalidOperationException("Fatal Error!");
            if (!(_matrix.Clone() is double[,] identity)) throw new InvalidOperationException("Fatal Error!");

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

        /// <summary>
        /// Return a filled matrix with the same shape
        /// </summary>
        /// <param name="value">Value parameter</param>
        /// <returns>A filled matrix with the same shape</returns>
        public Matrix Fill(double value)
        {
            var mat = Duplicate();
            mat.InFill(value);
            return mat;
        }

        /// <summary>
        /// Fill the matrix
        /// </summary>
        /// <param name="value">Value parameter</param>
        public void InFill(double value)
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = value;
        }

        /// <summary>
        /// ArgMax Index in a flattened matrix
        /// </summary>
        public int ArgMaxIndex()
        {
            var tmp = double.NegativeInfinity;
            var x = 0; var y = 0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                if (_matrix[row, col] >= tmp)
                {
                    tmp = _matrix[row, col];
                    x = row; y = col;
                }
            return x * y;
        }

        /// <summary>
        /// Argmax of the Matrix
        /// </summary>
        public Matrix ArgMax()
        {
            var mat = Duplicate();
            mat.InArgMax();
            return mat;
        }

        /// <summary>
        /// Inplace Argmax of the Matrix
        /// </summary>
        public void InArgMax()
        {
            var tmp = double.NegativeInfinity;
            var x = 0; var y = 0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                if (_matrix[row, col] >= tmp)
                {
                    tmp = _matrix[row, col];
                    x = row; y = col;
                }
            InFill(0);
            _matrix[x, y] = 1.0;
        }

        /// <summary>
        /// ArgMin Index in a flattened matrix
        /// </summary>
        public int ArgMinIndex()
        {
            var tmp = double.PositiveInfinity;
            var x = 0; var y = 0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                if (_matrix[row, col] <= tmp)
                {
                    tmp = _matrix[row, col];
                    x = row; y = col;
                }
            return x * y;
        }

        /// <summary>
        /// Inplace Argmin of the Matrix
        /// </summary>
        public Matrix ArgMin()
        {
            var mat = Duplicate();
            mat.InArgMin();
            return mat;
        }

        /// <summary>
        /// Inplace Argmin of the Matrix
        /// </summary>
        public void InArgMin()
        {
            var tmp = double.PositiveInfinity;
            var x = 0; var y = 0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                if (_matrix[row, col] <= tmp)
                {
                    tmp = _matrix[row, col];
                    x = row; y = col;
                }
            InFill(0);
            _matrix[x, y] = 1.0;
        }
        
        /// <summary>
        /// Cummulative Sum Matrix of all elements
        /// </summary>
        public Matrix Cumsum()
        {
            var mat = Duplicate();
            mat.InCumsum();
            return mat;
        }

        /// <summary>
        /// Fill the matrix with Cummulative Sum of all it's elements
        /// </summary>
        public void InCumsum()
        {
            var vec = Flatten();
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
            {
                var sum = 0.0;
                for (var index = 0; index < row * col; index++) sum += vec[index, 0];
                _matrix[row, col] = sum;
            }
        }

        /// <summary>
        /// Main Diagonal of the Matrix as a Vector
        /// </summary>
        public Matrix Diagonal()
        {
            var max = Math.Max(Rows, Columns);
            var result = new Matrix(max, 1);
            for (var i = 0; i < max; i++) result[i, 0] = _matrix[max, max];
            return result;
        }

        /// <summary>
        /// Replace the matrix with a vector containing the Main Diagonal of the Matrix
        /// </summary>
        public void InDiagonal()
        {
            var max = Math.Max(Rows, Columns);
            var result = new Matrix(max, 1);
            for (var i = 0; i < max; i++) result[i, 0] = _matrix[max, max];

            InReshape(max, 1);
            for (var i = 0; i < max; i++) _matrix[max, 0] = result[i, 0];
        }

        /// <summary>
        /// Main Diagonal of the Matrix as a Matrix
        /// </summary>
        public Matrix FullDiagonal()
        {
            var max = Math.Max(Rows, Columns);
            var result = new Matrix(max, max).Fill(0.0);
            for (var i = 0; i < max; i++) result[i, i] = _matrix[max, max];
            return result;
        }

        /// <summary>
        /// Inplace Main Diagonal of the Matrix as a Matrix
        /// </summary>
        public void InFullDiagonal()
        {
            var max = Math.Max(Rows, Columns);
            var result = new Matrix(max, 0);
            for (var i = 0; i < max; i++) result[i, 0] = _matrix[max, max];

            InReshape(max, max);
            InFill(0.0);
            for (var i = 0; i < max; i++) _matrix[max, max] = result[i, i];
        }

        /// <summary>
        /// Rounds the Matrix values
        /// </summary>
        public Matrix Round()
        {
            var mat = Duplicate();
            mat.InRound();
            return mat;
        }

        /// <summary>
        /// Rounds the Matrix values In Place
        /// </summary>
        public void InRound()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = Math.Round(_matrix[row, col]);
        }

        /// <summary>
        /// Ceiling Operation on all Matrix elements
        /// </summary>
        public Matrix Ceiling()
        {
            var mat = Duplicate();
            mat.InCeiling();
            return mat;
        }

        /// <summary>
        /// Ceiling Operation on all Matrix elements In Place
        /// </summary>
        public void InCeiling()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = Math.Ceiling(_matrix[row, col]);
        }

        /// <summary>
        /// Floor Operation on all Matrix elements
        /// </summary>
        public Matrix Floor()
        {
            var mat = Duplicate();
            mat.InFloor();
            return mat;
        }

        /// <summary>
        /// Floor Operation on all Matrix elements In Place
        /// </summary>
        public void InFloor()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
                _matrix[row, col] = Math.Floor(_matrix[row, col]);
        }

        #endregion
    }
}