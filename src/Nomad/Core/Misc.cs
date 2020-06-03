// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using System.Threading.Tasks;

namespace Nomad.Core
{
    public partial class Matrix
    {
        /// <summary>
        /// Calculate the Softmax Matrix
        /// </summary>
        /// <returns>The Softmax Matrix</returns>
        public Matrix Softmax()
        {
            var mat = Duplicate();
            mat.InSoftmax();
            return mat;
        }

        /// <summary>
        /// Inplacely Calculate the Softmax Matrix
        /// </summary>
        public void InSoftmax()
        {
            var sum = 0.0;
            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++)
                    sum += _matrix[row, col];
            });

            Parallel.For(0, Rows, row =>
            {
                for (var col = 0; col < Columns; col++)
                    _matrix[row, col] = _matrix[row, col] / sum;
            });
        }

        /// <summary>
        /// Dropout
        /// </summary>
        /// <param name="chance">The chance value (between 0 and 1)</param>
        /// <returns>The dropped out matrix</returns>
        public Matrix Dropout(double chance)
        {
            var result = Duplicate();
            result.InDropout(chance);
            return result;
        }

        /// <summary>
        /// Inplace Dropout
        /// </summary>
        /// <param name="chance">The chance value (between 0 and 1)</param>
        public void InDropout(double chance)
        {
            Math.Clamp(chance, 0.0f, 1.0f);
            var random = new Random();
            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
            {
                var d = random.NextDouble();
                if (d < chance) _matrix[i, j] = 0.0;
            }
        }
    }
}
