/********************************************\
         Primary Matrix class logic.
\********************************************/

using System;

namespace Nomad.Matrix
{
    public partial class Matrix
    {
        private double[,] _matrix;

        public int Rows { get { return _matrix.GetLength(0); } }
        
        public int Columns { get { return _matrix.GetLength(1); } }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row - 1, column - 1];
            }

            set
            {
                _matrix[row - 1, column - 1] = value;
            }
        }

        public Matrix(int Rows, int Columns)
        {
            _matrix = new double[Rows, Columns];
        }

        public Matrix(int m) : this(m, m) { }
        
        #region Dot Product

        public void InDot(Matrix Matrix)
        {
            if (Columns != Matrix.Rows)
            {
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            }

            var _result = new double[Rows, Matrix.Columns];
            for (int _row = 0; _row < Rows; _row++)
            {
                for (int _col = 0; _col < Matrix.Columns; _col++)
                {
                    double _sum = 0;
                    for (int i = 0; i < Columns; i++)
                    {
                        _sum += _matrix[_row, i] * Matrix[i + 1, _col + 1];
                    }
                    _result[_row, _col] = _sum;
                }
            }

            _matrix = _result;
        }

        public Matrix Dot(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InDot(matrix);
            return _mat;
        }

        #endregion

        #region Hadamard (Element Multiplication)

        public void InHadamard(Matrix Matrix)
        {
            if (Columns != Matrix.Columns || Rows != Matrix.Rows)
            {
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            }

            for (int _row = 0; _row < Rows; _row++)
            {
                for (int _col = 0; _col < Columns; _col++)
                {
                    _matrix[_row, _col] *= Matrix[_row + 1, _col + 1];
                }
            }
        }

        public Matrix Hadamard(Matrix matrix)
        {
            var _mat = Duplicate();
            _mat.InHadamard(matrix);
            return _mat;
        }

        #endregion

        #region Scale Operation

        public void InScale(double Scalar)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] *= Scalar;
                }
            }
        }

        public Matrix Scale(double scalar)
        {
            var _mat = Duplicate();
            _mat.InScale(scalar);
            return _mat;
        }

        #endregion

        #region Add Operation

        public void InAdd(Matrix Matrix)
        {
            // Vector Broadcasting
            if (Matrix.Shape().Type() == Utility.EType.VectorTransposed)
            {
                Matrix.InTranspose();
            }

            if (Matrix.Shape().Type() == Utility.EType.Vector)
            {
                if (Rows != Matrix.Rows)
                {
                    throw new InvalidOperationException("Cannot broadcast Vector.");
                }

                for (int _row = 0; _row < Rows; _row++)
                {
                    for (int _col = 0; _col < Columns; _col++)
                    {
                        _matrix[_row, _col] += Matrix[_row, 1];
                    }
                }
                return;
            }

            // Normal Addition
            if (Rows != Matrix.Rows || Columns != Matrix.Columns)
            {
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            }
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] += Matrix[_row + 1, _col + 1];
                }
            }
        }

        public Matrix Add(Matrix Matrix)
        {
            var _mat = Duplicate();
            _mat.InAdd(Matrix);
            return _mat;
        }

        #endregion

        #region Subtraction Operation

        public void InSub(Matrix Matrix)
        {
            // Vector Broadcasting
            if (Matrix.Shape().Type() == Utility.EType.VectorTransposed)
            {
                Matrix.InTranspose();
            }

            if (Matrix.Shape().Type() == Utility.EType.Vector)
            {
                if (Rows != Matrix.Rows)
                {
                    throw new InvalidOperationException("Cannot broadcast Vector.");
                }

                for (int _row = 0; _row < Rows; _row++)
                {
                    for (int _col = 0; _col < Columns; _col++)
                    {
                        _matrix[_row, _col] -= Matrix[_row, 1];
                    }
                }
                return;
            }

            // Normal Subtraction
            if (Rows != Matrix.Rows || Columns != Matrix.Columns)
            {
                throw new InvalidOperationException("Cannot sub matrices of different sizes.");
            }
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] -= Matrix[_row + 1, _col + 1];
                }
            }
        }

        public Matrix Sub(Matrix Matrix)
        {
            var _mat = Duplicate();
            _mat.InSub(Matrix);
            return _mat;
        }

        #endregion

        #region Inverse Operation

        public void InInverse()
        {
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Only square matrices can be inverted.");
            }

            int _dimension = Rows;
            var _result = _matrix.Clone() as double[,];
            var _identity = _matrix.Clone() as double[,];

            //make identity matrix
            for (int _row = 0; _row < _dimension; _row++)
            {
                for (int _col = 0; _col < _dimension; _col++)
                {
                    _identity[_row, _col] = (_row == _col) ? 1.0 : 0.0;
                }
            }

            //invert
            for (int i = 0; i < _dimension; i++)
            {
                double _tmp = _result[i, i];
                for (int j = 0; j < _dimension; j++)
                {
                    _result[i, j] = _result[i, j] / _tmp;
                    _identity[i, j] = _identity[i, j] / _tmp;
                }
                for (int k = 0; k < _dimension; k++)
                {
                    if (i != k)
                    {
                        _tmp = _result[k, i];
                        for (int n = 0; n < _dimension; n++)
                        {
                            _result[k, n] = _result[k, n] - _tmp * _result[i, n];
                            _identity[k, n] = _identity[k, n] - _tmp * _identity[i, n];
                        }
                    }
                }
            }
            _matrix = _identity;
        }

        public Matrix Inverse()
        {
            var _mat = Duplicate();
            _mat.InInverse();
            return _mat;
        }

        #endregion

        #region Transpose Operation

        public void InTranspose()
        {
            var _result = new double[Columns, Rows];

            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result[_col, _row] = _matrix[_row, _col];
                }
            }

            _matrix = _result;
        }

        public Matrix Transpose()
        {
            var _mat = Duplicate();
            _mat.InTranspose();
            return _mat;
        }

        public Matrix T()
        {
            var _mat = Duplicate();
            _mat.InTranspose();
            return _mat;
        }

        #endregion

        #region Map Functionality

        public void InMap(Func<double, double> func)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = func(_matrix[_row, _col]);
                }
            }
        }

        public Matrix Map(Func<double, double> func)
        {
            var _mat = Duplicate();
            _mat.InMap(func);
            return _mat;
        }

        #endregion

        #region Randomization

        public void InRandomize(double lowest, double highest)
        {
            Random _random = new Random();
            double _diff = highest - lowest;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
            {
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = (_random.NextDouble() * _diff) + lowest;
                }
            }
        }

        public Matrix Randomize(double lowest, double highest)
        {
            var _mat = Duplicate();
            _mat.InRandomize(lowest, highest);
            return _mat;
        }

        public void InRandomize()
        {
            InRandomize(0.0, 1.0);
        }

        public Matrix Randomize()
        {
            var _mat = Duplicate();
            _mat.InRandomize();
            return _mat;
        }

        #endregion

        #region Utility

        public Matrix Duplicate()
        {
            var _result = new Matrix(Rows, Columns);
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _result[row + 1, col + 1] = _matrix[row, col];
                }
            }
            return _result;
        }

        public Nomad.Utility.Shape Shape()
        {
            return new Utility.Shape(Rows, Columns);
        }

        public Utility.EType IsVector()
        {
            return Shape().Type();
        }

        #endregion
    }
}