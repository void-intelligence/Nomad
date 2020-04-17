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
        public static Matrix Rotation2D(double angle)
        {
            double _rad = Math.PI * angle / 180.0;
            var _result = new Matrix(2);
            _result[0, 0] = Math.Cos(_rad);
            _result[0, 1] = -Math.Sin(_rad);
            _result[1, 0] = Math.Sin(_rad);
            _result[1, 1] = Math.Cos(_rad);
            return _result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around X axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix Rotation3DX(double angle)
        {
            double _rad = Math.PI * angle / 180.0;
            var _result = new Matrix(3);
            _result[0, 0] = 1.0;
            _result[0, 1] = 0.0;
            _result[0, 2] = 0.0;
            //
            _result[1, 0] = 0.0;
            _result[1, 1] = Math.Cos(_rad);
            _result[1, 2] = -Math.Sin(_rad);
            //
            _result[2, 0] = 0.0;
            _result[2, 1] = Math.Sin(_rad);
            _result[2, 2] = Math.Cos(_rad);
            return _result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around Y axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix Rotation3DY(double angle)
        {
            double _rad = Math.PI * angle / 180.0;
            var _result = new Matrix(3);
            _result[0, 0] = Math.Cos(_rad);
            _result[0, 1] = 0.0;
            _result[0, 2] = Math.Sin(_rad);
            //
            _result[1, 0] = 0.0;
            _result[1, 1] = 1.0;
            _result[1, 2] = 0.0;
            //
            _result[2, 0] = -Math.Sin(_rad);
            _result[2, 1] = 0.0;
            _result[2, 2] = Math.Cos(_rad);
            return _result;
        }

        /// <summary>
        /// Creates roration matrix for 3D rotation around Z axis
        /// </summary>
        /// <param name="angle">Rotation Angle in Degrees</param>
        /// <returns>Rotation Matrix</returns>
        public static Matrix Rotation3DZ(double angle)
        {
            double _rad = Math.PI * angle / 180.0;
            var _result = new Matrix(3);
            _result[0, 0] = Math.Cos(_rad);
            _result[0, 1] = -Math.Sin(_rad);
            _result[0, 2] = 0.0;
            //
            _result[1, 0] = Math.Sin(_rad);
            _result[1, 1] = Math.Cos(_rad);
            _result[1, 2] = 0.0;
            //
            _result[2, 0] = 0.0;
            _result[2, 1] = 0.0;
            _result[2, 2] = 1.0;
            return _result;
        }

        public static Matrix Scaling(double factor)
        {
            var _result = new Matrix(3);
            _result[0, 0] = factor;
            _result[0, 1] = 0.0;
            _result[0, 2] = 0.0;
            //
            _result[1, 0] = 0.0;
            _result[1, 1] = factor;
            _result[1, 2] = 0.0;
            //
            _result[2, 0] = 0.0;
            _result[2, 1] = 0.0;
            _result[2, 2] = factor;
            return _result;
        }

        public static Matrix Scaling(double factorX, double factorY, double factorZ)
        {
            var _result = new Matrix(3);
            _result[0, 0] = factorX;
            _result[0, 1] = 0.0;
            _result[0, 2] = 0.0;
            //
            _result[1, 0] = 0.0;
            _result[1, 1] = factorY;
            _result[1, 2] = 0.0;
            //
            _result[2, 0] = 0.0;
            _result[2, 1] = 0.0;
            _result[2, 2] = factorZ;
            return _result;
        }

        public static Matrix Translation(double moveX, double moveY, double moveZ)
        {
            var _result = new Matrix(4);
            _result[0, 0] = 1.0;
            _result[0, 1] = 0.0;
            _result[0, 2] = 0.0;
            _result[0, 3] = moveX;
            //
            _result[1, 0] = 0.0;
            _result[1, 1] = 1.0;
            _result[1, 2] = 0.0;
            _result[1, 3] = moveY;
            //
            _result[2, 0] = 0.0;
            _result[2, 1] = 0.0;
            _result[2, 2] = 1.0;
            _result[2, 3] = moveZ;
            //
            _result[3, 0] = 0.0;
            _result[3, 1] = 0.0;
            _result[3, 2] = 0.0;
            _result[3, 3] = 1.0;
            return _result;
        }
    }
}
