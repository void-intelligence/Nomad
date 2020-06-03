// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using System.Collections.Generic;
using Nomad.Utility;

namespace Nomad.Core
{
    public partial class Matrix
    {
        /// <summary>
        /// Flatten
        /// </summary>
        /// <returns>The Flattened Vector</returns>
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

        /// <summary>
        /// Flattens the Matrix
        /// </summary>
        public void InFlatten()
        {
            _matrix = Flatten()._matrix;
        }
        
        /// <summary>
        /// Widen
        /// </summary>
        /// <param name="row">Row size</param>
        /// <param name="col">Col size</param>
        /// <returns></returns>
        public Matrix Widen(int row, int col)
        {
            if (Rows != row * col) throw new InvalidOperationException("Invalid matrix size.");

            var transpose = false;
            if (Type() != EType.Vector && Type() != EType.VectorTransposed)
                throw new InvalidOperationException("Cannot widen a non-vector matrix.");
            if (Type() == EType.VectorTransposed)
            {
                InTranspose();
                transpose = true;
            }

            var result = new Matrix(row, col);

            var k = 0;
            for (var i = 0; i < row; i++)
            for (var j = 0; j < col; j++)
            {
                result[i, j] = this[k, 0];
                k++;
            }

            if (transpose) InTranspose();

            return result;
        }

        /// <summary>
        /// Widens the Vector into a Matrix
        /// </summary>
        /// <param name="row">Row size</param>
        /// <param name="col">Col size</param>
        public void InWiden(int row, int col)
        {
            _matrix = Widen(row, col)._matrix;
        }

        /// <summary>
        /// Inplace Reshape
        /// </summary>
        /// <param name="row">New row size</param>
        /// <param name="col">New col size</param>
        public void InReshape(int row, int col)
        {
            _matrix = Reshape(row, col)._matrix;
        }

        /// <summary>
        /// Reshape
        /// </summary>
        /// <param name="row">Row size</param>
        /// <param name="col">Col size</param>
        public Matrix Reshape(int row, int col)
        {
            var flattened = Flatten();

            var shape = flattened.Shape();
            // Flatten
            if (shape.X == row && shape.Y == col) return flattened;
            // Flatten Transpose
            if (shape.X == col && shape.Y == row) return flattened.Transpose();

            var widened = flattened.Widen(row, col);
            return widened;
        }
        
        /// <summary>
        /// Concatinates two matrices into a vector
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <param name="mergeIndex">Output Merge Index</param>
        /// <returns>The concatinated vector</returns>
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

        /// <summary>
        /// Concatinates two matrices into a vector
        /// </summary>
        /// <param name="matrix">Matrix parameter</param>
        /// <param name="mergeIndex">Output Merge Index</param>
        public void InMerge(Matrix matrix, out int mergeIndex)
        {
            _matrix = Merge(matrix, out mergeIndex)._matrix;
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
    }
}
