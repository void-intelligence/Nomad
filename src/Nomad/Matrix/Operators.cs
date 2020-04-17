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
        public static Matrix operator !(Matrix matrix)
        {
            return matrix.Inverse(); 
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            return first.Add(second);
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            return first.Sub(second);
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            // Scale the first matrix
            if (first.Type() == Utility.EType.Scalar)
            {
                return second.Scale(first[0, 0]);
            }
            // Scale the second matrix
            else if (second.Type() == Utility.EType.Scalar)
            {
                return first.Scale(second[0, 0]);
            }
            // If shape are equal and neither of the two matrices are square
            // Calculate the Hadamard product between the first and the second
            // Matrix, returning the result
            else if (first.Shape() == second.Shape() && first.Type() != Utility.EType.SquareMatrix && second.Type() != Utility.EType.SquareMatrix)
            {
                return first.Hadamard(second);
            }
            // Calculate the dot product if none of the above
            else
            {
                return first.Dot(second);
            }
        }

        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return matrix.Scale(scalar);
        }

        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return matrix.Scale(scalar);
        }

        public static bool operator ==(Matrix first, Matrix second)
        {
            bool result = (first.Rows == second.Rows) && (first.Columns == second.Columns);
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

        public static bool operator !=(Matrix first, Matrix second)
        {
            bool result = (first.Rows != second.Rows) || (first.Columns != second.Columns);
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

        public static bool operator >(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) > (second.Rows * second.Columns);
        }

        public static bool operator <(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) < (second.Rows * second.Columns);
        }

        public static bool operator >=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) >= (second.Rows * second.Columns);
        }

        public static bool operator <=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) <= (second.Rows * second.Columns);
        }

        public override bool Equals(object obj)
        {
            Matrix matrix = obj as Matrix;
            if (obj == null)
            {
                return false;
            }
            bool result = (Rows == matrix.Rows) && (Columns == matrix.Columns);
            if (result)
            {
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Columns; col++)
                    {
                        result &= (this[row, col] == matrix[row, col]);
                        if(!result)
                        {
                            return false;
                        }
                    }
                }
            }
            return result;
        }
        
        public override int GetHashCode()
        {
            StringBuilder _matrixString = new StringBuilder();
            _matrixString.Append(Rows).Append("x").Append(Columns).Append("=");
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _matrixString.Append(this[row, col]).Append(";");
                }
            }
            return _matrixString.ToString().GetHashCode();
        }
    }
}
