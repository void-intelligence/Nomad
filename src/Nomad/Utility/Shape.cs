// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

namespace Nomad.Utility
{
    public class Shape
    {
        public int X { get; }
        public int Y { get; }

        public Shape(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + ", " + Y.ToString() + ")";
        }

        public EType Type()
        {
            switch (X)
            {
                case 1 when Y == 1:
                    return EType.Scalar;
                case 1 when Y != 1:
                    return EType.VectorTransposed;
            }

            if (X != 1 && Y == 1) return EType.Vector;
            if (X != 1 && Y != 1 && X == Y) return EType.SquareMatrix;
            if (X != 1 && Y != 1 && X != Y) return EType.Matrix;
            return EType.Matrix;
        }
    }
}
