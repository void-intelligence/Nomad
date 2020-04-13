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
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = 0.0;
                }
            }
        }

        private void InIdentity()
        {
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Identity matrix must be square.");
            }

            InZero();

            for (int n = 0; n < Rows; n++)
            {
                _matrix[n, n] = 1.0;
            }
        }

        #endregion

        #region Static Matrix creator functions

        public static Matrix Zero(int size)
        {
            var _result = new Matrix(size);
            _result.InZero();
            return _result;
        }

        public static Matrix Zero(int rows, int cols)
        {
            var _result = new Matrix(rows, cols);
            _result.InZero();
            return _result;
        }

        public static Matrix Identity(int size)
        {
            var _result = new Matrix(size);
            _result.InIdentity();
            return _result;
        }

        public static Matrix Vandermonde(int rows, int cols)
        {
            var _result = new Matrix(rows, cols);
            for (int m = 1; m <= rows; m++)
            {
                for (int n = 1; n <= cols; n++)
                {
                    _result[m, n] = Math.Pow(m, n - 1);
                }
            }
            return _result;
        }

        #endregion
    }
}
