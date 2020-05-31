// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;

namespace Nomad.Core
{
    public partial class Matrix
    {
        public static Matrix Zero(int size)
        {
            var result = new Matrix(size);
            result.InFill(0.0);
            return result;
        }

        public static Matrix Zero(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InFill(0.0);
            return result;
        }

        public static Matrix Identity(int size)
        {
            var result = new Matrix(size);
            result.InFill(0.0);
            for (var n = 0; n < result.Rows; n++) result[n, n] = 1.0;
            return result;
        }

        public static Matrix Vandermonde(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            for (var m = 1; m <= rows; m++)
            for (var n = 1; n <= cols; n++) result[m, n] = Math.Pow(m, n - 1);
            return result;
        }

    }
}
