﻿// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;

namespace Nomad.Core
{
    public partial class Matrix
    {
        public static Matrix operator!(Matrix matrix)
        {
            return matrix.Inverse();
        }

        public static Matrix operator+(Matrix first, Matrix second)
        {
            return first.Add(second);
        }

        public static Matrix operator-(Matrix first, Matrix second)
        {
            return first.Sub(second);
        }

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
        
        public static Matrix operator /(Matrix first, Matrix second)
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

        public static Matrix operator+(Matrix matrix, double value)
        {
            return matrix.Add(value);
        }
        
        public static Matrix operator +(double value, Matrix matrix)
        {
            return matrix.Add(value);
        }

        public static Matrix operator-(Matrix matrix, double value)
        {
            return matrix.Sub(value);
        }

        public static Matrix operator -(double value, Matrix matrix)
        {
            for (var i = 0; i < matrix.Rows; i++)
            for (var j = 0; j < matrix.Columns; j++) matrix[i, j] = value - matrix[i, j];
            return matrix;
        }

        public static Matrix operator*(Matrix matrix, double scalar)
        {
            return matrix.Scale(scalar);
        }

        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return matrix.Scale(scalar);
        }

        public static Matrix operator/(Matrix matrix, double scalar)
        {
            return matrix.Scale(1 / scalar);
        }

        public static Matrix operator /(double scalar, Matrix matrix)
        {
            for (var i = 0; i < matrix.Rows; i++)
            for (var j = 0; j < matrix.Columns; j++) matrix[i, j] = scalar / matrix[i, j];
            return matrix;
        }

        public static bool operator==(Matrix first, Matrix second)
        {
            // ReSharper disable PossibleNullReferenceException
            var result = first.Rows == second.Rows;
            result &= first.Columns == second.Columns;
            if (!result) return false;
            // ReSharper enable PossibleNullReferenceException

            for (var row = 0; row < first.Rows; row++)
            for (var col = 0; col < first.Columns; col++)
                result &= Math.Abs(first[row, col] - second[row, col]) < 0.01;
            
            return result;
        }

        public static bool operator!=(Matrix first, Matrix second)
        {
            return !(first == second);
        }

        public static bool operator>(Matrix first, Matrix second)
        {
            return first.Rows * first.Columns > second.Rows * second.Columns;
        }

        public static bool operator<(Matrix first, Matrix second)
        {
            return first.Rows * first.Columns < second.Rows * second.Columns;
        }

        public static bool operator>=(Matrix first, Matrix second)
        {
            return first.Rows * first.Columns >= second.Rows * second.Columns;
        }

        public static bool operator<=(Matrix first, Matrix second)
        {
            return first.Rows * first.Columns <= second.Rows * second.Columns;
        }
    }
}
