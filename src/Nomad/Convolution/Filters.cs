using System;
using System.Collections.Generic;
using System.Text;

namespace Nomad.Convolution
{
    public static class Filters
    {
        public static Matrix.Matrix Sobel()
        {
            return new Matrix.Matrix(3, 3)
            {
                [0, 0] = 1.0,
                [0, 1] = 1.0,
                [0, 2] = 1.0,
                [1, 0] = 0.0,
                [1, 1] = 0.0,
                [1, 2] = 0.0,
                [2, 0] = -1.0,
                [2, 1] = -1.0,
                [2, 2] = -1.0
            };
        }

        public static Matrix.Matrix Scharr()
        {
            return new Matrix.Matrix(3, 3)
            {
                [0, 0] = 3.0,
                [0, 1] = 10.0,
                [0, 2] = 3.0,
                [1, 0] = 0.0,
                [1, 1] = 0.0,
                [1, 2] = 0.0,
                [2, 0] = -3.0,
                [2, 1] = -10.0,
                [2, 2] = -3.0
            };
        }
    }
}
