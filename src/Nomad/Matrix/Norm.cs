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
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    double _value = _matrix[_row, _col];

                    if (Math.Abs(_value) > _result)
                    {
                        _result = Math.Abs(_value);
                    }
                }
            }
            return _result;
        }

        // Manhattan Norm
        public double ManhattanNorm()
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += Math.Abs(_matrix[_row, _col]);
                }
            }
            return _result;
        }

        // Taxicab Norm
        public double TaxicabNorm()
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += Math.Abs(_matrix[_row, _col]);
                }
            }
            return _result;
        }

        // PNorm
        public double PNorm(double p)
        {
            double _result = 0;
            if (p < 1)
            {
                for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                {
                    for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                    {
                        _result += Math.Abs(_matrix[_row, _col]);
                    }
                }
                return _result;
            }

            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += Math.Pow(Math.Abs(_matrix[_row, _col]), p);
                }
            }

            return Math.Pow(_result, 1.0 / p);
        }

        // Euclidean Norm (Frobenius Norm)
        public double EuclideanNorm()
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += _matrix[_row, _col] * _matrix[_row, _col];
                }
            }
            return Math.Sqrt(_result);
        }

        // Frobenius Norm (Euclidean Norm)
        public double FrobeniusNorm()
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += _matrix[_row, _col] * _matrix[_row, _col];
                }
            }
            return Math.Sqrt(_result);
        }

        // Absolute Norm
        public double AbsoluteNorm()
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += Math.Abs(_matrix[_row, _col]);
                }
            }
            return _result;
        }

        public double IntegrateCustomNorm(Func<double, double> func)
        {
            double _result = 0;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result += func(_matrix[_row, _col]);
                }
            }
            return _result;
        }
    }
}
