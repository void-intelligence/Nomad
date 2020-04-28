// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED
/********************************************\
        Matrix norm calculations logic.
\********************************************/

using System;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        // Maximum Norm
        public double MaximumNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++)
            {
                var value = _matrix[row, col];
                if (Math.Abs(value) > result) result = Math.Abs(value);
            }

            return result;
        }

        // Manhattan Norm
        public double ManhattanNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += Math.Abs(_matrix[row, col]);

            return result;
        }

        // Taxicab Norm
        public double TaxicabNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += Math.Abs(_matrix[row, col]);

            return result;
        }

        // PNorm
        public double PNorm(double p)
        {
            var result = 0.0;
            if (p < 1)
            {
                for (var row = 0; row < _matrix.GetLength(0); row++)
                for (var col = 0; col < _matrix.GetLength(1); col++) result += Math.Abs(_matrix[row, col]);

                return result;
            }

            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += Math.Pow(Math.Abs(_matrix[row, col]), p);

            return Math.Pow(result, 1.0 / p);
        }

        // Euclidean Norm (Frobenius Norm)
        public double EuclideanNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += _matrix[row, col] * _matrix[row, col];

            return Math.Sqrt(result);
        }

        // Frobenius Norm (Euclidean Norm)
        public double FrobeniusNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += _matrix[row, col] * _matrix[row, col];

            return Math.Sqrt(result);
        }

        // Absolute Norm
        public double AbsoluteNorm()
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += Math.Abs(_matrix[row, col]);

            return result;
        }

        public double IntegrateCustomNorm(Func<double, double> func)
        {
            var result = 0.0;
            for (var row = 0; row < _matrix.GetLength(0); row++)
            for (var col = 0; col < _matrix.GetLength(1); col++) result += func(_matrix[row, col]);

            return result;
        }
    }
}