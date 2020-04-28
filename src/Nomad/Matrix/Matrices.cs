// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

/********************************************\
     Logic for creating different matrices. 
\********************************************/

using System;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        #region (PRIVATE) In-Place Matrix Manipulation

        private void InZero()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) _matrix[row, col] = 0.0;
        }

        private void InIdentity()
        {
            if (Rows != Columns) throw new InvalidOperationException("Identity matrix must be square.");

            InZero();

            for (var n = 0; n < Rows; n++) _matrix[n, n] = 1.0;
        }

        #endregion

        #region Static Matrix creator functions

        public static Matrix Zero(int size)
        {
            var result = new Matrix(size);
            result.InZero();
            return result;
        }

        public static Matrix Zero(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InZero();
            return result;
        }

        public static Matrix Identity(int size)
        {
            var result = new Matrix(size);
            result.InIdentity();
            return result;
        }

        public static Matrix Vandermonde(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            for (var m = 1; m <= rows; m++)
            for (var n = 1; n <= cols; n++) result[m, n] = Math.Pow(m, n - 1);

            return result;
        }

        #endregion
    }
}