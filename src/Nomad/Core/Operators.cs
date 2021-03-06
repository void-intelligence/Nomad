﻿// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using System.Threading.Tasks;

namespace Nomad.Core
{
    public partial class Matrix
    {
        // Inverse
        public static Matrix operator!(Matrix matrix)
        {
            return matrix.Inverse();
        }

        // Addition
        public static Matrix operator+(Matrix first, Matrix second)
        {
            return first.Add(second);
        }
        public static Matrix operator+(Matrix matrix, double value)
        {
            return matrix.Add(value);
        }
        public static Matrix operator+(double value, Matrix matrix)
        {
            return matrix.Add(value);
        }

        // Subtraction
        public static Matrix operator-(Matrix first, Matrix second)
        {
            return first.Sub(second);
        }
        public static Matrix operator-(Matrix matrix, double value)
        {
            return matrix.Sub(value);
        }
        public static Matrix operator-(double value, Matrix matrix)
        {
            Parallel.For(0, matrix.Rows, i =>
            {
                for (var j = 0; j < matrix.Columns; j++) matrix[i, j] = value - matrix[i, j];
            });
            return matrix;
        }

        // Dot and Scale
        public static Matrix operator*(Matrix first, Matrix second)
        {
            if (first.Type() == Utility.EType.Scalar)
                return second.Scale(first[0, 0]);
            if (second.Type() == Utility.EType.Scalar)
                return first.Scale(second[0, 0]);
            if (first.Shape() == second.Shape() && first.Type() != Utility.EType.SquareMatrix &&
                second.Type() != Utility.EType.SquareMatrix)
                return first.Hadamard(second);
            return first.Dot(second);
        }
        public static Matrix operator*(Matrix matrix, double scalar)
        {
            return matrix.Scale(scalar);
        }
        public static Matrix operator*(double scalar, Matrix matrix)
        {
            return matrix.Scale(scalar);
        }

        // Division 
        public static Matrix operator/(Matrix first, Matrix second)
        {
            if (first.Type() == Utility.EType.Scalar)
                return second.Divide(first[0, 0]);
            else if (second.Type() == Utility.EType.Scalar)
                return first.Divide(second[0, 0]);
            else if (first.Shape() == second.Shape() && first.Type() != Utility.EType.SquareMatrix &&
                     second.Type() != Utility.EType.SquareMatrix)
                return first.HadamardDivision(second);
            else
                return first.DotDivision(second);
        }
        public static Matrix operator/(Matrix matrix, double scalar)
        {
            return matrix.Scale(1 / scalar);
        }
        public static Matrix operator/(double scalar, Matrix matrix)
        {
            Parallel.For(0, matrix.Rows, i =>
            {
                for (var j = 0; j < matrix.Columns; j++) matrix[i, j] = scalar / matrix[i, j];
            });
            return matrix;
        }

        // Power
        public static Matrix operator^(Matrix first, Matrix second)
        {
            return first.HadamardPower(second);
        }
        public static Matrix operator^(Matrix matrix, double power)
        {
            return matrix.Power(power);
        }
        public static Matrix operator^(double value, Matrix matrix)
        {
            Parallel.For(0, matrix.Rows, i =>
            {
                for (var j = 0; j < matrix.Columns; j++) matrix[i, j] = Math.Pow(value, matrix[i, j]);
            });
            return matrix;
        }
        
        // Equality
        public static bool operator==(Matrix first, Matrix second)
        {
            // ReSharper disable PossibleNullReferenceException
            var result = first.Rows == second.Rows;
            result &= first.Columns == second.Columns;
            if (!result) return false;
            // ReSharper enable PossibleNullReferenceException

            Parallel.For(0, first.Rows, row =>
            {
                for (var col = 0; col < first.Columns; col++)
                    result &= Math.Abs(first[row, col] - second[row, col]) < 0.01;
            });
            return result;
        }
        public static bool operator!=(Matrix first, Matrix second)
        {
            return !(first == second);
        }

        // Comparison (Frobenious Norm)
        public static bool operator>(Matrix first, Matrix second)
        {
            return first.FrobeniusNorm() > second.FrobeniusNorm();
        }
        public static bool operator<(Matrix first, Matrix second)
        {
            return first.FrobeniusNorm() < second.FrobeniusNorm();
        }
        public static bool operator>=(Matrix first, Matrix second)
        {
            return first.FrobeniusNorm() >= second.FrobeniusNorm();
        }
        public static bool operator<=(Matrix first, Matrix second)
        {
            return first.FrobeniusNorm() <= second.FrobeniusNorm();
        }
    }
}
