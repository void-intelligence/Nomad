// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

/********************************************\
         Matrix operator overloads. 
\********************************************/

using System;
using System.Text;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        #region Overloaded operators

        // Inverse
        public static Matrix operator !(Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.InInverse();
            return result;
        }

        // Add
        public static Matrix operator +(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.InAdd(second);
            return result;
        }

        // Sub
        public static Matrix operator -(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.InSub(second);
            return result;
        }

        // Dot
        public static Matrix operator *(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.InDot(second);
            return result;
        }

        // Scale
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            var result = matrix.Duplicate();
            result.InScale(scalar);
            return result;
        }

        // Scale
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.InScale(scalar);
            return result;
        }

        // Comparison eq
        public static bool operator ==(Matrix first, Matrix second)
        {
            bool result = false;
            result = (first.Rows == second.Rows) && (first.Columns == second.Columns);
            if (result)
            {
                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Columns; col++)
                    {
                        result &= (first[row, col] == second[row, col]);
                    }
                }
            }
            return result;
        }

        // Comparison ne
        public static bool operator !=(Matrix first, Matrix second)
        {
            bool result = false;
            result = (first.Rows != second.Rows) || (first.Columns != second.Columns);
            if (!result)
            {
                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Columns; col++)
                    {
                        result |= (first[row, col] != second[row, col]);
                    }
                }
            }
            return result;
        }

        // Comparison g
        public static bool operator >(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) > (second.Rows * second.Columns);
        }

        // Comparison l
        public static bool operator <(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) < (second.Rows * second.Columns);
        }

        // Comparison ge
        public static bool operator >=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) >= (second.Rows * second.Columns);
        }

        // Comparison le
        public static bool operator <=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) <= (second.Rows * second.Columns);
        }

        // Comparison eq
        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            if (obj == null)
            {
                return false;
            }
            bool result = false;
            result = (this.Rows == matrix.Rows) && (this.Columns == matrix.Columns);
            if (result)
            {
                for (int row = 0; row < this.Rows; row++)
                {
                    for (int col = 0; col < this.Columns; col++)
                    {
                        result &= (this[row, col] == matrix[row, col]);
                    }
                }
            }
            return result;
        }

        // Hash Code
        public override int GetHashCode()
        {
            var _matrixString = new StringBuilder();
            _matrixString.Append(this.Rows).Append("x").Append(this.Columns).Append("=");
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    _matrixString.Append(this[row, col]).Append(";");
                }
            }
            return _matrixString.ToString().GetHashCode();
        }

        #endregion
    }
}
