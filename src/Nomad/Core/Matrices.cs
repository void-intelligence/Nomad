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

        public static Matrix One(int size)
        {
            var result = new Matrix(size);
            result.InFill(1.0);
            return result;
        }

        public static Matrix One(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InFill(1.0);
            return result;
        }

        public static Matrix Infinite(int size, bool positive = true)
        {
            var result = new Matrix(size);
            result.InFill(positive ? double.PositiveInfinity : double.NegativeInfinity);
            return result;
        }

        public static Matrix Infinite(int rows, int cols, bool positive = true)
        {
            var result = new Matrix(rows, cols);
            result.InFill(positive ? double.PositiveInfinity : double.NegativeInfinity);
            return result;
        }

        public static Matrix Epsilon(int size)
        {
            var result = new Matrix(size);
            result.InFill(double.Epsilon);
            return result;
        }

        public static Matrix Epsilon(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InFill(double.Epsilon);
            return result;
        }

        public static Matrix Pi(int size)
        {
            var result = new Matrix(size);
            result.InFill(Math.PI);
            return result;
        }

        public static Matrix Pi(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InFill(Math.PI);
            return result;
        }

        public static Matrix E(int size)
        {
            var result = new Matrix(size);
            result.InFill(Math.E);
            return result;
        }

        public static Matrix E(int rows, int cols)
        {
            var result = new Matrix(rows, cols);
            result.InFill(Math.E);
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
            for (var m = 0; m < rows; m++)
            for (var n = 0; n < cols; n++) result[m, n] = Math.Pow(m, n - 1 + double.Epsilon);
            return result;
        }
    }
}
