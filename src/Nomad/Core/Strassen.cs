// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;

namespace Nomad.Core
{
    public static class Strassen
    {
        private static void SafeAplusBintoC(Matrix a, int xa, int ya, Matrix b, int xb, int yb, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                {
                    c[i, j] = 0;
                    if (xa + j < a.Columns && ya + i < a.Rows) c[i, j] += a[ya + i, xa + j];
                    if (xb + j < b.Columns && yb + i < b.Rows) c[i, j] += b[yb + i, xb + j];
                }
        }

        private static void SafeAminusBintoC(Matrix a, int xa, int ya, Matrix b, int xb, int yb, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                {
                    c[i, j] = 0;
                    if (xa + j < a.Columns && ya + i < a.Rows) c[i, j] += a[ya + i, xa + j];
                    if (xb + j < b.Columns && yb + i < b.Rows) c[i, j] -= b[yb + i, xb + j];
                }
        }

        private static void SafeACopytoC(Matrix a, int xa, int ya, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                {
                    c[i, j] = 0;
                    if (xa + j < a.Columns && ya + i < a.Rows) c[i, j] += a[ya + i, xa + j];
                }
        }

        private static void AplusBintoC(Matrix a, int xa, int ya, Matrix b, int xb, int yb, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++) c[i, j] = a[ya + i, xa + j] + b[yb + i, xb + j];
        }

        private static void AminusBintoC(Matrix a, int xa, int ya, Matrix b, int xb, int yb, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++) c[i, j] = a[ya + i, xa + j] - b[yb + i, xb + j];
        }

        private static void ACopytoC(Matrix a, int xa, int ya, Matrix c, int size)
        {
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++) c[i, j] = a[ya + i, xa + j];
        }

        // Smart matrix multiplication
        public static Matrix StrassenMultiply(Matrix a, Matrix b)                
        {
            if (a.Columns != b.Rows) throw new Exception("Wrong dimension of matrix!");

            Matrix r;

            var msize = Math.Max(Math.Max(a.Rows, a.Columns), Math.Max(b.Rows, b.Columns));

            if (msize < 32)
            {
                r = Matrix.Zero(a.Rows, b.Columns);
                for (var i = 0; i < r.Rows; i++)
                    for (var j = 0; j < r.Columns; j++)
                        for (var k = 0; k < a.Columns; k++)
                            r[i, j] += a[i, k] * b[k, j];
                return r;
            }

            var size = 1; var n = 0;
            while (msize > size) { size *= 2; n++; }
            var h = size / 2;


            var mField = new Matrix[n, 9];

            /*
             *  8x8, 8x8, 8x8, ...
             *  4x4, 4x4, 4x4, ...
             *  2x2, 2x2, 2x2, ...
             *  . . .
             */

            // Rows
            for (var i = 0; i < n - 4; i++)
            {
                var z = (int)Math.Pow(2, n - i - 1);
                for (var j = 0; j < 9; j++) mField[i, j] = new Matrix(z, z);
            }

            // (A11 + A22) * (B11 + B22);
            SafeAplusBintoC(a, 0, 0, a, h, h, mField[0, 0], h);
            SafeAplusBintoC(b, 0, 0, b, h, h, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 1], 1, mField);

            // (A21 + A22) * B11;
            SafeAplusBintoC(a, 0, h, a, h, h, mField[0, 0], h);
            SafeACopytoC(b, 0, 0, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 2], 1, mField);

            //A11 * (B12 - B22);
            SafeACopytoC(a, 0, 0, mField[0, 0], h);
            SafeAminusBintoC(b, h, 0, b, h, h, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 3], 1, mField);

            //A22 * (B21 - B11);
            SafeACopytoC(a, h, h, mField[0, 0], h);
            SafeAminusBintoC(b, 0, h, b, 0, 0, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 4], 1, mField);

            //(A11 + A12) * B22;
            SafeAplusBintoC(a, 0, 0, a, h, 0, mField[0, 0], h);
            SafeACopytoC(b, h, h, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 5], 1, mField);

            //(A21 - A11) * (B11 + B12);
            SafeAminusBintoC(a, 0, h, a, 0, 0, mField[0, 0], h);
            SafeAplusBintoC(b, 0, 0, b, h, 0, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 6], 1, mField);

            // (A12 - A22) * (B21 + B22);
            SafeAminusBintoC(a, h, 0, a, h, h, mField[0, 0], h);
            SafeAplusBintoC(b, 0, h, b, h, h, mField[0, 1], h);
            StrassenMultiplyRun(mField[0, 0], mField[0, 1], mField[0, 1 + 7], 1, mField); 

            r = new Matrix(a.Rows, b.Columns);

            // C11
            for (var i = 0; i < Math.Min(h, r.Rows); i++)
                for (var j = 0; j < Math.Min(h, r.Columns); j++)
                    r[i, j] = mField[0, 1 + 1][i, j] + mField[0, 1 + 4][i, j] - mField[0, 1 + 5][i, j] + mField[0, 1 + 7][i, j];

            // C12
            for (var i = 0; i < Math.Min(h, r.Rows); i++)
                for (var j = h; j < Math.Min(2 * h, r.Columns); j++)
                    r[i, j] = mField[0, 1 + 3][i, j - h] + mField[0, 1 + 5][i, j - h];

            // C21
            for (var i = h; i < Math.Min(2 * h, r.Rows); i++)
                for (var j = 0; j < Math.Min(h, r.Columns); j++)
                    r[i, j] = mField[0, 1 + 2][i - h, j] + mField[0, 1 + 4][i - h, j];

            // C22
            for (var i = h; i < Math.Min(2 * h, r.Rows); i++)
                for (var j = h; j < Math.Min(2 * h, r.Columns); j++)
                    r[i, j] = mField[0, 1 + 1][i - h, j - h] - mField[0, 1 + 2][i - h, j - h] + mField[0, 1 + 3][i - h, j - h] + mField[0, 1 + 6][i - h, j - h];

            return r;
        }

        // function for square matrix 2^N x 2^N

        private static void StrassenMultiplyRun(Matrix a, Matrix b, Matrix c, int l, Matrix[,] f)
        {
            // A * B into C, level of recursion, matrix field
            var size = a.Rows;
            var h = size / 2;

            if (size < 32)
            {
                for (var i = 0; i < c.Rows; i++)
                    for (var j = 0; j < c.Columns; j++)
                    {
                        c[i, j] = 0;
                        for (var k = 0; k < a.Columns; k++) c[i, j] += a[i, k] * b[k, j];
                    }
                return;
            }

            // (A11 + A22) * (B11 + B22);
            AplusBintoC(a, 0, 0, a, h, h, f[l, 0], h);
            AplusBintoC(b, 0, 0, b, h, h, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 1], l + 1, f); 

            // (A21 + A22) * B11;
            AplusBintoC(a, 0, h, a, h, h, f[l, 0], h);
            ACopytoC(b, 0, 0, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 2], l + 1, f); 

            //A11 * (B12 - B22);
            ACopytoC(a, 0, 0, f[l, 0], h);
            AminusBintoC(b, h, 0, b, h, h, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 3], l + 1, f); 

            //A22 * (B21 - B11);
            ACopytoC(a, h, h, f[l, 0], h);
            AminusBintoC(b, 0, h, b, 0, 0, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 4], l + 1, f); 

            //(A11 + A12) * B22;
            AplusBintoC(a, 0, 0, a, h, 0, f[l, 0], h);
            ACopytoC(b, h, h, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 5], l + 1, f); 

            //(A21 - A11) * (B11 + B12);
            AminusBintoC(a, 0, h, a, 0, 0, f[l, 0], h);
            AplusBintoC(b, 0, 0, b, h, 0, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 6], l + 1, f); 

            // (A12 - A22) * (B21 + B22);
            AminusBintoC(a, h, 0, a, h, h, f[l, 0], h);
            AplusBintoC(b, 0, h, b, h, h, f[l, 1], h);
            StrassenMultiplyRun(f[l, 0], f[l, 1], f[l, 1 + 7], l + 1, f);

            // C11
            for (var i = 0; i < h; i++)
                for (var j = 0; j < h; j++)
                    c[i, j] = f[l, 1 + 1][i, j] + f[l, 1 + 4][i, j] - f[l, 1 + 5][i, j] + f[l, 1 + 7][i, j];

            // C12
            for (var i = 0; i < h; i++)
                for (var j = h; j < size; j++)
                    c[i, j] = f[l, 1 + 3][i, j - h] + f[l, 1 + 5][i, j - h];

            // C21
            for (var i = h; i < size; i++)
                for (var j = 0; j < h; j++)
                    c[i, j] = f[l, 1 + 2][i - h, j] + f[l, 1 + 4][i - h, j];

            // C22
            for (var i = h; i < size; i++)
                for (var j = h; j < size; j++)
                    c[i, j] = f[l, 1 + 1][i - h, j - h] - f[l, 1 + 2][i - h, j - h] + f[l, 1 + 3][i - h, j - h] + f[l, 1 + 6][i - h, j - h];
        }
    }
}
