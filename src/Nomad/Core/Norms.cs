// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using System.Threading.Tasks;

namespace Nomad.Core
{
    public partial class Matrix
    {
        /// <summary>
        /// Maximum Norm
        /// </summary>
        public double MaximumNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++)
                {
                    var value = _matrix[row, col];
                    if (Math.Abs(value) > result) result = Math.Abs(value);
                }
            });

            return result;
        }

        /// <summary>
        /// Manhattan Norm
        /// </summary>
        public double ManhattanNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += Math.Abs(_matrix[row, col]);
            });
            return result;
        }

        /// <summary>
        /// Taxicab Norm
        /// </summary>
        public double TaxicabNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += Math.Abs(_matrix[row, col]);
            });
            return result;
        }
        
        /// <summary>
        /// P Norm
        /// </summary>
        /// <param name="p">Root Value</param>
        /// <returns></returns>
        public double PNorm(double p)
        {
            var result = 0.0;
            if (p < 1)
            {
                Parallel.For(0, Rows, row =>
                {
                    for (var col = 0; col < Columns; col++) result += Math.Abs(_matrix[row, col]);
                });
                return result;
            }

            for (var row = 0; row < Rows; row++)
                for (var col = 0; col < Columns; col++) result += Math.Pow(Math.Abs(_matrix[row, col]), p);

            return Math.Pow(result, 1.0 / p);
        }

        /// <summary>
        /// Euclidean Norm (Frobenius Norm)
        /// </summary>
        public double EuclideanNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += _matrix[row, col] * _matrix[row, col];
            });
            return Math.Sqrt(result);
        }

        /// <summary>
        /// Frobenius Norm (Euclidean Norm)
        /// </summary>
        public double FrobeniusNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += _matrix[row, col] * _matrix[row, col];
            });
            return Math.Sqrt(result);
        }

        /// <summary>
        /// Absolute Norm
        /// </summary>
        /// <returns></returns>
        public double AbsoluteNorm()
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += Math.Abs(_matrix[row, col]);
            });
            return result;
        }

        /// <summary>
        /// Custom Norm
        /// </summary>
        /// <param name="func">Custom Norm Function</param>
        public double IntegrateCustomNorm(Func<double, double> func)
        {
            var result = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++) result += func(_matrix[row, col]);
            });
            return result;
        }
    }

}
