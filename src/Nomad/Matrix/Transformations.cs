// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

/********************************************\
      Matrix Transformation Functionality. 
\********************************************/

using System;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        /// <summary>
        /// Creates rotation matrix for 2D rotation
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix MatrixRotation2D(double angle)
        {
            var rad = Math.PI * angle / 180.0;
            var result = new Matrix(2)
            {
                [0, 0] = Math.Cos(rad), [0, 1] = -Math.Sin(rad), [1, 0] = Math.Sin(rad), [1, 1] = Math.Cos(rad)
            };
            return result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around X axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix MatrixRotation3Dx(double angle)
        {
            var rad = Math.PI * angle / 180.0;
            var result = new Matrix(3)
            {
                [0, 0] = 1.0, [0, 1] = 0.0, [0, 2] = 0.0,
                [1, 0] = 0.0, [1, 1] = Math.Cos(rad), [1, 2] = -Math.Sin(rad),
                [2, 0] = 0.0, [2, 1] = Math.Sin(rad), [2, 2] = Math.Cos(rad)
            };
            return result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around Y axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix MatrixRotation3Dy(double angle)
        {
            var rad = Math.PI * angle / 180.0;
            var result = new Matrix(3)
            {
                [0, 0] = Math.Cos(rad), [0, 1] = 0.0, [0, 2] = Math.Sin(rad),
                [1, 0] = 0.0, [1, 1] = 1.0, [1, 2] = 0.0,
                [2, 0] = -Math.Sin(rad), [2, 1] = 0.0, [2, 2] = Math.Cos(rad)
            };
            return result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around Z axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix MatrixRotation3Dz(double angle)
        {
            var rad = Math.PI * angle / 180.0;
            var result = new Matrix(3)
            {
                [0, 0] = Math.Cos(rad), [0, 1] = -Math.Sin(rad), [0, 2] = 0.0,
                [1, 0] = Math.Sin(rad), [1, 1] = Math.Cos(rad), [1, 2] = 0.0,
                [2, 0] = 0.0, [2, 1] = 0.0, [2, 2] = 1.0
            };
            return result;
        }

        public static Matrix Scaling(double factor)
        {
            var result = new Matrix(3)
            {
                [0, 0] = factor, [0, 1] = 0.0, [0, 2] = 0.0,
                [1, 0] = 0.0, [1, 1] = factor, [1, 2] = 0.0,
                [2, 0] = 0.0, [2, 1] = 0.0, [2, 2] = factor
            };
            return result;
        }

        public static Matrix Scaling(double factorX, double factorY, double factorZ)
        {
            var result = new Matrix(3)
            {
                [0, 0] = factorX, [0, 1] = 0.0, [0, 2] = 0.0, 
                [1, 0] = 0.0, [1, 1] = factorY, [1, 2] = 0.0,
                [2, 0] = 0.0, [2, 1] = 0.0, [2, 2] = factorZ
            };
            return result;
        }

        public static Matrix Translation(double moveX, double moveY, double moveZ)
        {
            var result = new Matrix(4)
            {
                [0, 0] = 1.0, [0, 1] = 0.0, [0, 2] = 0.0, [0, 3] = moveX,
                [1, 0] = 0.0, [1, 1] = 1.0, [1, 2] = 0.0, [1, 3] = moveY,
                [2, 0] = 0.0, [2, 1] = 0.0, [2, 2] = 1.0, [2, 3] = moveZ,
                [3, 0] = 0.0, [3, 1] = 0.0, [3, 2] = 0.0, [3, 3] = 1.0
            };
            return result;
        }
    }
}