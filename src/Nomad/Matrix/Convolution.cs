using System;
using System.Collections.Generic;
using System.Text;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        public Matrix Convolve(Matrix filter, int padSizeX = 1, int padSizeY = 1, double padValue = 0, int stride = 1)
        {
            return Pad(padSizeX, padSizeY, padValue).Convolve(filter, stride);
        }

        public Matrix Convolve(Matrix filter, int stride = 1)
        {
            var newX = (Rows - filter.Rows) / stride + 1;
            var newY = (Columns - filter.Columns) / stride + 1;
            var result = new Matrix(newX, newY);

            var resArray = new List<double>();
            for (var i = 0; i < Rows; i+= stride)
            for (var j = 0; j < Columns; j += stride)
            {
                var tempSum = 0.0;
                for (var k = 0; k < filter.Rows; k++)
                {
                    if (k + i >= Rows) continue;
                    for (var l = 0; l < filter.Columns; l++)
                        if (l + j < Columns)
                        {
                            // Pool Operation (Sum)
                            tempSum += _matrix[i + k, j + l] * filter[k, l];
                        }
                }

                resArray.Add(tempSum);
            }

            var n = 0;
            for (var i = 0; i < result.Rows; i++)
            for (var j = 0; j < result.Columns; j++) 
                result[i, j] = resArray[n++];

            return result;
        }

        /// <summary>
        /// Same Padding
        /// </summary>
        public Matrix Pad(Matrix filter, double value = 0.0)
        {
            var sizeRow = (int)((filter.Rows - 1.0) / 2.0);
            var sizeCol = (int)((filter.Columns - 1.0) / 2.0);

            var mat = new Matrix(Rows + sizeRow * 2, Columns + sizeCol * 2);
            mat.InFill(value);

            for (var i = sizeRow; i < mat.Rows - sizeRow; i++)
            for (var j = sizeCol; j < mat.Columns - sizeCol; j++) mat[i, j] = _matrix[i, j];

            return mat;
        }

        /// <summary>
        /// Valid Padding
        /// </summary>
        public Matrix Pad(int size, double value = 0.0)
        {
            var mat = new Matrix(Rows + size * 2, Columns + size * 2);
            mat.InFill(value);

            for (var i = size; i < mat.Rows - size; i++)
            for (var j = size; j < mat.Columns - size; j++) mat[i, j] = _matrix[i, j];

            return mat;
        }

        /// <summary>
        /// Valid Padding
        /// </summary>
        public Matrix Pad(int sizeRow, int sizeCol, double value = 0.0)
        {
            var mat = new Matrix(Rows + sizeRow * 2, Columns + sizeCol * 2);
            mat.InFill(value);

            for (var i = sizeRow; i < Rows; i++)
            for (var j = sizeCol; j < Columns; j++) mat[i, j] = _matrix[i, j];

            return mat;
        }
    }
}