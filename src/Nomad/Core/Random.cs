// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using Nomad.Utility;

namespace Nomad.Core
{
    public partial class Matrix
    {
        /// <summary>
        /// Get a random matrix filled with a custom distribution of random numbers
        /// </summary>
        /// <param name="lowest">Lower bound</param>
        /// <param name="highest">Upper bound</param>
        /// <param name="distribution">Distribution type</param>
        /// <returns>A random matrix filled with a custom distribution of random numbers</returns>
        public Matrix Randomize(double lowest = 0.0, double highest = 1.0,
            EDistribution distribution = EDistribution.Gaussian)
        {
            var mat = Duplicate();
            mat.InRandomize(lowest, highest, distribution);
            return mat;
        }


        /// <summary>
        /// Fill the matrix with a custom distribution of random numbers
        /// </summary>
        /// <param name="lowest">Lower bound</param>
        /// <param name="highest">Upper bound</param>
        /// <param name="distribution">Distribution type</param>
        public void InRandomize(double lowest = 0.0, double highest = 1.0, EDistribution distribution = EDistribution.Gaussian)
        {
            var diff = highest - lowest;
            switch (distribution)
            {
                case EDistribution.Invalid:
                    {
                        throw new InvalidOperationException("Invalid Random Distribution Mode!");
                    }
                case EDistribution.Uniform:
                    {
                        var random = new Random();
                        for (var row = 0; row < _matrix.GetLength(0); row++)
                            for (var col = 0; col < _matrix.GetLength(1); col++)
                                _matrix[row, col] = random.NextDouble() * diff + lowest;

                        break;
                    }
                case EDistribution.Normal:
                case EDistribution.Gaussian:
                    {
                        var dispersion = diff / 2;
                        var random = new Random();
                        for (var row = 0; row < _matrix.GetLength(0); row++)
                            for (var col = 0; col < _matrix.GetLength(1); col++)
                            {
                                var u1 = 1.0 - random.NextDouble();
                                var u2 = 1.0 - random.NextDouble();

                                var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

                                //random normal(mean,stdDev^2)
                                var randNormal = 0 + dispersion * randStdNormal;

                                _matrix[row, col] = randNormal;
                            }

                        break;
                    }
                default:
                    throw new InvalidOperationException("Invalid Random Distribution Mode!");
            }
        }

    }
}
