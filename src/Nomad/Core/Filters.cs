// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

namespace Nomad.Core
{
    public partial class Matrix
    {
        public static class Filters
        {
            public static Matrix Sobel()
            {
                return new Matrix(3, 3)
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

            public static Matrix Scharr()
            {
                return new Matrix(3, 3)
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
}
